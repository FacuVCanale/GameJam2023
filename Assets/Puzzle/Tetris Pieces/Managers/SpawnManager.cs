using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
  public List<GameObject> spawnables;

  public List<Transform> leftWallSpawners;
  public List<Transform> rightWallSpawners;
  public List<Transform> topWallSpawners;
  public List<Transform> bottomWallSpawners;

  private GameObject spawned;

  private void Update()
  {
   if(Input.GetKeyDown(KeyCode.Return) )
   {
     SpawnRandom();
   } 
  }

  void SpawnRandom()
  {
   GameObject randomSpawnable = spawnables[Random.Range(0, spawnables.Count)];

   int randomIndex = Random.Range(0, 4);
   Transform spawner;

    Vector3 offset;

    Vector3 spawnPosition;

   switch (randomIndex)
    {
        case 0:
            spawner = leftWallSpawners[Random.Range(0, leftWallSpawners.Count)];
            offset = randomSpawnable.GetComponent<TetrisPieces>().horizontalOffset;
            spawnPosition = spawner.position;
            spawnPosition = new Vector3((int)spawnPosition.x, (int)spawnPosition.y, (int)spawnPosition.z);
            spawned = Instantiate(randomSpawnable, spawnPosition + offset, spawner.rotation);
            spawned.GetComponent<TetrisPieces>().moveDirection = Vector3.right;
            spawned.AddComponent<VerticalMovement>();
            break;
        case 1:
            spawner = rightWallSpawners[Random.Range(0, rightWallSpawners.Count)];
            offset = randomSpawnable.GetComponent<TetrisPieces>().horizontalOffset;
            spawnPosition = spawner.position;
            spawnPosition = new Vector3((int)spawnPosition.x, (int)spawnPosition.y, (int)spawnPosition.z);
            spawned = Instantiate(randomSpawnable, spawnPosition + offset, spawner.rotation);
            spawned.GetComponent<TetrisPieces>().moveDirection = Vector3.left;
            spawned.AddComponent<VerticalMovement>();
            break;
        case 2:
            spawner = topWallSpawners[Random.Range(0, topWallSpawners.Count)];
            offset = randomSpawnable.GetComponent<TetrisPieces>().verticalOffset;
            spawnPosition = spawner.position;
            spawnPosition = new Vector3((int)spawnPosition.x, (int)spawnPosition.y, (int)spawnPosition.z);
            spawned = Instantiate(randomSpawnable, spawnPosition + offset, spawner.rotation);
            spawned.GetComponent<TetrisPieces>().moveDirection = Vector3.down;
            spawned.AddComponent<HorizontalMovement>();
            break;
        case 3:
            spawner = bottomWallSpawners[Random.Range(0, bottomWallSpawners.Count)];
            offset = randomSpawnable.GetComponent<TetrisPieces>().verticalOffset;
            spawnPosition = spawner.position;
            spawnPosition = new Vector3((int)spawnPosition.x, (int)spawnPosition.y, (int)spawnPosition.z);
            spawned = Instantiate(randomSpawnable, spawnPosition + offset, spawner.rotation);
            spawned.GetComponent<TetrisPieces>().moveDirection = Vector3.up;
            spawned.AddComponent<HorizontalMovement>();
            break;
    }
 }
}