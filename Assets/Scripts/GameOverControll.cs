using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverControll : MonoBehaviour {

    public Text textDistance;
    public Text textCoins;
    public Text textScore;    
    public GameObject[] player;
    public GameObject panelInGame;
    public GameObject gameController;
    public GameObject startGame;
    public GameObject shop;


    void OnEnable()
    {
        textDistance.text =""+ (int)PlayerController.distance+" m";
        textCoins.text = "" + PlayerController.coin;
        textScore.text = "" + PlayerController.score;       
    }

    public void ButRefresh()
    {
        AudioControll.instance.audioButton.Play();
        Instantiate(player [ WareHouse.maybaySelected - 1 ], player [ WareHouse.maybaySelected - 1 ].transform.position, player [ WareHouse.maybaySelected - 1 ].transform.rotation);
        panelInGame.SetActive(true);
        gameController.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ButHome()
    {
        AudioControll.instance.audioButton.Play();
        SceneManager.LoadScene(1);
    }

    public void ButShop()
    {
        AudioControll.instance.audioButton.Play();
        GameObject map = GameObject.FindGameObjectWithTag("Map");
        Destroy(map);
        startGame.SetActive(true);
        shop.SetActive(true);
        gameObject.SetActive(false);
    }
}
