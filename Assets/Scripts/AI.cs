using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class AgentBehavior : MonoBehaviour
{
    public Transform _destination;
    public RawImage Image = null;
    public Texture2D[] PNGs;
    public Texture2D PNG = null;
    public NavMeshAgent navMeshAgent;
    private bool IsHitting;
    private bool IsDead = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PNG = PNGs[Random.Range(0, PNGs.Length)];
        _destination = Player_Controller.Instance.transform;
        UnityEngine.Debug.Log(Censure.Instance.Censure_State);
        bool IsCensure = Censure.Instance.Censure_State;
        UnityEngine.Debug.Log("Censure?" + IsCensure);
        Image.texture = PNG;
        if (IsCensure == true)
        {
            Image.color = new Color(0, 0, 0);
            UnityEngine.Debug.Log("CEST UNE ATTEINTE A LA LIBERTE DEXPRESSION");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (navMeshAgent.enabled == true)
        {
            navMeshAgent.destination = _destination.position;
        }
    }
    public void Hit()
    {
        IsDead = true;
        transform.rotation = new Quaternion(45, 45, 45, 45);
         Rigidbody TargetRigid = GetComponent<Rigidbody>();
            TargetRigid.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        }
    public void OnTriggerStay(Collider other)
    {
        if (IsDead != true)
        {
            if (other.gameObject.layer == 3)
            {
                if (IsHitting != true)
                {
                    StopCoroutine("AttackDelay");
                    StartCoroutine("AttackDelay");
                    IsHitting = true;
                }
            }
        }

    }
    void OnTriggerExit(Collider other)
    {
    }
    
    IEnumerator AttackDelay()
  {
    Data.Instance.SendMessage("PlayerDamaged");
    UnityEngine.Debug.Log("Ouille" + Data.Instance.Hp);
    yield return new WaitForSeconds(2);
    IsHitting = false;
  }
    }