using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game : MonoBehaviour
{
    public GameObject scoreDisplay;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        //scoreDisplay = GameObject.Find("score").GetComponent<Text>(); ;
    }

    // Update is called once per frame
    void Update()
    {
        //scoreDisplay.text = "";
    }
}
