namespace Managers
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement; 
    
    public class GameManager : MonoSingleton<GameManager>
    {
        public string CurrentScene { get { return currentScene; } }
        public Action<string> OnNewSceneLoaded; 

        private string currentScene = String.Empty;
        private string lastSceneLoaded = String.Empty; 
        private readonly List<AsyncOperation> asyncOperations = new List<AsyncOperation>();

        protected override void Init()
        {
            base.Init();
            DontDestroyOnLoad(gameObject);
            currentScene = SceneManager.GetActiveScene().name;
        }

        public void LoadScene(string sceneName, Action<AsyncOperation> OnSceneLoadingComplete = null)
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            asyncOperations.Add(asyncOperation);
            asyncOperation.completed += OnSceneLoaded;
            lastSceneLoaded = currentScene;
            currentScene = sceneName;

            if (OnSceneLoadingComplete == null) return; 
            asyncOperation.completed += OnSceneLoadingComplete;
        }

        private void OnSceneLoaded(AsyncOperation asyncOperation)
        {
            if(asyncOperations.Contains(asyncOperation))
            {
                asyncOperations.Remove(asyncOperation); 
            }

            UnloadScene(lastSceneLoaded); 
            OnNewSceneLoaded(currentScene); 
            Debug.Log($"The {currentScene} scene has been loaded successfully."); 
        }

        public void UnloadScene(string sceneName, Action<AsyncOperation> OnSceneUnloadingCompleted = null)
        {
            AsyncOperation asyncOperation = SceneManager.UnloadSceneAsync(sceneName);
            asyncOperations.Add(asyncOperation);
            asyncOperation.completed += OnSceneUnloaded;
            
            if (OnSceneUnloadingCompleted == null) return; 
            asyncOperation.completed += OnSceneUnloadingCompleted; 
        }

        private void OnSceneUnloaded(AsyncOperation asyncOperation)
        {
            if(asyncOperations.Contains(asyncOperation))
            {
                asyncOperations.Remove(asyncOperation); 
            }

            SceneManager.SetActiveScene(SceneManager.GetSceneByName(currentScene)); 
            Debug.Log($"The {lastSceneLoaded} scene has been unloaded succesfully"); 
        }
    }

    public static class SceneNames
    {
        public const string MAIN_MENU = "MainMenu";
        public const string LOBBY     = "Lobby"; 
    }
}
