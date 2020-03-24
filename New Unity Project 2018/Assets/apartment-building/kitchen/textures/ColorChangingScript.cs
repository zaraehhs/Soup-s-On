using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    //Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            rend.material.SetColor("_Color", Random.ColorHSV());
        }
    }
}
