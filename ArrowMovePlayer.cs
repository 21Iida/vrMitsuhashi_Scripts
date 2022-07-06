using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

/// <summary>
/// 視線とトラッカーの入力からプレイヤーを移動させます
/// <summary>
public class ArrowMovePlayer : MonoBehaviour
{
    //選択状態ならtrueにする、未選択状態でfalse
    bool selectedNow = false;
    PlayerMove playerMove;
    //SteamVRのトラッカーから入力を受け取る
    [SerializeField] SteamVR_Input_Sources handType = default;
    [SerializeField] SteamVR_Action_Boolean grabGrip = default;
    //目的地設定
    [SerializeField] Vector3 targetPos = Vector3.zero;
    [SerializeField] Transform targetObj = default;

    void Update()
    {
        if(selectedNow && (Input.GetKeyDown(KeyCode.Return) || grabGrip.GetStateDown(handType)))
        {
            playerMove.MoveTargetSet(targetPos);
        }
    }

    public void TargetSet(Transform target)
    {
        targetObj = target;
        //ターゲット用のオブジェクトが設定されているならそっちへ向かうようにします
        targetPos = targetObj.position;
    }

    //非表示にされるとき、フラグをリセットします
    private void OnDisable() {
        selectedNow = false;
    }

    //プレイヤーの視線上に入ったとき
    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("PlayerEye"))
        {
            playerMove = col.transform.root.gameObject.GetComponent<PlayerMove>();
            selectedNow = true;
        }
    }
    //プレイヤーの視線上から外れたとき
    void OnTriggerExit(Collider col)
    {
        if(col.CompareTag("PlayerEye"))
        {
            selectedNow = false;
        }
    }

}
