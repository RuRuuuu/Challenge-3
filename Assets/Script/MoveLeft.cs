using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 15f;
    private PlayerController  playerControllerScript; 
    //because playerController is a component we use it when assigning variable to it
  private float leftBound = -15;



    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        //this means we are getting the playerController script that is attached to the 
        //player object in the hierarchy and assigned it to that variable
        
    }

    // Update is called once per frame
    void Update()
    {

        if (playerControllerScript.gameOver == false)
        //what this mean is that if the gameOver variable in the playerControllerScript is
        //actually false its only then that the background and obstacle should move
        {
             transform.Translate(Vector3.left * Time.deltaTime * speed);  
        }
     
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        //this means that if the position of the tag named obstacle is -10 it should be destroyed  
        //since this script is used by both the obstacle component and the the background 
        //we use tag to get only the obstacle 
             {
           Destroy(gameObject); 
        } 
    }
}
