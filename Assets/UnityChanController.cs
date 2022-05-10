using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnityChanController : MonoBehaviour
{

    //アニメーションのためのコンポーネントを入れる
    private Animator myAnimator;

    //Unityちゃんを移動させるコンポーネント
    private Rigidbody myRigidbody;

    //前方向の速度
    private float velocityZ = 16f;

    //横方向の速度
    private float velocityX = 10f;

    //左右に移動できる範囲
    private float movableRange = 3.4f;

    //上方向の速度
    private float velocityY = 10f;

    //動きを減速させる係数
    private float coefficient = 0.99f;

    //ゲーム終了の判定
    private bool isEnd = false;

    //ゲーム終了時に表示するテキスト
    private GameObject stateText;

    //スコアを表示するテキスト
    private GameObject scoreText;

    //得点
    private int score = 0;

    //左ボタン押下の判定
    private bool isLButtonDown = false;

    //右ボタン押下の判定
    private bool isRButtonDown = false;

    //ジャンプボタン押下の判定
    private bool isJButtonDown = false;


    // Start is called before the first frame update
    void Start()
    {
        //Animatorのコンポーネントを取得
        this.myAnimator = GetComponent<Animator>();

        //走るアニメーションを開始
        this.myAnimator.SetFloat("Speed", 1);

        //Rigidbodyコンポーネントを取得
        this.myRigidbody = GetComponent<Rigidbody>();

        //シーン中のstateTextオブジェクトを取得
        this.stateText = GameObject.Find("GameResultText");

        //シーン中のscoreTextオブジェクトを取得
        this.scoreText = GameObject.Find("ScoreText");

    }

    // Update is called once per frame
    void Update()
    {
        //ゲーム終了ならUnityちゃんの動きを減衰する
        if (this.isEnd)
        {
            this.velocityZ *= this.coefficient;
            this.velocityX *= this.coefficient;
            this.velocityY *= this.coefficient;
            this.myAnimator.speed *= this.coefficient;
        }
         
        //横方向の速度の初期化
        float inputVelocityX = 0;

        //上方向の入力による速度
        float inputVelocityY = 0;

        //Unityちゃんを矢印キーまたはボタンに応じて左右に遷移させる
        if ((Input.GetKey(KeyCode.LeftArrow) || this.isLButtonDown) && -this.movableRange < this.transform.position.x)
        {

            //左方向への速度を代入
            inputVelocityX = -this.velocityX;
            
        }
        else if ((Input.GetKey(KeyCode.RightArrow) || this.isRButtonDown) && this.transform.position.x < this.movableRange)
        {

            //右方向への速度を代入
            inputVelocityX = this.velocityX;

        }

        //ジャンプしていない時にスペースが押されたらジャンプする
        if((Input.GetKeyDown(KeyCode.Space) || this.isJButtonDown) && this.transform.position.y < 0.5f)
        {
            //  ジャンプアニメーションを再生
            this.myAnimator.SetBool("Jump", true);

            //上方向への速度を代入
            inputVelocityY = this.velocityY;
        }
        else
        {
            //現在のY軸の速度を代入
            inputVelocityY = this.myRigidbody.velocity.y;
        }

        //Jumpステートの場合はJampにfalseをセットする
        if (this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            this.myAnimator.SetBool("Jump", false); 
        }


        //UnityChanに速度を付加
        this.myRigidbody.velocity = new Vector3(inputVelocityX, inputVelocityY, this.velocityZ);
    }

    //トリガーモードで他のオブジェクトと接触した場合の処理
    void OnTriggerEnter(Collider other)
    {
        //障害物に衝突した場合
        if (other.gameObject.tag == "CarTag" || other.gameObject.tag == "TrafficConeTag")
        {

            this.isEnd = true;

            //stateTextにGAME OVERを表示
            this.stateText.GetComponent<Text>().text = "GAME OVER";

        }

        //ゴールした場合
        if(other.gameObject.tag == "GoalTag")
        {
            this.isEnd = true;

            //stateTextにCLEARを表示
            this.stateText.GetComponent<Text>().text = "CLEAR!!";

        }

        //コインに衝突した場合
        if(other.gameObject.tag == "CoinTag")
        {

            //スコアを加算
            this.score += 10;

            //ScoreTextに獲得した点数を表示
            this.scoreText.GetComponent<Text>().text = "Score" + this.score + "pt";

            //パーティクルを再生
            GetComponent<ParticleSystem>().Play();

            //接触したコインオブジェクトを破壊
            Destroy(other.gameObject);
        }
    }

    //ジャンプボタンを押したときの処理
    public void GetMyJumpButtonDown()
    {

        this.isJButtonDown = true;

    }

    //ジャンプボタンを離した場合の処理
    public void GetMyJumpButtonUp()
    {

        this.isJButtonDown = false;

    }

    //左ボタンを押し続けた時の処理
    public void GetMyLeftButtonDown()
    {

        this.isLButtonDown = true;

    }

    //左ボタンを離したときの処理
    public void GetMyLeftButtonUp()
    {

        this.isLButtonDown = false;

    }

    //右ボタンを押し続けた時の処理
    public void GetMyRightButtonDown()
    {

        this.isRButtonDown = true;

    }

    //右ボタンを離したときの処理
    public void GetMyRightButtonUp()
    {

        this.isRButtonDown = false;

    }
}
