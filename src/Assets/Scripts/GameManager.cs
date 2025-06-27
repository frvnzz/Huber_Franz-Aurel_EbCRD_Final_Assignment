using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public TargetSpawner targetSpawner;
    // public ScoreManager scoreManager;
    [Header("Game Settings")]
    public int startingScore = 0;
    public float gameDuration = 60f; // in seconds
    void Start()
    {
        StartGame();
    }
    public void StartGame()
    {
        if (ScoreManager.Instance != null)
            ScoreManager.Instance.score = startingScore;
        if (targetSpawner != null)
            targetSpawner.SpawnTarget();
        if (Timer.Instance != null)
            Timer.Instance.StartTimer(gameDuration);
    }
    public void ResetGame()
    {
        StartGame();
    }
    public void EndGame()
    {
        Debug.Log("Final Score: " + ScoreManager.Instance.score);
        ScoreManager.lastScore = ScoreManager.Instance.score;
        StartCoroutine(DelayedGameOverLoad());
    }

    private IEnumerator DelayedGameOverLoad()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        SceneManager.LoadSceneAsync("GameOver");
    }
}