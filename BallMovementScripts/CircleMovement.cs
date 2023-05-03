using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleMovement : MonoBehaviour
{


    private float horizontalMove;
    private bool leftMove;
    private bool rightMove;

    public float spd = 0.01f;

    public GameObject targetObject;
    
   public float x = 2f;
    public float speed = 5f;
   
    Rigidbody2D rb;
    private Vector3 target;

 


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("You Can't Pass the Block");
        
        
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = transform.position;

        leftMove = false;
        rightMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        keyMovemnet();
        movement();
        //clickMove();
    }



    public void keyMovemnet()
    {

        //Code for Key Movement Purpose


        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(x, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= new Vector3(x, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, x, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= new Vector3(0, x, 0);

        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(new Vector3(0f, 3000f, 0f));
        }

    }


    public void clickMove()
    {
        //For Click move purpose code

        if (Input.GetMouseButtonDown(0))
        {


            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
            transform.position = Vector3.MoveTowards(transform.position, target, 400f);


        }


        Vector2 position = new Vector2(0.0f, 0.0f);
        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        position = Vector2.Lerp(transform.position, cursorPosition, 1f);
        rb.MovePosition(position);

    }



    //Function for only Click move Purpose
    public void move(float sp)
    {
        rb.AddForce(transform.position * sp);
    }




    //Code For LonPress button move
    public void pointerDownLeft()
    {
        leftMove = true;
    

    }
    public void pointerUPLeft()
    {
        leftMove = false;
        
    }

    public void pointerDownRight()
    {
        rightMove = true;
    }

    public void pointerUpRight()
    {
        rightMove = false;
        
    }


  



    public void movement()
    {
        if(leftMove)
        {
            horizontalMove = -spd;
            
        }
        else if (rightMove)
        {

            horizontalMove = spd;
            
        }
        else
        {
            horizontalMove = 0;
            //spd = 0;
            
        }
    }

    

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
    }




    //Code to make Object Jump 
    public void jump(float jspeed)
    { 
      //  rb.AddForce(new Vector3(0f, 17000f, 0f));
       rb.AddForce(transform.up * jspeed);
    }
}
