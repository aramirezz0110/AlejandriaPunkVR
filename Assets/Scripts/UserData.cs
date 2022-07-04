using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.SceneManagement;
using TMPro;
public class UserData : MonoBehaviour
{
    public static UserData Instance;
    
    public TMP_Text scoreText;
    private void Awake()
    {
        Instance = this; 
    }
    private void Start()
    {
        if(SceneManager.GetActiveScene().name==ProjectParams.MainMenuScene)
        {
            scoreText.text = "Score: "+ GetPoints();
        }
    }
    public void SetPoints(int value)
    {
        int currentPoints = GetPoints();
        currentPoints +=value;
        PlayerPrefs.SetInt(ProjectParams.UserPoints, currentPoints);
    }
    public int GetPoints()
    {
        return PlayerPrefs.GetInt(ProjectParams.UserPoints, 0);
    }
    public void RestorePoints()
    {
        PlayerPrefs.SetInt(ProjectParams.UserPoints, 0);
        scoreText.text = "Score: "+ GetPoints();
    }
}
