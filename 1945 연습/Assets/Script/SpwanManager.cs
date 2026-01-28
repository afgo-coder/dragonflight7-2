using UnityEngine;

public class SpwanManager : MonoBehaviour
{
    public GameObject monster1;
    public GameObject monster2;

    public float spawnDelay = 2f;

    public float minX = -2.5f;
    public float maxX = 2.5f;
    public float spawnY = 6f;

    void Start()
    {
        InvokeRepeating("Spawn", 1f, spawnDelay);
    }

    void Spawn()
    {
        float rand = Random.Range(0f, 6f); // 0 ~ 6

        GameObject spawnMonster;

        // 5 : 1 ∫Ò¿≤
        if (rand < 5f)
        {
            spawnMonster = monster1; // 5
        }
        else
        {
            spawnMonster = monster2; // 1
        }

        float x = Random.Range(minX, maxX);
        Vector3 pos = new Vector3(x, spawnY, 0);

        Instantiate(spawnMonster, pos, Quaternion.identity);
    }
}