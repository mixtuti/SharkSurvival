using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    // [SerializeField]
    // float scrollSpeed = -1;
    // Vector3 cameraRectMin;
    // void Start()
    // {
    //     //カメラの範囲を取得
    //     cameraRectMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.transform.position.z));
    // }
    // void Update()
    // {
    //     Move();
    // }
    // void Move()
    // {
    //     transform.Translate(Vector3.right * scrollSpeed * Time.deltaTime);   //X軸方向にスクロール
    //     //カメラの左端から完全に出たら、右端に瞬間移動
    //     if (transform.position.x < (cameraRectMin.x - Camera.main.transform.position.x) * 2)
    //     {
    //         transform.position = new Vector2((Camera.main.transform.position.x - cameraRectMin.x) * 2, transform.position.y);
    //     }
    // }

    [SerializeField] private float scrollSpeed; //背景をスクロールさせるスピード
    [SerializeField] private float startLine;//背景のスクロールを開始する位置
    [SerializeField] private float deadLine; //背景のスクロールが終了する位置
    [SerializeField] private float y;


    void Update()
    {
        Scroll();
    }

    public void Scroll()
    {
        transform.Translate(scrollSpeed, 0, 0); //x座標をscrollSpeed分動かす

        if(transform.position.x < deadLine) //もし背景のx座標よりdeadLineが大きくなったら
        {
            transform.position = new Vector3(startLine, y, 0);//背景をstartLineまで戻す
        }
    }
}
