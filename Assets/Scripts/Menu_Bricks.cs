using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Menu_Bricks : MonoBehaviour
{
    public GameObject Brick;
    void Start()
    {
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
 yield return new WaitForSeconds(0.25f);
      Vector3 Spawner = Random.insideUnitSphere * 20;
        Spawner = new Vector3(Spawner.x, 8, 0);
        UnityEngine.Quaternion RandQ = UnityEngine.Quaternion.Euler(Random.Range(0, 90), Random.Range(0, 90), Random.Range(0, 90));
            Instantiate(Brick, Spawner, RandQ);
            StartCoroutine(Spawn());
    }
}
