using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDamageShooter : MonoBehaviour
{
    [SerializeField] int rangeMax;
    [SerializeField] int rangeMin;
    [SerializeField] int damage;
    [SerializeField] int attackDelay;
    [SerializeField] int windUp;

    bool canAttack = true;
    bool coroutineRuning = false;
    float attackDelayScaled;


    NavMeshAgent nav;
    GameObject player;
    Transform shootPoint;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        nav = GetComponent<NavMeshAgent>();

        shootPoint = transform.GetComponentInChildren<Transform>();
    }


    // Update is called once per frame
    void Update()
    {
        var distance = player.transform.position - transform.position;
        if (!coroutineRuning)
        {
            StartCoroutine("CheckDistance",distance);
        }

        if(rangeMax >= distance.magnitude && canAttack ) 
        {
            StartCoroutine("DealDamage", damage);
        }

    }



    private IEnumerator CheckDistance(float distance)
    {
        coroutineRuning = true;
        if (distance <= rangeMin)
        {
            canAttack = false;
        } 
        yield return new WaitForSeconds(3f);
        if (distance > rangeMin && distance <= rangeMax)
        {
            canAttack = true;
        }
        coroutineRuning = false;
    }

    private IEnumerator DealDamage(int damage)
    {
        
        canAttack = false;

        RaycastHit hit;

        Physics.Raycast(shootPoint.position, transform.forward, out hit, Mathf.Infinity);

        if (hit.transform.CompareTag("Player"))
        {
            print("HitPlayer");
            transform.GetComponent<FacePlayer>().enabled = false;
            transform.GetComponent<ChasePlayer>().enabled = false;

            yield return new WaitForSeconds(windUp);

            Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity);

            if (hit.collider.tag == "Player")
            {
                player.GetComponent<PlayerHealth>().TakeDamage(damage);
                print("HitPlayerAgain");
            }

            transform.GetComponent<FacePlayer>().enabled = true;

            yield return new WaitForSeconds(attackDelay);

        }

        transform.GetComponent<ChasePlayer>().enabled = true;

        canAttack = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, rangeMax);
        Gizmos.DrawWireSphere(transform.position, rangeMin);
    }
}
