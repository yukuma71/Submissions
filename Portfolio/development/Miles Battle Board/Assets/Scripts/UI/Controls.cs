using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public GameObject Title;
    public GameObject SpecialThanks;
    public GameObject StartButton;
    public GameObject ExitButton;
    public GameObject ControlsButton;

    public GameObject Controls1;
    public GameObject Controls2;
    public GameObject Controls3;
    public GameObject Controls4;
    public GameObject Controls5;
    public GameObject Controls6;
    public GameObject Controls7;
    public GameObject Controls8;
    public GameObject Controls9;
    public GameObject Controls10;
    public GameObject Controls11;
    public GameObject Controls12;
    public GameObject Controls13;


    public void ControlsTransition()
    {
        Title.SetActive(false);
        SpecialThanks.SetActive(false);
        StartButton.SetActive(false);
        ExitButton.SetActive(false);
        ControlsButton.SetActive(false);

        Controls1.SetActive(true);
        Controls2.SetActive(true);
        Controls3.SetActive(true);
        Controls4.SetActive(true);
        Controls5.SetActive(true);
        Controls6.SetActive(true);
        Controls7.SetActive(true);
        Controls8.SetActive(true);
        Controls9.SetActive(true);
        Controls10.SetActive(true);
        Controls11.SetActive(true);
        Controls12.SetActive(true);
        Controls13.SetActive(true);
    }
}
