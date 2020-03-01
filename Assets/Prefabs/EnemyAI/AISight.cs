using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AISight : MonoBehaviour
{
    public float view = 135f;//ai view in degrees
    public int playerInSight = -1;//state var
    public int playerMissing = -1;

    //might use the following for hearing
    //>>
    //public Vector3 playerLastPosition;
    //private NavMeshAgent agent;        

    private SphereCollider coll;//"length" of eyesight
    public GameObject[] player;//player reference

    private moveTo selfState;//reference to state machine

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
        coll = GetComponent<SphereCollider>();
        selfState = GetComponent<moveTo>();
    }

    void OnTriggerStay(Collider other)
    {
        bool hiding = player[0].GetComponent<playerStateTest>().isHiding;
        bool behindWall = false;
        if (selfState.isChasing == 1)
        {
            selfState.lastPlayerSight = player[0].transform;
        }

        //check if the player is in sight
        if (GameObject.ReferenceEquals(other.gameObject, player[0]))
        {
            //--------------------------------------------------------------------------------------------------------------------------------------------
            //playerInSight = -1;//default false
            //--------------------------------------------------------------------------------------------------------------------------------------------
            Vector3 directionPlayer = other.transform.position - transform.position; //make a vector pointing at the player
            float angle = Vector3.Angle(directionPlayer, transform.forward);//find angle between forward self and the player

            if (angle < 0.5f * view)//if player is less than half of our view angle...
            {
                RaycastHit wallChecker;
                //print(coll.radius);
                if (Physics.Raycast(transform.position + transform.up, directionPlayer.normalized, out wallChecker, coll.radius))//if there is a collider
                {
                    if (GameObject.ReferenceEquals(wallChecker.collider.gameObject, player[0]) && selfState.isChasing == 1)//if it's the player and we're chasing them
                    {
                        playerInSight = 1;//we can see the player (there was no wall, so if they are hiding we saw them hide)
                        playerMissing = -1;
                    }
                    else if (GameObject.ReferenceEquals(wallChecker.collider.gameObject, player[0]) && selfState.isHunting == 1)//if it's the player and we're hunting
                    {
                        if (hiding) //player[0].isHiding
                            playerInSight = -1;//cannot see player, player is hiding
                        else
                            //print("found you!");
                            playerInSight = 1;//can see player
                        playerMissing = -1;
                    }
                    else if (GameObject.ReferenceEquals(wallChecker.collider.gameObject, player[0]) && selfState.isSearching == 1)//if it's the player and we're searching
                    {
                        //print("there you are!");
                        if (hiding) //player[0].isHiding
                            playerInSight = -1;//cannot see player, player is hiding
                        else
                            playerInSight = 1;//can see player
                    }
                    else
                    {
                        behindWall = true;
                    }

                }
            }

        }
        if (selfState.isChasing == 1 && hiding == false && behindWall)//if chasing, as long as player is in the range keep chasing unless they hid while we couldn't see them
        {
            //print("player is in range although wall");
            playerInSight = 1;
        }
        if (selfState.isChasing == 1 && hiding && behindWall)//they hid while we are chasing them
        {
            //print("player hid");
            playerInSight = -1;
            playerMissing = 1;
            selfState.agent.destination = selfState.lastPlayerSight.position;//go to where the player last was before they disappeared
        }

        //make-shift onTriggerExit
        if (Mathf.Abs(player[0].transform.position.x - transform.position.x) > coll.radius && Mathf.Abs(player[0].transform.position.z - transform.position.z) > coll.radius)
        {
            //print("you've outrun me");
            if (GameObject.ReferenceEquals(other.gameObject, player[0]))//if player is not in vision
            {
                if (selfState.isChasing == 1)
                {
                    //player is missing!
                    playerMissing = 1;
                }
                selfState.agent.destination = selfState.lastPlayerSight.position;//go to where the player last was before they disappeared
                playerInSight = -1;//can no longer see the player
            }
        }

    }
}

