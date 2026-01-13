using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine.UI;

public enum Platform
{
    Auto,
    WindowsPhone,
    Android,
    IOS,
}
public class MoregameController : MonoBehaviour
{
    public static MoregameController Instance;
    public GameObject Canvas;
    public GameObject MoregameItem;
    [Header("Moregame Id")]
    public string winphoneId; // Id moregame windows phone
    public string androidId; // Id moregame android
    public string iOSId; // Id moregame ios 

    [Header("Requset link")]
    public string requestLink;
    public Platform platform;

    [Header("UI")]
    [SerializeField]
    public Transform grid;
    [SerializeField]
    private Text title;
    [SerializeField]
    private ScrollRect scroll;

    [SerializeField]
    public GameObject _warning;

    [SerializeField]
    private bool isHorizontal;
    [SerializeField]
    private RectTransform rectButton;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            gameObject.SetActive(false);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {

        isHorizontal = Screen.width <= Screen.height;
        if (Screen.width > Screen.height)
        {
            MoregameItem item = MoregameItem.GetComponent<MoregameItem>();
            item.UpdateIconSize(Vector2.zero, 18);
        }
        else
        {
            MoregameItem item = MoregameItem.GetComponent<MoregameItem>();
            item.UpdateIconSize(Vector2.zero, 28);
        }
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            Update();
            grid.gameObject.SetActive(false);
            Load();
        }
        else
        {

        }
    }

    public void Load()
    {
        _warning.SetActive(false);
        while (grid.childCount > 0)
        {
            Transform child = grid.GetChild(0);
            child.SetParent(null);
            Destroy(child.gameObject);
        }
        CreateRequestLink();
        StartCoroutine(Request());
    }

    void CreateRequestLink()
    {
        if (platform == Platform.Auto)
        {
            switch (Application.platform)
            {
                case RuntimePlatform.Android:
                    platform = Platform.Android;
                    break;
                case RuntimePlatform.IPhonePlayer:
                    platform = Platform.IOS;
                    break;
                case RuntimePlatform.WP8Player:
                    platform = Platform.WindowsPhone;
                    break;
            }
        }

        if (platform == Platform.Android)
            requestLink = "http://xplay.vn:8088/tvs/ads?w=480&h=800&prf=android&pid=" + androidId + "&l=1";
        else if (platform == Platform.IOS)
            requestLink = "http://210.211.124.104:8088/tvs/ads?prf=iphone&pid=" + iOSId + "&l=1";
        else if (platform == Platform.WindowsPhone)
            requestLink = "http://210.211.124.104:8088/tvs/ads?w=480&h=800&prf=window&pid=" + winphoneId + "&l=1";
    }

    IEnumerator Request()
    {
        string data = "";
        var headers = new Dictionary<string, string> { { "User-Agent", "Roblox/WinInet" } };
        var www = new WWW(requestLink, null, headers);
        yield return www;
        if (www.error != null)
        {
            data = PlayerPrefs.GetString("moregame", "");
            _warning.SetActive(true);
        }
        else
        {
            data = www.text;
        }
        View(data);
    }

    void View(string data)
    {
        if (data == "")
            return;
        PlayerPrefs.SetString("moregame", data);
        grid.gameObject.SetActive(true);
        XmlDocument xDoc = new XmlDocument();
        xDoc.LoadXml(data);
        XmlNodeList listGames = xDoc.DocumentElement.SelectNodes("Game");
        int numOfMoregame = listGames.Count;
        if (numOfMoregame > 0)
        {
            for (int i = 0; i < numOfMoregame; i++)
            {
                GameObject moregameItem = Instantiate(MoregameItem);
                moregameItem.transform.SetParent(grid);
                moregameItem.transform.position = Vector2.zero;
                moregameItem.transform.localScale = new Vector3(1, 1, 1);
                MoregameItem moregameItemScript = MoregameItem.GetComponent<MoregameItem>();
                moregameItemScript.moreGameController = this;
                string gameLink = listGames[i].SelectSingleNode("Link").InnerText;
                switch (platform)
                {
                    case Platform.Android:
                        gameLink = "https://play.google.com/store/apps" + gameLink.Replace("market:/", "");
                        break;
                    case Platform.IOS:
                        gameLink = gameLink;
                        break;
                    case Platform.WindowsPhone:
                        gameLink = "http://www.windowsphone.com/s?appid=" + gameLink.Replace("mid:", "");
                        break;
                }
                moregameItemScript.SetMoregameItem(
                    listGames[i].SelectSingleNode("Name").InnerText,
                    gameLink,
                    listGames[i].SelectSingleNode("Image").InnerText);
            }
        }
    }

    void Update()
    {
        if (Screen.width > Screen.height)
        {
            if (!isHorizontal)
            {
                isHorizontal = true;
                GridLayoutGroup glg = grid.GetComponent<GridLayoutGroup>();
                glg.constraint = GridLayoutGroup.Constraint.FixedRowCount;
                glg.childAlignment = TextAnchor.MiddleLeft;
                glg.cellSize = new Vector2(300, 150);
                RectTransform rect = glg.GetComponent<RectTransform>();
                rect.anchorMin = new Vector2(0, .5f);
                rect.anchorMax = new Vector2(0, .5f);
                rect.pivot = new Vector2(0, .5f);
                rect.anchoredPosition = new Vector2(0, 0);
                scroll.horizontal = true;
                scroll.vertical = false;
                title.fontSize = 50;
                rectButton.sizeDelta = new Vector2(50, 50);
                foreach (Transform child in grid)
                    child.GetComponent<MoregameItem>().UpdateIconSize(glg.cellSize, 18);
                _warning.transform.localScale = new Vector3(1, 1, 1);
            }
        }
        else
        {
            if (isHorizontal)
            {
                isHorizontal = false;
                GridLayoutGroup glg = grid.GetComponent<GridLayoutGroup>();
                glg.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
                glg.childAlignment = TextAnchor.UpperCenter;
                glg.cellSize = new Vector2(500, 250);
                RectTransform rect = glg.GetComponent<RectTransform>();
                rect.anchorMin = new Vector2(.5f, 1);
                rect.anchorMax = new Vector2(.5f, 1);
                rect.pivot = new Vector2(.5f, 1);
                rect.anchoredPosition = new Vector2(0, 0);
                scroll.horizontal = false;
                scroll.vertical = true;
                title.fontSize = 90;
                rectButton.sizeDelta = new Vector2(90, 90);
                foreach (Transform child in grid)
                    child.GetComponent<MoregameItem>().UpdateIconSize(glg.cellSize, 28);
                _warning.transform.localScale = new Vector3(2, 2, 1);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
            Quit();
    }

    public void Quit()
    {
        //Application.Quit();
        gameObject.SetActive(false);
        //SceneManager.LoadScene(0);
    }
}
