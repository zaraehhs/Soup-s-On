using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class origDragObject : MonoBehaviour

{
    //updated vs
    private Vector3 mOffset;


    //private Vector3 newLocation;
    private float mZCoord;
    private float zStart;
    private float xStart;
    private float yStart;
    private bool collide = false;
    private bool grabbed = false;
    private Vector3 newLocation;
    Rigidbody rb;

    //public GameObject : Transform;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        yStart = transform.position.y;
        xStart = transform.position.x;
        zStart = transform.position.z;
    }
    
    private void Update()
    {
        if (grabbed)
        {
            rb.useGravity = false;


            newLocation = GetMouseAsWorldPoint()+mOffset;
            //newLocation = GetMouseAsWorldPoint();// + mOffset;

            
            GameObject pot = GameObject.Find("pot");
            Transform potTransform = pot.transform;
            // get player position
            Vector3 potPosition = potTransform.position;
            Debug.Log("position = " + transform.position);
            Debug.Log("target position = " + newLocation);
           
            //Debug.Log("pot position = " + potPosition);


            //float disFromStart = System.Math.Abs(xStart - potPosition.x);
            //float disTotalToPot = System.Math.Abs(xStart - potPosition.x);
            //float percentToPot = disFromStart / disTotalToPot;
            //Debug.Log("ptp");
            //Debug.Log(percentToPot);

            newLocation.z = potPosition.z;
            
            //Vector3 direction = Vector3.MoveTowards(transform.position, newLocation, 1);

            Vector3 direction = new Vector3(newLocation.x - transform.position.x, newLocation.y - transform.position.y, potPosition.z).normalized;
            //direction = transform.TransformDirection(direction);
           
            
            Debug.DrawRay(transform.position, direction, Color.green);
            //Debug.DrawRay(transform.position, newLocation,Color.green);
            rb.AddForce(direction*100);
            /*
            Vector3 direction = Vector3.MoveTowards(transform.position, newLocation, step);
            float force = 10;
            rb.AddForce(force*direction);*/
        }
        else
        {
           
        }
    }
    private void OnMouseUp()
    {
        grabbed = false;
        rb.useGravity = true;
        rb.velocity = new Vector3(0, 0, 0);
    }

    void OnMouseDown()

    {

        //mZCoord = Camera.main.WorldToScreenPoint(

            //gameObject.transform.position).z;

        Debug.Log("mouse down");
        grabbed = true;

        // Store offset = gameobject world pos - mouse world pos

        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();

    }



    private Vector3 GetMouseAsWorldPoint()

    {

        // Pixel coordinates of mouse (x,y)

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = transform.position.z;
        float mousey = Camera.main.ScreenToWorldPoint(mousePos).y;
        float mousex = Camera.main.ScreenToWorldPoint(mousePos).x;
        return new Vector3(mousex, mousey, transform.position.z);


    }



    void OnMouseDrag()

    {/*
        //Vector3 newLocation = GetMouseAsWorldPoint() + mOffset;
        newLocation = GetMouseAsWorldPoint() + mOffset;
        //transform.position = GetMouseAsWorldPoint() + mOffset;


        GameObject pot = GameObject.Find("pot");
        Transform potTransform = pot.transform;
        // get player position
        Vector3 potPosition = potTransform.position;


        //float disFromStart = System.Math.Abs(xStart - potPosition.x);
        //float disTotalToPot = System.Math.Abs(xStart - potPosition.x);
        //float percentToPot = disFromStart / disTotalToPot;
        //Debug.Log("ptp");
        //Debug.Log(percentToPot);

        newLocation.z = potPosition.z;
        
        */


        //transform.position = newLocation;
        //}
        
        

      

    }

    

    

}
