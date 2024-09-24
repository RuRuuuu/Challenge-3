using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 startPos;
    private float repeatWidth;
    void Start()
    {

         startPos = transform.position;
        //this means that the initial position of this gameObject is assigned to this variable 


        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
        //what this mean is that we stored the box collider of the image size in the x axis and divided
        // it by 2 since the background id actually two images connected together so we can get each end of the 
        //background image so we can use it in creating the infinite background


      
      
    }

    // Update is called once per frame
    void Update()
    {
    if (transform.position.x < startPos.x - repeatWidth)
    //this means that if the current position x axis of the object at the update is less that the start or
    //initial position x axis minus small space or offset whish is 50 then the current position should be the 
    //start position (endless circle)
     {
        transform.position = startPos;
    }
        
    }
}
