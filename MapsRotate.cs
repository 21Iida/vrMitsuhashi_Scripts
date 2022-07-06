using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ミニマップがプレイヤーに向くようにしています
/// <summary>
public class MapsRotate : MonoBehaviour
{
    [SerializeField] Transform PlayerTransform = default;

    void Update()
    {
        this.transform.LookAt(PlayerTransform);
    }
}
