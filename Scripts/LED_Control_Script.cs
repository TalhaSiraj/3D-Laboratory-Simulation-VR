using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LED_Control_Script : MonoBehaviour
{
    private DragandDrop DAD;

    private GameObject parent;
    private static bool Starttime = false , GlowingLED = false , break_time = false;
    private static int countingunit=1;
    private static int counting;
    private static int Validatepatternindex = 0;
    private static int i = 0;

    [HideInInspector]
    public List<string> LEDNAMES = new List<string>{"LED 5mm ON","LED  Blue","LED  Yellow","LED  Green"};
    public static bool CheckPattern = false;


    List<string> ButtonsNAMES = new List<string>{"push button Red","push button Blue","push button Yellow","push button Green"};
    void Start(){
        Debug.Log("LEd Script Start");
        counting = 0;
    }
    void Awake(){
        Debug.Log("LEd Script Awake");
    }

    void Update(){
        if(Starttime){
            increaseTimer();
        }
        if((DragandDrop.labinstructionNumber == 6) && PotentiometerScript_.satisfy){
            LEDPattern();
        }
    }

    public void EnabledLED(string nameofLED){
        try{
            parent = GameObject.Find(nameofLED);
            foreach (Transform child in parent.transform){
                if(child.name.Contains("Spot Light") && (!child.GetComponent<Light>().enabled)){
                    child.GetComponent<Light>().range = 0.5f;
                    child.GetComponent<Light>().enabled = true;
                    GlowingLED = true;
                }
            }
        }catch(System.Exception e){}
            
    }


    public void DisableLED(string nameofLED){
        try{
            parent = GameObject.Find(nameofLED);
            foreach (Transform child in parent.transform){
                if((child.name.Contains("Spot Light") && (child.GetComponent<Light>().enabled)) || (child.name.Contains("Spot Light (1)")&& (child.GetComponent<Light>().enabled))){
                    child.GetComponent<Light>().range = 0.5f;
                    child.GetComponent<Light>().enabled = false;
                    GlowingLED = false;
                }
            }
        }catch(System.Exception e){}
        
    }

    void increaseTimer(){
        counting =counting + 1;
        if(countingunit == counting){
            counting = 0;
            Starttime = false;
        }
    }

    void setCounter(int value){
        countingunit = value;

    }
    public void ChangeTimerStart(bool state){
        Starttime = state;
    }

    public bool getStateOfTimer(){
        return Starttime;
    }

    void LEDPattern(){
        if(DragandDrop.labinstructionNumber == 6){
                if(!Starttime && (!GlowingLED) && (!break_time) && (i <= (LEDNAMES.Count-1))){
                    try{
                        setCounter(100);
                        Starttime = true;
                        EnabledLED(LEDNAMES[i]);
                    }catch(System.Exception e){}
                }else{
                    if(i <= (LEDNAMES.Count-1)){
                        if(!Starttime && (GlowingLED) && (!break_time)){
                            try{
                                DisableLED(LEDNAMES[i]);
                            }catch(System.Exception e){}
                            if(i < LEDNAMES.Count){
                                setCounter(10);
                                i = i+1;
                                Starttime = true;
                                break_time = true;
                            }
                        }else{
                            if((!Starttime) && break_time){
                                break_time = false;
                            }
                    }
                }else{
                    CheckPattern = true;
                }
                    
            }

        }
    }

    public void ValidateLedPattern(string ledname){
        if(ButtonsNAMES[Validatepatternindex].Contains(ledname)){
            EnabledLED(LEDNAMES[Validatepatternindex]);
            Validatepatternindex = Validatepatternindex+1;
            if(Validatepatternindex >= LEDNAMES.Count){
                Validatepatternindex = 0;
                Starttime = false ;
                GlowingLED = false ;
                break_time = false;
                countingunit=1;
                counting = 0;
                i = 0;
                DAD = GameObject.FindObjectOfType(typeof(DragandDrop)) as DragandDrop;
                FindObjectOfType<AudioManager>().Play("patterncompleted");
                DAD.TriggerMusic(true);
                foreach(string name in LEDNAMES){
                    DisableLED(name);
                }
            }
            
        }else{
            for(int i = 0 ; i< Validatepatternindex ; i++){
                DisableLED(LEDNAMES[i]);
            }
            Starttime = false ;
            GlowingLED = false ;
            break_time = false;
            countingunit=1;
            counting = 0;
            Validatepatternindex = 0;
            i = 0;
            ChangeTimerStart(true);
        }

    }
}
