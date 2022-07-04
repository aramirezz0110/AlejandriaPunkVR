using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
public class SceneAdmin : MonoBehaviour
{
    public static SceneAdmin Instance;
    bool vrEnabled;
    private void Awake()
    {
        

        //previous
        if(SceneManager.GetActiveScene().name == ProjectParams.MainMenuScene)
        {
            StartCoroutine(DisableVRView());
            vrEnabled =false;
        }else if(SceneManager.GetActiveScene().name == ProjectParams.LobbyScene )
        {
            //SceneManager.GetActiveScene().name == ProjectParams.LobbyScene
            StartCoroutine(EnableVRView());
            vrEnabled = true;
        }
    }
    private void Update()
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                LoadMainMenuScene();
            }
        }
        
    }
    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene(ProjectParams.MainMenuScene);
    }
    public void LoadLobbyScene()
    {
        SceneManager.LoadScene(ProjectParams.LobbyScene);
    }
    public void LoadTempleScene()
    {
        SceneManager.LoadScene(ProjectParams.TempleScene);
    }
    public void LoadTriviaScene()
    {
        SceneManager.LoadScene(ProjectParams.TriviaScene);
    }

    public IEnumerator DisableVRView()
    {
        print("VR disabled");
        XRSettings.LoadDeviceByName("None");  
        yield return null;      
        XRSettings.enabled = false;
    }
    public void EnableVR()
    {
        StartCoroutine(EnableVRView());
    }
    private IEnumerator  EnableVRView()
    {
        print("VR enabled");
        XRSettings.LoadDeviceByName("Cardboard");  
        yield return null;      
        XRSettings.enabled = true;
    }
}

