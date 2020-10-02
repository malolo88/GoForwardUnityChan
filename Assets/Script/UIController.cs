using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;
using UnityEditor;

public class UIController : MonoBehaviour
{
    //ゲームオーバーテキスト
    private GameObject gameOverText;

    //走行距離テキスト
    private GameObject runLengthText;

    //走った距離
    public static float len = 0;

    //走る速度
    private float speed = 5f;

    //ゲームオーバーの判定
    private bool isGameOver = false;

    //ゲームオーバー後の経過時間
    private float waitTime = 0.0f;

    //ゲーム開始か停止の変数
    bool m_isGameStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        //シーンビューからオブジェクトの実体を検索する
        this.gameOverText = GameObject.Find("GameOver");
        this.runLengthText = GameObject.Find("RunLength");

        //runLengthTextの表示をNullにする。
        runLengthText.GetComponent<Text>().text = "";
    }

    // Update is called once per frame
    void Update()
    {
        //ゲームが開始されていれば走った距離を更新する
        if (m_isGameStarted)
        {
            if (this.isGameOver == false)
            {
                //走った距離を更新する
                UIController.len += this.speed * Time.deltaTime;

                //走った距離を表示する
                this.runLengthText.GetComponent<Text>().text = "距離: " + len.ToString("F2") + "m";
            }

            //ゲームオーバーになった場合
            if (this.isGameOver == true)
            {
                waitTime += Time.deltaTime;

                //4秒経過したらResul画面に遷移する
                if (waitTime >= 4.0f)
                {
                    SceneManager.LoadScene("ResultScene");
                }
            }
        }

    }

    public void GameOver()
    {
        //ゲームオーバーになったときに、画面上にゲームオーバーを表示する
        this.gameOverText.GetComponent<Text>().text = "ゲームオーバー";
        this.isGameOver = true;
    }

    //ゲーム開始のスクリプト
    public void StartGame()
    {
        m_isGameStarted = true;
    }

    //走った長さを共有する関数
    public static float GetLength()
    {
        return len;
    }
}
