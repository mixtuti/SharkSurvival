using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    EnemyDataList enemyData;

    [Header("敵データ")]
    [SerializeField] public EnemyDataList enemyDataList;

    [SerializeField] enemy_move enemymove_OBJ;

    private int number;

    [Header("生成する範囲A")]
    [SerializeField] private Transform rangeA;
    [Header("生成する範囲B")]
    [SerializeField] private Transform rangeB;


    // 経過時間
    private float time;

    public int GeneratTime;

    void Start()
    {
        
    }
    
    void Update()
    {
        // 前フレームからの時間を加算していく
        time = time + Time.deltaTime;

        // 約1秒置きにランダムに生成されるようにする。
        if (time > GeneratTime)
        {
            // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
            float x = Random.Range(rangeA.position.x, rangeB.position.x);
            // rangeAとrangeBのy座標の範囲内でランダムな数値を作成
            float y = Random.Range(rangeA.position.y, rangeB.position.y);
            // rangeAとrangeBのz座標の範囲内でランダムな数値を作成
            float z = Random.Range(rangeA.position.z, rangeB.position.z);

            // 生成するオブジェクトをランダムにする
            number = Random.Range(0, enemyDataList.EnemyStatusList.ToArray().Length);
            // GameObjectを上記で決まったランダムな場所に生成
            enemy_move OBJ = Instantiate(enemymove_OBJ, new Vector3(x, y, z), Quaternion.identity);
            OBJ.enemyData = enemyDataList.EnemyStatusList[number];
            OBJ.SetUP();

            // 経過時間リセット
            time = 0f;
        }
    }
}
