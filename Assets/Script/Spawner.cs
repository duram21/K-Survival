using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    public SpawnData[] spawnData;
    
    float timer;
    int level;

    void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        level = Mathf.Min(Mathf.FloorToInt(GameManager.instance.gameTime / 10f), spawnData.Length - 1);

        if(timer > spawnData[level].spawnTime)
        {
            timer = 0;
            Spawn();
        }

    }

    void Spawn()
    {
        GameObject monster = GameManager.instance.pool.Get(0);
        monster.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
        monster.GetComponent<Monster>().Init(spawnData[level]);
    }
}

[System.Serializable]
public class SpawnData
{
    public float spawnTime;
    public int spriteType;
    public int health;
    public float speed;
}