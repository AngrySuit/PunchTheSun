using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Search;
using UnityEngine;

public class WaveFormater : MonoBehaviour
{
    [SerializeField] int waveCount = 0;

    [SerializeField] Transform[] spawners;

    bool beingPerformed = false;


    [System.Serializable]
    private class EnemyGroup
    {
        public EnemyTypes enemyType;
        public GameObject enemy;
        public int amount;
    }

    [System.Serializable]
    private class Wave
    {
        [SerializeField] public List<EnemyGroup> enemyAmountList;

        public EnemyGroup GetInsides(int index)
        {
            EnemyGroup tempVar = enemyAmountList[index];

            return tempVar;
        }
    }

    [SerializeField] private List<Wave> Waves = new List<Wave>();

    private void Awake()
    {
        spawners = gameObject.GetComponentsInChildren<Transform>();
    }


    private void Update()
    {
        StartCoroutine("CheckWave");
    }


    private IEnumerator CheckWave()
    {
        if (waveCount < Waves.Count && !GameObject.FindGameObjectWithTag("Enemy") && !beingPerformed)
        {
            beingPerformed = true;

            yield return new WaitForSeconds(1f);

            StartCoroutine("SpawnWave");

            waveCount++;
            beingPerformed = false;
        }
    }



    private IEnumerator SpawnWave()
    {
        Wave wave = getwave();
        Debug.Log("Performed");
        foreach (EnemyGroup enemyClass in wave.enemyAmountList)
        {
            for (int amount = enemyClass.amount; amount > 0; amount--)
            {
                Debug.Log("isTrue");
                yield return new WaitForSeconds(0.5f);
                GameObject.Instantiate(enemyClass.enemy, transform.position, Quaternion.identity);
            }
        }      
    }

    private Wave getwave()
    {
        Wave tempVar = Waves[waveCount];

        return tempVar;
    }
}
