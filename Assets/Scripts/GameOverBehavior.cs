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


    public void GoToMainMenu(){
        SceneManager.LoadScene(0);
    }
    public void PlayAgain(){
        SceneManager.LoadScene(1);
    }

    public void EndGame(){
        asteroidSpawner.enabled = false;
        GameOverScreen.gameObject.SetActive(true);
        int score = scoreSystem.EndScore();
        scoreText.text = $"Final Score : {score}";
        
    }
}
