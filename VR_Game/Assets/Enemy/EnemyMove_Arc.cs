using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove_Arc : MonoBehaviour
{
    public float speed = 1.0f;
    public float radius = 1.0f;
   // public float _Angle = 1.0f;
   // public float width = 1.0f;
   // public float  = 1.0f;

    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

        Vector3 pos = this.transform.position;


        if (pos.z != 0 && pos.x != -1)
        {


            pos.x = radius * Mathf.Sin(Time.time * speed);
            pos.z = radius * Mathf.Cos(Time.time * speed);

            this.transform.position = new Vector3(pos.x - speed, 0, pos.z - speed);
        }



          // this.transform.position = new Vector3(0, 0, pos.z - speed);

           // this.transform.position = new Vector3(pos.x - speed, 0, pos.z - speed);
        

    }

   //public void Move() {
   //
   //     Vector3 pos = this.transform.position;
   //
   //
   //
   //
   // }
}
