using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    private CircuitSettings circuitSetting;
    private DragandDrop DAD;
    void Start(){
        Debug.Log("Light Script start");
        circuitSetting = GameObject.FindObjectOfType(typeof(CircuitSettings)) as CircuitSettings;
        if(GameObject.Find("Light (1)").GetComponent<Light>().enabled == false){
            GameObject.Find("Light (1)").GetComponent<Light>().enabled = true;
            GameObject.Find("Light (2)").GetComponent<Light>().enabled = true;
            GameObject.Find("Light (3)").GetComponent<Light>().enabled = true;
        }

    }
    void Awake(){
        Debug.Log("Light Script Awake");
        circuitSetting = GameObject.FindObjectOfType(typeof(CircuitSettings)) as CircuitSettings;
        if(GameObject.Find("Light (1)").GetComponent<Light>().enabled == false){
            GameObject.Find("Light (1)").GetComponent<Light>().enabled = true;
            GameObject.Find("Light (2)").GetComponent<Light>().enabled = true;
            GameObject.Find("Light (3)").GetComponent<Light>().enabled = true;
        }
    }
    void OnMouseDown(){
        try{
            if(gameObject.name.Contains("LightOff")){
                if(GameObject.Find("Light (1)").GetComponent<Light>().enabled == true){
                    GameObject.Find("Light (1)").GetComponent<Light>().enabled = false;
                    GameObject.Find("Light (2)").GetComponent<Light>().enabled = false;
                    GameObject.Find("Light (3)").GetComponent<Light>().enabled = false;
                    DAD = GameObject.FindObjectOfType(typeof(DragandDrop)) as DragandDrop;
                    if(circuitSetting.ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex][DragandDrop.mostInternalIndex].Contains(""+GameObject.Find("Light (1)").GetComponent<Light>().enabled)){
                        circuitSetting.increseAchieved();
                        if(CircuitSettings.NumberofobjectiveAchieved == circuitSetting.ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex].Count){
                            CircuitSettings.NumberofobjectiveAchieved = 0;
                            DragandDrop.mostInternalIndex = 0;
                            if(DragandDrop.labinstructionNumberIndex<circuitSetting.ObjectivesItemNames[DragandDrop.labinstructionNumber].Count){
                                DragandDrop.labinstructionNumberIndex = DragandDrop.labinstructionNumberIndex+1;
                            }
                            DAD.updateInstruction();                    
                        }else{
                            DragandDrop.mostInternalIndex = DragandDrop.mostInternalIndex +1;
                        }
                    }                 
                }else{
                    GameObject.Find("Light (1)").GetComponent<Light>().enabled = true;
                    GameObject.Find("Light (2)").GetComponent<Light>().enabled = true;
                    GameObject.Find("Light (3)").GetComponent<Light>().enabled = true;                    
                }
            }
        }catch(System.Exception e){}
        
    }
}
