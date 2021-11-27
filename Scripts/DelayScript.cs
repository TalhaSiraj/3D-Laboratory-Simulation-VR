using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayScript : MonoBehaviour
{
    private static bool Starttime = false;
    private static int countingunit = 0;
    private int counting = 0;
    
    void Start(){
        Debug.Log("DelayScript Start");
    }

    void Awake(){
        Debug.Log("AwakeScript Start");
    }
    void Update()
    {
        if(Starttime){
            increaseTimer();
        }
        Debug.Log("");
    }
    
    void increaseTimer(){
        counting = counting +1;
        if((countingunit+1) == counting){
            counting = 0;
            Starttime = false;
        }
    }

    public void setCounter(int value){
        countingunit = value;

    }
    public void ChangeTimerState(bool state){
        if(!Starttime){
            Starttime = state;
        }
    }

    public bool getTimerState(){
        return Starttime;
    }
}
