using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //Health
    [SerializeField] Image[] hearts;
    [SerializeField] AudioClip heartSound;
    private int numberOfHearts;
    private int heartIndex;

    [SerializeField] private AudioSource gameAudio;
    [SerializeField] GameObject heartParticle;
    GameManager gameManager;
    Vector3 particalPosition;
    Vector3 particalPositionOffset;
    

    // Start is called before the first frame update
    void Start()
    {
        heartIndex = 0;
        numberOfHearts = 3;
        gameManager = FindObjectOfType<GameManager>();
        //particalPositionOffset = new Vector3(0.5f, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        particalPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(hearts[heartIndex]);
            gameAudio.PlayOneShot(heartSound, 1f);
            StartCoroutine(StartParticleEffect());
            heartIndex++;
            numberOfHearts--;

            if (heartIndex == 3)
            {
                gameManager.Restart();
            }
        }
    }

    IEnumerator StartParticleEffect()
    {
        GameObject partical = Instantiate(heartParticle, particalPosition, Quaternion.identity);
        yield return new WaitForSeconds(2f);
        Destroy(partical);
    }


}
