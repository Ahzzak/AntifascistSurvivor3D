using UnityEngine;
using TMPro;
public class Brick : MonoBehaviour
{
    public TMP_Text Ui;
    public void PickUp()
    {
        Data.Instance.Ammo += 1;
        Destroy(gameObject);
    }
}