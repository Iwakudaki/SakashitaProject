using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : ScenesManager {
	[ SerializeField ] private TextMesh _time_limit_text = null;
	[ SerializeField ] private float _time_limit = 0;

	private bool _is_finish_time_limit = false;

	private void Start( ) {
		int show_time_limit = ( int )_time_limit;
		_time_limit_text.text = show_time_limit.ToString( );
	}

	private void FixedUpdate( ) {
		TimeLimitCount( );
	}

	private void Update( ) {
		ShowTimeLimit( );

		if ( _is_finish_time_limit ) {
			NextScene( );
		}
	}

	private void TimeLimitCount( ) { 
		if ( _is_finish_time_limit ) return;

		if ( _time_limit <= 0 ) { 
			_time_limit = 0;
			_is_finish_time_limit = !_is_finish_time_limit;
			return;
		}
		_time_limit -= Time.deltaTime;
	}

	private void ShowTimeLimit( ) { 
		int show_time_limit = ( int )_time_limit;
		_time_limit_text.text = show_time_limit.ToString( );
	}

	protected override void NextScene( ) { 
		_scene_changer.SceneChange( StringConstantRegistry.SCENE_NAME.RESULT );
	} 

}
