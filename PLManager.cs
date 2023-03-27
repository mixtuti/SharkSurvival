using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLManager : MonoBehaviour
{
    [Header("経験値テーブル")]
    [SerializeField] public PlayerExpTable PLExpTable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // lv = PlayerExpTable.SetPlayerLevel(lv, exp);
    // PlayerExpTableのScriptable ObjectをPublicとかでPlayerに持たせて、経験値計算が終わったあとにSetPlayerLevelを呼ぶ
}
