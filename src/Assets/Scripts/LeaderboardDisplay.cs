using UnityEngine;
using TMPro;

public class LeaderboardDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI leaderboardText;

    void Start()
    {
        var data = LeaderboardManager.Load();
        leaderboardText.text = "Highscores\n";
        int rank = 1;
        foreach (var entry in data.entries)
        {
            leaderboardText.text += $"{rank}. {entry.score} ({entry.timestamp})\n";
            rank++;
        }
    }
}