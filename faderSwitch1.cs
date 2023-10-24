using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class faderSwitch3 : MonoBehaviour
{
    public Image imageToFadeIn;
    Color giverColour;

    bool onlyOnceFade;
    bool willRunOnce;
    bool doneFadeIn;

    public int sceneToSwitch = 2;

    public float decrementer_alpha = 0.08f;

    void Start()
    {
        onlyOnceFade = false;
        doneFadeIn = true;

        willRunOnce = true;

        startFadeIn();
    }

    void Update()
    {
        if (willRunOnce)
        {
            onlyOnceFade = true;

            giverColour = imageToFadeIn.color;
            giverColour.a = 0f;

            willRunOnce = false;
        }

        if (onlyOnceFade)
        {

            if (imageToFadeIn.color.a < 0.98f && doneFadeIn)
            {
                giverColour.a = giverColour.a + decrementer_alpha;
                imageToFadeIn.color = giverColour;

//                Debug.Log("growing to alpha(0 > 1) : " + imageToFadeIn.color.a + " | giver " + giverColour.a + " >> addition : " + (giverColour.a + decrementer_alpha));

                if (imageToFadeIn.color.a > 0.98f)
                {
                    doneFadeIn = false;
                }
            }
            else
            {
                giverColour.a = 1f;
                imageToFadeIn.color = giverColour;


                onlyOnceFade = false;
                SceneManager.LoadScene(sceneToSwitch);

                //gameObject.SetActive(false);
            }
        }
    }

    public void startFadeIn()
    {

        onlyOnceFade = true;
    }
}
