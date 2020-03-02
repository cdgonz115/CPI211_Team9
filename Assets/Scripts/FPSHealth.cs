using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FPSHealth : MonoBehaviour
{
    public bool Alive = true;
    public GameObject status;
    public Text keys;
    public Text message;
    public GameObject panel;

    private void FixedUpdate()
    {
        if (Input.anyKeyDown && !Alive) RestartGame();
    }

    public void Lost()
    {
        panel.SetActive(true);
        status.SetActive(true);
        status.GetComponent<Text>().color = Color.red;
        status.GetComponent<Text>().text = "You Died";
        keys.enabled = false;
        message.text="Press any key to restart";

        Alive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Graveyard");
    }
}
