using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public GameObject panel;
    public GameObject message;
    public GameObject keys;
    public GameObject enemy;

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            enemy.SetActive(true);
            panel.SetActive(false);
            message.SetActive(false);
            keys.SetActive(true);
        }
    }
}
