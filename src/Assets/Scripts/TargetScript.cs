using UnityEngine;
using System.Collections;

public class TargetScript : MonoBehaviour
{
	float randomTime;
	bool routineStarted = false;
	public bool isHit = false;

	[Header("Customizable Options")]
	// Minimum time before the target goes back up
	public float minTime;
	// Maximum time before the target goes back up
	public float maxTime;

	[Header("Audio")]
	public AudioClip upSound;
	public AudioClip downSound;

	[Header("Animations")]
	public AnimationClip targetUp;
	public AnimationClip targetDown;

	public AudioSource audioSource;

	public TargetSpawner spawner;

	private void Update()
	{
		randomTime = Random.Range(minTime, maxTime);

		// If target is hit
		if (isHit == true)
		{
			if (routineStarted == false)
			{
				// Animate the target "down"
				gameObject.GetComponent<Animation>().clip = targetDown;
				gameObject.GetComponent<Animation>().Play();

				// Set the downSound as current sound, and play it
				audioSource.GetComponent<AudioSource>().clip = downSound;
				audioSource.Play();

				// Start the timer
				StartCoroutine(DelayTimer());
				routineStarted = true;
			}
		}
	}

	// Detect collision with projectile
	private void OnCollisionEnter(Collision collision)
	{
		if (!isHit && collision.gameObject.CompareTag("Projectile"))
		{
			isHit = true;

			// Add score
			ScoreManager.Instance.AddScore(1);

			// Optionally, spawn a new target if using a spawner
			if (spawner != null)
			{
				spawner.SpawnTarget();
			}
		}
	}

	// Time before the target pops back up
	private IEnumerator DelayTimer()
	{
		// Wait for random amount of time
		yield return new WaitForSeconds(randomTime);
		// Animate the target "up"
		gameObject.GetComponent<Animation>().clip = targetUp;
		gameObject.GetComponent<Animation>().Play();

		// Set the upSound as current sound, and play it
		audioSource.GetComponent<AudioSource>().clip = upSound;
		audioSource.Play();

		// Target is no longer hit
		isHit = false;
		routineStarted = false;
	}
}