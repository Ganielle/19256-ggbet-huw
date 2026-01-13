using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Shop : MonoBehaviour {

    public GameObject menu;
    public Text textNoiDung;
    public Text textTien;
    public Text textTenVatPham;
    public Text textLvDan;
    public GameObject butBuy;
    public string [ ] getPlayers;
    public List<string> listPlayers;
    public string chuoiPlayer;
    public Text textCoin;
    public Sprite but;
    public Sprite butOn;
    public Image [ ] imageBut;
    public GameObject [ ] maps;
    public GameObject gameController;
    public GameObject panelInGame;
    public GameObject[] player;

    private int lvDan;
    private int button;
    private bool existed;

    void Start()
    {
        textCoin.text = PlayerPrefs.GetInt(ClassConst.sumCoin).ToString();
        if(!PlayerPrefs.HasKey(ClassConst.levelDan))
        {
            textLvDan.text = "Lv.1";
            lvDan = 1;
            PlayerPrefs.SetInt(ClassConst.levelDan, 1);
        }
        if(PlayerPrefs.HasKey(ClassConst.levelDan))           
        {
            switch(PlayerPrefs.GetInt(ClassConst.levelDan))
            {
                case 1:                
                lvDan = 1;
                textLvDan.text = "Lv.1";               
                break;
                case 2:
                lvDan = 2;
                textLvDan.text = "Lv.2";                
                break;
                case 3:
                lvDan = 3;
                textLvDan.text = "Lv.3";                
                break;
                case 4:
                lvDan = 4;
                textLvDan.text = "Lv.4";               
                break;
                case 5:
                lvDan = 5;
                textLvDan.text = "Lv.5";                
                break;
                case 6:
                lvDan = 6;
                textLvDan.text = "Lv.6";               
                break;
                case 7:
                lvDan = 7;
                textLvDan.text = "Lv.7";              
                break;
                case 8:
                lvDan = 8;
                textLvDan.text = "Lv.8";                
                break;
                case 9:
                lvDan = 9;
                textLvDan.text = "Lv.9";
                break;
            }
        }
    }

    private void ControllButton()
    {
        switch(button)
        {
            case 1:
            imageBut [ 0 ].sprite = but;
            break;
            case 2:
            imageBut [ 1 ].sprite = but;
            break;
            case 3:
            imageBut [ 2 ].sprite = but;
            break;
            case 4:
            imageBut [ 3 ].sprite = but;
            break;
            case 5:
            imageBut [ 4 ].sprite = but;
            break;
            case 6:
            imageBut [ 5 ].sprite = but;
            break;
            case 7:
            imageBut [ 6 ].sprite = but;
            break;
            case 8:
            imageBut [ 7 ].sprite = but;
            break;
            case 9:
            imageBut [ 8 ].sprite = but;
            break;
        }
    }

    private void StartPlayers()
    {
        listPlayers.Add("1@");
        for(int i = 0; i < listPlayers.Count; i++)
        {
            chuoiPlayer += listPlayers [ i ];
        }
        PlayerPrefs.SetString(ClassConst.players, chuoiPlayer);
    }

    private void SetPlayers()
    {
        getPlayers = PlayerPrefs.GetString(ClassConst.players).Split('@');
        for(int i = 0; i < getPlayers.Length; i++)
        {
            listPlayers.Add(getPlayers [ i ] + "@");
        }
        for(int j = 0; j < listPlayers.Count; j++)
        {
            chuoiPlayer += listPlayers [ j ];
        }
        PlayerPrefs.SetString(ClassConst.players, chuoiPlayer);
    }

    private void CheckPlayers(string maybay)
    {
        existed = false;
        getPlayers = PlayerPrefs.GetString(ClassConst.players).Split('@');
        for(int i = 0; i < getPlayers.Length; i++)
        {
            if(getPlayers [ i ] == maybay)
            {
                existed=true;
            }
        }
    }

    public void ButRePlay()
    {
        AudioControll.instance.audioButton.Play();
        int map = Random.Range(0, maps.Length);
        Instantiate(maps [ map ], maps [ map ].transform.position, maps [ map ].transform.rotation);
        Instantiate(player [ WareHouse.maybaySelected - 1 ], player [ WareHouse.maybaySelected - 1 ].transform.position, player [ WareHouse.maybaySelected - 1 ].transform.rotation);
        gameController.SetActive(true);
        panelInGame.SetActive(true);
        GameObject startGame = GameObject.Find("StartGame");
        startGame.SetActive(false);
    }

    public void ButBack()
    {
        AudioControll.instance.audioButton.Play();
        menu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void But1()
    {
        AudioControll.instance.audioButton.Play();
        textTenVatPham.text = "Equipment";
        textTien.text = "";
        textNoiDung.text = "Longest Distance:\t" + PlayerPrefs.GetInt(ClassConst.longestDistance) + "\nHighest Score:\t" + PlayerPrefs.GetInt(ClassConst.highestScore) + "\nMax Coin:\t" + PlayerPrefs.GetInt(ClassConst.maxCoin);
        ControllButton();
        imageBut [ 0 ].sprite = butOn;
        button = 1;
    }

    public void But2()
    {
        AudioControll.instance.audioButton.Play();
        ControllButton();
        imageBut [ 1 ].sprite = butOn;
        button = 2;
        switch(lvDan)
        {
            case 1:           
            lvDan = 2;
            textLvDan.text = "Lv.1";
            textTien.text = "0";
            textTenVatPham.text = "Đạn Lv.1";
            textNoiDung.text = "Đạn của bạn có mức sát thương là 20";
            break;
            case 2:
            if(PlayerPrefs.GetInt(ClassConst.levelDan) < 2)
            {
                butBuy.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                butBuy.GetComponent<Button>().enabled = true;
            }
            else
            {
                butBuy.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);
                butBuy.GetComponent<Button>().enabled = false;
            }
            lvDan = 3;
            textLvDan.text = "Lv.2";
            textTien.text = "50";
            textTenVatPham.text = "Đạn Lv.2";
            textNoiDung.text = "Nâng cấp đạn lên mức sát thương là 50";
            break;
            case 3:
            if(PlayerPrefs.GetInt(ClassConst.levelDan) < 3)
            {
                butBuy.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                butBuy.GetComponent<Button>().enabled = true;
            }
            else
            {
                butBuy.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);
                butBuy.GetComponent<Button>().enabled = false;
            }
            lvDan = 4;
            textLvDan.text = "Lv.3";
            textTien.text = "100";
            textTenVatPham.text = "Đạn Lv.3";
            textNoiDung.text = "Nâng cấp đạn lên mức sát thương là 80";
            break;
            case 4:
            if(PlayerPrefs.GetInt(ClassConst.levelDan) < 4)
            {
                butBuy.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                butBuy.GetComponent<Button>().enabled = true;
            }
            else
            {
                butBuy.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);
                butBuy.GetComponent<Button>().enabled = false;
            }
            lvDan = 5;
            textLvDan.text = "Lv.4";
            textTien.text = "150";
            textTenVatPham.text = "Đạn Lv.4";
            textNoiDung.text = "Nâng cấp đạn lên mức sát thương là 120";
            break;
            case 5:
            if(PlayerPrefs.GetInt(ClassConst.levelDan) < 5)
            {
                butBuy.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                butBuy.GetComponent<Button>().enabled = true;
            }
            else
            {
                butBuy.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);
                butBuy.GetComponent<Button>().enabled = false;
            }
            lvDan = 6;
            textLvDan.text = "Lv.5";
            textTien.text = "200";
            textTenVatPham.text = "Đạn Lv.5";
            textNoiDung.text = "Nâng cấp đạn lên mức sát thương là 150";
            break;
            case 6:
            if(PlayerPrefs.GetInt(ClassConst.levelDan) < 6)
            {
                butBuy.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                butBuy.GetComponent<Button>().enabled = true;
            }
            else
            {
                butBuy.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);
                butBuy.GetComponent<Button>().enabled = false;
            }
            lvDan = 7;
            textLvDan.text = "Lv.6";
            textTien.text = "250";
            textTenVatPham.text = "Đạn Lv.6";
            textNoiDung.text = "Nâng cấp đạn lên mức sát thương là 180";
            break;
            case 7:
            lvDan = 8;
            if(PlayerPrefs.GetInt(ClassConst.levelDan) < 7)
            {
                butBuy.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                butBuy.GetComponent<Button>().enabled = true;
            }
            else
            {
                butBuy.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);
                butBuy.GetComponent<Button>().enabled = false;
            }
            textLvDan.text = "Lv.7";
            textTien.text = "300";
            textTenVatPham.text = "Đạn Lv.7";
            textNoiDung.text = "Nâng cấp đạn lên mức sát thương là 220";
            break;
            case 8:
            if(PlayerPrefs.GetInt(ClassConst.levelDan) < 8)
            {
                butBuy.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                butBuy.GetComponent<Button>().enabled = true;
            }
            else
            {
                butBuy.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);
                butBuy.GetComponent<Button>().enabled = false;
            }
            lvDan = 9;
            textLvDan.text = "Lv.8";
            textTien.text = "350";
            textTenVatPham.text = "Đạn Lv.8";
            textNoiDung.text = "Nâng cấp đạn lên mức sát thương là 250";
            break;
            case 9:
            if(PlayerPrefs.GetInt(ClassConst.levelDan) < 9)
            {
                butBuy.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                butBuy.GetComponent<Button>().enabled = true;
            }
            else
            {
                butBuy.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);
                butBuy.GetComponent<Button>().enabled = false;
            }
            lvDan = 10;
            textLvDan.text = "Lv.9";
            textTien.text = "400";
            textTenVatPham.text = "Đạn Lv.9";
            textNoiDung.text = "Nâng cấp đạn lên mức sát thương là 280";
            break;
            case 10:
            butBuy.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);
            butBuy.GetComponent<Button>().enabled = false;
            lvDan = 2;
            textLvDan.text = "Lv.1";
            textTien.text = "0";
            textTenVatPham.text = "Đạn Lv.1";
            textNoiDung.text = "Đạn của bạn có mức sát thương là 20";
            break;
        }
    }

    public void But3()
    {
        AudioControll.instance.audioButton.Play();
        ControllButton();
        imageBut [ 2 ].sprite = butOn;
        button = 3;
        textTenVatPham.text = "Máy Bay 2";
        textTien.text = "500";
        textNoiDung.text = "Nâng cấp máy bay lên mức 2";
        CheckPlayers("2");
        if(existed)
        {
            butBuy.GetComponent<Button>().enabled = false;
            butBuy.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1f);
        }
        else
        {
            butBuy.GetComponent<Button>().enabled = true;
            butBuy.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        }
    }

    public void But4()
    {
        AudioControll.instance.audioButton.Play();
        ControllButton();
        imageBut [ 3 ].sprite = butOn;
        button = 4;
        textTenVatPham.text = "Máy Bay 3";
        textTien.text = "1000";
        textNoiDung.text = "Nâng cấp máy bay lên mức 3";
        CheckPlayers("3");
        if(existed)
        {
            butBuy.GetComponent<Button>().enabled = false;
            butBuy.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1f);
        }
        else
        {
            butBuy.GetComponent<Button>().enabled = true;
            butBuy.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        }
    }

    public void But5()
    {
        AudioControll.instance.audioButton.Play();
        ControllButton();
        imageBut [ 4 ].sprite = butOn;
        button = 5;
        textTenVatPham.text = "Máy Bay 4";
        textTien.text = "1500";
        textNoiDung.text = "Nâng cấp máy bay lên mức 4";
        CheckPlayers("4");
        if(existed)
        {
            butBuy.GetComponent<Button>().enabled = false;
            butBuy.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1f);
        }
        else
        {
            butBuy.GetComponent<Button>().enabled = true;
            butBuy.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        }
    }

    public void But6()
    {
        AudioControll.instance.audioButton.Play();
        ControllButton();
        imageBut [ 5 ].sprite = butOn;
        button = 6;
        textTenVatPham.text = "Máy Bay 5";
        textTien.text = "2000";
        textNoiDung.text = "Nâng cấp máy bay lên mức 5";
        CheckPlayers("5");
        if(existed)
        {
            butBuy.GetComponent<Button>().enabled = false;
            butBuy.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1f);
        }
        else
        {
            butBuy.GetComponent<Button>().enabled = true;
            butBuy.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        }
    }

    public void But7()
    {
        AudioControll.instance.audioButton.Play();
        ControllButton();
        imageBut [ 6 ].sprite = butOn;
        button = 7;
        butBuy.GetComponent<Button>().enabled = true;
        butBuy.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        textTenVatPham.text = "Khiên Thần Tốc";
        textTien.text = "500";
        textNoiDung.text = "Khiên thần tốc, giúp bạn vượt qua 3000m nhanh chóng";        
    }

    public void But8()
    {
        AudioControll.instance.audioButton.Play();
        ControllButton();
        imageBut [ 7 ].sprite = butOn;
        button = 8;
        butBuy.GetComponent<Button>().enabled = true;
        butBuy.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        textTenVatPham.text = "Boom Hủy Diệt";
        textTien.text = "400";
        textNoiDung.text = "Giúp bạn tiêu diệt toàn bộ kẻ thù đang xuất hiện";
    }

    public void But9()
    {
        AudioControll.instance.audioButton.Play();
        ControllButton();
        imageBut [ 8 ].sprite = butOn;
        button = 9;
        butBuy.GetComponent<Button>().enabled = true;
        butBuy.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        textTenVatPham.text = "Hỗ trợ đạn";
        textTien.text = "300";
        textNoiDung.text = "Gấp đôi luồng đạn";
    }

    public void ButBuy()
    {
        AudioControll.instance.audioButton.Play();
        switch(button)
        {
            case 2:
            // Do something  with bullet
            int sumCoin = PlayerPrefs.GetInt(ClassConst.sumCoin);
            switch(lvDan)
            {                
                case 3:
                if(sumCoin > 50)
                {
                    PlayerPrefs.SetInt(ClassConst.levelDan, 2);
                            PlayerPrefs.SetInt(ClassConst.sumCoin, sumCoin - 50);
                            PlayerPrefs.GetInt(ClassConst.sumCoin, sumCoin - 50);
                    textCoin.text = PlayerPrefs.GetInt(ClassConst.sumCoin).ToString();
                    butBuy.GetComponent<Button>().enabled = false;
                    butBuy.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);
                    textNoiDung.text = "Mua Thành Công, Đạn của bạn nâng cấp lên level 2 với mức sát thương là 50";
                }
                else
                {
                    textNoiDung.text = "Bạn không đủ tiền để mua nó, hãy chịu khó kiếm tiền";
                }
                break;
                case 4:
                if(sumCoin > 100)
                {
                    PlayerPrefs.SetInt(ClassConst.levelDan, 3);
                            PlayerPrefs.SetInt(ClassConst.sumCoin, sumCoin - 100);
                            PlayerPrefs.GetInt(ClassConst.sumCoin, sumCoin - 100);
                    textCoin.text = PlayerPrefs.GetInt(ClassConst.sumCoin).ToString();
                    butBuy.GetComponent<Button>().enabled = false;
                    butBuy.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);
                    textNoiDung.text = "Mua Thành Công, Đạn của bạn nâng cấp lên level 3 với mức sát thương là 800";
                }
                else
                {
                    textNoiDung.text = "Bạn không đủ tiền để mua nó, hãy chịu khó kiếm tiền";
                }
                break;
                case 5:
                if(sumCoin > 150)
                {
                    PlayerPrefs.SetInt(ClassConst.levelDan, 4);
                            PlayerPrefs.SetInt(ClassConst.sumCoin, sumCoin - 150);
                            PlayerPrefs.GetInt(ClassConst.sumCoin, sumCoin - 150);
                    textCoin.text = PlayerPrefs.GetInt(ClassConst.sumCoin).ToString();
                    butBuy.GetComponent<Button>().enabled = false;
                    butBuy.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);
                    textNoiDung.text = "Mua Thành Công, Đạn của bạn nâng cấp lên level 4 với mức sát thương là 120";
                }
                else
                {
                    textNoiDung.text = "Bạn không đủ tiền để mua nó, hãy chịu khó kiếm tiền";
                }
                break;
                case 6:
                if(sumCoin > 200)
                {
                    PlayerPrefs.SetInt(ClassConst.levelDan, 5);
                            PlayerPrefs.SetInt(ClassConst.sumCoin, sumCoin - 200);
                            PlayerPrefs.GetInt(ClassConst.sumCoin, sumCoin - 200);
                    textCoin.text = PlayerPrefs.GetInt(ClassConst.sumCoin).ToString();
                    butBuy.GetComponent<Button>().enabled = false;
                    butBuy.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);
                    textNoiDung.text = "Mua Thành Công, Đạn của bạn nâng cấp lên level 5 với mức sát thương là 150";
                }
                else
                {
                    textNoiDung.text = "Bạn không đủ tiền để mua nó, hãy chịu khó kiếm tiền";
                }
                break;
                case 7:
                if(sumCoin > 250)
                {
                    PlayerPrefs.SetInt(ClassConst.levelDan, 6);
                            PlayerPrefs.SetInt(ClassConst.sumCoin, sumCoin - 250);
                            PlayerPrefs.GetInt(ClassConst.sumCoin, sumCoin - 250);
                    textCoin.text = PlayerPrefs.GetInt(ClassConst.sumCoin).ToString();
                    butBuy.GetComponent<Button>().enabled = false;
                    butBuy.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);
                    textNoiDung.text = "Mua Thành Công, Đạn của bạn nâng cấp lên level 6 với mức sát thương là 180";
                }
                else
                {
                    textNoiDung.text = "Bạn không đủ tiền để mua nó, hãy chịu khó kiếm tiền";
                }
                break;
                case 8:
                if(sumCoin > 300)
                {
                    PlayerPrefs.SetInt(ClassConst.levelDan, 7);
                            PlayerPrefs.SetInt(ClassConst.sumCoin, sumCoin - 300);
                            PlayerPrefs.GetInt(ClassConst.sumCoin, sumCoin - 300);
                    textCoin.text = PlayerPrefs.GetInt(ClassConst.sumCoin).ToString();
                    butBuy.GetComponent<Button>().enabled = false;
                    butBuy.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);
                    textNoiDung.text = "Mua Thành Công, Đạn của bạn nâng cấp lên level 7 với mức sát thương là 220";
                }
                else
                {
                    textNoiDung.text = "Bạn không đủ tiền để mua nó, hãy chịu khó kiếm tiền";
                }
                break;
                case 9:
                if(sumCoin > 350)
                {
                    PlayerPrefs.SetInt(ClassConst.levelDan, 8);
                            PlayerPrefs.SetInt(ClassConst.sumCoin, sumCoin - 350);
                            PlayerPrefs.GetInt(ClassConst.sumCoin, sumCoin - 350);
                    textCoin.text = PlayerPrefs.GetInt(ClassConst.sumCoin).ToString();
                    butBuy.GetComponent<Button>().enabled = false;
                    butBuy.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);
                    textNoiDung.text = "Mua Thành Công, Đạn của bạn nâng cấp lên level 8 với mức sát thương là 250";
                }
                else
                {
                    textNoiDung.text = "Bạn không đủ tiền để mua nó, hãy chịu khó kiếm tiền";
                }
                break;
                case 10:
                if(sumCoin > 400)
                {
                    PlayerPrefs.SetInt(ClassConst.levelDan, 9);
                            PlayerPrefs.SetInt(ClassConst.sumCoin, sumCoin - 400);
                            PlayerPrefs.GetInt(ClassConst.sumCoin, sumCoin - 400);
                    textCoin.text = PlayerPrefs.GetInt(ClassConst.sumCoin).ToString();
                    butBuy.GetComponent<Button>().enabled = false;
                    butBuy.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);
                    textNoiDung.text = "Mua Thành Công, Đạn của bạn nâng cấp lên level 9 với mức sát thương là 280";
                }
                else
                {
                    textNoiDung.text = "Bạn không đủ tiền để mua nó, hãy chịu khó kiếm tiền";
                }
                break;
            }
            break;
            case 3:
            // Buy may bay 2 gia la 500 coin
            if(PlayerPrefs.GetInt(ClassConst.sumCoin) > 500)
            {
                listPlayers.Clear();
                listPlayers.Add("2@");
                PlayerPrefs.SetInt(ClassConst.sumCoin, PlayerPrefs.GetInt(ClassConst.sumCoin) - 500);
                textCoin.text = PlayerPrefs.GetInt(ClassConst.sumCoin).ToString();
                butBuy.GetComponent<Button>().enabled = false;
                butBuy.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);
                if(!PlayerPrefs.HasKey(ClassConst.players))
                {
                    StartPlayers();
                }
                else
                {
                    SetPlayers();
                }
                textNoiDung.text = "Mua Thành Công, Máy Bay 2 đã thuộc quyền sở hữu của bạn";
            }
            else
            {
                textNoiDung.text = "Bạn không đủ tiền để mua nó, hãy chịu khó kiếm tiền";
            }
            
            break;
            case 4:
            // Buy may bay 3 gia la 1000 coin
            if(PlayerPrefs.GetInt(ClassConst.sumCoin) > 1000)
            {
                listPlayers.Clear();
                listPlayers.Add("3@");
                PlayerPrefs.SetInt(ClassConst.sumCoin, PlayerPrefs.GetInt(ClassConst.sumCoin) - 1000);
                textCoin.text = PlayerPrefs.GetInt(ClassConst.sumCoin).ToString();
                butBuy.GetComponent<Button>().enabled = false;
                butBuy.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);
                if(!PlayerPrefs.HasKey(ClassConst.players))
                {
                    StartPlayers();
                }
                else
                {
                    SetPlayers();
                }
                textNoiDung.text = "Mua Thành Công, Máy Bay 3 đã thuộc quyền sở hữu của bạn";
            }
            else
            {
                textNoiDung.text = "Bạn không đủ tiền để mua nó, hãy chịu khó kiếm tiền";
            }
            break;
            case 5:
            // Buy may bay 4 gia la 1500 coin
            if(PlayerPrefs.GetInt(ClassConst.sumCoin) > 1500)
            {
                listPlayers.Clear();
                listPlayers.Add("4@");
                PlayerPrefs.SetInt(ClassConst.sumCoin, PlayerPrefs.GetInt(ClassConst.sumCoin) - 1500);
                textCoin.text = PlayerPrefs.GetInt(ClassConst.sumCoin).ToString();
                butBuy.GetComponent<Button>().enabled = false;
                butBuy.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);
                if(!PlayerPrefs.HasKey(ClassConst.players))
                {
                    StartPlayers();
                }
                else
                {
                    SetPlayers();
                }
                textNoiDung.text = "Mua Thành Công, Máy Bay 4 đã thuộc quyền sở hữu của bạn";
            }
            else
            {
                textNoiDung.text = "Bạn không đủ tiền để mua nó, hãy chịu khó kiếm tiền";
            }
            break;
            case 6:
            // Buy may bay 5 gia la 2000 coin
            if(PlayerPrefs.GetInt(ClassConst.sumCoin) > 2000)
            {
                listPlayers.Clear();
                listPlayers.Add("5@");
                PlayerPrefs.SetInt(ClassConst.sumCoin, PlayerPrefs.GetInt(ClassConst.sumCoin) - 2000);
                textCoin.text = PlayerPrefs.GetInt(ClassConst.sumCoin).ToString();
                butBuy.GetComponent<Button>().enabled = false;
                butBuy.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);
                if(!PlayerPrefs.HasKey(ClassConst.players))
                {
                    StartPlayers();
                }
                else
                {
                    SetPlayers();
                }
                textNoiDung.text = "Mua Thành Công, Máy Bay 5 đã thuộc quyền sở hữu của bạn";
            }
            else
            {
                textNoiDung.text = "Bạn không đủ tiền để mua nó, hãy chịu khó kiếm tiền";
            }
            break;
            case 7:
            // Buy giap than toc gia la 500 coin
            if(PlayerPrefs.GetInt(ClassConst.sumCoin) >= 500)
            {
                PlayerPrefs.SetInt(ClassConst.sumCoin, PlayerPrefs.GetInt(ClassConst.sumCoin) - 500);
                textCoin.text = PlayerPrefs.GetInt(ClassConst.sumCoin).ToString();
                PlayerPrefs.SetInt(ClassConst.giap, PlayerPrefs.GetInt(ClassConst.giap) + 1);
                textNoiDung.text = "Mua Thành Công, Số Giáp thần tốc của bạn hiện tại là " + PlayerPrefs.GetInt(ClassConst.giap);
            }
            else
            {
                textNoiDung.text = "Bạn không đủ tiền để mua nó, hãy chịu khó kiếm tiền";
            }            
            break;
            case 8:
            //Buy boom huy diet gia la 400 coin
            if(PlayerPrefs.GetInt(ClassConst.sumCoin) >= 400)
            {
                PlayerPrefs.SetInt(ClassConst.sumCoin, PlayerPrefs.GetInt(ClassConst.sumCoin) - 400);
                textCoin.text = PlayerPrefs.GetInt(ClassConst.sumCoin).ToString();
                PlayerPrefs.SetInt(ClassConst.bom, PlayerPrefs.GetInt(ClassConst.bom) + 1);
                textNoiDung.text = "Mua Thành Công, Số Boom của bạn hiện tại là " + PlayerPrefs.GetInt(ClassConst.bom);
            }
            else
            {
                textNoiDung.text = "Bạn không đủ tiền để mua nó, hãy chịu khó kiếm tiền";
            }
            break;
            case 9:
            //Buy ho tro dan gia la 300 coin
            if(PlayerPrefs.GetInt(ClassConst.sumCoin) >= 300)
            {
                PlayerPrefs.SetInt(ClassConst.sumCoin, PlayerPrefs.GetInt(ClassConst.sumCoin) - 300);
                textCoin.text = PlayerPrefs.GetInt(ClassConst.sumCoin).ToString();
                PlayerPrefs.SetInt(ClassConst.pow, PlayerPrefs.GetInt(ClassConst.pow) + 1);
                textNoiDung.text = "Mua Thành Công, Số Pow của bạn hiện tại là " + PlayerPrefs.GetInt(ClassConst.pow);
            }
            else
            {
                textNoiDung.text = "Bạn không đủ tiền để mua nó, hãy chịu khó kiếm tiền";
            }
            break;
        }
    }
}
