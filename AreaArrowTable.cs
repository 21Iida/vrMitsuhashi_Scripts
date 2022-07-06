using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 矢印のオンオフ設定を空間ごとに設定します
/// 設定だけなので、ここでなにかオブジェクトを弄ったりはしていません
/// 設定はArrowSetが取得しに来ます
/// <summary>
public class AreaArrowTable : MonoBehaviour
{
    //この場所で表示してよい矢印
    Dictionary<string, bool> ArrowAreaFlag = new Dictionary<string, bool>();
    
    //Dictionaryはインスペクターから触れないので一度クラスに入れてAwakeで受け渡しています
	[System.Serializable]
	class Arrows {
		[SerializeField]
        bool FrontArrow = false,BackArrow = false,LeftArrow = false,RightArrow = false;
        //Awakeに渡す用のゲッター群
        public bool front { get{ return this.FrontArrow; } }
        public bool back { get{ return this.BackArrow; } }
        public bool left { get{ return this.LeftArrow; } }
        public bool right { get{ return this.RightArrow; } }
        
	};
    [SerializeField]
	Arrows arrows = null; //クラス内で受け渡すするために宣言

    public Dictionary<string, bool> getArrowAreaFlags
    { 
        get{ return this.ArrowAreaFlag; } 
    }

    void Awake()
    {
        //ここで実際にArrowsクラスの値をDictionaryに入れています
        //格納されたデータはArrowSet側で確認する
        ArrowAreaFlag.Add("FrontArrow",arrows.front);
        ArrowAreaFlag.Add("BackArrow",arrows.back);
        ArrowAreaFlag.Add("LeftArrow",arrows.left);
        ArrowAreaFlag.Add("RightArrow",arrows.right);
    }

    //シーンビューにギズモを出すだけ
    void OnDrawGizmosSelected()
    {
        if(arrows.front)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, transform.position + transform.right * 30);
        }
        if(arrows.back)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, transform.position + -transform.right * 30);
        }
        if(arrows.left)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, transform.position + transform.forward * 30);
        }
        if(arrows.right)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, transform.position + -transform.forward * 30);
        }
    }
}
