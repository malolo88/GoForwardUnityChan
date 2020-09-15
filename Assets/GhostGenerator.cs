using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostGenerator : MonoBehaviour
{
    //おばけのPrefab
    public GameObject ghostPrefab;

    //時間計測用の変数
    private float delta = 0;

    //おばけの生成間隔
    private float span = 3.0f;

    //おばけの生成位置：X座標
    private float genPosX = 10;

    //おばけの生成位置オフセット
    private float offsetY = 0.5f;
    //おばけの縦方向の間隔
    private float spaceY = 6.0f;

    //おばけの生成位置オフセット
    private float offsetX = 2.0f;
    //おばけの横方向の間隔
    private float spaceX = 2.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;

        //span秒以上の時間が経過したかを調べる
        if (this.delta > this.span)
        {
            this.delta = 0;

            //おばけの生成
            GameObject ghost = Instantiate(ghostPrefab) as GameObject;
            ghost.transform.position = new Vector2(this.genPosX, this.offsetY * this.spaceY);

            //次のおばけまでの生成時間を決める
            this.span = this.offsetX + this.spaceX;
        }
    }
}
