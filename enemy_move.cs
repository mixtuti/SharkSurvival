using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]

public class enemy_move : MonoBehaviour
{
    public EnemyData enemyData;
    private Rigidbody rb;
    public SpriteRenderer enemy_Img;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, enemyData.deleteTime);
    }

    void FixedUpdate()
    {
        //移動速度を直接変更する
        rb.velocity = new Vector2(-enemyData.velocity, 0);
    }

    public void SetUP(){enemy_Img.sprite = enemyData.E_sprite; } 
}
