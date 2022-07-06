using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// マップの切り替え時に、前のマップのレンダリング結果を破棄します
/// <summary>
public class MapTextureClear : MonoBehaviour
{
    [SerializeField] RenderTexture rTex = default;
    private void OnEnable() {
        rTex.Release();
    }
}
