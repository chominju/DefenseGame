using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject gameObj;
    public float spawnTimer = 0.8f;
    float currentSpawnTimer = 0.0f;
    
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        currentSpawnTimer += Time.deltaTime;
        if(currentSpawnTimer >=spawnTimer)
        {
            GameObject.Instantiate(gameObj);
            gameObj.transform.position = gameObject.transform.position;
            currentSpawnTimer = 0.0f;
        }
    }
}
