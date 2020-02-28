using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{

    private bool keyArea = false;

    // Start is called before the first frame update
    void Start()
    {
        Inventory.keyCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && keyArea == true)
        {
            Inventory.keyCount++;
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            keyArea = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "player")
        {
            keyArea = false;
        }
    }
}
