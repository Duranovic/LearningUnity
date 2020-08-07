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
    public GameObject gameStatusPopUp;

    public void OnClick()
    {
        StartCoroutine(WaitForMessageBox());
    }
    public void PlayAnimation()
    {
        if(GetChildGameObject(gameObject, "PlayerSprite").GetComponent<Animator>().GetInteger("showHand") > 0) 
        {
            GetChildGameObject(gameObject, "PlayerSprite").GetComponent<Animator>().SetTrigger("backToIdle");
            GetChildGameObject(gameObject, "OponentSprite").GetComponent<Animator>().SetTrigger("backToIdle");
        }
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
    IEnumerator WaitForMessageBox()
    {
        string text = EventSystem.current.currentSelectedGameObject.GetComponent<Button>().GetComponentInChildren<TextMeshProUGUI>().text;
        _gameStatusText = GetChildGameObject(gameObject, "GameStatusText").GetComponent<Text>();
        SetPlayerAnswer(text);
        SetOpponentAnswer();
        PlayAnimation();
        GetTheWinner();
        yield return new WaitForSeconds(1.33f);
        //After we have waited 5 seconds print the time again.
        //GameObject go = Instantiate(gameStatusPopUp, new Vector3(0, 0, -10000), Quaternion.identity, gameObject.GetComponentInParent<Canvas>().transform);
        //go.transform.localScale = new Vector3(1, 1, 1);
        //if ((_opponentAnswer + _playerAnswer) % 2 != 0)
        //{
        //    go.GetComponentInChildren<Text>().text = "YOU LOST!";
        //    go.GetComponentInChildren<Text>().color = new Color(139, 0, 0);
        //}
        //else
        //{
        //    go.GetComponentInChildren<Text>().text = "YOU WON!";
        //    go.GetComponentInChildren<Text>().color = new Color(0, 0, 0);
        //}
    }
    static public GameObject GetChildGameObject(GameObject fromGameObject, string withName)
    {
        //Author: Isaac Dart, June-13.
        Transform[] ts = fromGameObject.transform.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in ts) if (t.gameObject.name == withName) return t.gameObject;
        return null;
    }
}
