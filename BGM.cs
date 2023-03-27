using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AudioManager;

public class BGM : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BGMManager.Instance.Play(
            audioPath       : BGMPath.BGM_TMP, //再生したいオーディオのパス
            volumeRate      : 0.2f,                //音量の倍率
            delay           : 0,                //再生されるまでの遅延時間
            pitch           : 1,                //ピッチ
            isLoop          : true,             //ループ再生するか
            allowsDuplicate : false             //他のBGMと重複して再生させるか
);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
