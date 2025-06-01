using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasePlayer : MonoBehaviour
{
    // Declaring Variables 
    GameObject player;
    NavMeshAgent nav;
    [SerializeField] float detectionRange;
    bool detectedPlayer;

    void Awake()
    {
        // Finding  The Components 
        player = GameObject.FindGameObjectWithTag("Player");
        nav = GetComponent<NavMeshAgent>();
    }

    void Update()
    {   
        // Checks if the player is in range to be dected
        // if so it  makes the enmey chase the player
        var distance = player.transform.position - transform.position;
        if (detectionRange < distance.magnitude) detectedPlayer = true;
        if (detectedPlayer) nav.SetDestination(player.transform.position);
    }
}
