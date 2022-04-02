using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    Rigidbody enemyRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody>();
        enemyRigidbody.velocity = new Vector3(moveSpeed, 0, 0);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "BoxColliderEnemy")
        {
            Debug.Log("Collided");
            //enemyRigidbody.velocity = new Vector3(-moveSpeed, 0, 0);
            moveSpeed *= -1;
            enemyRigidbody.velocity = new Vector3(moveSpeed, 0, 0);
            Debug.Log($"{enemyRigidbody.velocity}");
        }
    }
}
