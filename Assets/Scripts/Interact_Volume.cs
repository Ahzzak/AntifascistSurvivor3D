using UnityEngine;

public class Interact_Volume : MonoBehaviour
{
    public GameObject InteractBuffer;

    void Start()
    {
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            InteractBuffer = other.gameObject;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject == InteractBuffer)
        {
            InteractBuffer = null;
        }
    }
}