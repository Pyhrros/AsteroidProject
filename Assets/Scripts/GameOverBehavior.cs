using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverBehavior : MonoBehaviour
{
    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] private AsteroidSpawn asteroidSpawner;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private ScoreSystem scoreSystem;


    public void goToMainMenu(){
        SceneManager.LoadScene(0);
    }
    public void playAgain(){
        SceneManager.LoadScene(1);
    }

    public void endGame(){
        asteroidSpawner.enabled = false;
        GameOverScreen.gameObject.SetActive(true);
        int score = scoreSystem.endScore();
        scoreText.text = $"Final Score : {score}";
        
    }
}
