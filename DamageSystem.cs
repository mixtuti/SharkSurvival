using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageSystem : MonoBehaviour
{
    [SerializeField]
    GameObject PlayerObject;

    [SerializeField]
    GameObject HPSystem;

    private float PlayerHP;
    private int MaxHP;


    // Start is called before the first frame update
    void Start()
    {
        PlayerHP = PlayerObject.GetComponent<Move_Player>().Php;
        MaxHP = (int)PlayerHP;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHP = PlayerObject.GetComponent<Move_Player>().Php;

        //HPSystemのスクリプトのHPDown関数に2つの数値を送る
        HPSystem.GetComponent<HPSystem>().HPDown(PlayerHP, MaxHP);
    }
}
