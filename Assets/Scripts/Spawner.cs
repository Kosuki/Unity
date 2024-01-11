using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private bool ToRight;

    private GameObject[] Targets;

    private float spawnTime;

    public GameManager gameManager;

    public List<WaveScriptable> waves;
    public AudioSource ShotAudioSource;


    private int WaveIndex = 0;

    private void Awake()
    {
        foreach (var item in waves)
        {
            item.actived = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Settings.SpawnFreqMax = waves[0].enemyRateMax;
        Settings.TargetSpeed = waves[WaveIndex].enemySpeed;
        Targets = waves[0].targets;
        waves[0].actived = true;
        SetSpawnTime();
        Invoke(nameof(SpawnTarget), spawnTime);
    }


    private void FixedUpdate()
    {
        int a = Settings.Score / 20;
        if (a < waves.Count)
        {
            if (Settings.Score > 0 && a != 0 && !waves[a].actived)
            {
                print("NEW WAVE");
                waves[a].actived = true;
                ChangeWave();
            }
        }
    }

    private void SpawnTarget()
    {
        GameObject target = Targets[Random.Range(0, Targets.Length)];
        Target spawned = Instantiate(target, transform).GetComponent<Target>();
        spawned.goRight = ToRight;
        spawned.ShotAudioSource = ShotAudioSource;
        SetSpawnTime();
        Invoke(nameof(SpawnTarget), spawnTime);
    }

    private void SetSpawnTime()
    {
        spawnTime = Random.Range(1, Settings.SpawnFreqMax);
    }

    private void ChangeWave()
    {
        WaveIndex += 1;
        Settings.SpawnFreqMax = waves[WaveIndex].enemyRateMax;
        Settings.TargetSpeed = waves[WaveIndex].enemySpeed;
        Targets = waves[WaveIndex].targets; 
    }
}
