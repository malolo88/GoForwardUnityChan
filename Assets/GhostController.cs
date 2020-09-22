﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    //おばけの移動速度
    [SerializeField] private float speed = -8;

    //落ちる速度
    float fallSpeed;

    //x軸の消滅位置
    int deadLineX = -10;

    //y軸の消滅位置
    int deadLineY = -6;

    // Start is called before the first frame update
    void Start()
    {
        this.fallSpeed = 0.01f + 0.1f * Random.value;
    }

    // Update is called once per frame
    void Update()
    {
        //おばけを移動させる
        //transform.Translate(this.speed * Time.deltaTime, -fallSpeed, 0);
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        //画面外に出たら破棄する
        if (transform.position.x < deadLineX || transform.position.y < deadLineY)
        {
            Destroy(gameObject);
        }
    }

}
