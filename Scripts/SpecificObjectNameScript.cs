using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecificObjectNameScript : MonoBehaviour
{
    private TextScript pintextscript;
    private DragandDrop DAD;
    private AddingScript AS;


    void Start()
    {
        Debug.Log("Specific Object Start");
        DAD = GameObject.FindObjectOfType(typeof(DragandDrop)) as DragandDrop;
        AS = GameObject.FindObjectOfType(typeof(AddingScript)) as AddingScript;
        pintextscript = GameObject.FindObjectOfType(typeof(TextScript)) as TextScript; 
    }
    void Awake(){
        Debug.Log("Specific Object Awake");
    }
    void OnMouseOver(){
        try{
            if(DAD.ArduinoPinExist(gameObject.name) || DAD.CollectableObjectExist(gameObject.tag) || DAD.BreadBoardPinExist(gameObject.tag)){
                try{
                    string objectName = "";
                    objectName = AS.Namechanger[gameObject.name];
                    if(objectName.Length>0){
                        pintextscript.changePinTextState(true);
                        pintextscript.SetPinText(AS.Namechanger[gameObject.name]);
                    }else{
                        pintextscript.changePinTextState(true);
                        pintextscript.SetPinText(gameObject.name);
                    }
                }catch(System.Exception e){}

            }
        }catch(System.Exception e){}
    }

    void OnMouseExit(){
        try{
            pintextscript.changePinTextState(false);
        }catch(System.Exception e){}
    }
}
