using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    //This script should be attached to a UI Text element
    public Text counterText;
    public float seconds, minutes;

    void Start ()
    {
        counterText = GetComponent<Text>() as Text;
    }
    //call this on update
    void Update ()
	{
        minutes = (int)(Time.time/60f);
        seconds = (int)(Time.time % 60f);
        counterText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
	}

}