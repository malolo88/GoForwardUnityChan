﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnityChanController : MonoBehaviour
{
    //アニメーションをするためのコンポーネントを入れる
    Animator animator;

    //Unityちゃんを移動させるコンポーネントを入れる
    Rigidbody2D rigid2D;

    //地面の位置
    private float groundLevel = -3.0f;

    //ジャンプの速度の減衰
    private float dump = 0.8f;

    //ジャンプの速度
    float jumpVelocity = 20;

    //ゲームオーバーになる位置
    private float deadLine = -9;

    // おふだのPrefab
    public GameObject amuletPrefab;

    // ライフ
    public int m_life = 10;

    // ライフ表示パネル
    public RectTransform m_lifePanel;

    // ライフ表示のプレハブ
    public GameObject m_lifeImage;


    // Start is called before the first frame update
    void Start()
    {
        //アニメータのコンポーネントを取得する
        this.animator = GetComponent<Animator>();
        //Rigidbody2Dのコンポーネントを取得する
        this.rigid2D = GetComponent<Rigidbody2D>();

        RefleshLifeCounter(m_life);
    }

    // Update is called once per frame
    void Update()
    {
        //走るアニメーションを再生するために、Animatorのパラメータを調節する
        this.animator.SetFloat("Horizontal", 1);

        //着地しているかどうかを調べる
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool("isGround", isGround);

        //ジャンプ状態のときにはボリュームを0にする
        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;

        //着地状態でクリックされた場合
        if (Input.GetMouseButtonDown(0) && isGround)
        {
            //上方向の力をかける
            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);
        }

        //クリックをやめたら上方向への速度を減速する
        if (Input.GetMouseButton(0) == false)
        {
            if (this.rigid2D.velocity.y > 0)
            {
                this.rigid2D.velocity *= this.dump;
            }
        }

        //デッドラインを超えた場合ゲームオーバーにする
        if (transform.position.x < this.deadLine)
        {
            //UIControllerのGameOver関数を呼び出して画面上に「Game Over」と表示する
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();

            //ユニティちゃんを破棄する
            Destroy(gameObject);
        }

        //右クリックを押したら弾を発射する
        if (Input.GetMouseButtonDown(1))
        {
            Instantiate(amuletPrefab, transform.position, Quaternion.identity);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ghost")
        {
            m_life -= 1;
            if (m_life < 0)
            {
                Debug.Log("Game over");
            }

            RefleshLifeCounter(m_life);
        }
    }

    void RefleshLifeCounter(int lifeCount)
    {
        foreach (Transform t in m_lifePanel.transform)  // ライフパネルの下にあるやつ全部消す
        {
            Destroy(t.gameObject);
        }

        for (int i = 0; i < lifeCount; i++)
        {
            GameObject go = Instantiate(m_lifeImage);
            go.transform.SetParent(m_lifePanel);
        }

    }
}
