using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject Target;
    public Rigidbody Brick;
    public ParticleSystem Blood;
    private bool Doonce = false;
    void Start()
    {
    }
    void OnCollisionEnter(Collision other)
    {
        if (Doonce != true)
        {
            Doonce = true;
            Rigidbody p = Instantiate(Brick, transform.position, transform.rotation);
        }
                 Target = other.gameObject;
            if (Target.layer == 3)
            {
                Application.Quit();
            }
            if (Target.layer == 8)
            {
                Instantiate(Blood, transform.position, transform.rotation);
                Target.SendMessage("Hit", true);
            }
            if (Target.layer == 9)
            {
                Target.SendMessage("Hit", true);
            }
            Destroy(gameObject);
        


    }
}