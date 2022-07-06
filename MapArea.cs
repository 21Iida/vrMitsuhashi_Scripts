using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// マップのエリアの判定をします
/// MapChangerを働かせます
/// <summary>
public class MapArea : MonoBehaviour
{
    private enum AreaState
    {
        F1a,
        F2a
    }

    [SerializeField] AreaState areaState = default;
    [SerializeField] MapChanger mapChanger = default;

    //自分のエリアにプレイヤーが侵入してきたらマップを切り替える
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            if(areaState == AreaState.F1a)
            {
                mapChanger.MapChange("1Fa");
            }
            if(areaState == AreaState.F2a)
            {
                mapChanger.MapChange("2Fa");
            }
        }
    }
}
