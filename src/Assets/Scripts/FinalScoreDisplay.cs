using UnityEngine;
using TMPro;

public class FinalScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalScoreText;

    void Start()
    {
        if (finalScoreText != null)
        {
            finalScoreText.text = "Final Score: " + ScoreManager.lastScore;
        }
    }
}