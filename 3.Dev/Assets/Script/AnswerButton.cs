using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class AnswerButton : MonoBehaviour
{
    public Text answerText;
    public Button btnComp;
    internal Sprite defaultAnswer;
    internal object image;

    public void SetAnswerText(string content)
    {
        if(answerText)
           answerText.text = content;
       
    }

    
}
