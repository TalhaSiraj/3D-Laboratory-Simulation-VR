using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    private DragandDrop DAD;
    private LED_Control_Script LCS;
    private DelayScript DS;
    static List<string> LEDNAMES_ = new List<string>{};

    void Start(){
        Debug.Log("ButtonScript Start");
        LCS = GameObject.FindObjectOfType(typeof(LED_Control_Script)) as LED_Control_Script;
    }
    void Awake(){
        Debug.Log("ButtonScript Awake");
        LCS = GameObject.FindObjectOfType(typeof(LED_Control_Script)) as LED_Control_Script;
    }
    void Update(){
        if((DragandDrop.labinstructionNumber == 6) && PotentiometerScript_.satisfy){
            if(LEDNAMES_.Count == 4){
                foreach(string ledname in LEDNAMES_){
                    LCS.DisableLED(ledname);
                }
            }
        }
    }

    void OnMouseDown(){
        DAD = GameObject.FindObjectOfType(typeof(DragandDrop)) as DragandDrop;
        
        if(gameObject.name.Contains("push button Blue")){
            if(DragandDrop.labinstructionNumber == 5 && DAD.getMusicState()){
                FindObjectOfType<AudioManager>().StopMusic();
                FindObjectOfType<AudioManager>().Play("Buzzerlab1");
            }
            if(DragandDrop.labinstructionNumber == 6 && DAD.getMusicState()){
                FindObjectOfType<AudioManager>().StopMusic();
                FindObjectOfType<AudioManager>().Play("Buzzerlab1");
                LCS.EnabledLED("LED  Blue");
                LEDNAMES_.Add("LED  Blue");
            }
        }
        if(gameObject.name.Contains("push button Red")){
            if(DragandDrop.labinstructionNumber == 5 && DAD.getMusicState()){
                FindObjectOfType<AudioManager>().StopMusic();
                FindObjectOfType<AudioManager>().Play("Buzzerlab2");
            }
            if(DragandDrop.labinstructionNumber == 6 && DAD.getMusicState()){
                FindObjectOfType<AudioManager>().StopMusic();
                FindObjectOfType<AudioManager>().Play("Buzzerlab2");
                LCS.EnabledLED("LED 5mm ON");
                LEDNAMES_.Add("LED 5mm ON");
            }
        }
        if(gameObject.name.Contains("push button Yellow")){
            if(DragandDrop.labinstructionNumber == 5 && DAD.getMusicState()){
                FindObjectOfType<AudioManager>().StopMusic();
                FindObjectOfType<AudioManager>().Play("Buzzerlab3");
            }
            if(DragandDrop.labinstructionNumber == 6 && DAD.getMusicState()){
                FindObjectOfType<AudioManager>().StopMusic();
                FindObjectOfType<AudioManager>().Play("Buzzerlab3");
                LCS.EnabledLED("LED  Yellow");
                LEDNAMES_.Add("LED  Yellow");
            }
        }
        if(gameObject.name.Contains("push button Green")){
            if(DragandDrop.labinstructionNumber == 6 && DAD.getMusicState()){
                FindObjectOfType<AudioManager>().StopMusic();
                FindObjectOfType<AudioManager>().Play("Buzzerlab2");
                LCS.EnabledLED("LED  Green");
                LEDNAMES_.Add("LED  Green");
            }
        }
    }

    bool match_Pattern(){
        int points = 1;
        for(int i = 0 ; i < LEDNAMES_.Count ; i++){
            if(LEDNAMES_[i].Contains(LCS.LEDNAMES[i])){
                points = points +1;
            }
        }
        if(points == 4){
            return true;
        }else{
            return false;
        }
    }
}
