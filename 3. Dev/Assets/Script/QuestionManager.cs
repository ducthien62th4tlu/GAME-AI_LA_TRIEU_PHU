using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class QuestionManager : MonoBehaviour
{
    public QuestionData[] questions;
    List<QuestionData> m_questions;
    QuestionData m_curQuestion;

    public static QuestionManager Ins;
    public void Awake()
    {
        m_questions = questions.ToList();

        Debug.Log(GetRandomQuesstion().question);

        MakeSingleton();
    }

    public QuestionData CuQuestion { get => m_curQuestion; set => m_curQuestion = value; }

    public QuestionData GetRandomQuesstion()
    {
    
        if(m_questions != null && m_questions.Count > 0)
        {
            int randIdx = Random.Range(0, m_questions.Count);

            m_curQuestion = m_questions[randIdx];

            m_questions.RemoveAt(randIdx);
        }
        
        return m_curQuestion;
    }

    public void MakeSingleton()
    {
        if (Ins == null)
        {
            Ins = this;
        }
        else
            Destroy(gameObject);
    }
}
