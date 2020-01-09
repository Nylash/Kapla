using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DJ : MonoBehaviour
{
#pragma warning disable 0649
    [Header("SOURCES")]
    [SerializeField] List<AudioSource> audioSourcesUI = new List<AudioSource>();
    [SerializeField] List<AudioSource> audioSourcesGame = new List<AudioSource>();
    #region GAME SOUNDS VARIABLES
    [Header("Piece drop")]
    [Header("SOUNDS")]
    [SerializeField] List<AudioClip> drop_clips = new List<AudioClip>();
    [SerializeField] float drop_minPitch;
    [SerializeField] float drop_maxPitch;
    [SerializeField] float drop_minVolume;
    [SerializeField] float drop_maxVolume;
    [Header("Piece rotation")]
    [SerializeField] List<AudioClip> rotation_clips = new List<AudioClip>();
    [SerializeField] float rotation_minPitch;
    [SerializeField] float rotation_maxPitch;
    [SerializeField] float rotation_minVolume;
    [SerializeField] float rotation_maxVolume;
    [Header("Piece fall")]
    [SerializeField] List<AudioClip> fall_clips = new List<AudioClip>();
    [SerializeField] float fall_minPitch;
    [SerializeField] float fall_maxPitch;
    [SerializeField] float fall_minVolume;
    [SerializeField] float fall_maxVolume;
    [Header("Piece movement impossible")]
    [SerializeField] List<AudioClip> imp_clips = new List<AudioClip>();
    [SerializeField] float imp_minPitch;
    [SerializeField] float imp_maxPitch;
    [SerializeField] float imp_minVolume;
    [SerializeField] float imp_maxVolume;
    [Header("Piece ground")]
    [SerializeField] List<AudioClip> ground_clips = new List<AudioClip>();
    [SerializeField] float ground_minPitch;
    [SerializeField] float ground_maxPitch;
    [SerializeField] float ground_minVolume;
    [SerializeField] float ground_maxVolume;
    [Header("Confettis")]
    [SerializeField] AudioClip confettis_clip;
    [SerializeField] float confettis_minPitch;
    [SerializeField] float confettis_maxPitch;
    [SerializeField] float confettis_minVolume;
    [SerializeField] float confettis_maxVolume;
    [Header("Piano")]
    [SerializeField] List<AudioClip> piano_clips = new List<AudioClip>();
    [SerializeField] float piano_minPitch;
    [SerializeField] float piano_maxPitch;
    [SerializeField] float piano_minVolume;
    [SerializeField] float piano_maxVolume;
    [Header("Xylophone")]
    [SerializeField] List<AudioClip> xylophone_clips = new List<AudioClip>();
    [SerializeField] float xylophone_minPitch;
    [SerializeField] float xylophone_maxPitch;
    [SerializeField] float xylophone_minVolume;
    [SerializeField] float xylophone_maxVolume;
    [Header("Bomb")]
    [SerializeField] AudioClip bomb_clip;
    [SerializeField] float bomb_minPitch;
    [SerializeField] float bomb_maxPitch;
    [SerializeField] float bomb_minVolume;
    [SerializeField] float bomb_maxVolume;
    #endregion
    #region UI SOUNDS VARIABLES
    [Header("Player turn")]
    [Header("UI SOUNDS")]
    [SerializeField] AudioClip turn_clip;
    [SerializeField] float turn_volume;
    [Header("Time warning")]
    [SerializeField] AudioClip warning_clip;
    [SerializeField] float warning_volume;
    [Header("Menu validation")]
    [SerializeField] AudioClip validation_clip;
    [SerializeField] float validation_volume;
    [Header("Menu change")]
    [SerializeField] AudioClip change_clip;
    [SerializeField] float change_volume;
    [Header("Menu pause")]
    [SerializeField] AudioClip pause_clip;
    [SerializeField] float pause_volume;
    [Header("Victory")]
    [SerializeField] AudioClip victory_clip;
    [SerializeField] float victory_volume;
    #endregion
    [Header("MUSICS")]
    [SerializeField] AudioClip inMenuMusic;
    [SerializeField] float inMenuMusic_volume;
    [SerializeField] AudioClip inGameMusic;
    [SerializeField] float inGameMusic_volume;
#pragma warning restore 0649
    public static DJ instance;
    AudioSource musicSource;

    private void Awake()
    {
        //temp to remove unity's debug updater which crashes with new input
        GameObject go = GameObject.Find("[Debug Updater]");
        if (go != null) DestroyImmediate(go);

        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        musicSource = GetComponent<AudioSource>();
    }

    public void PlaySound(SoundsKeyWord sound)
    {
        switch (sound)
        {
            #region GAME SOUNDS
            case SoundsKeyWord.Drop:
                AudioSource dropSrc = SelectGameAudioSource();
                dropSrc.pitch = Random.Range(drop_minPitch, drop_maxPitch);
                dropSrc.volume = Random.Range(drop_minVolume, drop_maxVolume);
                dropSrc.clip = drop_clips[Random.Range(0, drop_clips.Count)];
                dropSrc.Play();
                break;
            case SoundsKeyWord.Rotation:
                AudioSource rotationSrc = SelectGameAudioSource();
                rotationSrc.pitch = Random.Range(rotation_minPitch, rotation_maxPitch);
                rotationSrc.volume = Random.Range(rotation_minVolume, rotation_maxVolume);
                rotationSrc.clip = rotation_clips[Random.Range(0, rotation_clips.Count)];
                rotationSrc.Play();
                break;
            case SoundsKeyWord.Fall:
                AudioSource fallSrc = SelectGameAudioSource();
                fallSrc.pitch = Random.Range(fall_minPitch, fall_maxPitch);
                fallSrc.volume = Random.Range(fall_minVolume, fall_maxVolume);
                fallSrc.clip = fall_clips[Random.Range(0, fall_clips.Count)];
                fallSrc.Play();
                break;
            case SoundsKeyWord.Impossible:
                AudioSource impSrc = SelectGameAudioSource();
                impSrc.pitch = Random.Range(imp_minPitch, imp_maxPitch);
                impSrc.volume = Random.Range(imp_minVolume, imp_maxVolume);
                impSrc.clip = imp_clips[Random.Range(0, imp_clips.Count)];
                impSrc.Play();
                break;
            case SoundsKeyWord.Ground:
                AudioSource groundSrc = SelectGameAudioSource();
                groundSrc.pitch = Random.Range(ground_minPitch, ground_maxPitch);
                groundSrc.volume = Random.Range(ground_minVolume, ground_maxVolume);
                groundSrc.clip = ground_clips[Random.Range(0, ground_clips.Count)];
                groundSrc.Play();
                break;
            case SoundsKeyWord.Confettis:
                AudioSource confettisSrc = SelectGameAudioSource();
                confettisSrc.pitch = Random.Range(confettis_minPitch, confettis_maxPitch);
                confettisSrc.volume = Random.Range(confettis_minVolume, confettis_maxVolume);
                confettisSrc.clip = confettis_clip;
                confettisSrc.Play();
                break;
            case SoundsKeyWord.Piano:
                AudioSource pianoSrc = SelectGameAudioSource();
                pianoSrc.pitch = Random.Range(piano_minPitch, piano_maxPitch);
                pianoSrc.volume = Random.Range(piano_minVolume, piano_maxVolume);
                pianoSrc.clip = piano_clips[Random.Range(0, piano_clips.Count)];
                pianoSrc.Play();
                break;
            case SoundsKeyWord.Xylophone:
                AudioSource xyloSrc = SelectGameAudioSource();
                xyloSrc.pitch = Random.Range(xylophone_minPitch, xylophone_maxPitch);
                xyloSrc.volume = Random.Range(xylophone_minVolume, xylophone_maxVolume);
                xyloSrc.clip = xylophone_clips[Random.Range(0, xylophone_clips.Count)];
                xyloSrc.Play();
                break;
            case SoundsKeyWord.Bomb:
                AudioSource bombSrc = SelectGameAudioSource();
                bombSrc.pitch = Random.Range(bomb_minPitch, bomb_maxPitch);
                bombSrc.volume = Random.Range(bomb_minVolume, bomb_maxVolume);
                bombSrc.clip = bomb_clip;
                bombSrc.Play();
                break;
            #endregion
            #region UI SOUNDS
            case SoundsKeyWord.Turn:
                AudioSource turnSrc = SelectUIAudioSource();
                turnSrc.pitch = 1;
                turnSrc.volume = turn_volume;
                turnSrc.clip = turn_clip;
                turnSrc.Play();
                break;
            case SoundsKeyWord.Warning:
                AudioSource warningSrc = SelectUIAudioSource();
                warningSrc.pitch = 1;
                warningSrc.volume = warning_volume;
                warningSrc.clip = warning_clip;
                warningSrc.Play();
                break;
            case SoundsKeyWord.Validation:
                AudioSource validationSrc = SelectUIAudioSource();
                validationSrc.pitch = 1;
                validationSrc.volume = validation_volume;
                validationSrc.clip = validation_clip;
                validationSrc.Play();
                break;
            case SoundsKeyWord.Change:
                AudioSource changeSrc = SelectUIAudioSource();
                changeSrc.pitch = 1;
                changeSrc.volume = change_volume;
                changeSrc.clip = change_clip;
                changeSrc.Play();
                break;
            case SoundsKeyWord.Pause:
                AudioSource pauseSrc = SelectUIAudioSource();
                pauseSrc.pitch = 1;
                pauseSrc.volume = pause_volume;
                pauseSrc.clip = pause_clip;
                pauseSrc.Play();
                break;
            case SoundsKeyWord.Victory:
                AudioSource victorySrc = SelectUIAudioSource();
                victorySrc.pitch = 1;
                victorySrc.volume = victory_volume;
                victorySrc.clip = victory_clip;
                victorySrc.Play();
                break;
            #endregion
            default:
                Debug.LogError("You can't be here.");
                break;
        }
    }

    public void PlayMusic(MusicKeyWork music)
    {
        switch (music)
        {
            case MusicKeyWork.Menu:
                musicSource.volume = inMenuMusic_volume;
                musicSource.clip = inMenuMusic;
                break;
            case MusicKeyWork.Game:
                musicSource.volume = inGameMusic_volume;
                musicSource.clip = inGameMusic;
                break;
            default:
                break;
        }
        musicSource.Play();
    }

    AudioSource SelectGameAudioSource()
    {
        foreach (AudioSource item in audioSourcesGame)
        {
            if (!item.isPlaying)
                return item;
        }
        Debug.LogError("We need more AudioSource for game sounds.");
        return null;
    }

    AudioSource SelectUIAudioSource()
    {
        foreach (AudioSource item in audioSourcesUI)
        {
            if (!item.isPlaying)
                return item;
        }
        Debug.LogError("We need more AudioSource for UI sounds.");
        return null;
    }
    
    public enum SoundsKeyWord
    {
        Drop, Rotation, Fall, Impossible, Ground, Confettis, Piano, Xylophone, Bomb, Turn, Warning, Validation, Change, Pause, Victory
    }

    public enum MusicKeyWork
    {
        Menu, Game
    }
}
