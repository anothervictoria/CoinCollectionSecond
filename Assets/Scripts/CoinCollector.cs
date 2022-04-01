using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] ParticleSystem particleSystem;
    public CoinController coinController;
    public GameManager gameManager;

    private void Reset()
    {
        audioSource = GetComponent<AudioSource>();
        particleSystem = GetComponentInChildren<ParticleSystem>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coinController.coins.Remove(other.gameObject);
            audioSource.Play();
            particleSystem.Play();
            gameManager.UpdateScore();
        }
        if (other.gameObject.CompareTag("KillZone"))
        {
            gameManager.PlayerDie();
            gameManager.PlayerAudio();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Moving")
        {
            this.gameObject.transform.parent = collision.gameObject.transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Moving")
        {
            this.gameObject.transform.parent = null;
        }
    }
}
