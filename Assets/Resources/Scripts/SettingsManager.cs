using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    #region DEFAULT
    private AudioClip[] auClipMusic; // array of music
    public static readonly AudioClip[] auClipSfx = new AudioClip[57]; // audios sfx  
    [Header("0 - AudioSource Music"), Space(1), Header("1 - AudioSource Sfx"), Space(1), Header("2 - Toggle Music"), Space(1), Header("3 - Toggle Sfx"), Space(1), Header("4 - Slider Music"), Space(1), Header("5 - Slider Sfx")]
    public GameObject[] stMasterManager; // settings master manager
    public static bool check_Music; // check play music
    public static int random_Sfx, r, t; // random sfx (audio), random BG, random texture BG
    private Renderer rd_BG; // renderer BG
    private readonly Texture2D[] tx_BG = new Texture2D[16]; // texture BG
    private Vector2 move_BG; // vector BG 

    /// <summary>
    /// stMasterManager0 - auMusic
    /// stMasterManager1 - Sfx
    /// stMasterManager2 - tgMusic
    /// stMasterManager3 - tgSfx
    /// stMasterManager4 - slVolumeMusic
    /// stMasterManager5 - slVolumeAudio
    /// </summary>

    void Start()
    {
        // load states
        SaveStates();
        AudioManager();
        BackgroundManager();
    }

    void Update()
    {

        #region CHECK OUT - MUSIC NOT PLAYING
        if (!stMasterManager[0].GetComponent<AudioSource>().isPlaying)
        {
            stMasterManager[0].GetComponent<AudioSource>().clip = auClipMusic[Random.Range(0, auClipMusic.Length)];
            stMasterManager[0].GetComponent<AudioSource>().Play();
            check_Music = !check_Music;
            BackgroundManager();
        } 
        #endregion

        #region MOVE BG
        if (r == 0)
        {
            move_BG = new Vector2(Time.time * -0.5f, Time.time * 0.5f);
        }
        if (r == 1)
        {
            move_BG = new Vector2(Time.time * 0.5f, Time.time * -0.5f);
        }
        if (r == 2)
        {
            move_BG = new Vector2(Time.time * 0.5f, Time.time * 0.5f);
        }
        if (r == 3)
        {
            move_BG = new Vector2(Time.time * -0.5f, Time.time * -0.5f);
        }
        rd_BG.material.mainTextureOffset = move_BG;
        #endregion
    }
    #endregion

    #region CHECK STATES 
    public void SettingsStates(int i)
    {
        switch (i)
        {
            // music
            case 0:
                if (stMasterManager[2].GetComponent<Toggle>().isOn == false)
                {
                    PlayerPrefs.SetInt("MUSIC", 0);
                    stMasterManager[0].GetComponent<AudioSource>().mute = true;
                    stMasterManager[4].GetComponent<Slider>().interactable = false;
                }
                else
                {
                    PlayerPrefs.SetInt("MUSIC", 1);
                    stMasterManager[0].GetComponent<AudioSource>().mute = false;
                    stMasterManager[4].GetComponent<Slider>().interactable = true;
                }
                break;

            // volume music
            case 1:
                stMasterManager[0].GetComponent<AudioSource>().volume = stMasterManager[4].GetComponent<Slider>().value;
                PlayerPrefs.SetFloat("VOLUMEMUSIC", stMasterManager[4].GetComponent<Slider>().value);
                PlayerPrefs.Save();
                break;

            // audio
            case 2:
                if (stMasterManager[3].GetComponent<Toggle>().isOn == false)
                {
                    PlayerPrefs.SetInt("AUDIO", 0);
                    stMasterManager[1].GetComponent<AudioSource>().mute = true;
                    stMasterManager[1].GetComponent<AudioSource>().playOnAwake = false;
                    stMasterManager[5].GetComponent<Slider>().interactable = false;

                }
                else
                {
                    PlayerPrefs.SetInt("AUDIO", 1);
                    stMasterManager[1].GetComponent<AudioSource>().mute = false;
                    stMasterManager[1].GetComponent<AudioSource>().playOnAwake = true;
                    stMasterManager[1].GetComponent<AudioSource>().PlayOneShot(auClipSfx[random_Sfx]);
                    stMasterManager[5].GetComponent<Slider>().interactable = true;
                }
                break;

            // volume audio
            case 3:
                stMasterManager[1].GetComponent<AudioSource>().volume = stMasterManager[5].GetComponent<Slider>().value;
                PlayerPrefs.SetFloat("VOLUMEAUDIO", stMasterManager[5].GetComponent<Slider>().value);
                PlayerPrefs.Save();
                break;
        }
    }

    void SaveStates()
    {
        stMasterManager[4].GetComponent<Slider>().value = PlayerPrefs.GetFloat("VOLUMEMUSIC"); // SAVE SETTINGS VOLUME OF MUSIC
        stMasterManager[5].GetComponent<Slider>().value = PlayerPrefs.GetFloat("VOLUMEAUDIO"); // SAVE SETTINGS VOLUME OF AUDIO

        // SAVE MUSIC SETTINGS
        if (PlayerPrefs.GetInt("MUSIC") == 0)
        {
            stMasterManager[2].GetComponent<Toggle>().isOn = false;
            stMasterManager[0].GetComponent<AudioSource>().mute = true;
            stMasterManager[4].GetComponent<Slider>().interactable = false;
            stMasterManager[0].GetComponent<AudioSource>().volume = stMasterManager[4].GetComponent<Slider>().value;
        }
        else
        {
            stMasterManager[2].GetComponent<Toggle>().isOn = true;
            stMasterManager[0].GetComponent<AudioSource>().mute = false;
            stMasterManager[4].GetComponent<Slider>().interactable = true;
            stMasterManager[0].GetComponent<AudioSource>().volume = stMasterManager[4].GetComponent<Slider>().value;
        }

        // SAVE AUDIO SETTINGS
        if (PlayerPrefs.GetInt("AUDIO") == 0)
        {
            stMasterManager[3].GetComponent<Toggle>().isOn = false;
            stMasterManager[1].GetComponent<AudioSource>().mute = true;
            stMasterManager[5].GetComponent<Slider>().interactable = false;
            stMasterManager[1].GetComponent<AudioSource>().volume = stMasterManager[5].GetComponent<Slider>().value;
        }
        else
        {
            stMasterManager[3].GetComponent<Toggle>().isOn = true;
            stMasterManager[1].GetComponent<AudioSource>().mute = false;
            stMasterManager[5].GetComponent<Slider>().interactable = true;
            stMasterManager[1].GetComponent<AudioSource>().volume = stMasterManager[5].GetComponent<Slider>().value;
        }
    }

    void AudioManager()
    {
        // get components audio source  and load audios
        stMasterManager[0].GetComponent<AudioSource>();
        stMasterManager[1].GetComponent<AudioSource>();
        auClipMusic = Resources.LoadAll<AudioClip>("Audios/Musics");

        for (int i = 0; i < auClipSfx.Length; i++)
        {
            auClipSfx[i] = Resources.Load<AudioClip>("Audios/Sfxs/Clicks/" + i + "");
        }

        random_Sfx = Random.Range(0, auClipSfx.Length);
        AudioClip sfx = auClipSfx[random_Sfx];

        stMasterManager[0].GetComponent<AudioSource>().clip = auClipMusic[Random.Range(0, auClipMusic.Length)];
        stMasterManager[0].GetComponent<AudioSource>().Play();
        check_Music = true;
    }

    void BackgroundManager()
    {
        rd_BG = GetComponent<Renderer>();

        for (int i = 0; i < tx_BG.Length; i++)
        {
            tx_BG[i] = Resources.Load("Sprites/Elements/BG/" + i + "") as Texture2D;
        }

        r = Random.Range(0, 4);
        t = Random.Range(0, tx_BG.Length);
        Texture2D t2d = tx_BG[t];
        rd_BG.material.mainTexture = t2d;
    }
    #endregion
}