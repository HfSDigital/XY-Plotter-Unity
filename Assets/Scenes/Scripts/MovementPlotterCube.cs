using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;



public class MovementPlotterCube : MonoBehaviour
{
    public Vector3 posX;
    public Vector3 posY;
    public float speed = 1;
    public string portName;
    SerialPort plotter;
    public int xPos;
    public int yPos;
   

    // Use this for initialization
    void Start()
    {
        plotter = new SerialPort("COM5", 115200);
        plotter.Open();
 
    }

  
     
  

    // Update is called once per frame
    void Update()
    {
        if (plotter.IsOpen)
        {
            print("plotter an");
        }
       if (Input.GetKeyDown(KeyCode.H))
        {

            plotter.WriteLine("G28");
            xPos = 0;
            yPos = 0;
        } 

        if (Input.GetKeyDown(KeyCode.RightArrow))   // x-Achse
        {
            print("right key is pressed");
            MoveX();
            xPos++;

        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            print("up key is pressed");
            MoveY();
            yPos++;

            //plotter.WriteLine("G1 Y100");


        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            print("left key is pressed");
            MoveX();
            xPos--;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            print("down key is pressed");
            MoveY();
            yPos--;
        }

        plotter.WriteLine("G1 X" + xPos.ToString());
       plotter.WriteLine("G1 Y" + yPos.ToString());

    }

    void MoveX()
    {
        transform.position += posX * speed;

    }
    void MoveY()
    {
        transform.position += posY * speed;
    }
}