using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public float timePerQuestion;
    float m_curTime;
    int m_rightCount;

    public AnswerButton correctAnswerButton;
    public AnswerButton wrongAnswerButton;
    public AnswerButton defaulAnswerButton;

    private void Awake()
    {
        m_curTime = timePerQuestion;
    }
    // Start is called before the first frame update
    void Start()
    {
        CreateQuestion();

        StartCoroutine(TimeCoutingDown());

        UIManager.Ins.SetTimeText("00 : " + m_curTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateQuestion()
    {
        QuestionData qs = QuestionManager.Ins.GetRandomQuestion();
        UIManager.Ins.ResetAllButtonImages();
        if (qs != null)
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
                    int answerId = i;
                    if(string.Compare(temp[i].tag,"RightAnswer") == 0)
                    {
                        temp[i].SetAnswerText(qs.rightAnswer);
                        correctAnswerButton = temp[i];
                    }
                    else
                    {
                        temp[i].SetAnswerText(wrongAnswer[wrongAnswerCount]);
                        wrongAnswerCount++;
                    }

                    temp[answerId].btnComp.onClick.RemoveAllListeners();
                    temp[answerId].btnComp.onClick.AddListener(() => CheckRightAnswerEvent(temp[answerId]));
                }
            }
        }
    }
    void CheckRightAnswerEvent(AnswerButton answerButton)
    {
        if (answerButton.CompareTag("RightAnswer"))
        {
            m_curTime = timePerQuestion;
            UIManager.Ins.SetTimeText("00 : " + m_curTime);
            m_rightCount++;
            UIManager.Ins.ChangeRightAnswer(correctAnswerButton);
            if (m_rightCount == QuestionManager.Ins.questions.Length)
            {
                UIManager.Ins.dialog.SetDialogContent(" YOU WIN !");
                UIManager.Ins.dialog.Show(true);
                StopAllCoroutines();
                AudioController.Ins.PlayWinSound();
                
            }
            else
            {
                UIManager.Ins.ResetAllButtonImages();
                CreateQuestion();
                AudioController.Ins.PlayRightSound();
                Debug.Log("Ban da tra loi dung");
            }
        }
        else
        {
            UIManager.Ins.ChaneWrongAnswer(answerButton);
            UIManager.Ins.dialog.SetDialogContent(" YOU LOSE !");
            UIManager.Ins.dialog.Show(true);
            Debug.Log("Ban da tra loi sai, Tro choi ket thuc");
            AudioController.Ins.PlayLoseSound();
        }
    }

    IEnumerator TimeCoutingDown()
    {
        yield return new WaitForSeconds(1);
        if(m_curTime > 0)
        {
            m_curTime--;
            StartCoroutine(TimeCoutingDown());
            UIManager.Ins.SetTimeText("00 : " + m_curTime);
        }
        else
        {
            UIManager.Ins.dialog.SetDialogContent(" YOU LOSE !");
            UIManager.Ins.dialog.Show(true);
            StopAllCoroutines();
            AudioController.Ins.PlayLoseSound();
        }
        
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Out()
    {
        Application.LoadLevel("Scene1");
    }
    public void Replay()
    {
        AudioController.Ins.StopMusic();
        Application.LoadLevel("Scene3");
    }

    public void loadScene()
    {
        Application.LoadLevel("Scene2");
    }

    public void PlayScene()
    {
        AudioController.Ins.PlayGame();
        Application.LoadLevel("Scene3");
    }
}
