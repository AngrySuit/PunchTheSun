using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDamageDealer : MonoBehaviour
{

    // Declaring Variables //

    [SerializeField] int damage = 10;
    [SerializeField] int attackDelay = 60;

    bool canAttack = true;

    NavMeshAgent nav;
    GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        nav = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        var distance = player.transform.position - transform.position;

        if (nav.stoppingDistance >= distance.magnitude && canAttack)
        {
            StartCoroutine("DealDamage",damage);
        }
    }

    private IEnumerator DealDamage(int damage)
    {
        canAttack = false;

        player.GetComponent<PlayerHealth>().ChangeHealth(damage);

        transform.GetComponent<ChasePlayer>().enabled = false;

        yield return new WaitForSeconds(attackDelay/2);

        transform.GetComponent<ChasePlayer>().enabled = true;

        yield return new WaitForSeconds(attackDelay);

        canAttack = true;
    }

    private void OnDrawGizmosSelected()
    {
        nav = GetComponent<NavMeshAgent>();
        Gizmos.DrawWireSphere(transform.position, nav.stoppingDistance);
    }
}
