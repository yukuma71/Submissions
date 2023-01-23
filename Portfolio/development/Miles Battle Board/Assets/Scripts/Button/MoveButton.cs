using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButton : MonoBehaviour
{

	public MainControllar mainControllar;
	public MoveControllar moveControllar;
	public Flag flag;

	public void onclick()
	{
		GameObject action_charactor = mainControllar.GetActionCharactor();
        if(action_charactor == null)
        	Debug.Log("キャラクターを選択していません。");
		else if(action_charactor.GetComponent<CharactorControllar>().move_flag)
		{
			Debug.Log("このターンこのキャラクターは移動しました。");
		}
		//キャラクター選択中　＆　他のボタン処理中ではないか？
		else if(flag.GetSelectFlag() && !flag.GetButtonFlag()){
			MoveControllar.action_charactor = action_charactor;
            //ボタン処理中のフラグを立てる
			flag.SetButtonFlag(true);
			flag.SetMoveFlag(true);
			mainControllar.MoveRange(action_charactor.GetComponent<CharactorControllar>().move_power);
			moveControllar.DelayMethodMove();
        }
		else
			Debug.Log("ボタンの処理中です。");
	}
}
