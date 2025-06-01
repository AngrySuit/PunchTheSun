using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEditor.Search;
using UnityEngine;

public class WaveFormater : MonoBehaviour
{
    [SerializeField] int waveCount = 1;

    [SerializeField] Transform[] spawners;

    bool enemysExist = false;
    bool SpawnignWave = false;


    [System.Serializable]
    private class EnemyGroup
    {
        public GameObject enemy;
        public int amount;
    }

    [System.Serializable]
    private class Wave
    {
        [SerializeField] public List<EnemyGroup> enemyAmountList;

        public EnemyGroup GetInsides(int index)
        {
            return enemyAmountList[index];
        }
    }

    [SerializeField] private List<Wave> Waves = new List<Wave>();

    private void Awake()
    {
        spawners = gameObject.GetComponentsInChildren<Transform>();
    }


    private void Update()
    {

        if (!enemysExist) StartCoroutine("CheckWave");

        if (!SpawnignWave && GameObject.FindGameObjectWithTag("Enemy")) enemysExist = true;
    }


    private IEnumerator CheckWave()
    {
        enemysExist = true;
        SpawnignWave = true;

        if (waveCount <= Waves.Count)
        {
            yield return new WaitForSeconds(1f);

            StartCoroutine("SpawnWave");

            waveCount++;
        }
    }



    private IEnumerator SpawnWave()
    {
        
        int spawnerIndex = 0;
        
        Wave wave = getwave();

        foreach (EnemyGroup enemyClass in wave.enemyAmountList)
        {
            for (int amount = enemyClass.amount; amount != 0; amount--)
            {
                spawnerIndex++;

                if (spawnerIndex >= spawners.Count()) spawnerIndex = 0;

                yield return null; /*new WaitForSeconds(0.5f);*/

                GameObject.Instantiate(enemyClass.enemy, spawners[spawnerIndex].position, Quaternion.identity);
            }
        }

        SpawnignWave = false;
    }

    private Wave getwave()
    {
        return Waves[waveCount - 1];
    }
}
