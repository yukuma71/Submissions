using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorsImage : MonoBehaviour
{
	SpriteRenderer mysprite;

	//赤陣営
	public Sprite red_warrior;
	public Sprite red_knight;
	public Sprite red_priest;
	public Sprite red_witch;
	//青陣営
	public Sprite blue_warrior;
	public Sprite blue_knight;
	public Sprite blue_priest;
	public Sprite blue_witch;

	void Start(){
		//このオブジェクトのSpriteRendererを取得しておく
		mysprite = this.GetComponent<SpriteRenderer>();	
	}

    public void ChangeImage(int PlNum,int jobs){
    	if(PlNum == 1){// 1:赤 2:青
    		switch(jobs){//職業　1:戦士 2:騎士 3:僧侶 4:魔女
    			case 1:
    				mysprite.sprite = red_warrior;
    				break;
    			case 2:
    				mysprite.sprite = red_knight;
    				break;
    			case 3:
    				mysprite.sprite = red_priest;
    				break;
    			case 4:
    				mysprite.sprite = red_witch;
    				break;
    		}
    	}
    	else if(PlNum == 2){
    		switch(jobs){
    			case 1:
    				mysprite.sprite = blue_warrior;
    				break;
    			case 2:
    				mysprite.sprite = blue_knight;
    				break;
    			case 3:
    				mysprite.sprite = blue_priest;
    				break;
    			case 4:
    				mysprite.sprite = blue_witch;
    				break;
    		}
    	}
    	else{//その他マス
    		mysprite.sprite = null;
    	}
    }
}
