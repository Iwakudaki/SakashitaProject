using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Enemy : Character {

	public enum ENEMY_TYPE { 
		TYPE_A,
		TYPE_B,
		TYPE_C,
	};

	private EnemyMove _enemy_move = null;
	private ENEMY_TYPE _enemy_type = ENEMY_TYPE.TYPE_A;
	private float _move_speed = 0;
	private int _hit_point = 0;

	private void FixedUpdate( ) {
		if ( _enemy_move == null ) return;	//初期化されるまで更新しない

		Move( );
	}

	private void Update( ) {
		Death( );
	}

	private void OnTriggerEnter( Collider other ) {
		if ( other.gameObject.tag == "Bullet" ) { 
			_hit_point--;
			if ( _hit_point < 0 ) { 
				_hit_point = 0;
			}
		}
	}

	protected override void Move( ) {
		transform.position += _enemy_move.Move( _move_speed ) * Time.deltaTime;
	}

	protected override void Death( ) {
		if ( _hit_point <= 0 ) { 
			_is_death = true;
			Destroy( this.gameObject );
		}
	}

	//初期化
	public void Initialize( ENEMY_TYPE enemy_type, float move_speed, int hit_point ) { 
		_enemy_type = enemy_type;
		_move_speed = move_speed;
		_hit_point = hit_point;

		switch ( _enemy_type ) { 
			case ENEMY_TYPE.TYPE_A:
				_enemy_move = new StraightMove( );
				break;

			case ENEMY_TYPE.TYPE_B:
				_enemy_move = new StraightMove( );
				break;

			case ENEMY_TYPE.TYPE_C:
				_enemy_move = new StraightMove( );
				break;

			default:
				Assert.IsNotNull( _enemy_move, "[Enemy]動きの種類が入ってません" );
				break;
		}
	}

	
	//private Vector3 MoveA( ) { }
	//private Vector3 MoveB( ) { }
	//private Vector3 MoveC( ) { }
}
