using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyScript : MonoBehaviour
{
    public Text promptText; 

    private bool keyArea = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && keyArea == true)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Keys>().keyCount++;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Keys>().UpdateKeys();
            Destroy(gameObject);
            promptText.text = "";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            keyArea = true;
            promptText.text = "Press E to PickUp";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            keyArea = false;
            promptText.text = "";
        }
    }
}
