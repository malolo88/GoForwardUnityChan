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
            ghostPointText.GetComponent<ScoreController>().AddScore(10);

            //パーティクルを再生
            GetComponent<ParticleSystem>().Play();

            //オブジェクトの削除
            Destroy(collider.gameObject);
            Destroy(gameObject);
        }

        if (collider.gameObject.tag == "cube")
        {
            Destroy(gameObject);
        }

    }
}
