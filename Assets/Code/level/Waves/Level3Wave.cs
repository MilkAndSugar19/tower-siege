using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Level3Wave : MonoBehaviour
{
    [SerializeField] private GameObject LevelWon;

    [SerializeField] private GameObject[] EnemyList;
    private int currentSubWave = 0, currentWave = 0;
    float[][,] jaggedArray = new float[4][,]
    {
        new float[,]
        { // t,  c,  d,  wd,  iE || t - type, c - count, d - delay, wd - next wave delay, iE - is ending wave?
            {0, 15, 1.5f, 20, 0},
            {0, 20, 1, 25, 0},
            {0, 15, 1.2f, 0, 0},
            {1, 3, 5, 20, 0},
            {0, 40, 1, 10, 0},
            {2, 2, 4, 30, 0},
            {1, 3, 0.33f, 1, 0},
            {0, 50, 1, 0, 0},
            {1, 10, 3.65f, 35, 0},
            {2, 8, 4, 40, 1}
        },

        new float[,]
        { // t, c, d, wd, iE || t - type, c - count, d - delay, wd - next wave delay, iE - is ending wave?
            {3, 4, 8, 0, 0},
            {2, 10, 2.5f, 35, 0},
            {0, 50, 1.5f, 10, 0},
            {1, 5, 5, 35, 0},
            {2, 6, 3.15f, 0, 0},
            {1, 4, 8, 0, 0},
            {0, 25, 0.75f, 40, 0},
            {4, 10, 2.35f, 20, 0},
            {0, 30, 0.45f, 20, 1}

        },
        new float[,]
        { // t, c, d, wd, iE || t - type, c - count, d - delay, wd - next wave delay, iE - is ending wave?
            {4, 10, 1.5f, 22, 0},
            {0, 25, 0.66f, 4, 0},
            {1, 3, 5, 20, 0},
            {2, 8, 1.5f, 2.25f, 0},
            {0, 45, 0.8f, 40, 0},
            {4, 15, 0.85f, 5, 0},
            {3, 5, 5.25f, 30, 0},
            {0, 40, 0.5f, 15, 0},
            {4, 10, 2, 25, 0},
            {1, 10, 4, 4, 0},
            {0, 20, 0.5f, 10, 0},
            {4, 20, 1f, 20, 1}
        },
        new float[,]
        {
            {5, 10, 2.5f, 5, 0},
            {4, 25, 1.2f, 40, 0},
            {3, 30, 3, 10, 0},
            {6, 6, 5, 35, 0},
            {2, 20, 1.25f, 30, 0},
            {0, 100, 0.25f, 30, 1}
        }
    };

    private void Start()
    {
        Time.timeScale = 1f;
        Invoke("InitializeSpawn", 8f);
    }

    private void InitializeSpawn()
    {
        StartCoroutine(SpawningManager(currentWave, currentSubWave));
    }

    private IEnumerator SpawningManager(int wave, int subwave)
    {
        try
        {
            Invoke("InitializeNextWave", jaggedArray[wave][subwave, 3]);
        }
        catch (IndexOutOfRangeException)
        {
            InvokeRepeating("LastEnemyCheck", 1f, 1f);
        }

        for (int i = 0; i < jaggedArray[wave][subwave, 1]; i++)
        {
            print(i);
            Instantiate(EnemyList[(int)jaggedArray[wave][subwave, 0]], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(jaggedArray[wave][subwave, 2]);
        }
    }
    private void InitializeNextWave()
    {
        if (jaggedArray[currentWave][currentSubWave, 4] == 1)
        {
            currentWave++;
            currentSubWave = 0;
        }
        else
            currentSubWave++;

        StartCoroutine(SpawningManager(currentWave, currentSubWave));

    }

    private void LastEnemyCheck()
    {
        if (GameObject.FindGameObjectWithTag("Enemy") == null)
        {
            Time.timeScale = 0f;
            LevelWon.SetActive(true);
        }
    }
}
