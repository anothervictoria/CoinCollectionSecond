using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTile : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(direction * Time.deltaTime * speed, 0, 0);
        if (gameObject.transform.position.x >= 5)
        {
            direction = -1;
        }
        if (gameObject.transform.position.x <-5)
        {
            direction = 1;
        }
    }
}
