using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPSystem : MonoBehaviour
{
    [SerializeField]
    GameObject HPGage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HPDown(float PlayerHP, int MaxHP)
    {
        //HPGageの中のImageというコンポーネントのfillAmountを取得して操作する
        HPGage.GetComponent<Image>().fillAmount = PlayerHP / MaxHP;
    }
}
