using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDamageShooter : MonoBehaviour
{
    [SerializeField] int range = 10;
    [SerializeField] int damage = 10;
    [SerializeField] int attackDelay = 60;
    [SerializeField] int windUp = 60;

    bool canAttack = true;
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

        if (nav.stoppingDistance >= distance.magnitude)
        {
            canAttack = false;
        }
        else if(range >= distance.magnitude && canAttack) 
        {
            StartCoroutine("DealDamage", damage);
        }
    }

    private IEnumerator DealDamage(int damage)
    {
        canAttack = false;

        RaycastHit hit;
        Physics.Raycast(shootPoint.position, transform.forward, out hit, Mathf.Infinity);

        print("Hit");

        if (hit.transform.CompareTag("Player"))
        {
            //transform.getcomponent<faceplayer>().enabled = false;
            //transform.getcomponent<chaseplayer>().enabled = false;
            print("HitPlayer");
        }

        yield return new WaitForSeconds(windUp);

        Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity);

        if (hit.collider.tag == "Player")
        {
            //player.GetComponent<PlayerHealth>().TakeDamage(damage);
            print("HitPlayerAgain");
        }

        yield return new WaitForSeconds(attackDelay);

        //transform.GetComponent<FacePlayer>().enabled = true;
        //transform.GetComponent<ChasePlayer>().enabled = true;

        canAttack = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
