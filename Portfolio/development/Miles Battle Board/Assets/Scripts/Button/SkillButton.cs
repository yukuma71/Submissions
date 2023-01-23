using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;

public class SkillButton : MonoBehaviour
{

	public MainControllar maincontrollar;
    public CharactorControllar charactor1;
	public CharactorControllar charactor2;
	public CharactorControllar charactor3;
	public CharactorControllar charactor4;
	public CharactorControllar charactor5;
	public CharactorControllar charactor6;
	public CharactorControllar charactor7;
	public CharactorControllar charactor8;
	public Flag flag;
    public SkillControllar SkillControllar;

    public static GameObject action_charactor;


	public void onclick(){
        action_charactor = maincontrollar.GetActionCharactor();
        if(action_charactor == null)
            Debug.Log("キャラクターを選択していません。");
        else if(action_charactor.GetComponent<CharactorControllar>().action_flag){
            Debug.Log("このキャラクターは攻撃しました。");
        }
        else if(!flag.GetMpFlag()){
            Debug.Log("MPが足りません。");
        }
		//キャラクター選択中　＆　他のボタン処理中ではないか？
		else if(flag.GetSelectFlag() && !flag.GetButtonFlag()){
			SkillControllar.action_charactor = action_charactor;
			//ボタン処理中のフラグを立てる
			flag.SetButtonFlag(true);
            flag.SetSkillFlag(true);
            flag.SetSkillEffectFlag(false);
            maincontrollar.SkillRange(action_charactor.GetComponent<CharactorControllar>().jobnum);
            SkillControllar.DelayMethodSkill();
        }
		else
			Debug.Log("ボタンの処理中です。");
	}
}
