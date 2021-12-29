using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private Vector2 minPos, maxPos;
    [SerializeField] private float xIncrement, yIncrement;
    [SerializeField] private Vector2[] possibleStartingPositions;
    private Transform myTransform = null;

    // Start is called before the first frame update
    void Awake()
    {
        myTransform = transform;
    }

    private void Start()
    {
        myTransform.position = possibleStartingPositions[Random.Range(0, possibleStartingPositions.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        //UP input
        if (Input.GetKeyDown(KeyCode.W))
        {
            MoveVertical(1);
        }
        //DOWN input
        if(Input.GetKeyDown(KeyCode.S))
        {
            MoveVertical(-1);
        }
        //RIGHT input
        if(Input.GetKeyDown(KeyCode.D))
        {
            MoveHorizontal(1);
        }
        //LEFT input
        if(Input.GetKeyDown(KeyCode.A))
        {
            MoveHorizontal(-1);
        }
    }

    //Moves player in the horizontal direction
    private void MoveHorizontal(int xValue)
    {
        //Define future position x
        float xPlacement = xIncrement * xValue + myTransform.position.x;
        Debug.Log(xPlacement);

        //Restrict xPlacement
        if(xPlacement > maxPos.x)
        {
            xPlacement = minPos.x;
        }
        else if(xPlacement < minPos.x)
        {
            xPlacement = maxPos.x;
        }

        //Set position
        myTransform.position = new Vector2(xPlacement, myTransform.position.y);
    }

    //Moves player in the vertical direction
    private void MoveVertical(int yValue)
    {
        //Define future position y
        float yPlacement = yIncrement * yValue + myTransform.position.y;
        Debug.Log(yPlacement);

        //Restrict yPlacement
        if (yPlacement > maxPos.y)
        {
            yPlacement = minPos.y;
        }
        else if(yPlacement < minPos.y)
        {
            yPlacement = maxPos.y;
        }

        //Set position
        myTransform.position = new Vector2(myTransform.position.x, yPlacement);
    }
}
