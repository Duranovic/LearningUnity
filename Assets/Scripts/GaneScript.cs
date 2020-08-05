using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GaneScript : MonoBehaviour
{
    // Start is called before the first frame update
    public new GameObject gameObject;
    public Animator animator;
    void Start()
    {
        gameObject.GetComponentInChildren<Text>().text = DateTime.UtcNow.ToShortDateString();
    }
    void Update()
    {
        if (Input.touches.Any(x => x.phase == TouchPhase.Began))
        {
            animator.SetBool("isGameStarted", true);
        }
    }
}
