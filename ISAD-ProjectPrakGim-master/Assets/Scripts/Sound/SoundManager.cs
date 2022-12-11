using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }   

        else 
        {
            Load();
        }

        UpdateButtonIcon();
        AudioListener.pause = muted;
    }

    // MUSIC
    [SerializeField] Image musicOnIcon;
    [SerializeField] Image musicOffIcon;
    private bool muted = false;

    // mute & unmute state
    public void OnButtonPress()
    {
        if(muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }

        else 
        {
            muted = false;
            AudioListener.pause = false;
        }

        Save();
        UpdateButtonIcon();
    }

    // Switch music button state
    public void UpdateButtonIcon()
    {
        if(muted == false)
        {
            musicOnIcon.enabled = true;
            musicOffIcon.enabled = false;
        }

        else 
        {
            musicOnIcon.enabled = false;
            musicOffIcon.enabled = true;
        }

        Save();
    }

    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }
    
    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
}
