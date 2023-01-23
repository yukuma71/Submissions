using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTurnText : MonoBehaviour
{
	private Text targettext;

    public void TextPlayer(int nowturn)
    {
        this.targettext = this.GetComponent<Text>();
        if(nowturn == 1){
        	this.targettext.text = "1";
        	this.targettext.color = Color.red;
        }
        if(nowturn == 2){
        	this.targettext.text = "2";
        	this.targettext.color = Color.blue;
        }
    }
}
