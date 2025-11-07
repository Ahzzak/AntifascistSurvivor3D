using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class RandomAI : MonoBehaviour
{

    NavMeshAgent navMeshAgent;
    NavMeshPath path;
    public float timeForNewPath;
    public bool angry = false;
    bool inCoRoutine;
    Vector3 target;
    bool validPath;
    public Texture2D[] PNGs;
    public Texture2D PNG;
    public RawImage Image;


    // Use this for initialization
    void Start()
    {
        PNG = PNGs[Random.Range(0, PNGs.Length)];
        Image.texture = PNG;
        navMeshAgent = GetComponent<NavMeshAgent>();
        path = new NavMeshPath();
    }

    // Update is called once per frame
    void Update()
    {
         if (angry == true)
        {
            transform.LookAt(Player_Controller.Instance.transform.position);
        }
        if (!inCoRoutine)
            StartCoroutine(DoSomething());
        
    }
    Vector3 getNewRandomPosition()
    {
        float x = Random.Range(-40, 40);
        //   float y = Random.Range(-20, 20); I'm not sure if I should also use Y or not for going to other floors :/
        float z = Random.Range(-40, 40);
        Vector3 pos = new Vector3(x, 0, z);
        return pos;

    }
    IEnumerator DoSomething()
    {
        inCoRoutine = true;
        yield return new WaitForSeconds(timeForNewPath);
        GetNewPath();
        validPath = navMeshAgent.CalculatePath(target, path);
        if (!validPath) Debug.Log("found invalid path");
        while (!validPath)
        {
            yield return new WaitForSeconds(0.01f);
            GetNewPath();
            validPath = navMeshAgent.CalculatePath(target, path);
        }

        inCoRoutine = false;
    }
    void GetNewPath()
    {
            target = getNewRandomPosition();
            navMeshAgent.SetDestination(target);
    }
    public void Hit(bool angrymsg)
    {
        angry = angrymsg;
        GetNewPath();
        StartCoroutine(Calm());
    }

    IEnumerator Calm()
    {
        yield return new WaitForSeconds(5f);
        angry = false;
    }
}