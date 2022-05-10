using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{

    //carPrefabを入れる
    public GameObject carPrefab;

    //coinPrefabを入れる
    public GameObject coinPrefab;

    //cornPrefabを入れる
    public GameObject conePrefab;

    //スタート地点
    private int startPos = 40;

    //ゴール地点
    private int goalPos = 360;

    //アイテムを出すｘ方向の範囲
    private float posRange = 3.4f;

    //発展課題
    //Unityちゃんオブジェクト
    private GameObject unitychan;

    //アイテム生成位置
    private float ZDifference;

    //最後にアイテムを生成した際のZ座標を記憶するための変数
    private float lastGeneratePosZ;

    // Start is called before the first frame update
    void Start()
    {

        //発展課題
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
        this.lastGeneratePosZ = 50;

        //一定の距離ごとにアイテムを生成
        for (int i = startPos; i < startPos + 50; i += 15)
        {
            //生成するアイテムをランダムで決定
            int num = Random.Range(1, 11);
            if(num <= 2)
            {
                //コーンをｘ軸方向に１直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {

                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);

                }
            }
            else
            {
                //レーンごとにアイテムの生成
                for(int j = -1; j <= 1; j++)
                {
                    //アイテムの種類を決定
                    int item = Random.Range(1, 11);
                    //アイテムを置くｚ座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    //60%コイン配置：30%車配置：10%何もなし
                    if(1 <= item && item <= 6)
                    {
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
                    }
                    else if(7 <= item && item <= 9)
                    {
                        //車生成
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
                    }
                }
            }

        }

    }

    // Update is called once per frame
    void Update()
    {

        //発展課題
        this.ZDifference = this.unitychan.transform.position.z + 50; 

        //一定の距離ごとにアイテムを生成
        if (this.unitychan.transform.position.z - lastGeneratePosZ >= 15 && this.ZDifference < goalPos )
        { 
            //生成するアイテムをランダムで決定
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                //コーンをｘ軸方向に１直線に生成
                for (float i = -1; i <= 1; i += 0.4f)
                {

                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * i, cone.transform.position.y, ZDifference);

                }
            }
            else
            {
                //レーンごとにアイテムの生成
                for (int i = -1; i <= 1; i++)
                {
                    //アイテムの種類を決定
                    int item = Random.Range(1, 11);
                    //アイテムを置くｚ座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    //60%コイン配置：30%車配置：10%何もなし
                    if (1 <= item && item <= 6)
                    {
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * i, coin.transform.position.y, ZDifference + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車生成
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * i, car.transform.position.y, ZDifference + offsetZ);
                    }
                }
            }
            //最後にアイテムを生成した際のUnityちゃんのZ座標
            this.lastGeneratePosZ = this.unitychan.transform.position.z;

        }
    }
}
