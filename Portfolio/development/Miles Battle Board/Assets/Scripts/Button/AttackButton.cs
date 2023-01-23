using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButton : MonoBehaviour
{
    public MainControllar maincontrollar;
    public AttackControllar AttackControllar;
	public CharactorControllar charactor1;
	public CharactorControllar charactor2;
	public CharactorControllar charactor3;
	public CharactorControllar charactor4;
	public CharactorControllar charactor5;
	public CharactorControllar charactor6;
	public CharactorControllar charactor7;
	public CharactorControllar charactor8;
	public Flag flag;

    public static GameObject action_charactor;

	public void onclick(){
		//キャラクター選択中　＆　他のボタン処理中ではないか？
        action_charactor = maincontrollar.GetActionCharactor();
        if(action_charactor == null){
            Debug.Log("キャラクターを選択していません。");
        }
        else if(action_charactor.GetComponent<CharactorControllar>().action_flag){
            Debug.Log("このキャラクターは攻撃しました。");
        }
		else if(flag.GetSelectFlag() && !flag.GetButtonFlag()){
			AttackControllar.action_charactor = action_charactor;
			//ボタン処理中のフラグを立てる
			flag.SetButtonFlag(true);
            flag.SetAttackFlag(true);
            maincontrollar.AttackRange();
            AttackControllar.DelayMethodAttack();
        }
			//選択している全体番号を取得する
		else
			Debug.Log("ボタンの処理中です。");
	}
}
