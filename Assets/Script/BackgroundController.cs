using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    //スクロール速度
    private float scrollSpeed = -1;
    //背景終了位置
    private float deadLine = -16;
    //背景開始位置
    private float startLine = 15.8f;
    //スクロール開始か停止の変数
    bool m_isScrolling = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //スクロールが開始になったら背景を移動する
        if(m_isScrolling)
        {
            //背景を移動する
            transform.Translate(this.scrollSpeed * Time.deltaTime, 0, 0);

            //画面外に出たら、画面右端に移動する
            if (transform.position.x < this.deadLine)
            {
                transform.position = new Vector2(this.startLine, 0);
            }
        }
    }

    //スクロールを開始する関数
    public void StartScroll()
    {
        m_isScrolling = true;
    }

    //スクロールを停止する関数
    public void StopScroll()
    {
        m_isScrolling = false;
    }
}
