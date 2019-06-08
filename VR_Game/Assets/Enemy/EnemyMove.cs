using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    //インスペクター上で設定できる
    public float T = 1.0f; 
    public float speed = 1.0f;
    public float width = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = this.transform.position;
        float f = 1.0f / T;　//f = 1 / T(Hz)周波数
        float sin = Mathf.Sin(2 * Mathf.PI * f * Time.time); //sin = sin関数が一周するのに必要な長さ * 周波数 * 開始からの時間

        this.transform.position = new Vector3(sin * width, 0, pos.z - speed); 
    }

}
