using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kill : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hit_effect(){

    }

    void OnCollisionEnter(Collision other)
    {
        //ボールにぶつかったとき
        if(other.gameObject.tag == "Kill")
        {
            Debug.Log("敵がぶつかった！ Killz-one");
        }
        else
        {
            // Debug.Log("ボールじゃないところにぶつかった！");
        }
    }
}
