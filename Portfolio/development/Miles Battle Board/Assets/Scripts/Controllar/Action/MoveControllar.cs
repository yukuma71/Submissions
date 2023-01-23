using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControllar : MonoBehaviour
{
    public ReturnButton returnButton;
    public MainControllar mainControllar;
    public MasuControllar masuControllar;
    public Flag flag;

    public static GameObject action_charactor; //行動中のキャラ

    //２つの関数でReturnButtonが押されるか正しい対象を選択するまでループ
    public void DelayMethodMove()
    {
        //関数　MoveCorodinate　起動
        StartCoroutine(MoveCorodinate());
    }
    IEnumerator MoveCorodinate()
    {
        returnButton.SetReturnButtonFlag(false);
        //クリックするまで待機
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
        bool acted_flag = false;　//移動できたら true

        var area_clones = GameObject.FindGameObjectsWithTag ("Area");       //Tag:Areaのクローンプレハブ
        var range_clones = GameObject.FindGameObjectsWithTag ("Range");     //Tag:Rangeのクローンプレハブ
        byte action_pl = flag.GetActionPlNum();　                            //行動中のキャラのプレイヤーを取得
        var action_status = action_charactor.GetComponent<CharactorControllar>();
        //AreaとRangeの座標を示し合わせ
        foreach(var area_clone in area_clones)
        {
            foreach(var range_clone in range_clones)
            {
                //違う座標だったらスキップ
                if(area_clone.transform.position != range_clone.transform.position) continue;
                //移動処理
                Vector3 origunal_position = action_charactor.GetComponent<Transform>().position;
                action_charactor.GetComponent<Transform>().position = area_clone.transform.position;
                masuControllar.Movedate(action_charactor, origunal_position);
                Debug.Log("player" + action_status.plnum + "の" + Judges.GetJobName(action_status.jobnum) + "は移動しました。");
                acted_flag = true;
            }
        }

        //ReturnBottonが押されたか
        if (returnButton.GetReturnButtonFlag() && !mainControllar.JudgeMapClick())
        {
            flag.SetMoveFlag(false);
        }
        else if(acted_flag){
            //選択行動を解除し移動済みに
            action_status.move_flag = true;
            mainControllar.ResetCommonAction();
            flag.SetMoveFlag(false);
        }
        else if(!acted_flag && mainControllar.JudgeMapClick()){
            Debug.Log("移動不可です。繰り返します。");
            //攻撃不可のため繰り返し
            Invoke("DelayMethodMove", 0.1f);
        }
        else
            Invoke("DelayMethodMove", 0.1f);
    }
}
