using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInputScript : MonoBehaviour
{

    static bool takeinput = false;
    static string words="";
    private TextScript ts;


    void Start(){
        Debug.Log("Keyborad Start");
        ts = GameObject.FindObjectOfType(typeof(TextScript)) as TextScript;
    }

    
    void Awake(){
        Debug.Log("Keyborad Awake");
        ts = GameObject.FindObjectOfType(typeof(TextScript)) as TextScript;
    }


    void OnMouseDown(){
        if(takeinput){
            ts.changeLCDTextState(true);
            if(gameObject.name.Contains("A")){
                words = words+"A";
                words.Trim();
                ts.SetLCDScreenText(words);
            }
            if(gameObject.name.Contains("B")){
                words = words+"B";
                words.Trim();
                ts.SetLCDScreenText(words);
            }
            if(gameObject.name.Contains("C")){
                words = words+"C";
                words.Trim();
                ts.SetLCDScreenText(words);
            }
            if(gameObject.name.Contains("D")){
                words = words+"D";
                words.Trim();
                ts.SetLCDScreenText(words);
            }
            if(gameObject.name.Contains("E")){
                words = words+"E";
                words.Trim();
                ts.SetLCDScreenText(words);
            }
            if(gameObject.name.Contains("F")){
                words = words+"F";
                words.Trim();
                ts.SetLCDScreenText(words);
            }
            if(gameObject.name.Contains("G")){
                words = words+"G";
                words.Trim();
                ts.SetLCDScreenText(words);
            }
            if(gameObject.name.Contains("H")){
                words = words+"H";
                words.Trim();
                ts.SetLCDScreenText(words);
            }
            if(gameObject.name.Contains("I")){
                words = words+"I";
                words.Trim();
                ts.SetLCDScreenText(words);
            }if(gameObject.name.Contains("J")){
                words = words+"J";
                words.Trim();
                ts.SetLCDScreenText(words);
            }
            if(gameObject.name.Contains("K")){
                words = words+"K";
                words.Trim();
                ts.SetLCDScreenText(words);
            }
            if(gameObject.name.Contains("L")){
                words = words+"L";
                words.Trim();
                ts.SetLCDScreenText(words);
            }
            if(gameObject.name.Contains("M")){
                words = words+"M";
                words.Trim();
                ts.SetLCDScreenText(words);
            }
            if(gameObject.name.Contains("N")){
                words = words+"N";
                words.Trim();
                ts.SetLCDScreenText(words);
            }
            if(gameObject.name.Contains("O")){
                words = words+"O";
                words.Trim();
                ts.SetLCDScreenText(words);
            }
            if(gameObject.name.Contains("P")){
                words = words+"P";
                words.Trim();
                ts.SetLCDScreenText(words);
            }
            if(gameObject.name.Contains("Q")){
                words = words+"Q";
                words.Trim();
                ts.SetLCDScreenText(words);
            }
            if(gameObject.name.Contains("R")){
                words = words+"R";
                words.Trim();
                ts.SetLCDScreenText(words);
            }
            if(gameObject.name.Contains("S")){
                words = words+"S";
                words.Trim();
                ts.SetLCDScreenText(words);
            }

            if(gameObject.name.Contains("T")){
                words = words+"T";
                words.Trim();
                ts.SetLCDScreenText(words);
            }
            if(gameObject.name.Contains("U")){
                words = words+"U";
                words.Trim();
                ts.SetLCDScreenText(words);
            }
            if(gameObject.name.Contains("V")){
                words = words+"V";
                words.Trim();
                ts.SetLCDScreenText(words);
            }
            if(gameObject.name.Contains("W")){
                words = words+"W";
                words.Trim();
                ts.SetLCDScreenText(words);
            }
            if(gameObject.name.Contains("X")){
                words = words+"X";
                words.Trim();
                ts.SetLCDScreenText(words);
            }if(gameObject.name.Contains("Y")){
                words = words+"Y";
                words.Trim();
                ts.SetLCDScreenText(words);
            }if(gameObject.name.Contains("Z")){
                words = words+"Z";
                words.Trim();
                ts.SetLCDScreenText(words);
            }
        }
    }

    public void changetakeinput(bool state){
        takeinput = state;
    }

    public void Clearword(){
        words = "";
    }


    public string getword(){
        return words.Trim();
    }
}
