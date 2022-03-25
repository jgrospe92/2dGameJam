using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCountdown : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeValue = 60;
    public Text timerText;

    public PlayerMovement player;
    public GameObject hud;

    // Oxygen Object
    public OxygenLevel ox;
    public float currentOxygen;

    private void Start()
    {
        currentOxygen = timeValue;
        ox.setOxygen(currentOxygen);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;

            ox.currentLevel(timeValue);

        }
        else
        {
            timeValue = 0;
        }

        DisplayTime(timeValue);

        if(timeValue == 0)
        {
            player.isDead = true;
            hud.SetActive(true);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        else if(timeToDisplay > 0)
        {
            timeToDisplay += 1;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
