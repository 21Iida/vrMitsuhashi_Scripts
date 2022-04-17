/*
ミニマップがプレイヤーに向くようにしています
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapsRotate : MonoBehaviour
{
    [SerializeField] Transform PlayerTransform = default;

    void Update()
    {
        this.transform.LookAt(PlayerTransform);
    }
}
