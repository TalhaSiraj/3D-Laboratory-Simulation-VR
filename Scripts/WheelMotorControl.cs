using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelMotorControl : MonoBehaviour
{
    private string wheel_one="None";
    private string wheel_two="None";
    float wheelRotation = 15f;
    
    [HideInInspector]
    public string MovementKeyDown = "None";
    [HideInInspector]
    public static bool enableWheel = false;

    private DelayScript CS;

    void Start(){
        Debug.Log("WheelMotorController Start");
        try{
            CS = GameObject.FindObjectOfType(typeof(DelayScript)) as DelayScript;
        }catch(System.Exception e){}
    }

    void Awake(){
        Debug.Log("WheelMotorController Awake");
        try{
            CS = GameObject.FindObjectOfType(typeof(DelayScript)) as DelayScript;
        }catch(System.Exception e){}
    }

    void Update(){
        try{
            if(DragandDrop.labinstructionNumber == 16 && enableWheel){
                CS.setCounter(1);
                if(!CS.getTimerState()){
                    rotateWheel(wheelRotation);
                    CS.ChangeTimerState(true);
                }
            }
            if(DragandDrop.labinstructionNumber == 17 && enableWheel){
                if(!MovementKeyDown.Contains("None")){
                    if(!CS.getTimerState()){
                        CS.setCounter(1);
                    }
                    rotateWheel(wheelRotation);
                    CS.ChangeTimerState(true);
                }
            }else{
                if(!enableWheel){
                    wheel_one="None";
                    wheel_two="None";
                }
            }
        }catch(System.Exception e){}


    }


    public void rotateWheel(float speed){
        try{
            if(wheel_one.Contains("RightWheel") && wheel_two.Contains("LeftWheel") && MovementKeyDown.Contains("Up")){
                GameObject.Find("LeftWheel").transform.Rotate(0.5f*(-wheelRotation),90f,270f);
                GameObject.Find("RightWheel").transform.Rotate(0.5f*(-wheelRotation),90f,270f);
            }
            if(wheel_one.Contains("RightWheel") && wheel_two.Contains("LeftWheel") && MovementKeyDown.Contains("Down")){
                GameObject.Find("LeftWheel").transform.Rotate(0.5f*wheelRotation,90f,270f);
                GameObject.Find("RightWheel").transform.Rotate(0.5f*wheelRotation,90f,270f);
            }
            if(wheel_one.Contains("RightWheel") && wheel_two.Contains("None")){
                //GameObject.Find("RightWheel").transform.rotation = Quaternion.Euler(2f*wheelRotation,90f,270f);
                GameObject.Find("RightWheel").transform.Rotate(0.5f*wheelRotation,90f,270f);
            }
            if(wheel_two.Contains("LeftWheel") && wheel_one.Contains("None")){
                GameObject.Find("LeftWheel").transform.Rotate(-0.5f*wheelRotation,90f,270f);
            }
        }catch(System.Exception e){}

    }

    public void setWheelone_name(string wheelone){
        wheel_one = wheelone;
    }

    public void setWheeltwo_name(string wheeltwo){
        wheel_two = wheeltwo;
    }

    public string getWheelone_name(){
        return wheel_one;
    }
}
