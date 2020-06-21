using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    //Float values to define the box's position 
    private float min_x = -2.9f;
    private float max_x = 2.9f;

    
    private bool canMove;

    //Define the box speed
    private float speed = 10f;


    //Get Access to the player's rigidbody
    private Rigidbody2D rb;

    private bool isGameOver;
    private bool ignoreCollision;
    private bool ignoreTriggerEnt;


    //Set the gravity scale of the box to 0 when the script is exectued first
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }


    void Start()
    {
        //check if the box is moving or not 
        canMove = true;
        //Randomly define the position of the player
        if(Random.Range(0,2)>0){

            //add += -1 speed to change the direction
            speed += -1f;
        }
        //Send the instance to the gamemanager
        GameController.instance.boxScript = this;
    }

    // Update is called once per frame
    void Update()
    {
        //Call the move box on each frame update
        MoveBox();
    }

    void MoveBox()
    {
        //Check if the box can move or not 
        if(canMove){
            //declare a temp vector 3 position 
            Vector3 temp = transform.position;

            //Change the x axis of temp to make the box move 
            temp.x += speed * Time.deltaTime;

            //If the x value of temp is bigger than the max value of x 
            if (temp.x > max_x)
            {
                //change the direction
                speed *= -1f;
            }

            //else if the x value of temp is less than min value of x 
            else if (temp.x < min_x){

                //change the direction
                speed *= -1f;
            }
            //assign the box posi as temp 
            transform.position = temp;
        }
    }


    //Method to release the box 
    public void ReleaseBox()
    {
        //while releasing the box change the canMove bool to false
        canMove = false;
        //and set the gravity scale of box to random range of 2-4
        rb.gravityScale = Random.Range(2, 4);
    }



    //method to check if the box is released or not 
    void Released()
    {
        //if the game is over do nothing
        if(isGameOver){
            return;
        }
        //set ignore col and triger to true
        ignoreCollision = true;
        ignoreTriggerEnt = true;


        //get access to the gamecontroller instance and call the spawnnext box and move the camera
        GameController.instance.SpawnNextBox();
        GameController.instance.moveCamera();
    }

    //end game
    void RestartGame()
    {
        //call the restart game instace if the game is over 
        GameController.instance.RestartGame();
    }
    

    //collision checks
    void OnCollisionEnter2D(Collision2D col)
    {
        //if ignoreocllision is true return 
        if(ignoreCollision){
            return;
        }

        //if the collision object is platform 
        if(col.gameObject.tag=="Platform"){
            //call the release method 
            Invoke("Released", 0f);
            //set collision to true 
            ignoreCollision = true;
        }
        if (col.gameObject.tag == "Box")
        {
            //call the release method 
            Invoke("Released", 0f);
            //set collision to true 
            ignoreCollision = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (ignoreTriggerEnt)
        {
            return;
        }
        //if the collider tag is the gameover game object
        if(collider.tag=="GameOver"){
            //cancel the invoke landed method
            CancelInvoke("Landed");
            //set game over to true and call the restart game method
            isGameOver = true;
            ignoreTriggerEnt = true;
            Invoke("RestartGame",1f);
        }
       
    }



}
