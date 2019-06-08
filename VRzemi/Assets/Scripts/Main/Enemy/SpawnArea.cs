using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	private void OnDrawGizmos( ) {
		Gizmos.color = new Color( 0, 1f, 0, 0.2f );
		Gizmos.DrawCube( transform.position, transform.localScale );

		Gizmos.color = new Color( 0, 0, 0, 1f );
		Gizmos.DrawWireCube( transform.position, transform.localScale );
	}

}
