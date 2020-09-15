using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    //おばけの移動速度
    private float speed = -8;

    //消滅位置
    private float deadLine = -10;

    //落ちる速度
    float fallSpeed;

    // Start is called before the first frame update
    void Start()
    {
        this.fallSpeed = 0.01f + 0.1f * Random.value;
    }

    // Update is called once per frame
    void Update()
    {
        //おばけを移動させる
        transform.Translate(this.speed * Time.deltaTime, -fallSpeed, 0);

        //画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    //地面と衝突したら削除
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            Destroy(gameObject);
        }
    }
}
