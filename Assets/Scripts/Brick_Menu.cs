using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Brick_Menu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Lifetime());
    }
    IEnumerator Lifetime()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }  
}
