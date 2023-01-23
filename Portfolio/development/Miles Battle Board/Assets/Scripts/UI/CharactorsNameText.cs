using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharactorsNameText : MonoBehaviour
{

	private Text targetText; 

	private int jobnum; 
    
    public void JobText(int jobnum)
    {
    	switch(jobnum){
			case 1://キャラクター（全体番号)
				this.targetText = this.GetComponent<Text>();
				this.targetText.text = "戦士";
                break;
			case 2:
				this.targetText = this.GetComponent<Text>();
				this.targetText.text = "騎士";
                break;
			case 3:
				this.targetText = this.GetComponent<Text>();
				this.targetText.text = "僧侶";
                break;
			case 4:
				this.targetText = this.GetComponent<Text>();
				this.targetText.text = "魔女";
                break;
            default:
                this.targetText = this.GetComponent<Text>();
				this.targetText.text = "----------";
				break;
		}
    }
}
