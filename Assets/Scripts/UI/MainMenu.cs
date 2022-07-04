namespace UIMenus
{
    using UnityEngine;
    using UnityEngine.UI; 
    using Managers;
    using Interfaces; 

    public class MainMenu : MonoBehaviour, IUIMenu
    {
        [SerializeField]
        private MenuName menuName = MenuName.Default;

        [SerializeField]
        private CanvasGroup menuCanvasGroup = null;

        [SerializeField]
        private Button startButton = null;

        [SerializeField]
        private Button scoreButton = null;

        [SerializeField]
        private Button settingsButton = null;

        #region UnityMethods

        private void Awake()
        {
            GameManager.Instance.OnNewSceneLoaded += OnNewSceneLoaded; 
        }

        private void Start()
        {
            UIManager.Instance.ShowMenu(this); 
        }

        private void OnDestroy()
        {
            GameManager.Instance.OnNewSceneLoaded -= OnNewSceneLoaded; 
        }

        private void OnEnable()
        {
            startButton.onClick.AddListener(OnStartButtonPressed);
            scoreButton.onClick.AddListener(OnScoreButtonPressed);
            settingsButton.onClick.AddListener(OnSettingsButtonPressed); 
        }

        private void OnDisable()
        {
            startButton.onClick.RemoveListener(OnStartButtonPressed);
            scoreButton.onClick.RemoveListener(OnScoreButtonPressed);
            settingsButton.onClick.RemoveListener(OnSettingsButtonPressed); 
        }

        #endregion UnityMethods 

        #region IUIMenu

        public MenuName MenuName => menuName;

        public void DisableMenu()
        {
            gameObject.SetActive(false);
        }

        public void EnableMenu()
        {
            gameObject.SetActive(true); 
        }

        #endregion

        private void OnStartButtonPressed()
        {
            menuCanvasGroup.interactable = false; 
            GameManager.Instance.LoadScene(SceneNames.LOBBY, OnSceneLoadingComplete: asyncOperation =>
            {
                UIManager.Instance.HideMenu(this);
            });
        }

        private void OnScoreButtonPressed()
        {
            //TODO: Program functionality of the score button
        }

        private void OnSettingsButtonPressed()
        {
            UIManager.Instance.HideMenu(this); 
            UIManager.Instance.ShowMenu(UIManager.Instance.GetUIMenu(MenuName.Settings)); 
        }

        private void OnNewSceneLoaded(string sceneName)
        {
            if (sceneName != SceneNames.MAIN_MENU) return; 
            
            menuCanvasGroup.interactable = true;
            UIManager.Instance.ShowMenu(this);
        }
    }
}
