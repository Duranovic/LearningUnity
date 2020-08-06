using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = System.Random;

public class ButtonClickHandler : MonoBehaviour
{
    public new GameObject gameObject;
    private int _opponentAnswer;
    private int _playerAnswer;
    private Text _playerAnswerText;
    private Text _gameStatusText;
    
    public void OnClick()
    {       
        string text = EventSystem.current.currentSelectedGameObject.GetComponent<Button>().GetComponentInChildren<TextMeshProUGUI>().text;
        _gameStatusText = getChildGameObject(gameObject, "GameStatusText").GetComponent<Text>();

        setPlayerAnswer(text);
        setOpponentAnswer();
        getTheWinner();
        
    }
    public void setOpponentAnswer()
    {
        generateOpponentAnswer();
        Text opponentAnswerText = getChildGameObject(gameObject, "OpponentAnswerText").GetComponent<Text>();
        opponentAnswerText.text = _opponentAnswer.ToString();
    }
    public void setPlayerAnswer(string text)
    {
        _playerAnswerText = getChildGameObject(gameObject, "PlayerAnswerText").GetComponent<Text>();
        _playerAnswerText.text = text;
        _playerAnswer = int.Parse(text);
    }
    void getTheWinner()
    {
        if ((_opponentAnswer + _playerAnswer) % 2 != 0)
        {
            _gameStatusText.text = "YOU LOOSE!";
            _gameStatusText.color = new Color(139, 0, 0);
        }
        else
        {
            _gameStatusText.text = "YOU WIN!";
            _gameStatusText.color = new Color(123, 123, 123);
        }
    }
    void generateOpponentAnswer()
    {
        Random random = new Random();
        _opponentAnswer = random.Next(1, 6);
    }
    static public GameObject getChildGameObject(GameObject fromGameObject, string withName)
    {
        //Author: Isaac Dart, June-13.
        Transform[] ts = fromGameObject.transform.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in ts) if (t.gameObject.name == withName) return t.gameObject;
        return null;
    }
}
