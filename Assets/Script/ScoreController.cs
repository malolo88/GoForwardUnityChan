using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public static int score;
    UnityEngine.UI.Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<UnityEngine.UI.Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddScore(int score)
    {
        ScoreController.score += score;
        scoreText.text = "得点: " + ScoreController.score.ToString() + "点";
    }

    //得点を共有する関数
    public static float GetScore()
    {
        return score;
    }
}
