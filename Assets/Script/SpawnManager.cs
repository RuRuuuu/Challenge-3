using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3 (25, 0,0);

    private float startDelay = 2;
    private float repeatRange = 2; 

   private PlayerController playerControllerScript;
    void Start()
    {
          InvokeRepeating("SpawnObstacle", startDelay, repeatRange);

          playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

          //this method is like the setinterval method in javascript, it takes three params
          //one is the function it should call  in string, 2, is how ma y times to start
          //2. is the  times to repeat
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnObstacle (){

           if (playerControllerScript.gameOver == false)
           {
            //this means that if the gameOver variable in the playerController script is 
            //false then the the obstacles should multiple  but if true its shouldnt
               Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation); 
               //this takes in three parameters
      //1, the  gameobject, 2.the new position and three the prefab or gameobjet initial position 
           }


       
      
    }
}
