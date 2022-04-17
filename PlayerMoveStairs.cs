/*
階段に当たった時の挙動です
コライダーに応じて上下します
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveStairs : MonoBehaviour
{
    //Playerを動かすためのクラスを取得
    PlayerMove playerMove;
    void Start()
    {
        playerMove = transform.root.gameObject.GetComponent<PlayerMove>();
    }

    //階段のコライダーの種類を判別して上昇したり下降したりします。
    //これは滑らかな移動ではなくワープです
    void OnTriggerStay(Collider coll)
    {
        if(coll.CompareTag("UpStairs"))
        {
            playerMove.MoveVertical(playerMove.getMoveValue);
        }
        if(coll.CompareTag("DownStairs"))
        {
            playerMove.MoveVertical(-playerMove.getMoveValue);
        }
    }
}
