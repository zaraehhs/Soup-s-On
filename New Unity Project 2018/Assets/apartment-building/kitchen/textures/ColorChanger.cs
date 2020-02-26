using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public void changeColor();
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject dynamicColorObject in DynamicColorObject.list)
            dynamicColorObject.GetComponent<Renderer>().sharedMaterial.color = Color.red;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
