using System.Collections;
using UnityEngine;
using System;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private GameObject LevelWon;
    [SerializeField] private GameObject[] EnemyList;
    [SerializeField] private int currentSubWave = 0, currentWave = 0;
    float[][,] jaggedArray = new float[3][,]
    {
        new float[,] 
        { // t,  c,  d,  wd,  iE || t - type, c - count, d - delay, wd - next wave delay, iE - is ending wave?
            {0, 10, 1.5f, 20, 0},
            {0, 20, 1, 25, 0},
            {1, 2, 5, 0, 0},
            {0, 15, 1.5f, 20, 0},
            {0, 25, 1.5f, 32, 0},
            {1, 3, 4, 0, 0},
            {0, 10, 1, 15, 0},
            {1, 8, 2, 20, 0},
            {1, 5, 1, 10, 0},
            {0, 10, 0.5f, 5, 1}
        },

        new float[,]
        { // t, c, d, wd, iE || t - type, c - count, d - delay, wd - next wave delay, iE - is ending wave?
            {0, 10, 1, 8, 0},  //1
            {1, 5, 5, 0, 0},  //2
            {0, 10, 1, 20, 0},  //3
            {0, 20, 1, 25, 0},  //4
            {2, 3, 5, 0, 0},  //5
            {0, 15, 1.5f, 40, 0},  //6
            {2, 6, 4, 0, 0},  //7
            {1, 2, 6, 2, 0},  //8
            {0, 20, 1.5f, 40, 0},  //9 
            {2, 10, 2.2f, 30, 1},  //10
            
        },
        new float[,]
        { // t, c, d, wd, iE || t - type, c - count, d - delay, wd - next wave delay, iE - is ending wave?
            {0, 30, 0.6f, 13, 0},
            {3, 3, 6, 3, 0},
            {2, 10, 2, 10, 0},
            {0, 25, 0.5f, 20, 0},
            {1, 10, 5, 1, 0},
            {2, 15, 1, 5, 0},
            {3, 3, 7, 25, 0},
            {0, 40, 0.5f, 15, 0},
            {2, 10, 2, 25, 0},
            {1, 10, 4, 4, 0},
            {0, 20, 0.5f, 10, 1},
        }
    };

    private void Start()
    {
        Time.timeScale = 1f;
        Invoke("InitializeSpawn", 5f);
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
        if(jaggedArray[currentWave][currentSubWave, 4] == 1)
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