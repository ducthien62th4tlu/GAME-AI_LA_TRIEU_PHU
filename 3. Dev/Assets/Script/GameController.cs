using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CreateQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateQuestion()
    {
        QuestionData qs = QuestionManager.Ins.GetRandomQuesstion();

        if(qs != null)
        {
            UIManager.Ins.SetQuestionText(qs.question);
            string[] wrongAnswer = new string[] { qs.answerA,qs.answerB,qs.answerC};

            UIManager.Ins.ShuffleAnswwer();

            var temp = UIManager.Ins.answerButtons;
            if(temp != null && temp.Length > 0) 
            {
                int wrongAnswerCount = 0;
                for(int i = 0; i < temp.Length; i++)
                {
                    if(string.Compare(temp[i].tag,"RightAnswer") ==0)
                    {
                        temp[i].SetAnswerText(qs.rightAnswer);
                    }
                    else
                    {
                        temp[i].SetAnswerText(wrongAnswer[wrongAnswerCount]);
                        wrongAnswerCount++;
                    }
                     
                }
            }
        }
    }
}
