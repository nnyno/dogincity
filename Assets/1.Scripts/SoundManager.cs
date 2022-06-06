using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class Sound{
    public string soudName;
    public AudioClip clip;
}

public class SoundManager : MonoBehaviour
{
    [SerializeField] Image soundOn;
    [SerializeField] Image soundOff;
    private bool muted = false;
    







    // public static SoundManager instance;

    [Header("사운드 등록")]
    [SerializeField] Sound[] bgmSounds;
    // [SerializeField] Sound[] sfxSounds;

    [Header("브금 플레이어")]
    [SerializeField] AudioSource bgmPlayer;

    // [Header("효과음 플레이어")]
    // [SerializeField] AudioSource sfxPlayer;

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


        // instance = this;
        PlayRandomBGM();
    }


    // public void PlaySE(string _soundName){

    //     for(int i = 0; i < 10; i++)
    //     {
    //         if(_soundName == sfxSounds[i].soudName)
    //         {
    //             for(int x = 0; x < 5; x++)
    //             {
    //                 if(!sfxPlayer[x].isPlaying){
    //                     sfxPlayer[x].clip = sfxSounds[i].clip;
    //                     sfxPlayer[x].Play();
    //                     return;
    //                 }
    //             }
    //             Debug.Log("모든 효과음 플레이어가 사용중입니다!");
    //             return;
    //         }
    //     }
    //     Debug.Log("등록된 효과음이 없습니다.");
    // }

    public void PlayRandomBGM(){
        int random = Random.Range(0, 2);
        bgmPlayer.clip = bgmSounds[random].clip;
        bgmPlayer.Play();
    }





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
        AudioListener.pause = muted;
    }

    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }

    private void UpdateButtonIcon()
    {
        if(muted == false)
        {
            soundOn.enabled = true;
            soundOff.enabled = false;
        }
        else
        {
            soundOn.enabled = false;
            soundOff.enabled = true;
        }
    }
}