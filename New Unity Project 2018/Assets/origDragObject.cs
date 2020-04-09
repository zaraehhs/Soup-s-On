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
    private float maxDrag = 20;
    private bool inWater = false;
    private bool counted;
    Rigidbody rb;
    GameObject infoCanvas;
    GameObject dropZone;
    Collider dropCol;
    private bool enteredDropZone;
    //public GameObject : Transform;
    void Start()
    {
        infoCanvas = GameObject.Find("InfoCanvas");
        dropZone = GameObject.Find("dropZone");
        dropCol = dropZone.GetComponent<BoxCollider>();
        enteredDropZone = false;
        counted = false;
        rb = GetComponent<Rigidbody>();
        yStart = transform.position.y;
        xStart = transform.position.x;
        zStart = transform.position.z;
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        rb.drag = 2;

    }
    
    private void Update()
    {
        if (grabbed)
        {
            rb.useGravity = false;


            newLocation = GetMouseAsWorldPoint() +mOffset;
            
            
            if (dropCol.bounds.Contains(newLocation))
            {
                newLocation = dropZone.transform.position;
                enteredDropZone = true;
            }


            GameObject pot = GameObject.Find("pot");
            Transform potTransform = pot.transform;
            // get player position
            Vector3 potPosition = potTransform.position;
            
            //Debug.Log("position = " + transform.position);
            //Debug.Log("target position = " + newLocation);

            //Debug.Log("pot position = " + potPosition);

            
            float disFromStart = System.Math.Abs(xStart - transform.position.x);
            float xDisTotalToPot = System.Math.Abs(xStart - potPosition.x);
            float percentToPot = disFromStart / xDisTotalToPot;
            if (percentToPot > 1)
            {
                percentToPot = 1;
            }
            //Debug.Log("ptp");
            //Debug.Log(percentToPot);
            float zDisTotalToPot = System.Math.Abs(zStart - potPosition.z);
            if (zStart > potPosition.z)
            {
                newLocation.z = zStart - zDisTotalToPot * percentToPot;
            }
            else
            {
                newLocation.z = zStart + zDisTotalToPot * percentToPot;
            }

           
            Vector3 direction = new Vector3(newLocation.x - transform.position.x, newLocation.y - transform.position.y, newLocation.z - transform.position.z);
            
            direction = direction.normalized;
            
            Debug.DrawRay(transform.position, direction, Color.green);

            float xDis = System.Math.Abs(newLocation.x - transform.position.x);
            float yDis = System.Math.Abs(newLocation.y - transform.position.y);
            float zDis = System.Math.Abs(newLocation.z - transform.position.z);
            float smoothDis = 1;
            
            float smoothx = 1;
            float smoothy = 1;
            float smoothz = 1;
            
            if (xDis < smoothDis)
            {
                smoothx = xDis / smoothDis;
            }
            if (yDis < smoothDis)
            {
                smoothy = yDis / smoothDis;
            }
            if (zDis < smoothDis)
            {
                smoothz = zDis / smoothDis;
            }
            direction.x *= smoothx;
            direction.y *= smoothy;
            direction.z *= smoothz;
            //rb.AddForce(direction*80);
            
            rb.velocity = direction * 15;
            
            
            //Debug.Log(rb.velocity);
            /*
            Vector3 direction = Vector3.MoveTowards(transform.position, newLocation, step);
            float force = 10;
            rb.AddForce(force*direction);*/
        }
        else
        {
            //rb.useGravity = true;
            if (inWater)
            {
                if(transform.position.y > yStart)
                {
                    transform.Translate(0, -0.001f, 0);
                }
                
                //rb.position = rb.position - new Vector3(0, (1 / 5), 0);
                //transform.position = transform.position - new Vector3(0, 1, 0)/10;
                //Debug.Log("moving down");
                //float newY = transform.position.y;
                //newY += 1;
                //transform.position = new Vector3(transform.position.x, newY, transform.position.z);
            }
           
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

        //Debug.Log("mouse down");
        if (!inWater)
        {
            grabbed = true;
        }
        

        // Store offset = gameobject world pos - mouse world pos

        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger entered: " + gameObject.tag);
        if (other.gameObject.tag == "Finish" && enteredDropZone)
        {
            rb.velocity = Vector3.zero;
           
            rb.useGravity = true;
            rb.isKinematic = true;
            Debug.Log("in water");
            inWater = true;
            grabbed = false;
            //rb.drag = 4;
            if (!counted)
            {
                infoCanvas.GetComponent<game>().addCount(gameObject.tag);
                counted = true;
            }
            
        }
       
    }
    //
    //{
    
        //}
    


    private Vector3 GetMouseAsWorldPoint()

    {

        // Pixel coordinates of mouse (x,y)
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = mZCoord;
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

        double smooth = 0.01;
            bool smoothx = false;
            bool smoothy = false;
            bool smoothz = false;
            if (System.Math.Abs(newLocation.x - transform.position.x) < smooth)
            {
                Debug.Log("smooth x");
                smoothx = true;
            }
            if (System.Math.Abs(newLocation.y - transform.position.y) < smooth)
            {
                Debug.Log("smooth y");
                smoothy = true;
            }
            if (System.Math.Abs(newLocation.z - transform.position.z) < smooth)
            {
                Debug.Log("smooth z");
                smoothz = true;
            }
        if (smoothx)
            {
                direction.x = 0;
            }
            if (smoothy)
            {
                direction.y = 0;
            }
            if (smoothz)
            {
                direction.z = 0;
            }
        */


        //transform.position = newLocation;
        //}





    }

    

    

}
