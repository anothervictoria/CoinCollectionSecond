using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [HideInInspector] public List<GameObject> coins;
        
    [SerializeField] float coinRotateSpeed = 5f;
    

    // Start is called before the first frame update
    void Start()
    {
        
        coins = new List<GameObject>(GameObject.FindGameObjectsWithTag("Coin"));
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject c in coins)
        {
            c.gameObject.transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime * coinRotateSpeed);
        }
    }
}
