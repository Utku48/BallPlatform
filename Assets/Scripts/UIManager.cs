using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{


    public Image whiteeffectimage;
    private int effectControl = 0;
    public Animator LayoutAnimator;

    //Butonlar
    public GameObject settingsOpen;
    public GameObject settingClose;


    public GameObject SoundOn;
    public GameObject SoundOff;



    public void Start()
    {
        if (PlayerPrefs.HasKey("Sound") == false)//Sound Adında bir değişken var mı kontrol et. Eğer yoksa
        {
            PlayerPrefs.SetInt("Sound", 1); //Bu değişkene 1 ataması yap
        }


    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OnClick_soundOn()
    {
        SoundOn.SetActive(false);
        SoundOff.SetActive(true);
        AudioListener.volume = 0;
        PlayerPrefs.SetInt("Sound", 2);
    }

    public void OnClick_soundOff()
    {
        SoundOn.SetActive(true);
        SoundOff.SetActive(false);
        AudioListener.volume = 1;
        PlayerPrefs.SetInt("Sound", 1);
    }
    //Button Fonskiyonları


    public void Setting_Open()
    {
        settingsOpen.SetActive(false);
        settingClose.SetActive(true);
        LayoutAnimator.SetTrigger("Slide_down");



        if (PlayerPrefs.GetInt("Sound") == 1)
        {
            SoundOn.SetActive(true);
            SoundOff.SetActive(false);
            AudioListener.volume = 1;
        }
        else if (PlayerPrefs.GetInt("Sound") == 2)
        {
            SoundOn.SetActive(false);
            SoundOff.SetActive(true);
            AudioListener.volume = 0;
        }
    }

    public void Setting_Close()
    {
        settingsOpen.SetActive(true);
        settingClose.SetActive(false);
        LayoutAnimator.SetTrigger("Slide_up");
    }

















    public IEnumerator WhiteEffect()
    {
        whiteeffectimage.gameObject.SetActive(true);
        while (effectControl == 0)
        {
            yield return new WaitForSeconds(0.01f);
            whiteeffectimage.color += new Color(0, 0, 0, 0.25f);
            if (whiteeffectimage.color == new Color(whiteeffectimage.color.r, whiteeffectimage.color.g, whiteeffectimage.color.b, 1))
            {
                effectControl = 1;
            }
        }
        while (effectControl == 1)
        {
            yield return new WaitForSeconds(0.025f);
            whiteeffectimage.color -= new Color(0, 0, 0, 0.1f);
            if (whiteeffectimage.color == new Color(whiteeffectimage.color.r, whiteeffectimage.color.g, whiteeffectimage.color.b, 0))
            {
                effectControl = 2;
            }
        }


    }
}
