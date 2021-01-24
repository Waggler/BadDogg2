using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector3 movement = new Vector3(0, 0, 0);
    public GameObject[] waypoints;
    public GameObject player;
    [SerializeField] private float speed;


    //array of waypoints represent where we will go.  
    //length of the array is how many times we will move.  Its our destination
    // if we reach the end of the array we will reset and go back to 0 (Our first destination)
    //once this works 
    // if(currentPosition < 1f == true && player.isTouchingPlayer == true)
    // kill player
    //else keepMoving()
    void Start()
    {
        CallCorotuine();

    }


    public void CallCorotuine()
    {
        StartCoroutine(IStartmovement());
    }


    public IEnumerator IStartmovement()
    {
        yield return new WaitForSeconds(2f);
    }


    private void MoveToPlayer()
    {
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);

        // Check if the position of the cube and sphere are approximately equal.
        //You can put logic here for when Enemy is close to player
        if (Vector3.Distance(transform.position, player.transform.position) < .1f)
        {

        }
    }


    void Update()
    {
        MoveToPlayer();
    }
}
