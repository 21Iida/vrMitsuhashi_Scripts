using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaArrowGenerator : MonoBehaviour
{
    [SerializeField] GameObject arrowPrefaf;
    [SerializeField] List<Transform> listTraget;

    //設定に対して矢印プレハブを生成
    void Awake()
    {
        for(int i = 0; i < listTraget.Count; i++) {
            GameObject ap = Instantiate(arrowPrefaf, this.transform.position, Quaternion.identity);
            ap.transform.LookAt(listTraget[i].position);
            ap.transform.Rotate(new Vector3(0,-90,0));
            ap.transform.GetComponentInChildren<ArrowMovePlayer>().TargetSet(listTraget[i]);
            ap.transform.parent = this.transform;
        }
    }

    void Update()
    {
        
    }

    //設定されている移動先にギズモを伸ばす
    void OnDrawGizmosSelected()
    {
        for(int i = 0; i < listTraget.Count; i++)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(transform.position, (listTraget[i].position - transform.position)/1.5f + transform.position);
        }
    }
}
