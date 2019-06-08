﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMove : EnemyMove {

    public float T = 1.0f;
    public float width = 1.0f;

    public Vector3 Move(float speed) {

        float f = 1.0f / T;
        float sin = Mathf.Sin(2 * Mathf.PI * f * Time.time);

        return new Vector3(sin * width, 0, -1) * speed;
    }

}
