using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class Data : MonoBehaviour
{
    public Image Ui_Hp;
    public TMP_Text Ui_text;
    public TMP_Text Ui_Score;
    public int Ammo = 0;
    public static Data Instance;
    public GameObject Brick;
    public GameObject Capitalist;
    public GameObject Civilian;
    public float Hp;
    public float Hp_Max = 100;
    float Width = 1;
    float Difficulty = 1;
    public float Score = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void FixedUpdate()
    {
        Ui_text.text = "" + Ammo;
        Ui_Score.text = "" + Score;
        Ui_Hp.GetComponent<Image>().fillAmount = Width;        
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
            Vector3 Spawner = Random.insideUnitSphere * 40;
            Spawner = new Vector3(Spawner.x, 2, Spawner.z);
            Instantiate(Brick, Spawner, Quaternion.identity);
        }
        for (var i = 0; i < 10; i++)
        {
            Vector3 Spawner = Random.insideUnitSphere * 40;
            Spawner = new Vector3(Spawner.x, 2, Spawner.z);
            Instantiate(Civilian, Spawner, Quaternion.identity);
        }
        StartCoroutine(SpawnCapitalists());
        StartCoroutine(IncreaseDifficulty());
    }
    IEnumerator SpawnCapitalists()
    {
        yield return new WaitForSeconds(5f);
        for (var i = 0; i < Difficulty; i++)
        {
            Vector3 Spawner = Random.insideUnitSphere * 40;
            Spawner = new Vector3(Spawner.x, 2, Spawner.z);
            Instantiate(Capitalist, Spawner, Quaternion.identity);
        }
        StartCoroutine(SpawnCapitalists());
    }
    IEnumerator IncreaseDifficulty()
    {
        yield return new WaitForSeconds(45f);
        Difficulty += 1;
        UnityEngine.Debug.Log("Difficulty : " + Difficulty);
        StartCoroutine(IncreaseDifficulty());
        for (var i = 0; i < Difficulty * 2; i++)
        {
            Vector3 Spawner = Random.insideUnitSphere * 40;
            Spawner = new Vector3(Spawner.x, 2, Spawner.z);
            Instantiate(Brick, Spawner, Quaternion.identity);
        }
    }
    public void PlayerDamaged()
    {
        Hp += -5;
        Width = (Hp / Hp_Max) * 1;
    }
}
