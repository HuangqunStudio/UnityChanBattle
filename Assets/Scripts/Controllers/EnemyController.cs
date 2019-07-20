//
// Mecanimのアニメーションデータが、原点で移動しない場合の Rigidbody付きコントローラ
// サンプル
// 2014/03/13 N.Kobyasahi
//
using UnityEngine;
using System.Collections;

namespace Enemy
{
    // 必要なコンポーネントの列記
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CapsuleCollider))]
    [RequireComponent(typeof(Rigidbody))]

    public class EnemyController : MonoBehaviour
    {

        public float animSpeed = 1.5f;              // アニメーション再生速度設定
        public float lookSmoother = 3.0f;           // a smoothing setting for camera motion
        public bool useCurves = true;               // Mecanimでカーブ調整を使うか設定する
        // このスイッチが入っていないとカーブは使われない
        public float useCurvesHeight = 0.5f;        // カーブ補正の有効高さ（地面をすり抜けやすい時には大きくする）

        // 以下キャラクターコントローラ用パラメタ
        // 前進速度
        public float forwardSpeed = 7.0f;
        // 後退速度
        public float backwardSpeed = 5.0f;
        // 旋回速度
        public float rotateSpeed = 2.0f;
        // ジャンプ威力
        public float jumpPower = 5.0f;
        public float evadeSpeed = 10.0f;
        public GameObject weapon;
        public GameObject weaponHoldPoint;

        // キャラクターコントローラ（カプセルコライダ）の参照
        private CapsuleCollider col;
        private Rigidbody rb;
        // キャラクターコントローラ（カプセルコライダ）の移動量
        private Vector3 velocity;
        // CapsuleColliderで設定されているコライダのHeiht、Centerの初期値を収める変数
        private float orgColHight;
        private Vector3 orgVectColCenter;
        private Animator anim;                          // キャラにアタッチされるアニメーターへの参照
        private AnimatorStateInfo currentBaseState;         // base layerで使われる、アニメーターの現在の状態の参照
        private float x;

        // アニメーター各ステートへの参照
        static int idleState = Animator.StringToHash("Base Layer.Idle");
        static int locoState = Animator.StringToHash("Base Layer.Locomotion");
        static int jumpState = Animator.StringToHash("Base Layer.Jump");
        static int restState = Animator.StringToHash("Base Layer.Rest");
        static int evadeState = Animator.StringToHash("Base Layer.Evade");
        static int sweepState = Animator.StringToHash("Base Layer.SweepAttack");
        static int thrustState = Animator.StringToHash("Base Layer.TrustAttack");
        static int blockState = Animator.StringToHash("Base Layer.Block");
        static int damagedState = Animator.StringToHash("Base Layer.Damaged");

        // 初期化
        void Start()
        {
            // Animatorコンポーネントを取得する
            anim = GetComponent<Animator>();
            // CapsuleColliderコンポーネントを取得する（カプセル型コリジョン）
            col = GetComponent<CapsuleCollider>();
            rb = GetComponent<Rigidbody>();
            // CapsuleColliderコンポーネントのHeight、Centerの初期値を保存する
            orgColHight = col.height;
            orgVectColCenter = col.center;
            x = 0.0f;

            PickUpWeapon();
        }


        // 以下、メイン処理.リジッドボディと絡めるので、FixedUpdate内で処理を行う.
        void FixedUpdate()
        {
            currentBaseState = anim.GetCurrentAnimatorStateInfo(0);
            if (currentBaseState.nameHash == damagedState)
            {
                if (!anim.IsInTransition(0))
                {
                    anim.SetBool("Damaged", false);
                }
                velocity = new Vector3(0, 0, 0);
            }
        }

        // キャラクターのコライダーサイズのリセット関数
        void ResetCollider()
        {
            // コンポーネントのHeight、Centerの初期値を戻す
            col.height = orgColHight;
            col.center = orgVectColCenter;
        }

        void PickUpWeapon()
        {
            if (weapon && weaponHoldPoint)
            {
                weapon.transform.parent = weaponHoldPoint.transform;
                weapon.transform.localPosition = new Vector3(0, -0.5f, 0.04f);
                weapon.transform.localRotation = new Quaternion(0, 0, 0, 0);
            }
        }

        public void Hit()
        {
            return;
        }

        public void OnDamaged()
        {
            if (currentBaseState.nameHash != damagedState)
            {
                anim.SetBool("Damaged", true);
                Debug.Log("Damaged");
            }
        }
    }
}