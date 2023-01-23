using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnButton : MonoBehaviour
{

	public Flag flag;
	public MainControllar maincontrollar;
	
	public bool active_flag = false;　//このボタンは起動しているか

	public void onclick(){
		//キャラを選択しているか
		if(flag.GetSelectFlag()){
			//ボタン処理中のフラグを立てる
			flag.SetButtonFlag(true);
			//選択・行動を中止
			maincontrollar.ResetCommonAction();
		}
		else if(!flag.GetSelectFlag())
			Debug.Log("キャラクターを選択していません。");
		else
		Debug.Log("ボタンの処理中です。");
	}

	//このボタンが押されたかの判定・入出力
	public void oncthelikc(){
		active_flag = true;
	}
	public bool GetReturnButtonFlag(){
		return active_flag;
	} 
	public void SetReturnButtonFlag(bool set_flag){
		active_flag = set_flag;
	}
}
