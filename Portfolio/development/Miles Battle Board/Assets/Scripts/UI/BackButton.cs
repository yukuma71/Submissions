using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
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


    public void MainMenuTransition()
    {
        Title.SetActive(true);
        SpecialThanks.SetActive(true);
        StartButton.SetActive(true);
        ExitButton.SetActive(true);
        ControlsButton.SetActive(true);

        Controls1.SetActive(false);
        Controls2.SetActive(false);
        Controls3.SetActive(false);
        Controls4.SetActive(false);
        Controls5.SetActive(false);
        Controls6.SetActive(false);
        Controls7.SetActive(false);
        Controls8.SetActive(false);
        Controls9.SetActive(false);
        Controls11.SetActive(false);
        Controls12.SetActive(false);
        Controls13.SetActive(false);
        Controls10.SetActive(false);
    }
}
