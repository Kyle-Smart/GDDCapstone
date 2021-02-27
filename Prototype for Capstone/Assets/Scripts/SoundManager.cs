using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;
    public static SoundManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }


    public enum Sound
    {
        BoxDrop,
        BoxBreak,
        ButtonPressDown,
        ButtonStuckDown,
        DoorOpening,
        DoorClosing,
        DoorJamming,
        Generator,
        HPBarHit,
        UISelectOption,
        PlayerWalking,
        MainMenuMusic,
        LevelOneMusic
    }

    [System.Serializable]
    public class SoundAudioClip
    {
        public Sound sound;
        public AudioClip audioClip;
    }

    public SoundAudioClip[] arrayOfSoundAudioClips;

    public void PlaySound(Sound sound)
    {
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(GetAudioClip(sound), 0.25f);
    }

    private AudioClip GetAudioClip(Sound sound)
    {
        foreach (SoundAudioClip soundAudioClip in arrayOfSoundAudioClips)
        {
            if (soundAudioClip.sound == sound)
            {
                return soundAudioClip.audioClip;
            }
        }
        Debug.LogError("Sound "+ sound + " not found!");
        return null;
    }
}
