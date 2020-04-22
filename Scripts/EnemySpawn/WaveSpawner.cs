using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        [System.Serializable]
        public class Enemy
        {
            public Transform enemyPrefab;
            public int enemyIndex;
        }
        public Enemy[] enemy;
    }

    public Wave[] wave;
    public Transform spawnPoint;
    public Transform target;
    public float timeBetweenWaves;
    public Text waveText;

    private float countdown = 2f;
    private int waveIndex = 0;

    private void Start()
    {
        waveText.text = "" + waveIndex + "/" + wave.Length;
        PlayerStats.totalRounds = wave.Length;
        for (int i = 0; i < wave.Length; i++)
        {
            for (int j = 0; j < wave[i].enemy.Length; j++)
            {
                wave[i].enemy[j].enemyPrefab.transform.root.gameObject.GetComponent<Enemy>().target = target;
                PlayerStats.Enemy += wave[i].enemy[j].enemyIndex;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0f)
        {
            if(waveIndex < wave.Length)
            {
                StartCoroutine(SpawnWave(wave[waveIndex]));
                waveIndex += 1;
                PlayerStats.Rounds += 1;

                waveText.text = "" + waveIndex + "/" + wave.Length;
            }
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave(Wave w)
    {
        for (int i = 0; i < w.enemy.Length; i++)
        {
            for (int j = 0; j < w.enemy[i].enemyIndex; j++)
            {
                SpawnEnemy(w.enemy[i].enemyPrefab);
                yield return new WaitForSeconds(1f);
            }
        }
    }

    void SpawnEnemy(Transform enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        
    }
}
