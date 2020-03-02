using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorScript : MonoBehaviour
{
    public Animator anim;
    private bool doorArea = false;
    public int keysToOpen;
    public Text promptText;


    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && doorArea == true && GameObject.FindGameObjectWithTag("Player").GetComponent<Keys>().keyCount > keysToOpen-1)
        {
            anim.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && !anim.enabled)
        {
            if(keysToOpen==1)promptText.text = keysToOpen + " Key Needed";
            else promptText.text = keysToOpen + " Keys Needed";
            doorArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            promptText.text = "";
            doorArea = false;
        }
    }
}
