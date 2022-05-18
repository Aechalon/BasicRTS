using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public HeatMapManager hmManager;
    public Animator anim;

    public Rigidbody enemyRigidBody;
    public NavMeshAgent navMeshAgent;

    public GameObject player;

    public int whatHeatMap;
    public GameObject setUpHmA;
    public GameObject setUpHmB;
    public GameObject setUpHmC;

    public bool isEnemyActive = false;

    public int box1;
    public int box2;
    public int box3;

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");

        box1 = PlayerPrefs.GetInt("p_box1");
        box2 = PlayerPrefs.GetInt("p_box2");
        box3 = PlayerPrefs.GetInt("p_box3");

        if (box1 > box2 && box1 > box3)
        {
            whatHeatMap = 1;
            Debug.Log("Box 1");
        }
        else if (box2 > box1 && box2 > box3)
        {
            whatHeatMap = 2;
            Debug.Log("Box 2");
        }
        else if (box3 > box1 && box3 > box2)
        {
            whatHeatMap = 3;
            Debug.Log("Box 3");
        }
        else
        {
            whatHeatMap = Random.Range(1, 4);
            Debug.Log("Random");
        }
    }

    // Update is called once per frame
    void Update()
    {

        box1 = PlayerPrefs.GetInt("p_box1");
        box2 = PlayerPrefs.GetInt("p_box2");
        box3 = PlayerPrefs.GetInt("p_box3");


        if (isEnemyActive)
        {
            navMeshAgent.SetDestination(player.transform.position);
            anim.SetBool("isRun", true);
        }
        else
        {
            switch (whatHeatMap)
            {
                case 1:
                    navMeshAgent.SetDestination(setUpHmA.transform.position);
                    anim.SetBool("isRun", true);
                    break;
                case 2:
                    navMeshAgent.SetDestination(setUpHmB.transform.position);
                    anim.SetBool("isRun", true);
                    break;
                case 3:
                    navMeshAgent.SetDestination(setUpHmC.transform.position);
                     anim.SetBool("isRun", true);
                    break;
            }
        }

        if (box1 > box2 && box1 > box3)
        {
            whatHeatMap = 1;
            Debug.Log("Box 1");
        }
        else if (box2 > box1 && box2 > box3)
        {
            whatHeatMap = 2;
            Debug.Log("Box 2");
        }
        else if (box3 > box1 && box3 > box2)
        {
            whatHeatMap = 3;
            Debug.Log("Box 3");
        }
        if (!navMeshAgent.pathPending)
        {
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                if (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f)
                {

                    anim.SetBool("isRun", false);
                }

            }

        }

    }

    private void OnTriggerEnter(Collider actor)
    {
        if (actor.gameObject.CompareTag("Player"))
        {
            isEnemyActive = true;
        }
    }

    private void OnTriggerExit(Collider actor)
    {
        if (actor.gameObject.CompareTag("Player"))
        {
            isEnemyActive = false;
        }
    }
}

