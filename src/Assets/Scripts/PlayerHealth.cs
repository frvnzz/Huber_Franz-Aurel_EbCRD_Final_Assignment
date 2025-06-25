using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameManager gameManager;
    [SerializeField] private int health = 3;

    public void LoseHealth(int amount)
    {
        health -= amount;
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