using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcMove : EnemyMove {

    public float radius = 1.0f;
    public float speed = 1.0f;

    public Vector3 Move(float speed) {

            return new Vector3(-1 , 0, -1) * speed;
    }

      public void Arc() {

        


        if (pos.z != 0 && pos.x != -1)
        {

            pos.x = radius * Mathf.Sin(Time.time * speed);
            pos.z = radius * Mathf.Cos(Time.time * speed);

           transform.position = new Vector3(pos.x - speed, 0, pos.z - speed);
        }
    }

}
