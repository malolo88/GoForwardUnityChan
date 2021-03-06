﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostGenerator : MonoBehaviour
{
    //おばけのPrefab
    public GameObject ghostPrefab;

    //時間計測用の変数
    private float delta = 0;

    //おばけの生成位置：X座標
    private float genPosX = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;

        //span秒以上の時間が経過したかを調べる
        if (this.delta > Random.Range(4.0f, 8.0f))
        {
            this.delta = 0;

            //おばけの生成
            GameObject ghost = Instantiate(ghostPrefab) as GameObject;
            ghost.transform.position = new Vector2(this.genPosX, Random.Range(0.0f, 4.5f));

        }
    }
}
