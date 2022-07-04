namespace UIMenus
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI; 
    using Interfaces;
    using Managers;

    public class SettingsMenu : MonoBehaviour, IUIMenu
    {
        [SerializeField]
        private MenuName menuName = MenuName.Default; 

        [SerializeField]
        private Slider volumeSlider = null;

        [SerializeField]
        private Button backButton = null; 

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
            backButton.onClick.AddListener(OnBackButtonPressed); 
        }

        private void OnDisable()
        {
            backButton.onClick.RemoveListener(OnBackButtonPressed); 
        }

        #endregion

        private void OnBackButtonPressed()
        {
            UIManager.Instance.HideMenu(this);
            UIManager.Instance.ShowMenu(UIManager.Instance.GetUIMenu(MenuName.MainMenu)); 
            //TODO: Add the functionality for saving the volume settings 
        }
    }
}
