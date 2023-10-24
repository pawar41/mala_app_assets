
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterAudio_sceneSwitch : MonoBehaviour
{
    public AudioSource AudioSourceToCheck;
    private static readonly string initialPlayerPrefs = "initialPlayerPrefs";

    void Update()
    {
        // if first_time {}
        // else {}
        if (PlayerPrefs.GetInt(initialPlayerPrefs) == -1)
        {
            SceneManager.LoadScene(1);

        }


        if (AudioSourceToCheck != null)
        {
            if (!AudioSourceToCheck.isPlaying)
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
