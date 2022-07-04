using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TriviaController : MonoBehaviour
{
    public Trivia trivia;
    public TMP_Text triviaTitle;
    public TMP_Text questionTitle;
    public TMP_Text option1;
    public TMP_Text option2;
    public TMP_Text option3;

    public TMP_Text scoreText;
    [SerializeField] int questionsQuantity;
    [SerializeField]private string currentCorrectAnswer;
    [SerializeField] private string answerSelected;
    public SceneAdmin sceneAdmin;
    private int currentQuestion = 0;
    private int score=0;
    [SerializeField] List<TriviaModel> localQuestions=new List<TriviaModel>();
    // Start is called before the first frame update
    void Start()
    {
        triviaTitle.text = trivia.GetBookName();
        GetQuestions();
        LoadQuestionInCanvas(localQuestions[0]);
    }   
    
    void GetQuestions()
    {
        TriviaModel temp=null;
        for(int i=0; i<questionsQuantity; i++)
        {
            //temp = trivia.GetTriviaModel(Random.Range(0,questionsQuantity));
            temp = trivia.GetTriviaModel(i);
            localQuestions.Add(temp);
        }
    }
    void LoadQuestionInCanvas(TriviaModel questionGroup)
    {        
        questionTitle.text = questionGroup.Question;
        currentCorrectAnswer = questionGroup.CorrectAnswer;
        
        int randomPosition = Random.Range(0,3);
        switch(randomPosition)
        {
            case 0:
            {
                option1.text = questionGroup.CorrectAnswer;
                option2.text = questionGroup.IncorrectAnswer1;
                option3.text = questionGroup.IncorrectAnswer2;
                break;
            }
            case 1:
            {
                option1.text = questionGroup.IncorrectAnswer1;
                option2.text = questionGroup.CorrectAnswer;
                option3.text = questionGroup.IncorrectAnswer2;
                break;
            }
            case 2:
            {
                option1.text = questionGroup.IncorrectAnswer2;
                option2.text = questionGroup.IncorrectAnswer1;
                option3.text = questionGroup.CorrectAnswer;
                break;
            }
            default: break;
        }

        // option1.text = questionGroup.CorrectAnswer;
        // option2.text = questionGroup.IncorrectAnswer1;
        // option3.text = questionGroup.IncorrectAnswer2;
    }
    public void AnswerSelected(int index)
    {
        //print("Index: "+index);
        switch(index)
        {
            case 0:
            {
                //print("option1 selected");
                answerSelected = option1.text;
                break;
            }
            case 1:
            {
                //print("option1 selected");
                answerSelected = option2.text;
                break;
            }
            case 2:
            {
                //print("option1 selected");
                answerSelected = option3.text;
                break;
            }
            default: break;
        }
        if(answerSelected == currentCorrectAnswer){
            print("Correct!");
            score ++;
            scoreText.text = "Score: "+ score;           
        }
            
        else if(answerSelected != currentCorrectAnswer)
            print("Incorrect");

        NextQuestion();
    }
    void NextQuestion()
    {
        if(currentQuestion<questionsQuantity-1)
        {
            currentQuestion++;
            LoadQuestionInCanvas(localQuestions[currentQuestion]);
        }else
        {
            print("Trivia Finished!");
            UserData.Instance.SetPoints(score);
            sceneAdmin.LoadMainMenuScene();
        }
    }

}
