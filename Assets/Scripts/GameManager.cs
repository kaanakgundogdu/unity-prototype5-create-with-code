﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    public Button restartButton;
    public Button quitButton;
    public GameObject titleScreen;
    public static bool isGameActive;
    private int score;
    private float spawnRate = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0,targets.Count);
            Instantiate(targets[index]);
        }
    }
    public void UpdateScore(int scoreToAdd)
    {
        score +=scoreToAdd;
        scoreText.text= "Score: "+ score;
    }
    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true); 
        isGameActive=false;
        
    }

    public void RestartGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {

        SceneManager.LoadScene(0);
    }


    public void StartGame(int difficulty)
    {
        isGameActive=true;
        score=0;

        spawnRate /= difficulty;

        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
    }
}