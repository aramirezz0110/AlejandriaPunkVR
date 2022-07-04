using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CluesInRollerCoaster : MonoBehaviour
{
    [SerializeField] private Trivia trivia;
    public List<GameObject> clues =new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        HiddeAllClues();
        ShowCluesInScene();
        SetCluesInSigns();
    }
    void ShowCluesInScene()
    {
        int showRandomClues = Random.Range(0,2);
        if(showRandomClues==0)
            ShowPairClues();
        else if (showRandomClues==1)
            ShowUnpairClues();
    }
    void ShowPairClues()
    {
        int index = 0;
        foreach(GameObject clue in clues)
        {
            if(index%2==0)
            {
                clue.SetActive(true);
            }
            index ++;
        }    
    }
    void ShowUnpairClues()
    {
        int index = 0;
        foreach(GameObject clue in clues)
        {
            if(index%2!=0)
            {
                clue.SetActive(true);
            }
            index++;
        }    
    }
    void HiddeAllClues()
    {
        foreach(GameObject clue in clues)
        {
            clue.SetActive(false);
        }
    }
    void SetCluesInSigns()
    {
        int index = 0;
        TMP_Text temp;
        foreach(GameObject clue in clues)
        {
            temp = clue.GetComponentInChildren<TMP_Text>();
            temp.text = trivia.GetTriviaModel(index).CorrectAnswer;
            index++;
        }
    }
    
}
