using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;

    float timer;

    void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 0.2f)
        {
            timer = 0;
            Spawn();
        }

    }

    void Spawn()
    {
        GameObject monster = GameManager.instance.pool.Get(Random.Range(0, 2));
        monster.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
    }
}
