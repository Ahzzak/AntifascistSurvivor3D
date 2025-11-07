using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class Data : MonoBehaviour
{
    public Image Ui_Hp;
    public TMP_Text Ui_text;
    public int Ammo = 0;
    public static Data Instance;
    public GameObject Brick;
    public GameObject Capitalist;
    public GameObject Civilian;
    public float Hp;
    public float Hp_Max = 100;
    float Width = 300;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void FixedUpdate()
    {
        Ui_text.text = "" + Ammo;
        Width = (Hp / Hp_Max) * Width;
        Ui_Hp.GetComponent<RectTransform>().sizeDelta = new Vector2(Width, 25);        
    }
    private void Start()
    {
        Hp = Hp_Max;
        if (Instance == null)
        {
            Instance = this;
        }
        for (var i = 0; i < 10; i++)
        {
            Vector3 Spawner = Random.insideUnitSphere * 50;
            Spawner = new Vector3(Spawner.x, 2, Spawner.z);
            Instantiate(Brick, Spawner, Quaternion.identity);
            UnityEngine.Debug.Log("brick");
        }
        for (var i = 0; i < 10; i++)
        {
            Vector3 Spawner = Random.insideUnitSphere * 50;
            Spawner = new Vector3(Spawner.x, 2, Spawner.z);
            Instantiate(Civilian, Spawner, Quaternion.identity);
            UnityEngine.Debug.Log("brick");
        }
        StartCoroutine(SpawnCapitalists());
    }
    IEnumerator SpawnCapitalists()
    {
    yield return new WaitForSeconds(5f);
    Vector3 Spawner = Random.insideUnitSphere * 50;
    Spawner = new Vector3(Spawner.x, 2, Spawner.z);
    Instantiate(Capitalist, Spawner, Quaternion.identity);
    UnityEngine.Debug.Log("Capitalist");
    StartCoroutine(SpawnCapitalists());
    }
}
