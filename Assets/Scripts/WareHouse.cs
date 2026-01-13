using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WareHouse : MonoBehaviour {

    public GameObject menu;
    public GameObject [ ] panelMayBay;
    public GameObject [ ] imageCheck;
    public Button [ ] butCheck;

    public static int maybaySelected=1;

    private bool existed;
    private string [ ] getPlayers;

    void OnEnable()
    {
        for(int i = 0; i < panelMayBay.Length; i++)
        {
            CheckPlayers((i + 2).ToString());
            if(existed)
            {
                panelMayBay [ i ].SetActive(false);
                butCheck [ i + 1 ].enabled = true;
            }
        }
        OffImageCheck(maybaySelected-1);
    }

    private void CheckPlayers(string maybay)
    {
        existed = false;
        getPlayers = PlayerPrefs.GetString(ClassConst.players).Split('@');
        for(int i = 0; i < getPlayers.Length; i++)
        {
            if(getPlayers [ i ] == maybay)
            {
                existed = true;
            }
        }
    }

    private void OffImageCheck(int number)
    {
        for(int i = 0; i < butCheck.Length; i++)
        {
            if(i != number)
            {
                if(butCheck [ i ].IsActive())
                    imageCheck[i].SetActive(false);
            }
            else
            {
                imageCheck[i].SetActive(true);
            }
        }
    }

    public void But1()
    {
        AudioControll.instance.audioButton.Play();
        OffImageCheck(0);
        maybaySelected = 1;
    }

    public void But2()
    {
        AudioControll.instance.audioButton.Play();
        OffImageCheck(1);
        maybaySelected = 2;
    }

    public void But3()
    {
        AudioControll.instance.audioButton.Play();
        OffImageCheck(2);
        maybaySelected = 3;
    }

    public void But4()
    {
        AudioControll.instance.audioButton.Play();
        OffImageCheck(3);
        maybaySelected = 4;
    }

    public void But5()
    {
        AudioControll.instance.audioButton.Play();
        OffImageCheck(4);
        maybaySelected = 5;
    }

   

    public void ButBack()
    {
        AudioControll.instance.audioButton.Play();
        menu.SetActive(true);
        gameObject.SetActive(false);
    }
}
