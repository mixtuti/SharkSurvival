using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "MyScriptable/Create EnemyData")]

public class EnemyDataList : ScriptableObject
{
    public List<EnemyData> EnemyStatusList = new List<EnemyData>();
}

[System.Serializable]
public class EnemyData
{
    [Header("敵の名前")]
    [SerializeField] public string EnemyName;

    [Header("敵画像")]
    [SerializeField] public Sprite E_sprite;

    [SerializeField]
    [Header("生成するGameObject")]
    public GameObject EnemyPrefabs;

    [Header("最大HP")]
    [SerializeField] public int MaxHp;

    [Header("攻撃力")]
    [SerializeField] public int atk;

    [Header("移動速度")]
    public float velocity = 2f;

    [Header("経験値")]
    [SerializeField] public int exp;

    [Header("消えるまでの時間")]
    public float deleteTime;

    [Header("空腹度の回復量")]
    public int HealHp;
}
