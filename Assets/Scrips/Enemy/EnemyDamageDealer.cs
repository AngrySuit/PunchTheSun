using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDamageDealer : MonoBehaviour
{

    // Declaring Variables 

    [SerializeField] int damage;
    [SerializeField] int attackDelay;

    bool canAttack = true;

    NavMeshAgent nav;
    GameObject player;

    private void Awake()
    {
        // Fetching varialbes 

        player = GameObject.FindGameObjectWithTag("Player");

        nav = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Checks if player is in range to be hit and calls the coroutine if it is 

        var distance = player.transform.position - transform.position;

        if (nav.stoppingDistance >= distance.magnitude && canAttack)
        {
            StartCoroutine("DealDamage",damage);
        }
    }

    private IEnumerator DealDamage(int damage)
    {
        // Stops the enemy temporarily while attacking and
        // dellays the next attack longer still

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
        // Draws the enemies range in the editor
        nav = GetComponent<NavMeshAgent>();
        Gizmos.DrawWireSphere(transform.position, nav.stoppingDistance);
    }
}
