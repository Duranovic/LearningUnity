using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaneScript : MonoBehaviour
{
    // Start is called before the first frame update
    public new GameObject gameObject;
    void Start()
    {
        gameObject.GetComponentInChildren<Text>().text = DateTime.UtcNow.ToShortDateString();
    }
}
