﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class gameStart : MonoBehaviour {
    public GameObject bgmObj;
    public AudioSource bgmSource;

    void Awake() {
        bgmObj = GameObject.Find("BGM");
        if (bgmObj) {
            bgmSource = bgmObj.GetComponent<AudioSource>();
            bgmSource.Play();
        }
    }

    public void OnMouseDown() {
        int readyCoin = PlayerPrefs.GetInt("ReadyCoin");
        PlayerPrefs.SetInt("Coin", readyCoin);

        bgmObj = GameObject.Find("BGM");
        bgmSource = bgmObj.GetComponent<AudioSource>();
        bgmSource.Stop();
        DontDestroyOnLoad(bgmObj);

        SceneManager.LoadScene(2);

    }
}
