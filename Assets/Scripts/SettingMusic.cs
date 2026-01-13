using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingMusic : MonoBehaviour {

    public Image butOnMusic;
    public Image butOffMusic;
    public Image butOnSfx;
    public Image butOffSfx;
    public Sprite onSang;
    public Sprite onToi;
    public Sprite offSang;
    public Sprite offToi;

    void Start()
    {
        if(AudioControll.music)
        {
            butOnMusic.sprite = onSang;
            butOffMusic.sprite = offToi;
        }
        else
        {
            butOnMusic.sprite = onToi;
            butOffMusic.sprite = offSang;
        }

        if(AudioControll.sfx)
        {
            butOnSfx.sprite = onSang;
            butOffSfx.sprite = offToi;
        }
        else
        {
            butOnSfx.sprite = onToi;
            butOffSfx.sprite = offSang;
        }
    }

    public void ButOnMusic()
    {
        AudioControll.instance.audioButton.Play();
        AudioControll.instance.audioStart.volume = 1;
        AudioControll.instance.audioIngame.volume = 1;
        AudioControll.music = true;
        butOnMusic.sprite=onSang;
        butOffMusic.sprite = offToi;
    }

    public void ButOffMusic()
    {
        AudioControll.instance.audioButton.Play();
        AudioControll.instance.audioStart.volume = 0;
        AudioControll.instance.audioIngame.volume = 0;
        AudioControll.music = false;
        butOnMusic.sprite = onToi;
        butOffMusic.sprite = offSang;
    }

    public void ButOnSfx()
    {
        AudioControll.instance.audioButton.Play();
        AudioControll.instance.audioBom.volume = 1;
        AudioControll.instance.audioButton.volume = 1;
        AudioControll.sfx = true;
        butOnSfx.sprite = onSang;
        butOffSfx.sprite = offToi;
    }

    public void ButOffSfx()
    {
        AudioControll.instance.audioButton.Play();
        AudioControll.instance.audioBom.volume = 0;
        AudioControll.instance.audioButton.volume = 0;
        AudioControll.sfx = false;
        butOnSfx.sprite = onToi;
        butOffSfx.sprite = offSang;
    }
}
