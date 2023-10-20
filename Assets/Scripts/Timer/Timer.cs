using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text timerText;
    private float timeLeft;
    private bool isRunning;

    public void Start()
    {
        timerText = GetComponent<Text>();
        StartTimer(60);
    }

    public void StartTimer(float seconds)
    {
        timeLeft = seconds;
        isRunning = true;
    }

    void Update()
    {
        if (isRunning)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                timeLeft = 0;
                isRunning = false;
            }

            int minutes = (int)(timeLeft / 60);
            int seconds = (int)(timeLeft % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}


