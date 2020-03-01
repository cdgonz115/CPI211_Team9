using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Animator anim;
    private bool doorArea = false;
    public int keyCount;

    // Start is called before the first frame update
    void Start()
    {
        keyCount = 0;
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && doorArea == true && keyCount > 0)
        {
            anim.enabled = true;
            keyCount--;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            doorArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            doorArea = false;
        }
    }
}
