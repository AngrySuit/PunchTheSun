using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 10;
    [SerializeField] int attackDelay = 60;

    bool canAttack = true;
    float attackDelayScaled;


    NavMeshAgent nav;
    GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        nav = GetComponent<NavMeshAgent>();

        attackDelayScaled = attackDelay * Time.deltaTime;
    }


    // Update is called once per frame
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

        player.GetComponent<PlayerHealth>().TakeDamage(damage);

        transform.GetComponent<ChasePlayer>().enabled = false;

        yield return new WaitForSeconds(2);

        transform.GetComponent<ChasePlayer>().enabled = false;

        canAttack = true;
    }

    private void OnDrawGizmosSelected()
    {
        nav = GetComponent<NavMeshAgent>();
        Gizmos.DrawWireSphere(transform.position, nav.stoppingDistance);
    }
}
