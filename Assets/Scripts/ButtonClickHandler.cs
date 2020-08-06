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
        _gameStatusText = GetChildGameObject(gameObject, "GameStatusText").GetComponent<Text>();

        SetPlayerAnswer(text);
        SetOpponentAnswer();
        PlayAnimation();
        GetTheWinner();
    }
    public void PlayAnimation()
    {
        GetChildGameObject(gameObject, "PlayerSprite").GetComponent<Animator>().SetInteger("showHand", _playerAnswer);
        GetChildGameObject(gameObject, "OponentSprite").GetComponent<Animator>().SetInteger("showHand", _opponentAnswer);
    }
    public void SetOpponentAnswer()
    {
        GenerateOpponentAnswer();
        Text opponentAnswerText = GetChildGameObject(gameObject, "OpponentAnswerText").GetComponent<Text>();
        opponentAnswerText.text = _opponentAnswer.ToString();
    }
    public void SetPlayerAnswer(string text)
    {
        _playerAnswerText = GetChildGameObject(gameObject, "PlayerAnswerText").GetComponent<Text>();
        _playerAnswerText.text = text;
        _playerAnswer = int.Parse(text);
    }
    void GetTheWinner()
    {
        if ((_opponentAnswer + _playerAnswer) % 2 != 0)
        {
            _gameStatusText.text = "YOU LOST!";
            _gameStatusText.color = new Color(139, 0, 0);
        }
        else
        {
            _gameStatusText.text = "YOU WON!";
            _gameStatusText.color = new Color(0, 0, 0);            
        }
    }
    void GenerateOpponentAnswer()
    {
        Random random = new Random();
        _opponentAnswer = random.Next(1, 6);
    }
    static public GameObject GetChildGameObject(GameObject fromGameObject, string withName)
    {
        //Author: Isaac Dart, June-13.
        Transform[] ts = fromGameObject.transform.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in ts) if (t.gameObject.name == withName) return t.gameObject;
        return null;
    }
}
