using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Hiding : MonoBehaviour
{
    public bool isHiding = false;
    public float space;

    private CharacterController cc;

    private FirstPersonController fps;
    private CameraMovement cm;
    public Collider hidingPlace;
    private float distance;
    private Vector3 lastPos;
    public Text promptText;

    // Start is called before the first frame update
    void Start()
    {

        promptText.text = "";
        cc = GetComponent<CharacterController>();
        fps = GetComponent<FirstPersonController>();
        cm = GetComponentInChildren<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, hidingPlace.transform.position);

        if(distance < space && isHiding == false)
        {
            promptText.text = "Press E to Hide";

            if (Input.GetKeyDown("e") && (isHiding == false))
            {
                isHiding = true;
                lastPos = this.transform.position;
                transform.position = hidingPlace.transform.position+new Vector3(0,3.5f,0)+(.5f)*hidingPlace.transform.forward;
                cc.enabled = false;
                fps.enabled = false;
                cm.enabled = true;
                Wait();
            }
        }
        else if ((cc.enabled == false) && isHiding == true)
        {
            promptText.text = "Press E to Exit";

            if (Input.GetKeyDown("e") && (isHiding == true))
            {
                isHiding = false;
                transform.position = lastPos;
                cc.enabled = true;
                fps.enabled = true;
                cm.enabled = false;
            }
        }
        else
        {
            promptText.text = "";
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
    }
}
