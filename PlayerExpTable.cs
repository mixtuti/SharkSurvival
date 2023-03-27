using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerExpTable", menuName = "MyScriptable/PlayerExpTable")]
public class PlayerExpTable : ScriptableObject
{
    // レベルアップに必要な経験値クラス(PlayerExpTableData)を格納するリスト
    public List<PlayerExpTableData> m_playerExpTableData = new List<PlayerExpTableData>();

    // レベルアップ関数　引数は現在のプレイヤーのレベルと所持経験値
    public int SetPlayerLevel(int playerLevel, int playerExp)
    {
        // プレイヤーの所持経験値が次のレベルの経験値を超えていたら1レベルアップ
        if (playerExp >= m_playerExpTableData[playerLevel].m_exp)
        {
            return playerLevel + 1;
        }
        // そうじゃない場合はレベルアップしない
        return playerLevel;
    }
}

//Inspector表示用アトリビュート
[System.Serializable]
// レベルアップに必要な経験値を格納するクラス
public class PlayerExpTableData
{
    [Header("次のレベル")]
    public int m_level;
    [Header("必要経験値")]
    public int m_exp;
    [Header("増加する攻撃力")]
    public int m_atk;
    [Header("増加するHP量")]
    public int m_HP;
}