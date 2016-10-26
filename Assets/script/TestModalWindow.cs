﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System.Collections;

//  This script will be updated in Part 2 of this 2 part series.
public class TestModalWindow : MonoBehaviour {
    private ModalPanel modalPanel;
    private timerScript timer;

    private UnityAction myTenSecondsAction;
    private UnityAction myYesAction;
    private UnityAction myReAction;
    
    public GameObject bgmObj;
    public AudioSource bgmSource;

    void Awake() {
        modalPanel = ModalPanel.Instance();
        timer = FindObjectOfType<timerScript>();

        myTenSecondsAction = new UnityAction(TestTenSecondsFunction);
        myYesAction = new UnityAction(TestYesFunction);
        myReAction = new UnityAction(TestReFunction);
    }

    //  Send to the Modal Panel to set up the Buttons and Functions to call
    public void Test() {
        modalPanel.Choice(TestTenSecondsFunction, TestYesFunction, TestReFunction);
    }

    //  These are wrapped into UnityActions
    void TestTenSecondsFunction() {
        GameObject.Find("pauseButton").GetComponent<Button>().enabled = true;
        GameObject.Find("leftButton").GetComponent<Button>().enabled = true;
        GameObject.Find("rightButton").GetComponent<Button>().enabled = true;

        GameObject timeBar = GameObject.Find("timeBar");
        timer.timer = 10.0f;
        timeBar.transform.Translate(1.1f, 0.0f, 0.0f);
        PlayerPrefs.SetInt("Coin", (PlayerPrefs.GetInt("Coin") - 5));
    }

    void TestYesFunction() {
        if (PlayerPrefs.GetString("CurrentSkin") == "skin2") {
            PlayerPrefs.SetInt("Coin", (int)(PlayerPrefs.GetInt("Coin") * 1.5f));
        } else {
            PlayerPrefs.SetInt("Coin", (PlayerPrefs.GetInt("Coin")));
        }
        SceneManager.LoadScene(1);
    }

    void TestReFunction() {
        SceneManager.LoadScene(2);
    }

}