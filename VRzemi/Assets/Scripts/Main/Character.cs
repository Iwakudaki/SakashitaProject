using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {
	protected bool _is_death = false;

	protected abstract void Move( );
	protected abstract void Shoot( );

	public bool getIsDeath( ) { 
		return _is_death;	
	}
}