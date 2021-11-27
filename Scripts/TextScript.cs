using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextScript : MonoBehaviour
{
    Text Screentext;
    TextMeshProUGUI LCDTXT;
    TextMeshProUGUI moniterTXT;
    TextMeshProUGUI Pintext;
    TextMeshProUGUI ObsticleName;
    Text objectplacedSuccessfully;
    Text IR_Distance;
    Text Note;

    void Start(){
        Debug.Log("TextScript Start");
        Screentext = GameObject.Find("ScreenText").GetComponent<Text>();
        Note = GameObject.Find("Note").GetComponent<Text>();
        Pintext = GameObject.Find("PinName").GetComponent<TextMeshProUGUI>();
        objectplacedSuccessfully = GameObject.Find("ObjectPlacedText").GetComponent<Text>();
        Screentext.enabled = true;
        Pintext.enabled = false;
        objectplacedSuccessfully.enabled = false;
        Note.enabled = false;
            
        try{
            moniterTXT =GameObject.Find("moniterTXT").GetComponent<TextMeshProUGUI>();
            moniterTXT.text = "0";
            moniterTXT.enabled = false;
        }catch(System.Exception e){}
        try{    
            LCDTXT =GameObject.Find("LCDTXT").GetComponent<TextMeshProUGUI>();
            LCDTXT.enabled = false;          
        }catch(System.Exception e){}
        try{
            IR_Distance = GameObject.Find("IR_Distance").GetComponent<Text>();
            IR_Distance.enabled = false;
        }catch(System.Exception e){}
        try{
            ObsticleName = GameObject.Find("BoxName").GetComponent<TextMeshProUGUI>();
            ObsticleName.enabled = false;
        }catch(System.Exception e){}
    }

    void Awake(){
        Debug.Log("TextScript Awake");
        Screentext = GameObject.Find("ScreenText").GetComponent<Text>();
        Pintext = GameObject.Find("PinName").GetComponent<TextMeshProUGUI>();
        objectplacedSuccessfully = GameObject.Find("ObjectPlacedText").GetComponent<Text>();
        Screentext.enabled = true;
        Pintext.enabled = false;
        objectplacedSuccessfully.enabled = false;
            
        try{
            moniterTXT =GameObject.Find("moniterTXT").GetComponent<TextMeshProUGUI>();
            moniterTXT.text = "0";
            moniterTXT.enabled = false;
        }catch(System.Exception e){}
        try{    
            LCDTXT =GameObject.Find("LCDTXT").GetComponent<TextMeshProUGUI>();
            LCDTXT.enabled = false;          
        }catch(System.Exception e){}
        try{
            IR_Distance = GameObject.Find("IR_Distance").GetComponent<Text>();
            IR_Distance.enabled = false;
        }catch(System.Exception e){}
        try{
            ObsticleName = GameObject.Find("BoxName").GetComponent<TextMeshProUGUI>();
            ObsticleName.enabled = false;
        }catch(System.Exception e){}
    }


    public void changeNoteTextState(bool state){
        Note.enabled = state;
    }


    public void changeObsticleNameTextState(bool state){
        ObsticleName.enabled = state;
    }
    public void SetObsticleNameText(string value){
        ObsticleName.text = value;
    }


    public void changemoniterTXTTextState(bool state){
        moniterTXT.enabled = state;
    }
    public void SetmoniterTXTScreenText(string value){
        moniterTXT.text = "Value = "+value;
    }

    public int getmoniterTXTScreenText(){
        int value;
        int.TryParse(moniterTXT.text, out value);
        return  value;
    }

    public void changeIR_DistanceTextState(bool state){
        IR_Distance.enabled = state;
    }
    public void SetIR_DistanceScreenText(string value){
        try{
            IR_Distance.text = "IR Distance =  "+value;

        }catch(System.Exception e){}

        
    }



    public void changeLCDTextState(bool state){
        LCDTXT.enabled = state;
    }
    public void SetLCDScreenText(string value){
        try{
             LCDTXT.text = value;
        }catch(System.Exception e){}

       
    }

    public void SetScreenText(string value){
        try{
            Screentext.text = value;

        }catch(System.Exception e){}
        
    }

    public void changePinTextState(bool state){
        Pintext.enabled = state;
    }

    public void changeobjectplacedSuccessfullyState(bool state){
        objectplacedSuccessfully.enabled = state;
    }

    public void SetobjectplacedSuccessfullyText(string value){
        objectplacedSuccessfully.text = value;
    }
    public void SetPinText(string value){
        Pintext.text = value;
    }
}
