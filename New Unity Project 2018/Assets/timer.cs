using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public Text counterText;

    public float seconds, minutes;
    public float bonusSeconds;
    void Start()
    {
        counterText = GetComponent<Text>() as Text;

    }


    // Update is called once per frame
    void Update()
    {
        minutes = (int)(Time.time / 60f);
        seconds = (int)(Time.time % 60f) + bonusSeconds;
        if(seconds >= 60)
        {
            seconds -= 60;
            minutes += 1;
        }
        counterText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    void addTime()
    {
        bonusSeconds += 10;
    }

}
