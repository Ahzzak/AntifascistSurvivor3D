using UnityEngine;

public class Censure : MonoBehaviour
{
    public static Censure Instance;
    public bool Censure_State;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    public void ChangeCensure()
    {
        if (Censure_State == true)
        {
            Censure_State = false;
            UnityEngine.Debug.Log("Censure is false");
        }
        else
        {
            Censure_State = true;
            UnityEngine.Debug.Log("Censure is true");
        }
    }
}
