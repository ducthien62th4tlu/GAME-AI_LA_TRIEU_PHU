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
    public AnswerButton[] answerButtons;
    public Sprite rightAnswer;
    public Sprite wrongAnswer;
    public Sprite defaulAnswer;
    public float colorChangeDelay = 0.5f;

    public void Awake()
    {
        MakeSingleton();

    }
    
    public void SetTimeText(string content)
    {
        if(timeText)
            timeText.text = content;
    }

    public void SetQuestionText(string content)
    {
        if (questionText)
            questionText.text = content;
    }

    public void ShuffleAnswwer()
    {
        if(answerButtons != null && answerButtons.Length > 0)
        {
            for(int i = 0; i < answerButtons.Length; i++) 
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
        StartCoroutine(ChangeColorWithDelay(answerButton, rightAnswer, colorChangeDelay));
    }

    public void ChaneWrongAnswer(AnswerButton answerButton)
    {
        answerButton.GetComponent<Image>().sprite = wrongAnswer;
    }
    //public void ResetImage(AnswerButton answerButton)
    //{
    //    if (answerButton != null)
    //    {
    //        answerButton.GetComponent<Image>().sprite = defaulAnswer;
    //    }

    //}
    public void ResetButtonImage(AnswerButton answerButton)
    {
        if (answerButton != null)
        {
            answerButton.GetComponent<Image>().sprite = defaulAnswer;
        }
    }

    public void ResetAllButtonImages()
    {
        foreach (var button in answerButtons)
        {
            ResetButtonImage(button);
            StartCoroutine(ResetColorWithDelay(button, defaulAnswer, colorChangeDelay));
        }
    }
    IEnumerator ChangeColorWithDelay(AnswerButton answerButton, Sprite newSprite, float delay)
    {
        yield return new WaitForSeconds(delay);
        answerButton.GetComponent<Image>().sprite = newSprite;
    }
    IEnumerator ResetColorWithDelay(AnswerButton answerButton, Sprite newSprite, float delay)
    {
        yield return new WaitForSeconds(delay);
        answerButton.GetComponent<Image>().sprite = newSprite;
    }
    public void MakeSingleton()
    {
        if ( Ins == null)
        {
            Ins = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
