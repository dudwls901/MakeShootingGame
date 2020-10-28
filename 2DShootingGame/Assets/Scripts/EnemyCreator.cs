using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{

    private static EnemyCreator instance = null;
    Queue<GameObject> objectPool = new Queue<GameObject>();

    public float spawnLate;
    bool readySpawn = true;

    public GameObject enemy1;

    public Transform[] spawnPoint = new Transform[8];

    public GameObject objectPoolList;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public static EnemyCreator Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            InitializeNewZombie(enemy1);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (objectPool.Count != 0 && readySpawn)
        {
            StartCoroutine(ActiveMob());
        }
    }

    public void InitializeNewZombie(GameObject mob)
    {
        GameObject tmpMob = Instantiate(mob);
        tmpMob.transform.parent = objectPoolList.transform;
        tmpMob.transform.position = spawnPoint[Random.Range(0, 8)].position;
        tmpMob.SetActive(false);
        objectPool.Enqueue(tmpMob);
    }
    IEnumerator ActiveMob()
    {
        readySpawn = false;
        objectPool.Dequeue().SetActive(true);
        yield return new WaitForSeconds(spawnLate);
        readySpawn = true;
    }
    public void InactiveMob(GameObject mob)
    {
        mob.transform.position = spawnPoint[Random.Range(0, 8)].position;
        mob.SetActive(false);
        objectPool.Enqueue(mob);
    }
}
