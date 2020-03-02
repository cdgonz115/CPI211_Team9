using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keys : MonoBehaviour
{
    public int keyCount;
    public Text keys;

    public void UpdateKeys()
    {
        keys.text = "Keys: "+ keyCount;
    }
}
