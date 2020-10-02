using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultDisplay : MonoBehaviour
{
    public Text RunLengthText; //走った距離
    public Text ScoreText; //スコア

    float runLength;
    float score;
    
    // Start is called before the first frame update
    void Start()
    {
        //走った距離の表示
        runLength = UIController.GetLength();
        RunLengthText.text = "距離  : " + runLength.ToString("F2") + "m";

        //スコアの表示
        score = ScoreController.GetScore();
        ScoreText.text = "得点  : " + ScoreController.score.ToString() + "点";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
