using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartManager : MonoBehaviour
{
    //ハートのPrefab
    public GameObject heartPrefab;

    //ハートの数
    private int heartNum = 3;
    //ハートを並べる間隔
    private float space = 0.2f;
    
    // Start is called before the first frame update
    void Start()
    {
        //ハートを配置する座標を設定
        Vector2 heartPos = new Vector2(-8.0f, 3.0f);
        
        //ハートをx軸方向に３つ配置
        for(int i = 0; i < heartNum; i++)
        {
            GameObject heart = Instantiate(heartPrefab);
            heart.transform.position = new Vector2(heartPos.x + i + this.space * i, heart.transform.position.y);
            heart.name = "heart" + i;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
