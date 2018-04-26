﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Game : MonoBehaviour
{
	[SerializeField] int score = 0; // todo private

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading; // always unsubscribe
    }

	void Start()
    {
        SetupSingleton();
	}

    private void SetupSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
	
    public int GetScore()
    {
        return score;
    }

	public void Score(int points)
    {
		score += points;
	}

    private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0) // TODO consier even more robust
        {
            score = 0;
        }
    }
}