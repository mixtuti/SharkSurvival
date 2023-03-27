using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static float time;
    public Text TimeText;
    public bool isCount = false;

    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(isCount == false){
            time += Time.deltaTime;
            TimeText.text = time.ToString("F2");
        }
    }

    public static float getTime(){
		return time;
	}
}
