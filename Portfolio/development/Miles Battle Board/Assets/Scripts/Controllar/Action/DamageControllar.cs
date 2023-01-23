using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;

public class DamageControllar : MonoBehaviour
{
    public MainControllar mainControllar;
    public MasuControllar masuControllar;
    public Flag flag;
    public Judges judges;
    public EffectControllar effectControllar;

    public GameObject action_charactor;//行動中のキャラ
    private int atk;            //攻撃力
    private int skill_power;    //スキルの攻撃力・回復力・効果ターン
    
    //ATKを入力
    public void AttackInput(int attack){
        atk = attack;
    }

    //スキルパワーを入力
    public void SetSkillPower(int skill){
        skill_power = skill;
    }

    //Attackの処理
    public void AttackDamege(GameObject target_character, byte attack_job)
    {
        var target_status = target_character.GetComponent<CharactorControllar>();   //ターゲットのステータス取得
        Vector3　position = target_character.GetComponent<Transform>().position;    //ターゲットの座標取得    
        //エフェクト表示
        effectControllar.AttackEffect(position,attack_job);
        //軽減判定
        if(target_status.resist_turn > 0)
            atk = ResistDamage(atk);
        //ダメージ計算
        target_status.hp -= atk;

        DamageLog(target_character, atk);
        
        //攻撃したキャラを攻撃済みに
        action_charactor = mainControllar.GetActionCharactor();
        action_charactor.GetComponent<CharactorControllar>().action_flag = true;
        //死んだら
        if(target_status.hp <= 0)
            target_status.Die();
    }

    //スキルの処理
    public void SkillDamege(GameObject target_character)
    {
        var target_status = target_character.GetComponent<CharactorControllar>();   //ターゲットのステータス取得
        Vector3 position = target_character.GetComponent<Transform>().position;     //ターゲットの座標取得 
        //騎士のスキル
        if(mainControllar.action_charactor.GetComponent<CharactorControllar>().jobnum == KISHI){
            effectControllar.ShieldEffect(position);
            target_status.resist_turn = (byte)skill_power;
            Debug.Log("騎士のスキル、ボディーシールドを使用しました。");
        }
        //攻撃または回復
        else{
            if(target_status.resist_turn > 0 && skill_power > 0)
                skill_power = ResistDamage(skill_power);
            target_status.hp -= skill_power;
            if(target_status.hp > target_status.maxhp)
                target_status.hp = target_status.maxhp;
            else if(target_status.hp <= 0 ){
                target_status.hp = 0;
                target_status.Die();
            }
        }
        //EffectFlagを表示
        switch(mainControllar.action_charactor.GetComponent<CharactorControllar>().jobnum){
            case 1:
                DamageLog(target_character, skill_power);
                if(!flag.GetSkillEffectFlag())
                {
                    int rotateflag = 0;
                    Vector3 start = mainControllar.ReturnStartPosition();
                    start.x = start.x - 6;
                    start.y = start.y - 6;
                    if (start.x < position.x)//右
                        rotateflag = 1;
                    if (start.y > position.y)//下
                        rotateflag = 2;
                    if (start.x > position.x)//左
                        rotateflag = 3;
                    if (start.y < position.y)//上
                        rotateflag = 4;
                    effectControllar.PowerSlashEffect(position,rotateflag);
                    flag.SetSkillEffectFlag(true);
                }
                break;
            case KISHI:
                effectControllar.ShieldEffect(position);
                break;
            case SOURYO:
                Debug.Log("Player" + target_status.plnum +"の" + Judges.GetJobName(target_status.jobnum) + "のHPを" + (-skill_power) + "回復しました！　残りHP" + target_status.hp);
                if(!flag.GetSkillEffectFlag()){
                    effectControllar.HealEffect(position);
                    flag.SetSkillEffectFlag(true);
                }
                break;
            case MAJO:
                DamageLog(target_character, skill_power);
                if(!flag.GetSkillEffectFlag())
                {
                    position = masuControllar.GetClickPosition();
                    position.x -= 6;
                    position.y -= 6;
                    effectControllar.SpellEffect(position);
                    flag.SetSkillEffectFlag(true);
                }
                break;

        }
    }

    public void DamageLog(GameObject target, int damage)
    {
        var target_status = target.GetComponent<CharactorControllar>();   //ターゲットのステータス取得
        Debug.Log("Player" + target_status.plnum +"の" + Judges.GetJobName(target_status.jobnum) + "に" + damage + "ダメージ！　残りHP" + target_status.hp);
    }

    public int ResistDamage(int power){
         return (power / 2);
    }
}
