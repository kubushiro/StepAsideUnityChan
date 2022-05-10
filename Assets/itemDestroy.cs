using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemDestroy : MonoBehaviour
{


    //カメラの位置
    private GameObject Camera;

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

        

        //アイテムのZ座標がカメラのZ座標より小さい場合
        if(this.transform.position.z < this.Camera.transform.position.z)
        {
            //オブジェクトを破壊
            Destroy(this.gameObject);
        }
    }
}
