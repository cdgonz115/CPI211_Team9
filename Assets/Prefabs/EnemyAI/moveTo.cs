using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class moveTo : MonoBehaviour
{
    //init vars
    public NavMeshAgent agent;
    private AISight selfSight;

    //states
    public int isHunting = -1;
    public int isChasing = -1;
    public int isSearching = -1;

    //roaming route
    public Transform[] pathPoints = new Transform[4];
    public int pathIndex = 0;
    private Transform playerPos;
    private GameObject[] player;
    public Transform lastPlayerSight;

    //constants
    public float huntSpeed = 3f;
    public float chaseSpeed = 8f;
    public float searchSpeed = 5f;

    //init vars
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        selfSight = GetComponent<AISight>();
        player = GameObject.FindGameObjectsWithTag("Player");//player reference
        playerPos = player[0].transform;
        lastPlayerSight = playerPos;
    }

    //state machine
    void Update()
    {
        if (selfSight.playerInSight == 1)//if the player is seen
        {
            Chasing();//chase them
        }
        else if (selfSight.playerMissing == 1)//if they went missing while they were being chased
        {
            Searching();//search a bit
        }
        else//otherwise
        {
            Hunting();//keep hunting
        }
    }

    //hunting the player by following a predetermined route based off of empty checkpoint objects placed in the level
    void Hunting()
    {
        isHunting = 1;
        isChasing = -1;
        isSearching = -1;
        agent.speed = huntSpeed;

        if (agent.remainingDistance <= agent.stoppingDistance)//if we have arrived at a checkpoint
        {
            if (pathIndex < 3)//move on to the next pathPoints.Length
            {
                pathIndex++;//increment
                
            }
            else
            {
                pathIndex = 0;//otherwise, reset to zero
            }
        }
        //print(pathIndex);
        agent.destination = pathPoints[pathIndex].position;//continue hunt route
    }

    //chasing the player by running at them according to the navmesh
    void Chasing()
    {
        isHunting = -1;
        isChasing = 1;
        isSearching = -1;
        agent.speed = chaseSpeed;
        agent.destination = playerPos.position;//chase the player
    }

    //searching for the player since they "disappeared"
    void Searching()
    {
        isHunting = -1;
        isChasing = -1;
        isSearching = 1;
        agent.speed = searchSpeed;
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            selfSight.playerMissing = -1;
        }
    }
}
