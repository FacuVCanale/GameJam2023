using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnManager : MonoBehaviour {

  public List<GameObject> spawnables;

  public List<Transform> leftWallSpawners;
  public List<Transform> rightWallSpawners;
  public List<Transform> topWallSpawners;
  public List<Transform> bottomWallSpawners;

public GameObject progressBarAdjuster;

public GameObject message1;
public GameObject message2;
public GameObject message3;
private int messageIndex = 3;


  public bool ready = true;

  private GameObject spawned;

  public int spawnedCount;
  
  private int originalAmount;

  public TextMeshProUGUI countText;

  public GameObject greatWork;

    void Start() {
        originalAmount = spawnedCount;
        ChangeCountText();
    }

   void Update() {
   if (ready) {
     ready = false;
     SpawnRandom();
     ChangeCountText();
   } 
  }

  public void SpawnRandom() {
    if (spawnedCount > 0 ) {
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
    spawnedCount--;
    }
    else {
        greatWork.SetActive(true);
        if(progressBarAdjuster.transform.localScale.x > 0.75f){
            messageIndex = 1;
        }
        else if(progressBarAdjuster.transform.localScale.x > 0.30f){
            messageIndex = 2;
        }
        if(messageIndex == 1){
                    message1.SetActive(true);
                }
                else if(messageIndex == 2){
                    message2.SetActive(true);
                }
                else if(messageIndex == 3){
                    message3.SetActive(true);
                }
    }    
  }

  public void ChangeCountText() {
    countText.text = spawnedCount.ToString() + " / " + originalAmount.ToString();
    }

    public void ResetSpawnManager() {
        spawnedCount = originalAmount;
        ChangeCountText();
        greatWork.SetActive(false);
        ready = true;
    }
}