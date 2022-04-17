/*
プレイヤーの周りの矢印のオンオフを切り替えます
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSet : MonoBehaviour
{
    //方向とboolのセット
    Dictionary<string, bool> arrowFlags = new Dictionary<string, bool>();

    //矢印の親オブジェクトを取得
    [SerializeField]
    GameObject arrowObjRoot = default;
    //矢印の個別オブジェクト
    List<GameObject> arrowObj = new List<GameObject>();
    
    void Start()
    {
        //Rootオブジェクトから子オブジェクトを取得
        foreach(Transform child in arrowObjRoot.transform) {
            arrowObj.Add(child.gameObject);
		}
    }

    //Areaに当たれば矢印のDictionaryを更新します
    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Area"))
        {
            arrowFlags = col.GetComponent<AreaArrowTable>().getArrowAreaFlags;
            
            ArrowSwitch();
        }
    }

    //矢印のSetActiveを個別に切り替えます
    void ArrowSwitch()
    {
        foreach(var ao in arrowObj)
        {
            switch(ao.name)
            {
                case "Arrow_Front":
                    ActiveJudge(ao,"FrontArrow");
                    break;
                case "Arrow_Back":
                    ActiveJudge(ao,"BackArrow");
                    break;
                case "Arrow_Left":
                    ActiveJudge(ao,"LeftArrow");
                    break;
                case "Arrow_Right":
                    ActiveJudge(ao,"RightArrow");
                    break;
                
            }
        }
    }
    //そのオブジェクトのsetAcriveを切り替えます
    void ActiveJudge(GameObject ao,string arrowName)
    {
        ao.SetActive(arrowFlags[arrowName]);
    }
}
