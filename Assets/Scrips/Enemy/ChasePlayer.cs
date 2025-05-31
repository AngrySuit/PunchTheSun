using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasePlayer : MonoBehaviour
{
    // Declaring Variables //
    GameObject player;
    NavMeshAgent nav;

    void Awake()
    {
        // Finding  The Components //
        player = GameObject.FindGameObjectWithTag("Player");
        nav = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        
        nav.SetDestination(player.transform.position);
    }
}
