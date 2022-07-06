using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using DG.Tweening;
using KanKikuchi.AudioManager;

/// <summary>
/// プレイヤーを移動させるスクリプトです
/// <summary>
public class PlayerMove : MonoBehaviour
{
    [SerializeField] float smoothTime = 0.8f; //移動にかける時間
    //目的地を格納するベクター、SmoothDampを使うためのベクター
    Vector3 targetPos,vecZero = Vector3.zero;
    //1回の移動距離、スフィアの直径です
    [SerializeField] float moveValue = 50;
    public float getMoveValue{ get { return this.moveValue; } }
    //移動方向を制限するために矢印の選択状態を取得したい
    [SerializeField]
    GameObject arrowObjRoot = default;
    //前後左右の矢印コンポーネント
    List<ArrowAnim> arrowAnim = new List<ArrowAnim>();
    string selectedArrow; //現在選択されている矢印の名前

    float fadeDuration; //フェードしていく秒数。基本は移動時間

    public bool fadeOn = true; //フェードのオンオフ設定
    public AnimationCurve easeCurve = default; //移動用のアニメーションカーブ
    bool MoveOn = false; //DOTween呼び出し用bool
    //SteamVRのトラッカーから入力を受け取る
    [SerializeField] SteamVR_Input_Sources handType = default;
    [SerializeField] SteamVR_Action_Boolean grabGrip = default;

    //ここから更新していく
    //プレイヤーが現在動いているならture
    private bool canMove = false;
    public bool getCanMove{ get { return this.canMove; } }

    void Start() {
        //targetPosに初期値としてスタート地点を代入します
        targetPos = this.transform.position;
        
        //移動時にかかるフェードの秒数を設定
        fadeDuration = smoothTime;
    }

    void Update () {
        MoveDOTween();
        MoveStateClear();
    }

    //移動後のポイントを更新して、初期化なりフェードアウトのセットをします
    //こいつを呼べば移動が始まる。canMoveがfalseだと無反応です
    public void MoveTargetSet(Vector3 nextVec)
    {
        nextVec -=  this.transform.position;
        if(this.canMove)
        {
            targetPos += nextVec;
            canMove = false;
            if(fadeOn){ MoveFadeStart(); }
            MoveOn = true;
        }
    }
    
    //移動用の関数(新バージョン、DOTween使用)
    void MoveDOTween()
    {
        if(MoveOn)
        {
            transform.DOMove(targetPos, smoothTime).SetEase(easeCurve);
            SEManager.Instance.Play(SEPath.MOVE_GO);
            MoveOn = false;
        }
    }
    //目的地に到達したら移動可能に設定する
    void MoveStateClear()
    {
        if(Mathf.Abs(transform.position.x - targetPos.x) <= 0.1f && Mathf.Abs(transform.position.z - targetPos.z) <= 0.1f)
        {
            canMove = true;
        }
    }
    //階層を移動するときに呼びます。Y軸に上昇ならプラス、下降ならマイナスの値をお願いします
    public void MoveVertical(float yValue)
    {
        var nextPosition = transform.position + new Vector3(0, yValue, 0);
        nextPosition = 
            new Vector3(Mathf.Ceil(nextPosition.x),Mathf.Ceil(nextPosition.y),Mathf.Ceil(nextPosition.z));
        transform.position = nextPosition;
        targetPos = nextPosition;
        Debug.Log(nextPosition);
    }
    //移動時にフェードアウトをかけます
    void MoveFadeStart()
    {
        SteamVR_Fade.Start(new Color(0.0f, 0.0f, 0.0f, 1.0f), fadeDuration);
        Invoke("MoveFadeEnd",fadeDuration);
    }
    //フェードアウト後にフェードインをかけます
    void MoveFadeEnd()
    {
        SteamVR_Fade.Start(new Color(0.0f, 0.0f, 0.0f, 0.0f), fadeDuration);
    }

}
