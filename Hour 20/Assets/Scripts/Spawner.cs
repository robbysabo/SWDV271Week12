using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject powerupPrefab;
    public GameObject obstaclePrefab;
    public GameObject speedupPrefab;
    public float spawnCycle = .5f;
    GameManager manager;
    float elapsedTime;
    bool spawnPowerup = true;
    void Start()
    {
        manager = GetComponent<GameManager>();
    }
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > spawnCycle)
        {
            GameObject temp;
            if (spawnPowerup)
            {
                float rng = Random.value;
                if (rng > 0.5f)
                {
                    temp = Instantiate(powerupPrefab) as GameObject;
                } else
                {
                    temp = Instantiate(speedupPrefab) as GameObject;
                }
            }
            else
            {
                temp = Instantiate(obstaclePrefab) as GameObject;
            }
            Vector3 position = temp.transform.position;
            position.x = Random.Range(-3f, 3f);
            temp.transform.position = position;
            Collidable col = temp.GetComponent<Collidable>();
            col.manager = manager;
            elapsedTime = 0;
            spawnPowerup = !spawnPowerup;
        }
    }
}
