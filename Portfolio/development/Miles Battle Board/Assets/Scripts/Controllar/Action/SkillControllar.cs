using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;

public class SkillControllar : MonoBehaviour
{

    public ReturnButton returnButton;
    public MainControllar mainControllar;
    public DamageControllar damageControllar;
    public UI3Controllar ui3Controllar;
    public Flag flag;

    public static GameObject action_charactor; //行動中のキャラ

    //２つのでReturnButtonが押されるか正しい対象を選択するまでループ
    public void DelayMethodSkill()
    {
        StartCoroutine(SkillCoroutine());
    }
    IEnumerator SkillCoroutine()
    {
        returnButton.SetReturnButtonFlag(false);
        // クリックするまで待機
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
        
        
        bool acted_flag = false; //スキルを発動できたら true
        var area_clones = GameObject.FindGameObjectsWithTag ("Area");       //Tag:Areaのクローンプレハブ
        var charactors  = GameObject.FindGameObjectsWithTag("charactor");   //Tag:charactor
        byte action_pl = flag.GetActionPlNum();    
                                  //行動中のキャラのプレイヤーを取得
        //charactorとAreaの座標を示し合わせ
        foreach(var area_clone in area_clones)
        {
            foreach(var charactor in charactors)
            {
                //違う座標だったらスキップ
                if(area_clone.transform.position != charactor.transform.position) continue;
                var charactor_status = charactor.GetComponent<CharactorControllar>(); //ターゲットのステータス取得
                //僧侶
                if(action_charactor.GetComponent<CharactorControllar>().jobnum == SOURYO && action_pl == charactor_status.plnum){
                    damageControllar.SkillDamege(charactor);
                    acted_flag = true; 
                }
                //騎士
                if(action_charactor.GetComponent<CharactorControllar>().jobnum == KISHI && action_pl == charactor_status.plnum){
                    damageControllar.SkillDamege(charactor);
                    acted_flag = true; 
                }
                //その他
                else if(action_charactor.GetComponent<CharactorControllar>().jobnum != SOURYO && charactor_status.plnum != action_pl){
                    damageControllar.SkillDamege(charactor);
                    acted_flag = true;
                }
                    
            }
        }
        //ReturnBottonが押されたか
        if (returnButton.GetReturnButtonFlag() && !mainControllar.JudgeMapClick())
        {
            flag.SetSkillFlag(false);
        }
        //スキルを発動できたか
        else if(acted_flag){
            //選択行動を解除し攻撃済みに
            mainControllar.action_charactor.GetComponent<CharactorControllar>().action_flag = true;
            mainControllar.ResetCommonAction();
            flag.SetSkillFlag(false);
            action_charactor.GetComponent<CharactorControllar>().mp -= action_charactor.GetComponent<CharactorControllar>().skill_cost;
            //UI Board3に情報開示
            ui3Controllar.ClickData();

        }
        //発動できなかったら
        else if(!acted_flag && mainControllar.JudgeMapClick()){
            Debug.Log("スキル使用不可です。繰り返します。");
            //攻撃不可のため繰り返し
            Invoke("DelayMethodSkill", 0.1f);
        }
        else
            Invoke("DelayMethodSkill", 0.1f);
    }
}
