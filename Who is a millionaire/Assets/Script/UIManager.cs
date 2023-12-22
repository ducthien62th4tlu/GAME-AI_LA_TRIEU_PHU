using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class UIManager : MonoBehaviour
{
    public static UIManager Ins;
    public Text timeText;
    public Text questionText;
    public Dialog dialog;
    public Dialog setting;
    public AnswerButton[] answerButtons;
    public Sprite rightAnswer;
    public Sprite wrongAnswer;
    public Sprite defaulAnswer;

    public void Awake()
    {
        MakeSingleton();
    }

    public void SetTimeText(string content)
    {
        if (timeText)
            timeText.text = content;
    }

    public void SetQuestionText(string content)
    {
        if (questionText)
            questionText.text = content;
    }

    public void ShuffleAnswwer()
    {
        if (answerButtons != null && answerButtons.Length > 0)
        {
            for (int i = 0; i < answerButtons.Length; i++)
            {
                if (answerButtons[i])
                {
                    answerButtons[i].tag = "Untagged";
                }
            }
            int randIdx = Random.Range(0, answerButtons.Length);

            if (answerButtons[randIdx])
            {
                answerButtons[randIdx].tag = "RightAnswer";
            }
        }
    }
    public void ChangeRightAnswer(AnswerButton answerButton)
    {
        answerButton.GetComponent<Image>().sprite = rightAnswer;
    }

    public void ChaneWrongAnswer(AnswerButton answerButton)
    {
        answerButton.GetComponent<Image>().sprite = wrongAnswer;
    }

    public void ChangeDefaulAnswer(AnswerButton answerButton)
    {
        answerButton.GetComponent<Image>().sprite = defaulAnswer;
    }
    public void MakeSingleton()
    {
        if (Ins == null)
        {
            Ins = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
