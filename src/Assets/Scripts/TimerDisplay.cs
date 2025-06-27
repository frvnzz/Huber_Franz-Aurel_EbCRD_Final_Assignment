using UnityEngine;
using TMPro;

public class TimerDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;

    private void Update()
    {
        if (Timer.Instance != null)
        {
            float time = Mathf.Max(0, Timer.Instance.timeRemaining);
            int minutes = Mathf.FloorToInt(time / 60F);
            int seconds = Mathf.FloorToInt(time % 60F);
            timerText.text = $"{minutes:00}:{seconds:00}";
        }
    }
}