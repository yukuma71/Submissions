using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPUI : MonoBehaviour
{
	private Image image;//Component Imageを格納
	private int MAXHP;//最大体力を格納
	private int HP;//現在のHPを格納

	public void HPUIChange(int MAXHP,int HP){
		if(MAXHP == 444 && HP == 444){
			Image image = GetComponent<Image>();//imageにComponentからImageを格納
			image.fillAmount = (float)0;//現在のHP表示
		}
		else{
			Image image = GetComponent<Image>();//imageにComponentからImageを格納
			image.fillAmount = (float)HP/MAXHP;//現在のHP表示
		}
	}
}
