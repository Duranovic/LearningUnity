using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class GaneScript : MonoBehaviour
{
    // Start is called before the first frame update
    public new GameObject gameObject;
    private int _opponentAnswer;
    void Start()
    {
    }    
    void generateOpponentAnswer()
    {
        Random random = new Random();
        _opponentAnswer = random.Next(1, 5);
    }
    static public GameObject getChildGameObject(GameObject fromGameObject, string withName)
    {
        //Author: Isaac Dart, June-13.
        Transform[] ts = fromGameObject.transform.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in ts) if (t.gameObject.name == withName) return t.gameObject;
        return null;
    }
    public void ButtonClicked()
    {
        StartGame();
    }

    void StartGame()
    {
        generateOpponentAnswer();
        gameObject.GetComponentInChildren<Text>().text = _opponentAnswer.ToString();
        //getChildGameObject(gameObject, "sprite").GetComponent<Animator>().SetBool("isGameStarted", true);
        if (getChildGameObject(gameObject, "Sprite") == null)
        {
            Debug.Log("NULLLLL");
        }
        else
        {
            getChildGameObject(gameObject, "Sprite").GetComponent<Animator>().SetBool("isGameStarted", true);
        }
    }
}
