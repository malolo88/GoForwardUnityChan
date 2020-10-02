using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmuletController : MonoBehaviour
{
    //弾の移動速度()
    private float speed = 12;

    //得点用テキスト
    private GameObject ghostPointText;

    //爆発用のパーティクル
    public GameObject ExplosionPrefab;


    // Start is called before the first frame update
    void Start()
    {
        //シーンビューからオブジェクトの実体を検索する
        this.ghostPointText = GameObject.Find("Point");

    }

    // Update is called once per frame
    void Update()
    {
        //キューブを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        if (transform.position.x > 10)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "ghost")
        {
            //Explosion関数を実行
            Explosion();
            
            //ScoreController.csのAddScore関数を実行
            ghostPointText.GetComponent<ScoreController>().AddScore(10);
            
            //オブジェクトの削除
            Destroy(collider.gameObject);
            Destroy(gameObject);
        }

        if (collider.gameObject.tag == "cube")
        {
            Destroy(gameObject);
        }

    }

    void Explosion()
    {
        //爆発用パーティクルの生成
        Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);

    }
}
