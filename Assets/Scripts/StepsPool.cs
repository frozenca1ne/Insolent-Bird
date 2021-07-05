using System.Collections.Generic;
using UnityEngine;

public class StepsPool : MonoBehaviour
{
	[SerializeField] private float poolSize = 6;
	[SerializeField] private Transform birdPosition;
	[SerializeField] private GameObject[] stepsPrefabs;
	[SerializeField] private GameObject lastStep;
	[SerializeField] private float newStepOffsetY = 2.5f;
	[SerializeField] private float minDistanceToCreate = 7f;

	private GameObject newStep;
	private readonly List<GameObject> spawnedSteps = new List<GameObject>();

	private void Start()
	{
		spawnedSteps.Add(lastStep);
	}
	private void Update()
	{
		CheckPlayerDistance();
		
	}
	private void CheckPlayerDistance()
	{
		if(birdPosition.position.y + minDistanceToCreate > spawnedSteps[spawnedSteps.Count - 1].transform.position.y)
		{
			SpawnSteps();
		}
	}
	private void SpawnSteps()
	{
		newStep = Instantiate(stepsPrefabs[Random.Range(0, stepsPrefabs.Length)]);
		var newPosition = spawnedSteps[spawnedSteps.Count - 1].transform.position;
		newStep.transform.position = new Vector3(newPosition.x, newPosition.y + newStepOffsetY, newPosition.z);
		spawnedSteps.Add(newStep);
		CleanPool();
	}
	private void CleanPool()
	{
		if (spawnedSteps.Count < poolSize) return;
		Destroy(spawnedSteps[0].gameObject);
		spawnedSteps.RemoveAt(0);
	}	
	
}
