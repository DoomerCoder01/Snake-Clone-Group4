using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public MovingObject objectPrefab;
    public float spawnDistance = 20f;
    public float spawnRate = 20f;
    public int amountPerSpawn = 1;
    [Range(0f, 10f)]
    public float trajectoryVariance = 15f;

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    public void Spawn()
    {
        for (int i = 0; i < amountPerSpawn; i++)
        {
            // Choose a random direction from the center of the spawner and
            // spawn the object a distance away
            Vector3 spawnDirection = Random.insideUnitCircle.normalized;
            Vector3 spawnPoint = transform.position + (spawnDirection * spawnDistance);

            // Calculate a random variance in the objects's rotation which will
            // cause its trajectory to change
            float variance = Random.Range(-trajectoryVariance, trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            // Create the new object by cloning the prefab and set a random
            // size within the range
            MovingObject objects = Instantiate(objectPrefab, spawnPoint, rotation);
            objects.size = Random.Range(objects.minSize, objects.maxSize);

            // Set the trajectory to move in the direction of the spawner
            Vector2 trajectory = rotation * -spawnDirection;
            objects.SetTrajectory(trajectory);
        }
    }
}
