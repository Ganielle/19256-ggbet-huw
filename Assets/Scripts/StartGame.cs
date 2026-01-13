using UnityEngine;
using System.Collections;
using System;


public class StartGame : MonoBehaviour {

    public GameObject [ ] maps;
    public GameObject shop;
    public GameObject music;
    public GameObject[] player;
    public GameObject gameController;
    public GameObject panelInGame;    
    public GameObject warehouse;

    private Animator anim;   

    void Awake()
    {
        //if(!FB.IsInitialized)
        //{
        //    // Initialize the Facebook SDK
        //    FB.Init(InitCallback, OnHideUnity);
        //}
        //else
        //{
        //    // Already initialized, signal an app activation App Event
        //    FB.ActivateApp();
        //}
    }

    void Start()
    {
        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.SetInt(ClassConst.sumCoin, 10000);
        //Screen.SetResolution(600, 1024, true);
        //Camera.main.aspect = 600f / 1024f;
        if (!PlayerPrefs.HasKey(ClassConst.highestScore))
        {
            PlayerPrefs.SetInt(ClassConst.highestScore, 0);
        }
        if(!PlayerPrefs.HasKey(ClassConst.longestDistance))
        {
            PlayerPrefs.SetInt(ClassConst.longestDistance, 0);
        }
        if(!PlayerPrefs.HasKey(ClassConst.maxCoin))
        {
            PlayerPrefs.SetInt(ClassConst.maxCoin, 0);
        }
        
        anim = GetComponentInChildren<Animator>();
    }


    public void ButPlay()
    {
        AudioControll.instance.audioButton.Play();
        anim.SetBool("Touched", true);
        music.SetActive(false);
    }

    public void PlayGame()
    {
        AudioControll.instance.audioStart.Stop();
        AudioControll.instance.audioIngame.Play();
        int map = UnityEngine.Random.Range(0, maps.Length);
        Instantiate(maps [ map ], maps [ map ].transform.position, maps [ map ].transform.rotation);
        Instantiate(player [ WareHouse.maybaySelected - 1 ], player [ WareHouse.maybaySelected - 1 ].transform.position, player [ WareHouse.maybaySelected - 1 ].transform.rotation);
        gameController.SetActive(true);
        panelInGame.SetActive(true);
        GameObject startGame = GameObject.Find("StartGame");
        startGame.SetActive(false);
    }

    // Facebook share
    #region
    //private void InitCallback()
    //{
    //    if(FB.IsInitialized)
    //    {
    //        // Signal an app activation App Event
    //        FB.ActivateApp();
    //        // Continue with Facebook SDK
    //        // ...
    //    }
    //    else
    //    {
    //        Debug.Log("Failed to Initialize the Facebook SDK");
    //    }
    //}

    //private void OnHideUnity(bool isGameShown)
    //{
    //    if(!isGameShown)
    //    {
    //        // Pause the game - we will need to hide
    //        Time.timeScale = 0;
    //    }
    //    else
    //    {
    //        // Resume the game - we're getting focus again
    //        Time.timeScale = 1;
    //    }
    //}

    //private void ShareCallback(IShareResult result)
    //{
    //    if(result.Cancelled || !String.IsNullOrEmpty(result.Error))
    //    {
    //        Debug.Log("ShareLink Error: " + result.Error);
    //    }
    //    else if(!String.IsNullOrEmpty(result.PostId))
    //    {
    //        // Print post identifier of the shared content
    //        Debug.Log(result.PostId);
    //    }
    //    else
    //    {
    //        // Share succeeded without postID
    //        Debug.Log("ShareLink success!");
    //    }
    //}


    //public void ButShare()
    //{
    //    AudioControll.instance.audioButton.Play();
    //    music.SetActive(false);
    //            FB.ShareLink(
    //        new Uri("https://developers.facebook.com/"),
    //        callback: ShareCallback
    //    );
    //}

    #endregion

    public void ButShop()
    {
        AudioControll.instance.audioButton.Play();
        music.SetActive(false);
        shop.SetActive(true);
        gameObject.SetActive(false);
    }   

    public void ButSetup()
    {
        AudioControll.instance.audioButton.Play();
        switch(music.activeInHierarchy)
        {
            case true:
            music.SetActive(false);
            break;
            case false:
            music.SetActive(true);
            break;
        }
    }

    public void ButWarehouse()
    {
        AudioControll.instance.audioButton.Play();
        warehouse.SetActive(true);
        music.SetActive(false);
        gameObject.SetActive(false);        
    }
}
