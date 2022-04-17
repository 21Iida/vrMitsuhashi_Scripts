/*
球体の名前を自動でセットしてくれます
メインシーンで生きているやつがいたら殺してください
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RenameSphere : MonoBehaviour
{

    [ContextMenu("NameChange")]
    void NameChange()
    {
        //子オブジェクトの球体を検索
        GameObject ns = transform.Find("NormalSphere100").gameObject;
        //ちゃんと球体があれば名前を変更
        if(ns != null)
        {
            //子オブジェクトのマテリアルを取得して名前を設定。sharedMaterialにしないとマテリアルのインスタンスが増えるので注意
            string newName = ns.GetComponent<Renderer>().sharedMaterial.name;
            newName = "PhotoSphere_" + newName;
            //ここで名前をセット
            gameObject.name = newName;
        }
        
        //再生していなくてもこのスクリプトをremoveしてくれる
        EditorApplication.delayCall += () => DestroyImmediate(this);
    }
}
