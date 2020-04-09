using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newDragObject : MonoBehaviour
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

        if (newLocation.y < yStart)
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

        collide = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        collide = true;
        Debug.Log("trigger enter");
    }

}
