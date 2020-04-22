using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonCC : MonoBehaviour
{
    public Material[] materials; 
    public Renderer rend;
    private int index = 1;
    GameObject infoCanvas;

    public void buttonPressed(){

        if(materials.Length == 0) 
        {
            return; 
        }
        Debug.Log("stove changed");
        infoCanvas = GameObject.Find("InfoCanvas");
        infoCanvas.GetComponent<game>().stoveOn = true;
        infoCanvas.GetComponent<game>().setMessage("");
            index +=1;

            if (index == materials.Length + 1) {
                index = 1;
                infoCanvas.GetComponent<game>().stoveOn = false;
                Debug.Log("stove off");
            }

            print(index); 

            rend.sharedMaterial =materials[index -1]; 
    } 
}