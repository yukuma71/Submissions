using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
	//起動中又は起動済みの場合 true 
	public bool select_flag = false;		//キャラ選択
	public bool button_flag = false;		//ボタンが起動
	public bool attack_flag = false;		//attackが起動
	public bool skill_flag = false;			//skillが起動
	public bool mp_flag = false; 			//mpが足りているか
	public bool skill_effect_flag = false; 	//スキルエフェクトを表示したか
	public bool move_flag = false;			//moveが起動
	public byte allnum; 						//行動中のキャラのAllNum
	public byte action_plnum;				//行動中のキャラのPlNumの入出力


	//SelectFlagの入出力
	public void SetSelectFlag(bool flag){
			select_flag = flag;
		}
	public bool GetSelectFlag(){
		return select_flag;
	}

	//ButtonFlagの入出力
	public void SetButtonFlag(bool flag){
		button_flag = flag;
    }
	public bool GetButtonFlag(){
		return button_flag;
	}

	//AttackFlagの入出力
	public void SetAttackFlag(bool flag){
    	attack_flag = flag;
    }
    public bool GetAttackFlag(){
    	return attack_flag;
    }

    //SkillFlagの入出力
	public void SetSkillFlag(bool flag){
    	skill_flag = flag;
    }
    public bool GetSkillFlag(){
    	return skill_flag;
    }

    //MpFlagの入出力
    public void SetMpFlag(bool mp_judge){
    	mp_flag = mp_judge;
    }
    public bool GetMpFlag(){
    	return mp_flag;
    }

    //SkillEffectFlagの入出力
    public void SetSkillEffectFlag(bool flag){
		skill_effect_flag = flag;
	}
	public bool GetSkillEffectFlag(){
		return skill_effect_flag;
	}

	//MoveFlagの入出力
	public void SetMoveFlag(bool flag){
    	move_flag = flag;
    }
	public bool GetMoveFlag(){
    	return move_flag;
    }

    //行動中のキャラのAllNumの入出力
    public void SetAllNumber(byte flag){
		allnum = flag;
	}
	public byte GetAllNumber(){
		return allnum;
	}
	
	//行動中のキャラのPlNumの入出力
	public void SetActionPlNum(byte plnum){
		action_plnum = plnum;
	}
	public byte GetActionPlNum(){
		return action_plnum;
	}
}