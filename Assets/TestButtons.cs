using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestButtons : MonoBehaviour
{
    [SerializeField]
    Text t;
    // Update is called once per frame
    void Update()
    {
        t.text = "";
        for (int i = 0; i < 20; i++)
        {
            t.text += "Button " + i + "=" + Input.GetKey("joystick button " + i) + "| ";
        }
    }
}
