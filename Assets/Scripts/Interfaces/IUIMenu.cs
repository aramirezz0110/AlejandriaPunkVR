namespace Interfaces
{
    public interface IUIMenu
    {
        MenuName MenuName { get; }
        void EnableMenu();
        void DisableMenu(); 
    }

    public enum MenuName
    {
        Default,
        MainMenu,
        PuaseMenu,
        HUD,
        Settings
    }
}
