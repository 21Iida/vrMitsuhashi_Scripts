using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi.AudioManager;

/// <summary>
/// プレイヤーの周りの矢印単体の制御です
/// どの矢印が選択状態なのかをPlayerMoveが確認しに来ます
/// どうせ制御自体は一括だから親オブジェクトから操作したほうが良さげかも
/// <summary>
public class ArrowAnim : MonoBehaviour
{
    //経過時間
    float time;
    //オブジェクトのY座標の位置。ふわふわさせたいので宣言
    float arrowPositionY = 0;
    //ふわふわアニメーションの上下のスピード、大きさ
    [SerializeField]
    float updownSpeed = 5,updownScale = 0.1f;
    //選択状態ならtrueにする、未選択状態でfalse
    bool selectedNow = false;
    
    //PlayerMoveから観測する用ゲッター
    public bool ArrowSelectFlag
    {
        get{ return this.selectedNow; }
    }

    void Update()
    {
        time += Time.deltaTime;
        //選択状態によってアニメーションを切り替え
        if(selectedNow)
        {
            SelectSate();
        } else {
            IdleState();
        }
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
            this.GetComponent<Renderer>().material.color = Color.red;
            this.GetComponent<Outline>().OutlineWidth = 9;
            SEManager.Instance.Play(SEPath.SELECT);
            selectedNow = true;
        }
    }
    //プレイヤーの視線上から外れたとき
    void OnTriggerExit(Collider col)
    {
        if(col.CompareTag("PlayerEye"))
        {
            this.GetComponent<Renderer>().material.color = Color.white;
            this.GetComponent<Outline>().OutlineWidth = 0;
            selectedNow = false;
        }
    }

    //未選択状態のアニメーション
    void IdleState()
    {
        arrowPositionY = 0;
        transform.localPosition = new Vector3(transform.localPosition.x,arrowPositionY,transform.localPosition.z);
    }
    //選択状態のアニメーション
    void SelectSate()
    {
        arrowPositionY = Mathf.Sin(time * updownSpeed) * updownScale;
        transform.localPosition = new Vector3(transform.localPosition.x,arrowPositionY,transform.localPosition.z);
    }
}
