using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float curentTimer = 10;
    [SerializeField] private float resetTimer = 10;
    private bool dead = false;

    public Text timerText;
    public Text resultText;
    public Text quitText;
    public GameObject player;
    public GameObject enemy;
    public GameObject pickUp;
    public AudioSource musicSource;
    public AudioSource musicSource2;
    public int count = 0;
    public bool isEndOfGame = false;
    
    void Start()
    {
        dead = player.gameObject.GetComponent<PlayerController>().dead;
        musicSource.gameObject.SetActive(false);
        musicSource2.gameObject.SetActive(false);
    }


    void Update()
    {
        count = player.gameObject.GetComponent<PlayerController>().count;
        Timer();
        PlayAudio();
    }


    IEnumerator EndGameConditions()
    {
        yield return new WaitForSeconds(curentTimer);
        
        player.gameObject.SetActive(false);
        enemy.gameObject.SetActive(false);
        pickUp.gameObject.SetActive(false);
        isEndOfGame = true;

        if ((count <= 5) && (dead == true))
        {
            resultText.text = "You Lose! Please Try Again!";
        }
        else
        {
            resultText.text = "You Win! Game created by Kevin H. Davis!";
        }
        ChangeText();
    }


    public void ChangeText()
    {
        StartCoroutine(IChangeText());
    }


    IEnumerator IChangeText()
    {
        yield return new WaitForSeconds(2f);

        resultText.gameObject.SetActive(false);
        quitText.text = "Press the ESC key to Quit!";
    }


    private void Timer()
    {
        dead = player.gameObject.GetComponent<PlayerController>().dead;

        if (dead == true)
        {
            curentTimer = 0;
            timerText.text = curentTimer.ToString("0");
            StartCoroutine(EndGameConditions());
        }
        else
        {
            curentTimer -= 1 * Time.deltaTime;
            timerText.text = curentTimer.ToString("0");

            if (curentTimer <= 0)
            {
                curentTimer = 0;
                StartCoroutine(EndGameConditions());
            }
        }

    }


    private void PlayAudio()
    {
        if ((count <= 5) && (isEndOfGame == true) && (dead == true))
        {
            musicSource.gameObject.SetActive(true);
        }
        else if ((isEndOfGame == true) && (count == 5) && (dead == false))
        {
            musicSource2.gameObject.SetActive(true);
        }
    }
}
