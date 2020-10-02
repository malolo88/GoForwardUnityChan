using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExplosion : MonoBehaviour
{
    private ParticleSystem explosion;
    
    // Start is called before the first frame update
    void Start()
    {
        explosion = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        //パーティクルが終了したらオブジェクトを削除
        if (explosion.isStopped)
        {
            Destroy(this.gameObject);
        }
    }

    
}
