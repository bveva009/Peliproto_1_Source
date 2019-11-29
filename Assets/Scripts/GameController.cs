using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject Player, gameoverText, retryText, FailScreen, YesText, NoText;
    public int lives = 3, score = 0;
    public Text scoreText, lifeText;
    bool GameOver = false;
    public GameObject Explosion;
    public AudioSource ExplosionSound;

    private void Start()
    {
        lifeText.text = "Lives: " + lives.ToString();
        scoreText.text = "Score: " + score.ToString();
        ExplosionSound = GetComponent<AudioSource>();
    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
    }
    public void UpdateLives()
    {
        lives--;
        lifeText.text = "Lives: " + lives.ToString();
    }

    private void Update()
    {
        if (lives <= 0 && !GameOver)
        {
            GameOver = true;
            Debug.Log("GAME OVER");
            GameObject Spawner = GameObject.FindGameObjectWithTag("Car Spawner");
            Spawner.SetActive(false);
            GameObject[] Cars = GameObject.FindGameObjectsWithTag("Car");
            for (int i = 0; i < Cars.Length; i++)
            {
                Destroy(Cars[i].gameObject);
                GameObject carexplosion = Instantiate(Explosion, Cars[i].gameObject.transform.position, Player.gameObject.transform.rotation);
                ExplosionSound.Play();
                Destroy(carexplosion.gameObject, 3.9f);
            }
            GameObject explosion = Instantiate(Explosion, Player.gameObject.transform.position, Player.gameObject.transform.rotation);
            ExplosionSound.Play();
            Destroy(Player.gameObject);
            Destroy(explosion.gameObject, 3.9f);
            gameoverText.SetActive(true);
            retryText.SetActive(true);
            FailScreen.SetActive(true);
            YesText.SetActive(true);
            NoText.SetActive(true);
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }
}
