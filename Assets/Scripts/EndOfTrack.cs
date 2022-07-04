using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class EndOfTrack : MonoBehaviour
{
    public CinemachineDollyCart cart;
    public SceneAdmin sceneAdmin;
    public float limit =140f;
    public float waitTime = 5f;
    private void Update() 
    {
        print(cart.m_Position);  
        if(cart.m_Position>limit)
        {
            StartCoroutine(GoToTrivia());
        } 
    }
    IEnumerator GoToTrivia()
    {
        print("go to trivia");
        yield return new WaitForSeconds(waitTime);
        sceneAdmin.LoadTriviaScene();
    }
    
}
