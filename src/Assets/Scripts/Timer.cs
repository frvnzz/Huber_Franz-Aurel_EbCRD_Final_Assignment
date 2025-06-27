using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer Instance { get; private set; }

    public float timeRemaining;
    public bool timerIsRunning = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    public void StartTimer(float duration)
    {
        timeRemaining = duration;
        timerIsRunning = true;
    }

    private void Update()
    {
        if (!timerIsRunning)
            return;

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                timerIsRunning = false;
                OnTimerEnd();
            }
        }
    }

    private void OnTimerEnd()
    {
        var gameManager = FindFirstObjectByType<GameManager>();
        if (gameManager != null)
            gameManager.EndGame();
    }
}