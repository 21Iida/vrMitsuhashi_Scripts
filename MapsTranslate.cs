/*
マップがプレイヤーの視界に常に入るように滑らかに移動します
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapsTranslate : MonoBehaviour
{
    [SerializeField] Transform targetTransform = default;
    Vector3 velocity = Vector3.zero;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, targetTransform.position, ref velocity, 0.5f);
    }
}
