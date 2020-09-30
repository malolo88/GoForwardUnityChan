using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    //遊び方説明のパネル
    public GameObject explainPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    //スタートボタン
    public void ClickStartButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    //もう一度遊ぶボタン
    public void ClickRestartButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    //タイトル画面に戻るボタン
    public void ClickTitleButton()
    {
        SceneManager.LoadScene("TitleScene");
    }

    //遊び方ボタン
    public void ClickHowToPlayButton()
    {
        //説明の表示
        explainPanel.SetActive(true);
    }

    //閉じるボタン
    public void ClickCloseButton()
    {
        //説明の非表示
        explainPanel.SetActive(false);
    }
}
