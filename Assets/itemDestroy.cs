using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemDestroy : MonoBehaviour
{


    //カメラの位置
    private GameObject Camera;

    public float ConeDifference { get; private set; }

    //アイテムの位置とカメラの位置の差
    private GameObject ItemDifference;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //カメラオブジェクトの取得
        this.Camera = GameObject.Find("Main Camera");

        //アイテムの位置とカメラの位置の差
        this.ConeDifference = this.transform.position.z - this.Camera.transform.position.z;

        //アイテムのZ座標からカメラのZ座標を引いた値が負の時
        if(ConeDifference < 0)
        {
            //オブジェクトを破壊
            Destroy(this.gameObject);
        }
    }
}
