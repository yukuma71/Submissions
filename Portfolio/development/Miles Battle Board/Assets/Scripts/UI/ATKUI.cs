using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ATKUI : MonoBehaviour
{

	private Text targetText;

	private int ATKPower; 
    
    public void ATKPoworChange(int ATKPower)
    {
    	if(ATKPower == 444){
    		this.targetText = this.GetComponent<Text>();
			this.targetText.text = "--";
    	}
    	else{
			this.targetText = this.GetComponent<Text>();
			this.targetText.text = ""+ATKPower;
		}
    }
}