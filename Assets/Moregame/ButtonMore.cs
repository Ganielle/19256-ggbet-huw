using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonMore : MonoBehaviour
{
    public GameObject music;
    // Use this for initialization
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(MoreClick);
    }

    // Update is called once per frame
    void MoreClick()
    {
        AudioControll.instance.audioButton.Play();
        music.SetActive(false);
        MoregameController.Instance.gameObject.SetActive(true);
        //Application.LoadLevel("MoreGameScene");
    }
}
