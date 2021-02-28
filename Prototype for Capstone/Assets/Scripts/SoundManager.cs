using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;
    public static SoundManager Instance { get { return _instance; } }

    private GameObject onceShotGameObject;
    private AudioSource oneShotAudioSource;
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
        LevelOneMusic,
        UIButtonBreak
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
        if (onceShotGameObject == null)
        {
            onceShotGameObject = new GameObject("Sound");
            oneShotAudioSource = onceShotGameObject.AddComponent<AudioSource>();
        }

        oneShotAudioSource.PlayOneShot(GetAudioClip(sound), 0.25f);
    }

    public AudioSource PlayLoopingSound(Sound sound)
    {
        GameObject loopingAudioGameObject = new GameObject("Sound");
        AudioSource loopingAudioSource = loopingAudioGameObject.AddComponent<AudioSource>();


        loopingAudioSource.loop = true;
        loopingAudioSource.volume = 0.25f;
        loopingAudioSource.clip = GetAudioClip(sound);
        loopingAudioSource.Play();

        return loopingAudioSource;
    }

    public void StopSoundLooping(AudioSource source)
    {
        source.Stop();
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
