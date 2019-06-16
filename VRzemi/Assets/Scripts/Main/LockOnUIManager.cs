﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOnUIManager : MonoBehaviour {
	[ SerializeField ] private GazeController _gaze_controller = null;
	[ SerializeField ] private GameObject _lock_on_doing_ui = null;
	[ SerializeField ] private GameObject _lock_on_done_ui = null;

	GameObject _pre_lock_on_doing_obj = null;
	GameObject _pre_lock_on_done_obj = null;

	private void Start( ) {
		_lock_on_doing_ui.SetActive( false );
		_lock_on_done_ui.SetActive( false );
	}

	private void Update( ) {
		LockOnUIActiveChange( );
		LockOnUIPosUpdate( );
	}

	private void LockOnUIActiveChange( ) {
		//ロックオン中UIの表示切替---------------------------------------------------------------------------
		//ロックオン中UIが表示されていてロックオン中のオブジェクトがNULLだったら非表示にする
		if ( _lock_on_doing_ui.activeSelf && _gaze_controller.getLockOnDoingObject( ) == null ) { 
			_lock_on_doing_ui.SetActive( false );	
		}

		//前のフレームの時とロックオン中のオブジェクトが違っていてオブジェクトがNULLじゃなかったら表示更新
		if ( _pre_lock_on_doing_obj != _gaze_controller.getLockOnDoingObject( ) && 
			 _gaze_controller.getLockOnDoingObject( ) != null ) {
			_lock_on_doing_ui.SetActive( true );
		}
		//--------------------------------------------------------------------------------------------------

		//ロックオンUIの表示切替----------------------------------------------------------------------------
		//ロックオンUIが表示されていてロックオンしたオブジェクトがNULLだったら非表示にする
		if ( _lock_on_done_ui.activeSelf && _gaze_controller.getLockOnObject( ) == null ) { 
			_lock_on_done_ui.SetActive( false );	
		}

		//前のフレームの時とロックオンしたオブジェクトが違っていてオブジェクトがNULLじゃなかったら表示更新
		if ( _pre_lock_on_done_obj != _gaze_controller.getLockOnObject( ) && 
			 _gaze_controller.getLockOnObject( ) != null ) {
			_lock_on_done_ui.SetActive( true );
		}
		//---------------------------------------------------------------------------------------------------

		//このフレームのオブジェクトに更新
		_pre_lock_on_doing_obj = _gaze_controller.getLockOnDoingObject( );
		_pre_lock_on_done_obj = _gaze_controller.getLockOnObject( );

	}

	//ロックオンUIが表示されていたら場所を更新
	private void LockOnUIPosUpdate( ) {
		if ( _lock_on_doing_ui.activeSelf && _gaze_controller.getLockOnDoingObject( ) != null ) {
			_lock_on_doing_ui.transform.position = _gaze_controller.getLockOnDoingObject( ).transform.position;
		}

		if ( _lock_on_done_ui.activeSelf && _gaze_controller.getLockOnObject( ) != null ) { 
			_lock_on_done_ui.transform.position = _gaze_controller.getLockOnObject( ).transform.position;
		}
	} 

}