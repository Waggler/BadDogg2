using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController: MonoBehaviour
{
    private float hozMovement;
    private float vertMovement;

    public float speed;
    public int count; //set count to use integers
    private int lives;

    public bool dead;

    public Text countText; //create text for pickups
    public Text winText; //create win text
    public Text score;

    public ParticleSystem particles;

    private Rigidbody2D rd2d;

    public AudioClip boneSound;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        if (!this.gameObject.activeInHierarchy)
        {
            this.gameObject.SetActive(true);
        }
        rd2d = GetComponent<Rigidbody2D>();
        count = 0; //set count to 0 for bone pickups
        lives = 1; //set life or lives
        winText.text = "";
        SetCountText(); 
        SetLivesText();
        hozMovement = Input.GetAxis("Horizontal");
        vertMovement = Input.GetAxis("Vertical");
    }


    private void Update()
    {
        Vector3 movementDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        this.transform.position += movementDirection * speed * Time.deltaTime;
    } // END Update


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp")) //when a pickup is collected, add one to count and display it in count text
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
            audioSource.PlayOneShot(boneSound, 1f);

        }
        else if (other.gameObject.CompareTag("Enemy")) //when an enemy is collided with, subtract a life and display it in lives text if multiple lives
        {
            
            Instantiate(particles, this.gameObject.transform.position, this.gameObject.transform.rotation);
            lives -= 1;
            particles.gameObject.SetActive(true);
            particles.Play();
            //SetLivesText();
            other.gameObject.SetActive(false);
            dead = true;
            //AudioManager.PlaySound();
        }
    } // END OnTriggerEnter2D


    private void SetCountText()
    {
        countText.text = "Bones: " + count.ToString();
    } // END SetCountText


    private void SetLivesText()
    {
        if (lives <= 0) //if lives are 0 or less, destroy player and display text
        {
            winText.text = "You Lose! Please Try Again!";
            this.gameObject.SetActive(false);
        }
    } // END SetLivesText
}
