using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Animation DoorOpen;
    private bool doorArea = false;
    public int keyCount;

    // Start is called before the first frame update
    void Start()
    {
        keyCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && doorArea == true && keyCount > 0)
        {
            GameObject.Find("Door").GetComponent<Animation>.Play("DoorOpen");
            keyCount--;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "player")
        {
            doorArea = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "player")
        {
            doorArea = false;
        }
    }
}
