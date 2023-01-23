using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MPUI : MonoBehaviour
{
	private Image image;//Component Imageを格納
	private int MAXMP;//最大体力を格納
	private int MP;//現在のMPを格納

	public void MPUIChange(int MAXMP,int MP){
		if(MAXMP == 444 && MP == 444){
			Image image = GetComponent<Image>();//imageにComponentからImageを格納
			image.fillAmount = (float)0;//現在のMP表示
		}
		else{
			Image image = GetComponent<Image>();//imageにComponentからImageを格納
			image.fillAmount = (float)MP/MAXMP;//現在のMP表示
		}
	}
}
