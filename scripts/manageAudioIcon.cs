using UnityEngine;

public class manageAudioIcon : MonoBehaviour
{
    private static readonly string audioSettingsPrefs = "audioSettingsPrefs";
    private static readonly string initialPlayerPrefs = "initialPlayerPrefs";

    public GameObject playButton;
    public GameObject pauseButton;

    int AudioStatus;

    public AudioSource musicBG;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt(initialPlayerPrefs) != -1)
        {
            defaultAudio();

            PlayerPrefs.SetInt(initialPlayerPrefs, -1);
        } else
        {
            updateAudioStart();
        }
    }

    void defaultAudio()
    {
        playButton.SetActive(true);
        pauseButton.SetActive(false);
    }

    void muteAudio()
    {
        playButton.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void updateAudioStart()
    {
        AudioStatus = PlayerPrefs.GetInt(audioSettingsPrefs);
        //Debug.Log(AudioStatus);
        if (AudioStatus == -1)
        {
            muteAudio();
        } else
        {
            defaultAudio();
        }

        updateSpeakerSettings();
    }

    public void saveAudioSettings()
    {
        //AudioStatus = PlayerPrefs.GetInt(audioSettingsPrefs);

        if (playButton.active == true && pauseButton.active == false)
        {
            PlayerPrefs.SetInt(audioSettingsPrefs, 1);
        }
        else if (playButton.active == false && pauseButton.active == true)
        {
            PlayerPrefs.SetInt(audioSettingsPrefs, -1);
        } else
        {
            PlayerPrefs.SetInt(audioSettingsPrefs, 1);
        }
    }

    public void updateSpeakerSettings()
    {
        AudioStatus = PlayerPrefs.GetInt(audioSettingsPrefs);

        if (AudioStatus == -1 && musicBG!= null)
        {
            musicBG.Stop();
        }
        else if(musicBG != null)
        {
            musicBG.Play();
        }
    }

    void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus)
        {
            saveAudioSettings();
        }
    }
}
