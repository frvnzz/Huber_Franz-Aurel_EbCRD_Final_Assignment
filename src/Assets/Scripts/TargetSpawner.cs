using UnityEngine;
using System.Collections.Generic;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab;
    public Vector3 spawnAreaMin;
    public Vector3 spawnAreaMax;

    [SerializeField]
    private int numberOfTargets = 1;

    private List<GameObject> currentTargets = new List<GameObject>();

    void Start()
    {
        SpawnTargets();
    }

    public void SpawnTargets()
    {
        // Destroy existing targets
        foreach (var target in currentTargets)
        {
            if (target != null)
                Destroy(target);
        }
        currentTargets.Clear();

        for (int i = 0; i < numberOfTargets; i++)
        {
            Vector3 randomPos = new Vector3(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                Random.Range(spawnAreaMin.y, spawnAreaMax.y),
                Random.Range(spawnAreaMin.z, spawnAreaMax.z)
            );

            GameObject newTarget = Instantiate(targetPrefab, randomPos, Quaternion.identity);
            var targetScript = newTarget.GetComponent<TargetScript>();
            if (targetScript != null)
                targetScript.spawner = this;
            currentTargets.Add(newTarget);
        }
    }

    public void SpawnTarget()
    {
        Vector3 randomPos = new Vector3(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y),
            Random.Range(spawnAreaMin.z, spawnAreaMax.z)
        );

        GameObject newTarget = Instantiate(targetPrefab, randomPos, Quaternion.identity);
        var targetScript = newTarget.GetComponent<TargetScript>();
        if (targetScript != null)
            targetScript.spawner = this;
        currentTargets.Add(newTarget);
    }
}