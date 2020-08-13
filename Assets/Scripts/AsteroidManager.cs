using UnityEngine;
using System.Collections.Generic;

public class AsteroidManager : MonoBehaviour {
    //this makes a disk version of the object I guess
    [SerializeField]
	public GameObject asteroidPrefab;

    private List<GameObject> leftSpawnedAsteroids = new List<GameObject>();
    private List<GameObject> rightSpawnedAsteroids = new List<GameObject>();

	private float delaySeconds = .8f;

	private static float MAX_Y = 6.5f;
	private static float MIN_Y = -3f;

	private static float MIN_X = -10f;
	private static float MAX_X = 10f;

	private static float ASTEROID_MOVE_SPEED= 3f;

	private static float depleteableDelay;

    void Awake() {
		depleteableDelay = delaySeconds;
	}

	// Update is called once per frame
	void Update () {
		handleFromLeftAsteroids();
		handleFromRightAsteroids();
	}

	public void IncreaseDifficulty() {
		delaySeconds = delaySeconds *.99f;
		Debug.Log(delaySeconds);
	}
	
	private void handleFromLeftAsteroids()
	{
		Vector3 leftSpawnLocation = getSpawnLocation(true);
		spawnAsteroid(leftSpawnLocation);
		moveAsteroids(true);
		destroyAsteroids(true);
	}

	private void handleFromRightAsteroids()
	{
        Vector3 rightSpawnLocation = getSpawnLocation(false);
		spawnAsteroid(rightSpawnLocation);
		moveAsteroids(false);
		destroyAsteroids(false);
	}

    private Vector3 getSpawnLocation(bool fromLeft)
	{
		float ySpawnLocation = Random.Range(MIN_Y, MAX_Y);
		if(fromLeft) {
			return new Vector3(MIN_X, ySpawnLocation, 0);
		}
		return new Vector3(MAX_X, ySpawnLocation, 0);
	}

	private void spawnAsteroid(Vector3 spawnLocation)
	{
		GameObject asteroidInstance = null;
		depleteableDelay -= Time.deltaTime;
		if(depleteableDelay <= 0){
			asteroidInstance = (GameObject) Instantiate(asteroidPrefab, spawnLocation, Quaternion.identity);

			if(spawnLocation.x == MIN_X)
    		    leftSpawnedAsteroids.Add(asteroidInstance);
			else
    		    rightSpawnedAsteroids.Add(asteroidInstance);
			depleteableDelay = delaySeconds;
		}
	}

	private void moveAsteroids(bool fromLeft)
	{
		if(fromLeft)
		{
			foreach(GameObject asteroid in leftSpawnedAsteroids)
			{
				asteroid.transform.position += new Vector3(ASTEROID_MOVE_SPEED, 0, 0) * Time.deltaTime;
			}
		} else {
			foreach(GameObject asteroid in rightSpawnedAsteroids)
			{
				asteroid.transform.position += new Vector3(-ASTEROID_MOVE_SPEED, 0, 0) * Time.deltaTime;
			}
		}
	}

    private bool asteroidOutOfBounds(GameObject asteroidInstance)
	{
		if(asteroidInstance.transform.position.x > MAX_X || asteroidInstance.transform.position.x < MIN_X)
		{
			return true;
		}
		return false;
	}

	private void destroyAsteroids(bool fromLeft)
	{
		if(fromLeft)
		{
			for(int i = 0; i < leftSpawnedAsteroids.Count; i++)
			{
				if(asteroidOutOfBounds(leftSpawnedAsteroids[i]))
				{
					Destroy(leftSpawnedAsteroids[i]);
					leftSpawnedAsteroids.RemoveAt(i);
				}
			}
		} else {
			for(int i = 0; i < rightSpawnedAsteroids.Count; i++)
			{
				if(asteroidOutOfBounds(rightSpawnedAsteroids[i]))
				{
					Destroy(rightSpawnedAsteroids[i]);
					rightSpawnedAsteroids.RemoveAt(i);
				}
			}
		}
	}
}