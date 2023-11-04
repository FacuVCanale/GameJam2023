using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obtacles;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObstacle());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator SpawnObstacle()
    {
        while (true)
        {
            int randomIndex = Random.Range(0, obtacles.Length);
            float minTime = 0.6f;
            float maxTime = 1.8f;
            float randomTime = Random.Range(minTime,maxTime);

            Instantiate(obtacles[randomIndex], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(randomTime);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(collision.gameObject);
        }
        
    }
}
