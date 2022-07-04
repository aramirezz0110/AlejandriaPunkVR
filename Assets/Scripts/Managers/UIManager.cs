namespace Managers
{
    using System.Collections.Generic;
    using Interfaces;
    using UnityEngine;

    public class UIManager : MonoSingleton<UIManager>
    {
        [SerializeField]
        private Transform uiMenusContainer; 

        private readonly Dictionary<MenuName,IUIMenu> uiMenus = new Dictionary<MenuName, IUIMenu>(); 

        protected override void Init()
        {
            base.Init();
            DontDestroyOnLoad(gameObject); 
            
            foreach(Transform child in uiMenusContainer)
            {
                IUIMenu uiMenu = child.gameObject.GetComponent<IUIMenu>();
                
                if (uiMenu == null) continue; 
                
                uiMenus.Add(uiMenu.MenuName, uiMenu); 
            }
        }

        public void ShowMenu(IUIMenu uiMenu)
        {
            if (uiMenu == null) 
            {
                Debug.LogError($"{typeof(UIManager)} - The {uiMenu.MenuName} does not exist, please add one as child of the container game object.");
                return; 
            }
            uiMenu.EnableMenu(); 
        }

        public void HideMenu(IUIMenu uiMenu)
        {
            if (uiMenu == null)
            {
                Debug.LogError($"{typeof(UIManager)} - The {uiMenu.MenuName} does not exist, please add one as child of the container game object.");
                return; 
            }

            uiMenu.DisableMenu(); 
        }

        public IUIMenu GetUIMenu(MenuName name)
        {
            if (!uiMenus.ContainsKey(name)) return null; 

            return uiMenus[name]; 
        }
    }
}
