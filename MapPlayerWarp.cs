//マップからプレイヤーがワープできるようにするメイン部分です

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPlayerWarp : MonoBehaviour
{
    [SerializeField] PlayerMove playerMove;
    [SerializeField] Transform nextPos;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerMove.MoveTargetSet(nextPos.position);
        }
    }

}
