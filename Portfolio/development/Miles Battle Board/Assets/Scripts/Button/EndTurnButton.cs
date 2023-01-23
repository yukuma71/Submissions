using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnButton : MonoBehaviour
{

	public MainControllar maincontrollar;

    public void ButtonClick(){
    	maincontrollar.ChangeTurn();
    }
}
