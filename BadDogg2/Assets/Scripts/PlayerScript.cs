using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerScript : MonoBehaviour
{
    public Text countText; //create text for pickups
    public Text winText; //create win text
    public Text score;
    public float speed;

    private Rigidbody2D rd2d;
    private int count; //set count to use integers
    private int lives;
    private int scoreValue = 0;
    private float hozMovement;
    private float vertMovement;

    // Start is called before the first frame update
    void Start()
    {
        if(!this.gameObject.activeInHierarchy)
        {
            this.gameObject.SetActive(true);
        }

        rd2d = GetComponent<Rigidbody2D>();
        count = 0; //set count to 0
        lives = 1; //set lives to 3
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
        }
        else if (other.gameObject.CompareTag("Enemy")) //when an enemy is collected, subtract a life and display it in lives text
        {
            other.gameObject.SetActive(false);
            lives -= 1;
            SetLivesText();
        }
    } // END OnTriggerEnter2D


    private void SetCountText()
    {
        countText.text = "Score: " + count.ToString();

        if (count >= 5) //if count is 20 or higher display win text
        {
            winText.text = "You Win! Game created by Kevin H. Davis!";
        }
    } // END SetCountText


    private void SetLivesText()
    {
        if (lives <= 0) //if lives are 0 or less, destroy player and display text
        {
            winText.text = "You Lose! Please Try Again!";
            this.gameObject.SetActive(false);
            //Destroy(this.gameObject);
        }
    } // END SetLivesText
}
