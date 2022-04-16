using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Lamb : MonoBehaviour
{
    void FixedUpdate()
    {
        if (Input.GetButton("Fire1"))
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }
}