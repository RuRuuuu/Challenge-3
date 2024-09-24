using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;

    //get the animator component in unity
    private Animator playerAnim;

    public bool isOnGround = true;

    public bool gameOver = false;


    //smoke particle
    public ParticleSystem explosionParticle;

    // dirt particle while running
    public ParticleSystem dirtParticle;

    //audio clips variables
    public AudioClip jumpSound;
    public AudioClip crashSound;

//this is for the audio source to add tge jump and crash clips
private AudioSource playerAudio;

    void Start()
    {
      playerRb  = GetComponent<Rigidbody>();
      Physics.gravity = Physics.gravity * gravityModifier;//this mean our gravity is initial 
      //gravity times whatever value we give to the gravityModifier variable 


      //the getcomponenet gets the component inside the <>
      //addforce adds force to an object and also you can add vector position to it, to move
    

    playerAnim = GetComponent<Animator>();
    //assigned the variable to get the animation component unity

      //get the audio component in the player from unity
      playerAudio = GetComponent<AudioSource>();
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        
        {
            playerRb.AddForce(Vector3.up * jumpForce ,ForceMode.Impulse);
           
            //what this does is that is the space key
            // is pressed the object should 
            //jump up(vector up) in the speed of 100 and 
            //they should be a force impulse attached too
            isOnGround = false;

            playerAnim.SetTrigger("Jump_trig");
            //is is setting the trigger to the type "jump_trig"
            //both setTrigger and "jump_trig" are inbuilt in unity

            dirtParticle.Stop();


            playerAudio.PlayOneShot(jumpSound, 1.0f);
            //this means that we want the player to have a sound when they jump and
            //the float is for the volume of the sound
        }
    }



    ///this collision function is what is called when the gameObject collides(touches) with something
       private void OnCollisionEnter(Collision collision){
       if (collision.gameObject.CompareTag("Ground"))
       //this means that if this gameObject collides with any object that has a tag attached to it 
       // called "ground" then the if statement should be executed
       {
          isOnGround = true;
          dirtParticle.Play();
       }else if (collision.gameObject.CompareTag("Obstacle"))
       // if this gameObject collides with any object that has a tag attached to it 
       // called "obstacle" then the if  else statement should be executed
       {
        gameOver = true;
        Debug.Log("game over!!!");
        playerAnim.SetBool("Death_b", true);
        playerAnim.SetInteger("DeathType_int", 1);
        //this mean that death animation is a bolean thats why we use setBool
        //and also it also gets an integal indicating the type of death we want for the player
        //we we use choose 1 which is the first one in the animation layer on unity
         explosionParticle.Play(); 
         dirtParticle.Stop();



         playerAudio.PlayOneShot(crashSound, 1.0f);

       
       }

      
        //when its collides with something the boolean should be set back to the initial value

    }
   
}
