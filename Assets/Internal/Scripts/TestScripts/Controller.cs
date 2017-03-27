using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    public bool dontDestroyOnLoad;

    private void Awake()
    {
        if (!dontDestroyOnLoad)
            return;

        if (FindObjectsOfType(GetType()).Length > 1)
            Destroy(this.gameObject);
        else
        {
            this.transform.SetParent(null);
            DontDestroyOnLoad(this.gameObject);
        }
    }
}