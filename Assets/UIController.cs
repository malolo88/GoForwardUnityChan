﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

public class UIController : MonoBehaviour
{
    //ゲームオーバーテキスト
    private GameObject gameOverText;

    //走行距離テキスト
    private GameObject runLengthText;

    //走った距離
    private float len = 0;

    //走る速度
    private float speed = 5f;

    //ゲームオーバーの判定
    private bool isGameOver = false;

    //ゲームオーバー後の経過時間
    private float waitTime = 0.0f;

    bool m_isGameStarted = false;


    // Start is called before the first frame update
    void Start()
    {
        //シーンビューからオブジェクトの実体を検索する
        this.gameOverText = GameObject.Find("GameOver");
        this.runLengthText = GameObject.Find("RunLength");
        runLengthText.GetComponent<Text>().text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isGameStarted)
        {
            if (this.isGameOver == false)
            {
                //走った距離を更新する
                this.len += this.speed * Time.deltaTime;

                //走った距離を表示する
                this.runLengthText.GetComponent<Text>().text = "Distance: " + len.ToString("F2") + "m";
            }

            //ゲームオーバーになった場合
            if (this.isGameOver == true)
            {
                waitTime += Time.deltaTime;

                //3秒経過したらResul画面に遷移する
                if (waitTime >= 3.0f)
                {
                    SceneManager.LoadScene("ResultScene");
                }
            }
        }
    }

    public void GameOver()
    {
        //ゲームオーバーになったときに、画面上にゲームオーバーを表示する
        this.gameOverText.GetComponent<Text>().text = "Game Over";
        this.isGameOver = true;
    }

    public void StartGame()
    {
        m_isGameStarted = true;
    }
}
