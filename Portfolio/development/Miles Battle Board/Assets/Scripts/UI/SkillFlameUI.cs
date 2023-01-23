using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillFlameUI : MonoBehaviour
{
	public SkillDetailsUI skilldetailsui;
	public GameObject skilldetailsobj;

	private int jobs = 444;

	public void SkillRetention(int data){
		jobs = data;//キャラクタークリック時データ保持
	}

    void OnMouseOver(){
    	if(jobs != 444){//キャラクタークリック時以外弾く
    		skilldetailsobj.SetActive(true);//アクティブ化
    		skilldetailsui.ChangeSkillDetails(jobs);//スキル情報用UIに現在の選択キャラクターを送る
    	}
    }

    void OnMouseExit(){
    	if(jobs != 444){
    		skilldetailsobj.SetActive(false);//非アクティブ化
    	}
    }
}
