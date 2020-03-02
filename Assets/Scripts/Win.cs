using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public GameObject status;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            status.SetActive(true);
            status.GetComponent<Text>().color = Color.green;
            status.GetComponent<Text>().text = "You Won";
            StartCoroutine("win");
        }
    }
    IEnumerator win()
    {
        for (int x = 0; x < 300; x++)
        {
            yield return new WaitForEndOfFrame();
        }
        Application.Quit();
    }

}
