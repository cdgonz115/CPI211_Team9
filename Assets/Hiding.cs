using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hiding : MonoBehaviour
{
    private bool isHiding = false;
    public float space;

    private CharacterController cc;


    public Collider hidingPlace;
    private float distance;
    private Vector3 lastPos;

    public Text hideText;
    public Text promptText;

    // Start is called before the first frame update
    void Start()
    {
        hideText.text = "";
        promptText.text = "";
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, hidingPlace.transform.position);

        if(distance < space && isHiding == false)
        {
            hideText.text = "Hide in here?";
            promptText.text = "Press E to Hide";

            if (Input.GetKeyDown("e") && (isHiding == false))
            {
                lastPos = this.transform.position;
                transform.position = hidingPlace.transform.position;
                isHiding = true;
                cc.enabled = false;
                Wait();
            }
        }
        else if ((cc.enabled == false) && isHiding == true)
        {
            hideText.text = "Exit?";
            promptText.text = "Press E to Exit";

            if (Input.GetKeyDown("e") && (isHiding == true))
            {
                transform.position = lastPos;
                cc.enabled = true;
            }
        }
        else
        {
            hideText.text = "";
            promptText.text = "";
        }
    }

    private void OnTriggerEnter(Collider hidingPlace) //turn inHiding to true once you enter the collider
    {
        if(hidingPlace.gameObject.tag == "Hide")
        {
            isHiding = true;
        }
        else
        {
            isHiding = false;
        }
    }
    private void OnTriggerExit(Collider hidingPlace) //turn isHiding to false once you leave the other collider
    {
        if (hidingPlace.gameObject.tag == "Hide")
        {
            isHiding = false;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
    }
}
