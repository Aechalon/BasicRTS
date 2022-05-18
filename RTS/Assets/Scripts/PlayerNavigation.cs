using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavigation : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent navMeshAgent;
    public Animator anim;
    public Click click;
   
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        navMeshAgent = GetComponent<NavMeshAgent>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (click.selected)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {

                anim.SetBool("isRun", true);
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    navMeshAgent.SetDestination(hit.point);
                    


                }
              
            }
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                RaycastHit hit = new RaycastHit();
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {


                    if (hit.collider.gameObject != this.gameObject)
                    {
                        click.selected = false;

                    }
               
                  
                }
            }
              


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
}
