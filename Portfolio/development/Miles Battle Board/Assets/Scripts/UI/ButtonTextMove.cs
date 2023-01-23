using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTextMove : MonoBehaviour
{
	private Vector3 textpoint;
	private Vector3 position;
    public ButtonFlag buttonflag;

	private int textmovepower = 8;

    public void Downtext(){
		if (Input.GetMouseButtonDown(0))
        {
            if(buttonflag.buttontextmovebuttonflag == 0){
                buttonflag.buttontextmovebuttonflag = 99;
                position = GetComponent<RectTransform>().localPosition;
                position.y -= textmovepower;
                GetComponent<RectTransform>().localPosition = position;
            }
        }
	}
	public void Uptext(){
		if (Input.GetMouseButtonUp(0))
        {
            if(buttonflag.buttontextmovebuttonflag == 99){
                position = GetComponent<RectTransform>().localPosition;
                position.y += textmovepower;
                GetComponent<RectTransform>().localPosition = position;
                buttonflag.buttontextmovebuttonflag = 0;
            }
        }
	}
}
