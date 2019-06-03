using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpawnManager : MonoBehaviour {
	private readonly int SPAWN_ORDER_IDX = 0;

	[ System.Serializable ]
	private struct Spawn {
		public Enemy.ENEMY_TYPE type;
		public float spawn_time;
		public float move_speed;
	};

	[ SerializeField ] private List< Spawn > _spawn = new List< Spawn >( );
	[ SerializeField ] private GameObject _enemy = null;

	private float _spawn_count = 0;
	
	private void Start( ) {
		_spawn_count = _spawn[ SPAWN_ORDER_IDX ].spawn_time;
	}

	private void FixedUpdate( ) {
		SpawnCount( );
	}

	private void Update( ) {
		if ( !IsSpawnNext( ) ) return;

		SpawnEnemy( );
	}

	//常に先頭にある要素で生成する
	private void SpawnEnemy( ) {
		//時間になったら生成
		if ( IsSpawn( ) ) { 
			GameObject enemy_obj = Instantiate( _enemy, transform.position, Quaternion.identity );
			Enemy enemy = enemy_obj.GetComponent< Enemy >( );
			enemy.Initialize( _spawn[ SPAWN_ORDER_IDX ].type, _spawn[ SPAWN_ORDER_IDX ].move_speed );
			_spawn.Remove( _spawn[ SPAWN_ORDER_IDX ] );

			//次があったら次の時間を入れる
			if ( IsSpawnNext( ) ) {
				_spawn_count = _spawn[ SPAWN_ORDER_IDX ].spawn_time;
			} else { 
				Debug.Log( "[SpawnManager]全て生成終了" );
			}
		}
	}

	private void SpawnCount( ) { 
		_spawn_count -= Time.deltaTime;	
	}

	private bool IsSpawn( ) { 
		return _spawn_count <= 0;
	}

	private bool IsSpawnNext( ) { 
		return	_spawn.Count != 0;
	}

	//public void SpawnUpdate( ) { 
	//	if ( !IsSpawnNext( ) ) return;
	//
	//	SpawnCount( );
	//	SpawnEnemy( );
	//}

}
