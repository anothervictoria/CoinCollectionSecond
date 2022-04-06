using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    Rigidbody rb;
    NavMeshAgent pathFinder;
    Transform target;
    [SerializeField] float distanceToDash = 1.5f;
    [SerializeField] float dashSpeed = 30f;
    [SerializeField] float dashTimer;
    [SerializeField] float dashTime;
    float distance;
    bool canFollow = true;
    bool isFollowing = false;
    bool canDash;
    bool dashing;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pathFinder = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        dashing = false;
        StartCoroutine(Path());

    }



    private void Update()
    {
        transform.LookAt(target);
        distance = Vector3.Distance(target.position, transform.position);
        canDash = distance < distanceToDash;
        if (canDash && !dashing)
        {
            StartCoroutine(Dash());
            Debug.Log("candash = " + canDash);
        }
        else
        {
            // rb.velocity = Vector3.zero;
            Debug.Log("candash = " + canDash);
        }

    }

    private void FixedUpdate()
    {
        if (!isFollowing)
        {
            StartCoroutine(Path());

        }
    }

    IEnumerator Dash()
    {
        isFollowing = true;
        dashing = true;
        canFollow = false;
        Debug.Log("isdashing");

        rb.AddForce(transform.forward * dashSpeed * Time.deltaTime, ForceMode.VelocityChange);
        yield return new WaitForSeconds(dashTime);
        rb.velocity = Vector3.zero;
        yield return new WaitForSeconds(1f);
        isFollowing = false;
        canFollow = true;


        yield return new WaitForSeconds(dashTimer);
        dashing = false;





    }

    IEnumerator Path()
    {
        float refresh = 0.8f;
        while (target != null && canFollow)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, target.position.z);
            pathFinder.SetDestination(targetPosition);
            yield return new WaitForSeconds(refresh);
        }

    }

}
