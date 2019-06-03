using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Player : Character {
	[ SerializeField ] private GazeController _gaze_controller = null;
	[ SerializeField ] private GameObject _bullet = null;
	[ SerializeField ] private float _pos_z = 0;
	[ SerializeField ] private float _spped = 0;
	[ SerializeField ] private float _move_limit = 0;
	[ SerializeField ] private float _direction_size = 0;

	private Controller _controller = new Controller( );
	private GameObject _lock_on_obj = null;
	private Vector3 _limit_pos = new Vector3( 0, 0, 0 );
	private float _pre_pos_x = 0;

	private void Start( ) {
		Assert.IsNotNull( _gaze_controller, "[Player]GazeControllerの参照がありません" );

		_limit_pos = new Vector3( transform.position.x + _move_limit, 0, _pos_z );
		transform.position = new Vector3( 0, 0, _pos_z );
	}

	private void Update( ) {
		Move( );
		Direction( );

		if ( _controller.getCotrollerInput( Controller.INPUT_TYPE.TRIGGER_DOWN ) ) { 
			Shoot( );
		}
	}

	protected override void Move( ) {
		Vector2 pos = _controller.getControllerPos( );

		if ( ( _pre_pos_x != pos.x ) && ( pos.x != 0 ) ) {
			if ( _pre_pos_x < pos.x ) { 
				transform.position += new Vector3( 1, 0, 0 ) * _spped * Time.deltaTime;	
			}

			if ( _pre_pos_x > pos.x ) {
				transform.position += new Vector3( -1, 0, 0 ) * _spped * Time.deltaTime;	
			}
		}

		_pre_pos_x = pos.x;
		MoveLimit( );
	}

	protected override void Shoot( ) {
		//敵をロックオンしていたら撃つ
		if ( _gaze_controller.getHitObject( ) == null ) {
			_lock_on_obj = null;
			return;
		}
		if ( _lock_on_obj == _gaze_controller.getHitObject( ) ) return;

		_lock_on_obj = _gaze_controller.getHitObject( );
		Vector3 bullet_dir = _lock_on_obj.transform.position - transform.position;
		GameObject bullet_obj = Instantiate( _bullet, transform.position, Quaternion.LookRotation( bullet_dir.normalized ) );

		//どうにかしないと
		Bullet bullet = bullet_obj.GetComponent< Bullet >( );
		bullet.setTarget( _lock_on_obj );
	}

	//Playerが動ける範囲
	private void MoveLimit( ) {
		if ( transform.position.x > _limit_pos.x ) {
			transform.position = _limit_pos;
		}

		if ( transform.position.x < -_limit_pos.x ) {
			Vector3 reverse_limit_pos = new Vector3( -_limit_pos.x, 0, _pos_z );
			transform.position = reverse_limit_pos;	
		}
	}

	//角度を視線と常に合わせる
	private void Direction( ) {
		Vector3 player_dir = new Vector3( -_gaze_controller.getDirection( ).y, _gaze_controller.getDirection( ).x, 0 );	//恐らく、2Dと3Dで向きの計算が違うため入れ替えてる(2Dは単純にｘは横、ｙは縦。3Dはそれぞれの線の軸を中心に回転する)
		transform.eulerAngles = player_dir * _direction_size;
	}

}

//視線とオブジェクトの角度の合わせ方がよくわからない。PlayerのZには謎の値が入る　//360をかける

//ロックオンしたらしてる間は撃ち続けることができる
//敵には体力がある。
//ロックオン中の敵は赤いエフェクトをまとわせる
//ロックオンが完了したらその敵にUIを表示