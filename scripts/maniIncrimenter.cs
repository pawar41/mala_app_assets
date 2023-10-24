using UnityEngine;
using TMPro;

public class maniIncrimenter : MonoBehaviour
{
    public TextMeshProUGUI touchUpdateMani;

    int counterMani;
    private static readonly string maniCounterPrefs = "maniCounterPrefs";
    private static readonly string malaConterPrefs = "malaConterPrefs";

    private static readonly string initialManiPrefs = "initialManiPrefs";

    public GameObject ManiToFall;

    GameObject[] manis;

    void Start()
    {
        if(PlayerPrefs.GetInt(initialManiPrefs) == 0)
        {
            counterMani = 0;
            PlayerPrefs.SetInt(maniCounterPrefs, counterMani);
            PlayerPrefs.SetInt(initialManiPrefs, -1);


        }
        else if(PlayerPrefs.GetInt(initialManiPrefs) == -1) {
            counterMani = PlayerPrefs.GetInt(maniCounterPrefs);
        } else
        {
            counterMani = 0;
            PlayerPrefs.SetInt(maniCounterPrefs, counterMani);
        }

        touchUpdateMani.SetText(counterMani.ToString());

        for (int i = 1; i <= counterMani; i++)
        {
            Instantiate(ManiToFall, new Vector3(Random.Range(0.5f, 2.2f), Random.Range(3f, 10f), 50f), Quaternion.identity);
        }

    }

    public void incrementManiCounter()
    {
        counterMani++;
        touchUpdateMani.SetText(counterMani.ToString());
        PlayerPrefs.SetInt(maniCounterPrefs, counterMani);

        Instantiate(ManiToFall, new Vector3(Random.Range(0.5f, 2.2f), 3.3f, 86.1f), Quaternion.identity);

        if (counterMani > 108)
        {
            counterMani = 1;
            touchUpdateMani.SetText(counterMani.ToString());
            PlayerPrefs.SetInt(maniCounterPrefs, counterMani);


            PlayerPrefs.SetInt(malaConterPrefs, (PlayerPrefs.GetInt(malaConterPrefs)+1));

            DestroyManis();

            Instantiate(ManiToFall, new Vector3(Random.Range(0.5f, 2.2f), Random.Range(3f, 10f), 50f), Quaternion.identity);
        }
    }

    public void ResetManiCount()
    {
        counterMani = 0;
        touchUpdateMani.SetText(counterMani.ToString());
        PlayerPrefs.SetInt(maniCounterPrefs, counterMani);

        DestroyManis();
    }

    void DestroyManis()
    {
        manis = GameObject.FindGameObjectsWithTag("bits");
        foreach (GameObject go in manis)
        {
            if(go.name != "bit")
                Destroy(go);
        }
    }
}
