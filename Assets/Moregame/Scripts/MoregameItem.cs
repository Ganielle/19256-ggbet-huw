using System;
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoregameItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    [Header("Game infor")]
    [SerializeField]
    private string _gameName;
    [SerializeField]
    private string _iconLink;
    [SerializeField]
    private string _gameLink;
    [Header("UI")]
    [SerializeField]
    private Image _view;
    [SerializeField]
    private Text _nameView;
    [SerializeField]
    private Text _loadingView;


    public MoregameController moreGameController;

    // Use this for initialization
    void Start()
    {
        _nameView.text = _gameName;
        StartCoroutine(RequestIcon());
    }

    public void SetMoregameItem(string gameName, string gameLink, string iconLink)
    {
        _gameName = gameName;
        _gameLink = gameLink;
        _iconLink = iconLink;
        _nameView.text = gameName;
    }
    private IEnumerator RequestIcon()
    {
        WWW www = new WWW(_iconLink);
        yield return www;
        if (www.error == null)
        {
            _view.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(.5f, 0.5f));
            _view.color = Color.white;
            transform.Find("Loading").gameObject.SetActive(false);
        }
        else
        {
            moreGameController._warning.SetActive(true);
            Destroy(gameObject);
        }
    }

    public void UpdateIconSize(Vector2 size, int fontSize)
    {
        _loadingView.fontSize = fontSize;
        _nameView.fontSize = fontSize;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _view.transform.localScale = new Vector3(1.05f, 1.05f, 1);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _view.transform.localScale = new Vector3(1, 1, 1);

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Application.OpenURL(_gameLink);
    }
}
