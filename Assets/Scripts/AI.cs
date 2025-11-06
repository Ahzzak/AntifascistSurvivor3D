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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PNG = PNGs[Random.Range(0, PNGs.Length)];
        _destination = Player_Controller.Instance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (navMeshAgent.enabled == true)
        {
            navMeshAgent.destination = _destination.position;
        }

    }
}