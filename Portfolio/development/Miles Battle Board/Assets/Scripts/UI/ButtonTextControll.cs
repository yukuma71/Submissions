using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTextControll : MonoBehaviour
{
	public ButtonTextMove buttontextmove;

	public void DownButton(){
		buttontextmove.Downtext();
	}
	public void UpButton(){
		buttontextmove.Uptext();
	}
}
