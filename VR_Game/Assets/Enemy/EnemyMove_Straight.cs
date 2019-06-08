using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove_Straight : MonoBehaviour
{
    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 pos = this.transform.position;
        this.transform.position = new Vector3(0, 0, pos.z - speed);

    }
}
