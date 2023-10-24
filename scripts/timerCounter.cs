using UnityEngine;
using TMPro;

public class timerCounter : MonoBehaviour
{
    float SecondsStarted;
    float minutes, seconds, hours;

    float previousSecondsStaged;

    bool printTimer;
    public TextMeshProUGUI timerShowcase;
    bool startTimerButtonInatializer;
    bool timerRunning;


    void Start()
    {
        printTimer = false;
        startTimerButtonInatializer = true;
        timerRunning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (printTimer)
        {
            updateTimeTMP();
        }
    }

    public void startToCount()
    {
        if (startTimerButtonInatializer)
        {
            SecondsStarted = Time.fixedTime;
            startTimerButtonInatializer = false;
        }
        printTimer = true;

        if (timerRunning)
        {
            //Debug.Log("current seconds : " + Time.fixedTime + " prev seconds " + previousSecondsStaged);
            SecondsStarted += Time.fixedTime - previousSecondsStaged;
        }
        //convertToTime(Mathf.FloorToInt((Time.fixedTime - SecondsStarted)));
    }

    void convertToTime(int amountSeconds)
    {
        seconds = amountSeconds % 60;
        minutes = amountSeconds / 60;
        hours = amountSeconds / 3600;
    }

    void updateTimeTMP()
    {
        convertToTime(Mathf.FloorToInt((Time.fixedTime - SecondsStarted)));
        timerShowcase.SetText( hours.ToString("00") + " : " + minutes.ToString("00") + " : " + seconds.ToString("00"));
    }

    public void PauseToCount()
    {
        printTimer = false;
        timerRunning = true;

        previousSecondsStaged = Time.fixedTime;
    }

    public void ResetTimerCount()
    { 
        //PauseToCount();
        //Debug.Log("RESET called");
        SecondsStarted = Time.fixedTime;
        updateTimeTMP();
    }
}
