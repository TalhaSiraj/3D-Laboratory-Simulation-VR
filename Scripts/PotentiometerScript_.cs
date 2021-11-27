using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotentiometerScript_ : MonoBehaviour
{
    private bool PotentiometerEnabled = false ;
    private float CurrentTime = 0.0f , Delay_ = 5.0f, RotationSpeed = 5.0f ;
    private static bool  pauseTime = false;
    [HideInInspector]
    public static bool satisfy = false;
    [HideInInspector]
    public static float Increment = 2f;

    private DragandDrop DAD;
    private ServoMotorScript SMS;
    private LCDScript_ LCDS;
    private TextScript TS;
    private RaycastScript RCS;

    void Start(){
        Debug.Log("PotentiometerScript Start");
    }
    void Awake(){
        Debug.Log("PotentiometerScript Awake");
    }
    
    void OnMouseOver(){
        PotentiometerEnabled = true;
        if(DragandDrop.labinstructionNumber == 14){
            try{
                if(gameObject.name.Contains("3") ||gameObject.name.Contains("IRBOX") || gameObject.name.Contains("IRINNERBOX") || gameObject.name.Contains("RightClickRotateIR") || gameObject.name.Contains("LeftClickRotateIR")){
                    pauseTime = true;
                }else{
                    pauseTime = false;
                }
            }catch(System.Exception e){}

        }else{
            try{
                if(gameObject.tag.Contains("10k_ohm_potentiometer") || gameObject.name.Contains("10k Ohm Potentiometer") || gameObject.name.Contains("RightClickRotate") || gameObject.name.Contains("LeftClickRotate")){
                    
                    GameObject.Find("potentiometerRotater").GetComponent<MeshRenderer>().enabled = true;
                    
                    pauseTime = true;
                }else{
                    pauseTime = false;
                }
            }catch(System.Exception e){}
        }

    }

    void OnMouseDown(){
        if(pauseTime && satisfy && (DragandDrop.labinstructionNumber == 3)){
                float RotateX = GameObject.Find("potentiometerRotater").transform.rotation.x;
                if(gameObject.name.Contains("RightClickRotate")){
                    Increment = Increment-90.0f;
                    if(Increment<0.0){Increment = 0.0f;}
                    RotateX = RotateX-Increment;
                    if(RotateX >= 0.0){
                        GameObject.Find("potentiometerRotater").transform.rotation = Quaternion.Euler(-(RotateX),-90.0f,90.0f);
                        ChangeLEDColor(Increment);
                        Debug.Log("999 Right");
                    }
                }else{
                    Increment = Increment+90.0f;
                    if(Increment>360.0){Increment = 0.0f;}
                    RotateX = RotateX+Increment;
                    if(RotateX <= 360.0){
                        GameObject.Find("potentiometerRotater").transform.rotation = Quaternion.Euler((RotateX),-90.0f,90.0f);
                        ChangeLEDColor(Increment);
                        Debug.Log("999 Left");
                    }
                }
        }
    }

    void OnMouseDrag(){
        DAD = GameObject.FindObjectOfType(typeof(DragandDrop)) as DragandDrop;
        if(pauseTime && satisfy && (DragandDrop.labinstructionNumber == 1)){
            float RotateX =GameObject.Find("potentiometerRotater").transform.rotation.x;
            Debug.Log("Change LED Intensity");
            if(gameObject.name.Contains("RightClickRotate")){
                Increment = Increment-0.1f;
                if(RotateX>-1f){
                    GameObject.Find("potentiometerRotater").transform.rotation = Quaternion.Euler(-(RotateX*Increment),-90.0f,90.0f);
                    ChangeInsitityLED(Increment);
                    Debug.Log("Change LED Intensity D = "+Increment);
                }
            }else{
                Increment = Increment+0.2f;
                if((RotateX<360.0)){
                    GameObject.Find("potentiometerRotater").transform.rotation = Quaternion.Euler(-(RotateX*Increment),-90.0f,90.0f);
                    ChangeInsitityLED(Increment);
                    Debug.Log("Change LED Intensity I = "+Increment);
                }
            }
        }
        if((pauseTime && satisfy && (DragandDrop.labinstructionNumber == 4)) || (pauseTime && satisfy &&(DragandDrop.labinstructionNumber == 5)) ||  (pauseTime && satisfy &&(DragandDrop.labinstructionNumber == 6))){
            float RotateX =1f;
            Increment = AudioListener.volume;
            AudioManager AM =  GameObject.FindObjectOfType(typeof(AudioManager)) as AudioManager;
            if(gameObject.name.Contains("RightClickRotate")){
                RotateX = GameObject.Find("potentiometerRotater").transform.rotation.x;
                Increment = Increment-1f;
                if((-(RotateX*Increment))>0.0f){
                        GameObject.Find("potentiometerRotater").transform.rotation = Quaternion.Euler(-(RotateX*Increment),-90.0f,90.0f);
                        AudioListener.volume = Increment;
                }
            }else{
                
                if(gameObject.name.Contains("LeftClickRotate")){
                    RotateX = GameObject.Find("potentiometerRotater").transform.rotation.x;
                    Increment = Increment+1f;
                    if(((RotateX*Increment)<360.0)){
                        GameObject.Find("potentiometerRotater").transform.rotation = Quaternion.Euler(-(RotateX*Increment),-90.0f,90.0f);
                        AudioListener.volume = Increment;
                    }
                }
            }
        }
        if(pauseTime && satisfy && (DragandDrop.labinstructionNumber == 7)){
            float RotateX =1f;
            SMS = GameObject.FindObjectOfType(typeof(ServoMotorScript)) as ServoMotorScript;
            if(gameObject.name.Contains("RightClickRotate")){
                RotateX = GameObject.Find("potentiometerRotater").transform.rotation.x;
                Increment = (Increment-1f)*5;
                if((-(RotateX*Increment))<=0.0f){
                    GameObject.Find("potentiometerRotater").transform.rotation = Quaternion.Euler(-(RotateX*Increment),-90.0f,90.0f);
                    SMS.MoveServoMotor("negativeX",RotateX,Increment);
                }if(RotateX*Increment<-360){
                        Increment = 0;
                    }
                
            }else{
                
                if(gameObject.name.Contains("LeftClickRotate")){
                    RotateX = GameObject.Find("potentiometerRotater").transform.rotation.x;
                    Increment = (Increment+1f)*5;
                    if(((RotateX*Increment)<360.0)){
                        GameObject.Find("potentiometerRotater").transform.rotation = Quaternion.Euler(-(RotateX*Increment),-90.0f,90.0f);
                        SMS.MoveServoMotor("positiveX",RotateX,Increment);
                    }if(RotateX*Increment>360){
                        Increment = 0;
                    }
                }
            }
        }
        if(pauseTime && satisfy && (DragandDrop.labinstructionNumber == 10)){
            float RotateX =1f;
            LCDS = GameObject.FindObjectOfType(typeof(LCDScript_)) as LCDScript_;
            if(gameObject.name.Contains("RightClickRotate")){
                RotateX = GameObject.Find("potentiometerRotater").transform.rotation.x;
                Increment = (Increment-0.1f);
                if(Increment > 0.1f){
                    GameObject.Find("potentiometerRotater").transform.rotation = Quaternion.Euler((RotateX*10),-90.0f,90.0f);
                    LCDS.changeMetallicColorLCD(Increment);
                }if(Increment < 0f){
                        Increment = 0f;
                    }
                
            }else{
                if(gameObject.name.Contains("LeftClickRotate")){
                    RotateX = GameObject.Find("potentiometerRotater").transform.rotation.x;
                    Increment = (Increment+0.1f);
                    if(((Increment)<=1.0)){
                        GameObject.Find("potentiometerRotater").transform.rotation = Quaternion.Euler(-(RotateX*10),-90.0f,90.0f);
                        LCDS.changeMetallicColorLCD(Increment);
                    }if(Increment >= 1.0){
                        Increment = 0.9f;
                    }
                }
            }
        }
        if(pauseTime && satisfy && (DragandDrop.labinstructionNumber == 14)){
            TS = GameObject.FindObjectOfType(typeof(TextScript)) as TextScript;
            RCS = GameObject.FindObjectOfType(typeof(RaycastScript)) as RaycastScript;
                
            float RotateX =1f;
            if(gameObject.name.Contains("RightClickRotateIR")){
                Increment = (Increment-0.1f);
                if(Increment < 0){
                        Increment = 0;
                }
                RCS.setDistance(Increment);                     
                TS.changeIR_DistanceTextState(true);
                TS.SetIR_DistanceScreenText(Increment.ToString());
                
            }else{
                if(gameObject.name.Contains("LeftClickRotateIR")){
                    Increment = (Increment+0.1f);
                    if(Increment>360){
                        Increment = 0;
                    }
                }
                RCS.setDistance(Increment);
                TS.changeIR_DistanceTextState(true);
                TS.SetIR_DistanceScreenText(Increment.ToString());
            }
        }
    }

    public void ChangeLEDColor(float increment){
        try{
            if(DragandDrop.labinstructionNumber == 3){
                if(increment<= 90.0){
                    GameObject parent = GameObject.Find("Led RGB light 5mm1D ON");
                    foreach (Transform child in parent.transform){
                        if(child.name.Contains("9")){
                            child.GetComponent<MeshRenderer>().material.color =new Color32(0,254,111,1);
                        }
                    }
                }else{
                    if(increment> 90.0 && increment<= 180.0){
                        GameObject parent = GameObject.Find("Led RGB light 5mm1D ON");
                        foreach (Transform child in parent.transform){
                            if(child.name.Contains("9")){
                                child.GetComponent<MeshRenderer>().material.color =new Color32(0,122,254,1);
                            }
                        }
                    }else{
                        if(increment> 180.0 && increment<= 270.0){
                            GameObject parent = GameObject.Find("Led RGB light 5mm1D ON");
                            foreach (Transform child in parent.transform){
                                if(child.name.Contains("9")){
                                   child.GetComponent<MeshRenderer>().material.color =new Color32(254,9,0,1);
                                }
                            }
                        }   
                    }   
                }
            }
            if(DragandDrop.labinstructionNumber == 8){
                if(increment <= 0.1){
                    GameObject parent = GameObject.Find("Led RGB light 5mm1D ON");
                    foreach (Transform child in parent.transform){
                        if(child.name.Contains("9")){
                            child.GetComponent<MeshRenderer>().material.color =new Color32(0,254,111,1);
                        }
                    }
                }else{
                    if(increment <= 0.2){
                        GameObject parent = GameObject.Find("Led RGB light 5mm1D ON");
                        foreach (Transform child in parent.transform){
                            if(child.name.Contains("9")){
                                child.GetComponent<MeshRenderer>().material.color =new Color32(0,122,254,1);
                            }
                        }
                    }else{
                        if(increment <= 0.3){
                            GameObject parent = GameObject.Find("Led RGB light 5mm1D ON");
                            foreach (Transform child in parent.transform){
                                if(child.name.Contains("9")){
                                   child.GetComponent<MeshRenderer>().material.color =new Color32(254,9,0,1);
                                }
                            }
                        }   
                    }   
                }
            }
            if(DragandDrop.labinstructionNumber == 9){
                SMS = GameObject.FindObjectOfType(typeof(ServoMotorScript)) as ServoMotorScript;
                if(increment == 0.6){
                    GameObject parent = GameObject.Find("Led RGB light 5mm1D ON");
                    foreach (Transform child in parent.transform){
                        if(child.name.Contains("9")){
                            child.GetComponent<MeshRenderer>().material.color =new Color32(0,254,111,1);
                        }
                    }
                    SMS.MoveServoMotor(3f);
                    FindObjectOfType<AudioManager>().StopMusic();
                    FindObjectOfType<AudioManager>().Play("Buzzerlab1");
                    AudioListener.volume = 10.0f; 
                }else{
                    if(increment == 1.0){
                        try{
                            GameObject parent = GameObject.Find("Led RGB light 5mm1D ON");
                            foreach (Transform child in parent.transform){
                                if(child.name.Contains("9")){
                                    child.GetComponent<MeshRenderer>().material.color =new Color32(0,122,254,1);
                                }
                            }                        
                        }catch(System.Exception e){}
                        SMS.MoveServoMotor(2f);
                        FindObjectOfType<AudioManager>().StopMusic();
                        FindObjectOfType<AudioManager>().Play("Buzzerlab1");
                        AudioListener.volume = 5.0f;
                    }else{
                        if(increment == 2.0){
                            GameObject parent = GameObject.Find("Led RGB light 5mm1D ON");
                            foreach (Transform child in parent.transform){
                                if(child.name.Contains("9")){
                                   child.GetComponent<MeshRenderer>().material.color =new Color32(254,9,0,1);
                                }
                            }
                            SMS.MoveServoMotor(1f);
                            FindObjectOfType<AudioManager>().StopMusic();
                            FindObjectOfType<AudioManager>().Play("Buzzerlab1");
                            AudioListener.volume = 1.0f; 
                        }else{
                            AudioListener.volume = 0.0f;
                        }

                    }
                }
            }

        }catch(System.Exception e){}
    }

// IEnumerator loopDelay ()
//     {

//         print("started delay");
//         yield return new WaitForSeconds(200);
//     }
    void ChangeInsitityLED(float increment){
           if(DragandDrop.labinstructionNumber == 1){
                    GameObject parent = GameObject.Find("LED 5mm ON");
                    foreach (Transform child in parent.transform){
                        if(child.name.Contains("Spot Light")){
                            child.GetComponent<Light>().enabled = true;
                            child.GetComponent<Light>().range = increment;
                        }
                    }
                }
    }

    void Update(){
        try{
        if(PotentiometerEnabled){
            if(pauseTime == false){
                CurrentTime += Time.deltaTime;
            }

            if(CurrentTime>Delay_){
                CurrentTime = 0.0f;
                reset_MeshRend();
            }
        }
        }catch(System.Exception e){}
    }
    public void reset_MeshRend(){
        PotentiometerEnabled = false;
        
    }
}
