using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] GameObject shooterEnemy;
    [SerializeField] GameObject target;
    void Start()
    {
        shooterEnemy.transform.LookAt(target.transform);
    }

    // Update is called once per frame
    void Update()
    {
        shooterEnemy.transform.LookAt(target.transform);
    }
}
