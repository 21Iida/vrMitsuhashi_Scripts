/*
マップの表示を切り替えるやつです
MapAreaで呼びます
マップアイコンの管理をしているので、ステージを増やすごとにIconObjSetを実行してください
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapChanger : MonoBehaviour
{
    [SerializeField]
    GameObject map1fa = default,map2fa = default;
    //[SerializeField] GameObject stage1Fas = default,stage2Fas = default;
    
    //ステージセット
    [SerializeField] GameObject stage1Fa,stage2Fa;
    //ステージアイコン、面倒だけど一つ一つセットして
    [SerializeField] List<GameObject> stage1Fas,stage2Fas;

    [ContextMenu("IconObjSet")]
    //ステージのアイコンをセットしてくれる
    void IconObjSet()
    {
        stage1Fas = new List<GameObject>();
        stage2Fas = new List<GameObject>();

        //孫オブジェクトから名前を検索してListに追加してくれる
        foreach (Transform childTransform in stage1Fa.transform)
        {
            stage1Fas.Add(childTransform.Find("MapIcon").gameObject);
        }
        foreach (Transform childTransform in stage2Fa.transform)
        {
            stage2Fas.Add(childTransform.Find("MapIcon").gameObject);
        }

    }

    //階層とアルファベットを渡したらそいつ以外を非表示にしてくれるよ
    public void MapChange(string mapName)
    {
        AllHide();
        switch(mapName)
        {
            case "1Fa":
                map1fa.SetActive(true);
                stage1FasActive(true);
                break;
            case "2Fa":
                map2fa.SetActive(true);
                stage2FasActive(true);
                break;
            default:
                Debug.Log("マップの切り替えに失敗しました。");
                break;
        }
    }

    //ステージ1のアイコンを表示非表示
    void stage1FasActive(bool active)
    {
        for(int i = 0; i < stage1Fas.Count; i++) {
            stage1Fas[i].SetActive(active);
        }
    }

    //ステージ2のアイコンを表示非表示
    void stage2FasActive(bool active)
    {
        for(int i = 0; i < stage2Fas.Count; i++) {
            stage2Fas[i].SetActive(active);
        }
    }

    //一度全て非アクティブにします
    void AllHide()
    {
        map1fa.SetActive(false);
        map2fa.SetActive(false);
        stage1FasActive(false);
        stage2FasActive(false);
    }
}
