using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServoMotorScript : MonoBehaviour
{
    void Start () {
        Debug.Log("ServoMotor Script Start");
    }

    void Awake () {
        Debug.Log("ServoMotor Script Awake");
    }
    public void MoveServoMotor(string Direction,float rotateX,float increment){
        if(PotentiometerScript_.satisfy && (DragandDrop.labinstructionNumber == 7)){
            if(Direction.Contains("negativeX")){
                GameObject.Find("servo part 2-1").transform.rotation = Quaternion.Euler(0,-(rotateX*increment),0);
            }
            if(Direction.Contains("positiveX")){
                GameObject.Find("servo part 2-1").transform.rotation = Quaternion.Euler(0,(rotateX*increment),0);
            }
            
        }
    }
    
    public void MoveServoMotor(float increment){
        // GameObject.Find("servo part 2-1").transform.rotation = Quaternion.Euler(0,increment*4000.0f,0);
        // Debug.Log(GameObject.Find("servo part 2-1").transform.rotation);
        GameObject.Find("servo part 2-1").transform.Rotate(0f, increment*10f, 0.0f, Space.World);
    }

}
