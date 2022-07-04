namespace UIMenus
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI; 
    using Interfaces;
    using Managers;

    public class PauseMenu : MonoBehaviour, IUIMenu
    {
        [SerializeField]
        private MenuName menuName = Interfaces.MenuName.Default; 

        [SerializeField]
        private Button continueButton = null;

        [SerializeField]
        private Button mainMenuButton = null;

        [SerializeField]
        private Button settingsButton = null;

        [SerializeField]
        private CanvasGroup pauseMenuCanvasGroup = null;

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

        #region UnityMethods

        private void OnEnable()
        {
            continueButton.onClick.AddListener(OnContinueButtonPressed);
            mainMenuButton.onClick.AddListener(OnMainMenuButtonPressed);
            settingsButton.onClick.AddListener(OnSettingsButtonPressed); 
        }

        private void OnDisable()
        {
            continueButton.onClick.RemoveListener(OnContinueButtonPressed);
            mainMenuButton.onClick.RemoveListener(OnMainMenuButtonPressed);
            settingsButton.onClick.RemoveListener(OnSettingsButtonPressed); 
        }

        #endregion

        private void OnContinueButtonPressed()
        {
            UIManager.Instance.HideMenu(this);
            UIManager.Instance.ShowMenu(UIManager.Instance.GetUIMenu(MenuName.HUD)); 
        }

        private void OnMainMenuButtonPressed()
        {
            pauseMenuCanvasGroup.interactable = false;
            GameManager.Instance.LoadScene(SceneNames.MAIN_MENU, OnSceneLoadingComplete: asyncOperation =>
            {
                UIManager.Instance.HideMenu(this); 
            });
        }

        private void OnSettingsButtonPressed()
        {
            UIManager.Instance.HideMenu(this);
            UIManager.Instance.ShowMenu(UIManager.Instance.GetUIMenu(MenuName.Settings)); 
        }
    }
}
