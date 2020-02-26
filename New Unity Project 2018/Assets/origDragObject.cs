using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class origDragObject : MonoBehaviour

{
    //updated vs
    private Vector3 mOffset;



    private float mZCoord;
    private float zStart;
    private float xStart;
    private float yStart;
    private bool collide = false;
    private bool grabbed = false;

    //public GameObject : Transform;
    void Start()
    {
        yStart = transform.position.y;
        xStart = transform.position.x;
        zStart = transform.position.z;
    }
    /*
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {  // if left mouse button pressed...
           // cast a ray from the mouse pointer
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (!dragObj)
            {  // if nothing picked yet...
               // and the ray hit some rigidbody...
                if (Physics.Raycast(ray, hit) && hit.rigidbody)
                {
                    dragObj = hit.transform;  // save picked object's transform
                    length = hit.distance;  // get "distance from the mouse pointer"
                }
            }
            else
            {  // if some object was picked...
               // calc velocity necessary to follow the mouse pointer
                var vel = (ray.GetPoint(length) - dragObj.position) * speed;
                // limit max velocity to avoid pass through objects
                if (vel.magnitude > maxSpeed) vel *= maxSpeed / vel.magnitude;
                // set object velocity
                dragObj.rigidbody.velocity = vel;
            }
        }
        else
        {  // no mouse button pressed
            dragObj = null;  // dragObj free to drag another object
        }
    }
    */

    void OnMouseDown()

    {

        mZCoord = Camera.main.WorldToScreenPoint(

            gameObject.transform.position).z;



        // Store offset = gameobject world pos - mouse world pos

        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();

    }



    private Vector3 GetMouseAsWorldPoint()

    {

        // Pixel coordinates of mouse (x,y)

        Vector3 mousePoint = Input.mousePosition;



        // z coordinate of game object on screen

        mousePoint.z = mZCoord;



        // Convert it to world points

        return Camera.main.ScreenToWorldPoint(mousePoint);

    }



    void OnMouseDrag()

    {
        Vector3 newLocation = GetMouseAsWorldPoint() + mOffset;
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
        
        if(newLocation.y < yStart)
        {
            newLocation.y = yStart;
        }

        //if(newLocation.x )
       // if (pot.GetComponent(typeof(Collider)).bounds.Contains(newLocation))
       // {
           // print("point is inside collider");
        //}
        if (!collide)
        {
            transform.position = newLocation;
        }
        
        

    }

    private void OnTriggerEnter(Collider other)
    {
        collide = true;
        Debug.Log("trigger enter");
    }

}
