using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioClip musicClipOne;
    public AudioClip musicClipTwo;
    public AudioSource musicSource;
    public GameObject player;

    public int count;
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        count = player.gameObject.GetComponent<PlayerController>().count;
        //loseClip = audioManager.gameObject.GetComponent<PlayerController>().loseSound;
        musicSource = GetComponent<AudioSource>();
        if (count < 5)
        {
            /*Instantiate(loseAudio, new Vector3(0, 0, 0), Quaternion.identity);
            resultText.text = "You Lose! Please Try Again!";*/
            musicSource.Play();
            //OneShot(musicClipTwo, 0.2f);
        }
        else if (count == 5)
        {
            /*Instantiate(winAudio, new Vector3(0, 0, 0), Quaternion.identity);
            resultText.text = "You Win! Game created by Kevin H. Davis!";*/
            musicSource.Play();
            //OneShot(musicClipTwo, 0.2f);
        }
    }
}
