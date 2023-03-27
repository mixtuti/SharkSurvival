using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTimer : MonoBehaviour
{
    public Text TimeText;

    float time;

    // Start is called before the first frame update
    void Start()
    {
        time = Timer.getTime();
        TimeText.text = time.ToString("F2");
		// TimeText.text = time.ToString(time+"秒間生き残った！！");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
