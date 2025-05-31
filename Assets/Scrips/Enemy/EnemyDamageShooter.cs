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
    Rigidbody rb;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        nav = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();

        shootPoint = transform.GetComponentInChildren<Transform>();
    }


    // Update is called once per frame
    void Update()
    {
        var distance = player.transform.position - transform.position;

        if(rangeMax >= distance.magnitude && rangeMin < distance.magnitude) 
        {
            if (canAttack && !coroutineRuning)
            {
                StartCoroutine("DealDamageShoter", damage);
            }
        }

    }

    public IEnumerator DealDamageShoter(int damage)
    {
        coroutineRuning = true;
        canAttack = false;

        RaycastHit hit;

        Physics.Raycast(shootPoint.position, transform.forward, out hit, Mathf.Infinity);

        if (hit.transform.CompareTag("Player"))
        {            
            transform.GetComponent<FacePlayer>().enabled = false;
            transform.GetComponent<ChasePlayer>().enabled = false;
            nav.SetDestination(transform.position);

            rb.velocity = Vector3.zero;


            yield return new WaitForSeconds(windUp);

            Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity);

            if (hit.collider.tag == "Player")
            {
                player.GetComponent<PlayerHealth>().ChangeHealth(damage);
                print("HitPlayerAgain");
            }

            transform.GetComponent<FacePlayer>().enabled = true;

            yield return new WaitForSeconds(attackDelay);

        }

        transform.GetComponent<ChasePlayer>().enabled = true;


        canAttack = true;
        coroutineRuning = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, rangeMax);
        Gizmos.DrawWireSphere(transform.position, rangeMin);
    }
}
