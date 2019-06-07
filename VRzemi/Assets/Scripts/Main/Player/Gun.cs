using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	[ SerializeField ] private float _set_next_shoot_time = 0;	//次に撃てるまでの時間
	[ SerializeField ] private GameObject _bullet = null;

	private float _next_shoot_time = 0;
	private bool _is_shoot = true;


	private void Start( ) {
		_next_shoot_time = _set_next_shoot_time;
	}

	private void FixedUpdate( ) {
		NextShootCount( );
	}


	//撃てない状態のときは次に撃てるまでの時間をカウントする
	private void NextShootCount( ) { 
		if ( !_is_shoot ) {
			_next_shoot_time -= Time.deltaTime;
			if ( _next_shoot_time <= 0 ) {	//時間が来たら撃てる状態にする
				_next_shoot_time = 0;
				_is_shoot = true;
			}
		}
	}

	public void Shoot( GameObject lock_on_obj ) {
		if ( !_is_shoot ) return;	//撃てる状態でなければ撃たない

		Vector3 bullet_dir = lock_on_obj.transform.position - transform.position;
		GameObject bullet_obj = Instantiate( _bullet, transform.position, Quaternion.LookRotation( bullet_dir.normalized ) );

		//どうにかしないと
		Bullet bullet = bullet_obj.GetComponent< Bullet >( );
		bullet.setTarget( lock_on_obj );	//弾に追尾する対象を入れる
		
		_is_shoot = false;	//一度撃ったら撃てない状態にする
		_next_shoot_time = _set_next_shoot_time;
	}
}
