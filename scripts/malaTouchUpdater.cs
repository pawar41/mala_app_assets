using UnityEngine;
using TMPro;

public class malaTouchUpdater : MonoBehaviour
{
    public TextMeshProUGUI touchUpdate;

    int counter;
    private static readonly string malaConterPrefs = "malaConterPrefs";
    private static readonly string initialMalaPrefs = "initialMalaPrefs";


    void Start()
    {
        if (PlayerPrefs.GetInt(initialMalaPrefs) == 0)
        {
            counter = 0;
            PlayerPrefs.SetInt(malaConterPrefs, counter);
            PlayerPrefs.SetInt(initialMalaPrefs, -1);
        }
        else if(PlayerPrefs.GetInt(initialMalaPrefs) == -1)
        {
            counter = PlayerPrefs.GetInt(malaConterPrefs);
        } else
        {
            counter = 0;
            PlayerPrefs.SetInt(malaConterPrefs, counter);
        }

        touchUpdate.SetText(counter.ToString());

    }

    void Update()
    {
        if (PlayerPrefs.GetInt(malaConterPrefs) != counter )
        {
            counter = PlayerPrefs.GetInt(malaConterPrefs);
            touchUpdate.SetText(counter.ToString());
        }
    }

    public void incrementCountText()
    {
        counter++;
        touchUpdate.SetText(counter.ToString());
        PlayerPrefs.SetInt(malaConterPrefs, counter);
    }

    public void ResetMalaCount()
    {
        counter = 0;
        touchUpdate.SetText(counter.ToString());
        PlayerPrefs.SetInt(malaConterPrefs, counter);
    }

}
