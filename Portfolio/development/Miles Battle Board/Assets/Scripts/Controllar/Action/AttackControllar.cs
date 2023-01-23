using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackControllar : MonoBehaviour
{
    public ReturnButton returnButton;
    public MainControllar mainControllar;
    public DamageControllar damageControllar;
    public UI3Controllar ui3Controllar;
    public Flag flag;

    public static GameObject action_charactor; //行動中のキャラ

    //２つの関数でReturnButtonが押されるか正しい対象を選択するまでループ
    public void DelayMethodAttack()
    {
        StartCoroutine(AttackCoroutine());
    }

    IEnumerator AttackCoroutine()
    {

        returnButton.SetReturnButtonFlag(false);
        // クリックするまで待機
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }

        bool acted = false;　//攻撃できたら true
        var area_clones = GameObject.FindGameObjectsWithTag ("Area");       //Tag:Areaのクローンプレハブ
        var charactors  = GameObject.FindGameObjectsWithTag("charactor");   //Tag:charactor
        byte action_pl = flag.GetActionPlNum();　                            //行動中のキャラのプレイヤーを取得

        //charactorとAreaの座標を示し合わせ
        foreach(var area_clone in area_clones)
        {
            foreach(var charactor in charactors)
            {
                //違う座標だったらスキップ
                if(area_clone.transform.position != charactor.transform.position) continue;
                var charactor_status = charactor.GetComponent<CharactorControllar>();//ターゲットのステータス取得
                //攻撃対象が味方だったらスキップ
                if(charactor_status.plnum == action_pl) continue;
                //ダメージ計算
                damageControllar.AttackDamege(charactor, action_charactor.GetComponent<CharactorControllar>().jobnum);
                acted = true;
            }
        }
        //ReturnBottonが押されたか
        if (returnButton.GetReturnButtonFlag() && !mainControllar.JudgeMapClick())
        {
            flag.SetAttackFlag(false);
        }
        //攻撃できたか
        else if(acted){
            //選択行動を解除し攻撃済みに
            mainControllar.action_charactor.GetComponent<CharactorControllar>().action_flag = true;
            mainControllar.ResetCommonAction();
            flag.SetAttackFlag(false);
            //UI Board3に情報開示
            ui3Controllar.ClickData();
        }
        //できなかったら
        else if(!acted && mainControllar.JudgeMapClick()){
            Debug.Log("攻撃不可です繰り返します。");
            //攻撃不可のため繰り返し
            Invoke("DelayMethodAttack", 0.1f);
        }

        else
            Invoke("DelayMethodAttack", 0.1f);

    }
}
