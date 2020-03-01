using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{

    private bool keyArea = false;

    public GameObject a;
    private DoorScript doorStuff;

    // Start is called before the first frame update
    void Start()
    {
        doorStuff = a.GetComponent<DoorScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && keyArea == true)
        {
            doorStuff.keyCount++;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            keyArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            keyArea = false;
        }
    }
}
