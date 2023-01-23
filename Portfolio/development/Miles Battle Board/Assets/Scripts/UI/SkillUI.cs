using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUI: MonoBehaviour
{
	SpriteRenderer mysprite;

	public Sprite skill_warrior;
	public Sprite skill_knight;
	public Sprite skill_priest;
	public Sprite skill_witch;

	void Start(){
		//このオブジェクトのSpriteRendererを取得しておく
		mysprite = this.GetComponent<SpriteRenderer>();	
	}

    public void ChangeSkillIcons(int jobs){
    	switch(jobs){//職業　1:戦士 2:騎士 3:僧侶 4:魔女
			case 1://キャラクター（全体番号);
				mysprite.sprite = skill_warrior;
            	break;
			case 2:
				mysprite.sprite = skill_knight;
         	   	break;
			case 3:
				mysprite.sprite = skill_priest;
            	break;	
  			case 4:
  				mysprite.sprite = skill_witch;
            	break;
            default:
            	mysprite.sprite = null;
		    	break;
		}
    }
}