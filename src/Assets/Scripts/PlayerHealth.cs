using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameManager gameManager;
    [SerializeField] private int health = 3;
    public int Health => health;

    private void Start()
    {
        if (gameManager == null)
        {
            gameManager = FindFirstObjectByType<GameManager>();

            if (gameManager == null)
            {
                Debug.LogError("GameManager not found in the scene!");
            }
        }
    }

    public void LoseHealth(int amount)
    {
        health = Mathf.Max(0, health - amount);
        Debug.Log("Player Health: " + health);

        if (health <= 0)
        {
            gameManager.EndGame();
        }
    }

    public void MissedShot()
    {
        LoseHealth(1);
    }
}