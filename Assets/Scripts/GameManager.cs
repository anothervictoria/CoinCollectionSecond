using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int scoreCount;
    public GameObject gameOver;
    public GameObject menuItems;
    private bool checkForPause;
    public TextMeshProUGUI gameOverText;
    public Camera freeLookCamera;
    public Camera multiRigCamera;
    [SerializeField] private AudioSource gameAudio;
    [SerializeField] public AudioClip deathAudio;

    //Health
    //[SerializeField] Image[] hearts;
    //[SerializeField] AudioClip heartSound;
    //private int numberOfHearts;
    //private int heartIndex;

    private void Reset()
    {
        gameAudio = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //heartIndex = 0;
        //numberOfHearts = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!checkForPause)
            {
                Paused();
                checkForPause = true;
            }
            else
            {
                Paused();
                checkForPause = false;
            }

        }
        if (scoreCount >= 3)
        {
            GameComplete();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            if(freeLookCamera.depth == 2)
            {
                freeLookCamera.depth = 1;
                multiRigCamera.depth = 2;
            }
            else
            {
                freeLookCamera.depth = 2;
                multiRigCamera.depth = 1;
            }
            
        }
    }

    public void UpdateScore()
    {
        scoreCount++;
        scoreText.text = $"Coins: {scoreCount}";
    }

    public void PlayerDie()
    {
        gameOver.SetActive(true);
        menuItems.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Paused()
    {
        if(Time.timeScale != 0)
        {
            Time.timeScale = 0;
            menuItems.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            menuItems.SetActive(false);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void GameComplete()
    {
        
         PlayerDie();
         gameOverText.text = "Level Completed!";
        
    }

    public void PlayerAudio()
    {
        gameAudio.PlayOneShot(deathAudio, 1f);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Enemy")
    //    {
    //        Destroy(other.gameObject);
    //        Destroy(hearts[heartIndex]);
    //        gameAudio.PlayOneShot(heartSound, 1f);
    //        heartIndex++;
    //        numberOfHearts--;

    //        if (heartIndex == 3)
    //        {
    //            Restart();
    //        }
    //    }
    //}

}
