using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 扉の開閉システム
/// <summary>
public class DoorCloseOpen : MonoBehaviour
{
    [SerializeField] Material closeMaterial;
    Material openMaterial;
    [SerializeField] Renderer originalRenderer;

    void Start()
    {
        openMaterial = originalRenderer.material;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            originalRenderer.material = closeMaterial;
        }
        if(Input.GetKeyDown(KeyCode.S)){
            originalRenderer.material = openMaterial;
        }
    }
}
