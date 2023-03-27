using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PL_animetion : MonoBehaviour
{
    [Header("発生させるエフェクト(パーティクル)")]
    [SerializeField] private ParticleSystem particle;

    [Header("攻撃アニメーション")]
    public GameObject AttackObject; 

    GameObject[] tag1_Objects;
    public void Hit_effect(){
        // パーティクルシステムのインスタンスを生成する。
        ParticleSystem newParticle = Instantiate(particle);
        // パーティクルを発生させる。
        newParticle.Play();
        Destroy(newParticle.gameObject, 0.5f);
        Kill();
    }

    void Attack_end()
    {
        AttackObject.SetActive(false);
    }

    void Kill()
    {
        tag1_Objects = GameObject.FindGameObjectsWithTag("Enemy");
        
        for (int i = 0; i < tag1_Objects.Length; i++)
        {
            Debug.Log(tag1_Objects[i]);
            Destroy(tag1_Objects[i]);
        }
    }
}
