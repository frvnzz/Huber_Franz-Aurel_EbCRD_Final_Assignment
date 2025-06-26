using UnityEngine;
using TMPro;

public class PlayerHealthDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;
    private PlayerHealth playerHealth;

    void Start()
    {
        if (playerHealth == null)
        {
            playerHealth = Object.FindFirstObjectByType<PlayerHealth>();
            if (playerHealth == null)
            {
                Debug.LogError("PlayerHealth not found in the scene!");
            }
        }
    }

    void Update()
    {
        if (playerHealth != null)
        {
            healthText.text = "Health: " + playerHealth.Health;
        }
    }
}