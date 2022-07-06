using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーがバグで飛んだり、歩行してプレイエリアから外れた際にシステムメッセージを出します
/// <summary>
public class PlayAreaMessage : MonoBehaviour
{
    [SerializeField] GameObject MessagePanel = default;
    
    void Start()
    {
        MessagePanel.SetActive(false);
    }
    
    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("PlayArea"))
        {
            MessagePanel.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other) {
        if(other.CompareTag("PlayArea"))
        {
            MessagePanel.SetActive(false);
        }
    }
}
