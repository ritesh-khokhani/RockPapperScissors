using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                T[] objects = FindObjectsOfType<T>();

                if (objects.Length == 0)
                {
                    GameObject singleton = new GameObject($"{typeof(T).Name}(Singleton)");
                    instance = singleton.AddComponent<T>();
                }
                else
                {
                    instance = objects[0];
                    for (int i = 1; i < objects.Length; i++)
                        Destroy(objects[i].gameObject); // Ensure there is only one instance
                }
            }
            return instance;
        }
    }

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
}
