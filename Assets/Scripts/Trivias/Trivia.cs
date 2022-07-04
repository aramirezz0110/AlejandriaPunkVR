using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Trivia", menuName ="Scriptable/Trivia",order =1)]
public class Trivia : ScriptableObject
{
    [SerializeField] private string BookName;
    [SerializeField] private string Author;
    [SerializeField] private List<TriviaModel> questions = new List<TriviaModel>();

    public TriviaModel GetTriviaModel(int index)
    {
        return questions[index];
    }
    public string GetAuthor()
    {
        return Author;
    }
    public string GetBookName()
    {
        return BookName;
    }

}
[Serializable]
public class TriviaModel
{    
    public string Question;
    public string CorrectAnswer;
    public string IncorrectAnswer1;
    public string IncorrectAnswer2;
}