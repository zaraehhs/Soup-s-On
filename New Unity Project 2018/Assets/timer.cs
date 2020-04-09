using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public Text counterText;

    
    void Start()
    {
        counterText = GetComponent<Text>() as Text;

    }


    // Update is called once per frame
    void Update()
    {
        
    }

    

}
