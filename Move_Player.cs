using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AudioManager;
using UnityEngine.SceneManagement;
using Prime31.TransitionKit;

[RequireComponent(typeof(BoxCollider))]
public class Move_Player : MonoBehaviour
{

    int Cc, Oc, Shc, Sc, Wc, Fc, sac;
    public float Php = 100;
    public float exp = 0;
    int atk;

    int Heal;
    public Vector2 Speed;

    public HPManager hpManager;

    public Damege damegeAni;

    [SerializeField] public Animator animator;

    [Header("発生させるエフェクト(パーティクル)")]
    [SerializeField] private ParticleSystem particle;

    [Header("パーティクルの発生する場所")]
    [SerializeField] private GameObject effect_Pos;

    [Header("エフェクトが発生する長さ")]
    [SerializeField] private float effect_Time;

    [Header("攻撃アニメーション")]
    public GameObject AttackObject;

    [Header("減らしていくHPの量")]
    [SerializeField] public float decHp = 0.005f;

    [Header("インターバルの時間")]
    [SerializeField] private float intervalTime = 3.0f;

    private float remainTime;
    private bool interval;

    // [SerializeField] enemy_move enemymove_OBJ;
    string enemyName;

    [Header("次のシーン")] public SceneReference next_scene;

    // Start is called before the first frame update
    void Start()
    {
        interval = false;
        remainTime = intervalTime;
        AttackObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if(interval == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                // 左クリックされた瞬間に実行する（攻撃開始）
                Attack();
                interval = true;
            }
        }
        else if(interval == true)
        {
            remainTime -= Time.deltaTime;
            if(remainTime <= 0f)
            {
                interval = false;
                remainTime = intervalTime;
            }
        }

        Php = Php - decHp;
    }

    /// <summary>
    /// 敵との接触判定
    /// </summary>
    /// <param name="other"></param>
    void OnCollisionEnter(Collision other)
    {
        //敵にぶつかったとき
        if (other.gameObject.tag == "Enemy")
        {
            damegeAni.Damaged();
            enemyName = other.gameObject.GetComponent<enemy_move>().enemyData.EnemyName;
            atk = other.gameObject.GetComponent<enemy_move>().enemyData.atk;
            if (Php > 0)
            {
                if (enemyName == "Crab")
                {
                    Php = Php - atk;
                    Debug.Log(Php);
                    Debug.Log("かに" + atk);
                }
                else if (enemyName == "Orca")
                {
                    Php = Php - atk;
                    Debug.Log(Php);
                    Debug.Log("シャチ" + atk);
                }
                else if (enemyName == "Shark")
                {
                    Php = Php - atk;
                    Debug.Log(Php);
                    Debug.Log("さめ" + atk);
                }
                else if (enemyName == "Sunfish")
                {
                    Php = Php - atk;
                    Debug.Log(Php);
                    Debug.Log("まんぼう" + atk);
                }
                else if (enemyName == "WhaleShark")
                {
                    Php = Php - atk;
                    Debug.Log(Php);
                    Debug.Log("ジンベイザメ" + atk);
                }
                else if (enemyName == "FootBallfis")
                {
                    Php = Php - atk;
                    Debug.Log(Php);
                    Debug.Log("ちょうちんあんこう" + atk);
                }
                else if (enemyName == "sardine")
                {
                    Php = Php - atk;
                    Debug.Log(Php);
                    Debug.Log("いわし" + atk);
                }
                else if (enemyName == "Egg")
                {
                    Php = Php - atk;
                    Debug.Log(Php);
                    Debug.Log("玉子寿司" + atk);
                }
                else if (enemyName == "OracaBeam")
                {
                    Php = Php - atk;
                    Debug.Log(Php);
                    Debug.Log("シャチビーム" + atk);
                }
            }
            else if (Php <= 0)
            {
                //ゲームオーバー
                Debug.Log("ゲームオーバー");
                // var fishEye = new FishEyeTransition()
			    // {
				//     nextScene = SceneManager.GetSceneByName( next_scene ).buildIndex == 1 ? 2 : 2,
				//     duration = 1.0f,
				//     size = 0.08f,
				//     zoom = 10.0f,
				//     colorSeparation = 3.0f
			    // };
			    // TransitionKit.instance.transitionWithDelegate( fishEye );
                SceneManager.LoadScene(next_scene);
            }

            Debug.Log("敵にぶつかった！");
            // 効果音を鳴らす
            SEManager.Instance.Play(SEPath.SE_HIT);
            // ダメージを与える
            //hpManager.damage = enemyData.EnemyStatusList.;

            // ダメージエフェクト
            // パーティクルシステムのインスタンスを生成する。
            ParticleSystem newParticle = Instantiate(particle);
            // パーティクルの発生場所をこのスクリプトをアタッチしているGameObjectの場所にする。
            newParticle.transform.position = effect_Pos.transform.position;
            // パーティクルを発生させる。
            newParticle.Play();
            // インスタンス化したパーティクルシステムのGameObjectを削除する。
            Destroy(newParticle.gameObject, effect_Time);
        }
        else
        {
            Debug.Log("何にぶつかった？");
        }
    }

    void Move()
    {
        // 現在位置をPositionに代入
        float moveX = 0f;
        float moveY = 0f;
        Vector2 Position = transform.position;
        // 左キーを押し続けていたら
        if (Input.GetKey(KeyCode.A))
        {
            // 代入したPositionに対して加算減算を行う
            moveX -= Speed.x;
            transform.localEulerAngles = new Vector3(0f, 180f, 0f);
        }
        else if (Input.GetKey(KeyCode.D))
        { // 右キーを押し続けていたら
          // 代入したPositionに対して加算減算を行う
            moveX += Speed.x;
            transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.W))
        { // 上キーを押し続けていたら
          // 代入したPositionに対して加算減算を行う
            moveY += Speed.y;
        }
        else if (Input.GetKey(KeyCode.S))
        { // 下キーを押し続けていたら
          // 代入したPositionに対して加算減算を行う
            moveY -= Speed.y;
        }
        if (moveX != 0f && moveY != 0f)
        {
            moveX /= 1.4f;
            moveY /= 1.4f;
        }
        Position.x += moveX;
        Position.y += moveY;
        // 現在の位置に加算減算を行ったPositionを代入する
        transform.position = Position;
    }

    void Attack()
    {
        Debug.Log("攻撃!!");
        animator.SetTrigger("Attack");
        AttackObject.SetActive(true);
        // Heal = gameObject.GetComponent<enemy_move>().enemyData.HealHp;
        if (enemyName == "Crab")
        {
            Cc = Cc + 1;
            Debug.Log("かにを倒した数は：" + Cc);
            Php = Php + 10;
            Debug.Log("かにの回復量は：" + 10);
        }
        else if (enemyName == "Orca")
        {
            Oc = Oc + 1;
            Debug.Log("シャチを倒した数は：" + Oc);
            Php = Php + 10;
        }
        else if (enemyName == "Shark")
        {
            Shc = Shc + 1;
            Debug.Log("さめを倒した数は：" + Shc);
            Php = Php + 10;
        }
        else if (enemyName == "Sunfish")
        {
            Sc = Sc + 1;
            Debug.Log("まんぼうを倒した数は：" + Sc);
            Php = Php + 10;
        }
        else if (enemyName == "WhaleShark")
        {
            Wc = Wc + 1;
            Debug.Log("ジンベイザメを倒した数は：" + Wc);
            Php = Php + 10;
        }
        else if (enemyName == "FootBallfis")
        {
            Fc = Fc + 1;
            Debug.Log("ちょうちんあんこうを倒した数は：" + Fc);
            Php = Php + 10;
        }
        else if (enemyName == "sardine")
        {
            sac = sac + 1;
            Debug.Log("いわしを倒した数は：" + sac);
            Php = Php + 10;
        }
        else if (enemyName == "Egg")
        {
        }
        else if (enemyName == "OracaBeam")
        {

        }
        // }
        // 右クリックされた瞬間に実行する（必殺技）←必殺技の操作未定なので仮
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("必殺技!!");
            //必殺技の処理のかく
        }
    }
}

