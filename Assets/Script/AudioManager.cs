using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SoundState
{
    OFF = 0,
    ON = 1
}
public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource mainSource;
    [SerializeField] private AudioSource[] otherSources;
    private SoundState state;
    public void Awake()
    {
        if (!PlayerPrefs.HasKey("SoundState"))
        {
            PlayerPrefs.SetInt("SoundState", 1);
            ChangeSoundState(SoundState.ON);
        }
        else if (PlayerPrefs.GetInt("SoundState")==0)
        {
            ChangeSoundState(SoundState.OFF);
        }
        else
        {
            ChangeSoundState(SoundState.ON);
        }
        DontDestroyOnLoad(mainSource.gameObject);
    }
    public void ChangeSoundState(SoundState soundState)
    {
        state = soundState;
        switch (state)
        {
            case SoundState.OFF:
                PlayerPrefs.SetInt("SoundState", 0);
                mainSource.Pause();
                foreach (AudioSource source in otherSources)
                {
                    source.volume = 0;
                }
                break;
            case SoundState.ON:
                PlayerPrefs.SetInt("SoundState", 1);
                mainSource.Play();
                foreach (AudioSource source in otherSources)
                {
                    source.volume = 0.5f;
                }
                break;
            default:
                break;
        }
    }
}
