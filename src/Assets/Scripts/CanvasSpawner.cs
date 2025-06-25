using UnityEngine;

public class CanvasSpawner : MonoBehaviour
{
    [Header("Settings")]

    [Tooltip("Canvas prefab for UI spawned at start.")]
    [SerializeField]
    private GameObject canvasPrefab;

    private void Awake()
    {
        Instantiate(canvasPrefab);
    }
}