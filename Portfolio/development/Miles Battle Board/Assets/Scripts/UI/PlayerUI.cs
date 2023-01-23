using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{

	private Text targetText;

	private int PlNum; 
    
    public void PlayerUIChange(int PlNum)
    {
    	if(1 == PlNum || 2 == PlNum){
			this.targetText = this.GetComponent<Text>();
			this.targetText.text = ""+PlNum;
		}
		else{
			this.targetText = this.GetComponent<Text>();
			this.targetText.text = "--";
    	}
	}
}
