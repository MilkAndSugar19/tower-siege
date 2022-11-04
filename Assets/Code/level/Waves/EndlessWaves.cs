using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessWaves : MonoBehaviour
{


    [SerializeField] private GameObject[] EnemyList;
    [SerializeField] private int currentSubWave = 0, currentWave = 0;

    private const int avaliablePresets = 8;

    private float[][,] wavePresets = new float[avaliablePresets][,]
    {
        new float[,] // 1
        { // t, c, d, wd, iE || t - type, c - count, d - delay, wd - next wave delay, iE - is ending wave?
            {0, 10, 1, 10, 0},
            {0, 20, 0.8f, 16, 0},
            {0, 10, 1, 0, 0},
            {1, 3, 3, 10, 0},
            {0, 15, 1, 0, 0},
            {1, 4, 3, 20, 0},
            {0, 20, 0.5f, 20, 1}
        },
        new float[,] // 2
        { // t, c, d, wd, iE || t - type, c - count, d - delay, wd - next wave delay, iE - is ending wave?
            {0, 20, 0.7f, 14, 0},
            {0, 20, 0.9f, 0, 0},
            {1, 5, 4, 20, 0},
            {0, 20, 0.8f, 0, 0},
            {1, 4, 4, 0, 0},
            {2, 2, 2, 20, 0},
            {0, 15, 0.5f, 0, 0},
            {2, 8, 2, 15, 1}
        },
        new float[,] // 3
        { // t, c, d, wd, iE || t - type, c - count, d - delay, wd - next wave delay, iE - is ending wave?
            {1, 10, 2, 4, 0},
            {0, 20, 0.5f, 10, 0},
            {2, 6, 3, 0, 0},
            {1, 6, 2, 15, 0},
            {0, 25, 0.7f, 18, 0},
            {3, 4, 7, 0, 0},
            {1, 4, 5, 0, 0},
            {0, 20, 0.7f, 16, 1}
        },
        new float[,] // 4
        { // t, c, d, wd, iE || t - type, c - count, d - delay, wd - next wave delay, iE - is ending wave?
            {1, 15, 2.5f, 0, 0},
            {0, 25, 0.75f, 0, 0},
            {2, 5, 4, 20, 0},
            {3, 8, 2, 4, 0},
            {0, 30, 0.5f, 16, 0},
            {0, 20, 0.25f, 5, 0},
            {2, 10, 0.8f, 8, 0},
            {1, 5, 1f, 5, 1}
        },
        new float[,] // 5
        { // t, c, d, wd, iE || t - type, c - count, d - delay, wd - next wave delay, iE - is ending wave?
            {1, 10, 3, 0, 0},
            {2, 10, 2, 0, 0},
            {3, 5, 4, 0, 0},
            {0, 25, 0.5f, 30, 0},
            {0, 25, 0.25f, 5, 0},
            {4, 5, 1, 0, 0},
            {0, 20, 0.25f, 8, 0},
            {1, 5, 4, 0, 0},
            {4, 8, 1, 8, 0},
            {4, 15, 1.25f, 20, 1}
        },
        new float[,] // 6
        { // t, c, d, wd, iE || t - type, c - count, d - delay, wd - next wave delay, iE - is ending wave?
            {4, 10, 1.25f, 0, 0},
            {0, 20, 0.25f, 0, 0},
            {1, 5, 3, 20, 0},
            {3, 10, 2.5f, 3, 0},
            {2, 16, 1, 20, 0},
            {5, 3, 5, 2, 0},
            {4, 5, 2, 2, 0},
            {2, 10, 1, 2, 0},
            {0, 25, 0.2f, 5, 1}
        },
        new float[,] // 7
        { // t, c, d, wd, iE || t - type, c - count, d - delay, wd - next wave delay, iE - is ending wave?
            {3, 6, 5f, 1, 0},
            {4, 15, 2.25f, 1, 0},
            {2, 15, 5, 25, 0},
            {6, 3, 5, 0, 0},
            {5, 10, 1.5f, 0, 0},
            {4, 20, 1.5f, 30, 0},
            {0, 50, 0.25f, 2, 0},
            {1, 15, 1f, 15, 0},
            {4, 15, 1f, 15, 1}
        },
        new float[,] //randomly generated
        {
            {0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0},
            {0, 0, 0, 0, 1}
            
        }
    };

    private void Awake()
    {
        Invoke("InitializeSpawn", 8f);
        GenerateRandomWave();
    }

    private void InitializeSpawn()
    {
        StartCoroutine(SpawningManager(currentWave, currentSubWave));
    }

    private IEnumerator SpawningManager(int wave, int subwave)
    {
        Invoke("InitNext", wavePresets[wave][subwave, 3]); // 

        for (int i = 0; i < wavePresets[wave][subwave, 1]; i++)
        {
            Instantiate(EnemyList[(int)wavePresets[wave][subwave, 0]], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(wavePresets[wave][subwave, 2]);
        }
    }

    private void InitNext()
    {
        if (wavePresets[currentWave][currentSubWave, 4] == 1)
        {
            if(currentWave < 7)
            {
                currentWave++;
                currentSubWave = 0;
            }
            else if(currentWave >= 7)
            {
                GenerateRandomWave();
                currentSubWave = 0;
            }
        }
        else
            currentSubWave++;
        StartCoroutine(SpawningManager(currentWave, currentSubWave));
    }

    private void GenerateRandomWave()
    {//t, c, d, wd, iE || t - type, c - count, d - delay, wd - next wave delay, iE - is ending wave?
        for (int i = 0; i < 8; i++)
        {
            wavePresets[7][i, 0] = Random.Range(0, EnemyList.Length);
            if(wavePresets[7][i, 0] < 3)
            {
                wavePresets[7][i, 1] = Random.Range(10, 80);
                wavePresets[7][i, 2] = Random.Range(0.05f, 1f);
                wavePresets[7][i, 3] = (wavePresets[7][i, 1] * wavePresets[7][i,2]) / Random.Range(1.1f, 2f);
                if (i < 7)
                    wavePresets[7][i, 4] = 0;
                else
                    wavePresets[7][i, 4] = 1;
            }
            else
            {
                wavePresets[7][i, 1] = Random.Range(2, Random.Range(10, 50));
                wavePresets[7][i, 2] = Random.Range(0.1f, 1.2f);
                wavePresets[7][i, 3] = (wavePresets[7][i, 1] * wavePresets[7][i, 2]) / Random.Range(1.1f, 2f);
                if (i < 7)
                    wavePresets[7][i, 4] = 0;
                else
                    wavePresets[7][i, 4] = 1;
            }
        }
    }
}
