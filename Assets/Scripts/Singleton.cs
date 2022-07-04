namespace Managers
{
    using UnityEngine;
    
    public abstract class MonoSingleton<T>:MonoBehaviour where T:MonoSingleton<T>, new()  
    {
        private static T instance; 
        public static T Instance
        {
            get
            {
                if(instance == null)
                {
                    GameObject singletonGO = new GameObject($"{typeof(T)}"); 
                    singletonGO.AddComponent<T>();
                    Debug.LogWarning($"[{typeof(T)}] - is null, creating a new instance of it.");
                }
                return instance; 
            }
        }

        #region UnityMethods

        private void Awake()
        {
            instance = this as T;
            Init(); 
        }

        #endregion

        /// <summary>
        /// This method is called on the awake call of the object in unity.
        /// </summary>
        protected virtual void Init()
        {

        }
    }
}
