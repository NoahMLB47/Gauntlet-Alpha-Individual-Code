using Unity.Hierarchy;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    [SerializeField] private GameObject monsterToSpawn;

    [SerializeField] private int maxMonsters = 20;
    private GameObject[] spawnedMonsters;
    [SerializeField] private float spawnCooldown = 1.0f;

    [SerializeField] private float maxSpawnCooldown = 1.0f;
    [SerializeField] private Collider2D Collider;
    private bool activated;
    [SerializeField] private GameObject spawner;

    void Start()
    {
        activated = false;
    }
    private void Awake()
    {
        spawnedMonsters = new GameObject[maxMonsters];

        for (int i = 0; i < maxMonsters; i++) // pre spawn the monsters so we dont have to instantiate them every time
        {
            GameObject spawnedMonster = Instantiate(monsterToSpawn, spawner.transform.position, Quaternion.identity);

            spawnedMonster.SetActive(false);

            spawnedMonsters[i] = spawnedMonster;
        }
    }

    void Update()
    {
        if (activated) 
        {
            if (spawnCooldown >= 0.0f)
            {
                spawnCooldown -= Time.deltaTime;
            }
            else if (spawnCooldown <= 0.0f)
            {
                GameObject monster = nextFree();

                if (monster != null)
                {
                    monster.SetActive(true);
                }

                spawnCooldown = maxSpawnCooldown;
            }
        }
    }

    public GameObject nextFree() // returns the next free monster in the pool
    {
        for (int i = 0; i < maxMonsters; i++)
        {
            GameObject monster = spawnedMonsters[i];

            if (!monster.activeSelf)
            {
                HealthNDeath monsterScript = monster.GetComponent<HealthNDeath>();

                if (monsterScript != null)
                {
                    monsterScript.SetSpawner(gameObject);
                }

                return monster;
            }
        }

        return null;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!activated && collision.CompareTag("Player"))
        {
            activated = true;
        }
    }
   
}