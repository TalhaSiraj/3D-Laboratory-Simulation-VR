using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IRSensorScript_ : MonoBehaviour
{

    static int count;
    static int objectchangedCalculate;
    TextScript ts;
    private LED_Control_Script LCS;

    void Start(){
        Debug.Log("IR Sensor Start");
        count = 0;
        objectchangedCalculate= 0;
        LCS = GameObject.FindObjectOfType(typeof(LED_Control_Script)) as LED_Control_Script;
    }
    void Awake(){
        Debug.Log("IR Sensor Awake");
        LCS = GameObject.FindObjectOfType(typeof(LED_Control_Script)) as LED_Control_Script;
    }

    void Update(){
        Debug.Log("");
    }

    public void ChangeLEDColor(float increment ,string CollidedObject){
        try{
            if(DragandDrop.labinstructionNumber == 13){
                if((increment>=0.0 && increment <= 0.5)  && CollidedObject.Contains("Obsticle")){
                    LCS.EnabledLED("LED 5mm ON");
                }else{
                    LCS.DisableLED("LED 5mm ON");
                }
            }
            if(DragandDrop.labinstructionNumber == 14){
                if((PotentiometerScript_.Increment  == increment) && CollidedObject.Contains("Obsticle")){
                    FindObjectOfType<AudioManager>().Play("Buzzerlab1");
                    AudioListener.volume = 0.5f;
                }else{
                    FindObjectOfType<AudioManager>().StopMusic();
                }
            }
            if(DragandDrop.labinstructionNumber == 15){
                ts = GameObject.FindObjectOfType(typeof(TextScript)) as TextScript;
                if((increment>=0.0 && increment <= 0.5)  && CollidedObject.Contains("Obsticle")){
                    ts.changemoniterTXTTextState(true);
                    count = count+1;
                    ts.SetmoniterTXTScreenText(count.ToString());
                    FindObjectOfType<AudioManager>().Play("Buzzerlab1");
                    AudioListener.volume = 0.5f;
                }else{
                    FindObjectOfType<AudioManager>().StopMusic();
                }
            }
        }catch(System.Exception e){}
    }
}
