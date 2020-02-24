using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
public class Health : MonoBehaviour
{
    [SerializeField] public Text ht;
    public int health;
    private bool inv;
    private float timeLeft;
    public GameObject deathcam;
    public GameObject fps;
    public GameObject canvas;
    public AudioSource ads;
    public AudioClip oof;
    private void Start() => ht.text = "Health: "+health;
    public void takeDamage()
    {
        if (timeLeft<0)
        {
            ads.volume = 10;
            ads.PlayOneShot(oof);
            ads.volume = 1;
            health--;
            ht.text = "Health: " + health;
            timeLeft = 1;

        }
    }
    private void FixedUpdate()
    {
        timeLeft -= Time.deltaTime;
        if (health <= 0)
        {
            GetComponent<CharacterController>().enabled = false;
            GetComponent<FirstPersonController>().enabled = false;
            fps.SetActive(false);
            canvas.SetActive(false);            deathcam.SetActive(true);

        }
    }
        
}
