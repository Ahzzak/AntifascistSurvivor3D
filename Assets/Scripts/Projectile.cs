using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject Target;
    public Rigidbody Brick;
    void Start()
    {
    }
    void OnCollisionEnter(Collision other)
    {
        Rigidbody p = Instantiate(Brick, transform.position, transform.rotation);
        Target = other.gameObject;
        if (Target.layer == 3)
        {
            Application.Quit();
        }
        if (Target.layer == 8)
        {
            Rigidbody TargetRigid = Target.GetComponent<Rigidbody>();
            TargetRigid.useGravity = false;
            TargetRigid.constraints = RigidbodyConstraints.None;
            TargetRigid.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
            Target.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            UnityEngine.Debug.Log("Meurt pourriture capitaliste");
            TargetRigid.useGravity = true;

        }
        if (Target.layer == 9)
        {
            Target.SendMessage("Hit", true);
        }
        Destroy(gameObject);


    }
}