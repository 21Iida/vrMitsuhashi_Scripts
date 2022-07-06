using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// マップからプレイヤーがワープできるようにするメイン部分です
/// <summary>
public class MapPlayerWarp : MonoBehaviour
{
    [SerializeField] PlayerMove playerMove;
    [SerializeField] Transform nextPos;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerMove.MoveTargetSet(nextPos.position);
        }
    }

}
