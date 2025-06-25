using UnityEngine;
public class GameManager : MonoBehaviour
{
    public TargetSpawner targetSpawner;
    public ScoreManager scoreManager;
    [Header("Game Settings")]
    public int startingScore = 0;
    void Start()
    {
        StartGame();
    }
    public void StartGame()
    {
        if (scoreManager != null)
            scoreManager.score = startingScore;
        if (targetSpawner != null)
            targetSpawner.SpawnTarget();
    }
    public void ResetGame()
    {
        StartGame();
    }
    public void EndGame()
    {
        Debug.Log("Game Over! Final Score: " + scoreManager.score);
    }
}