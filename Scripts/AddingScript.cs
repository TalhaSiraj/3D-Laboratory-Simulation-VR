using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddingScript : MonoBehaviour
{


    private TextScript pintextscript;
    private DragandDrop DAD;
    private CircuitSettings CCS;
    public Dictionary<string,string> Namechanger = new Dictionary<string, string>{
        {"LED 5mm ON","Red LED"},
        {"LED Blue","Blue LED"},
        {"LED Yellow","Yellow LED"},
        {"LED Green","Green LED"},
        {"Led RGB light 5mm1D ON","RGB LED"},
        {"10k Ohm Resistor1C","10K Ohm Resistor"},
        {"330 Ohm Resistor","330 Ohm Resistor"},
        {"330_Ohm_Resistor_A","330 Ohm Resistor'1'"},
        {"330_Ohm_Resistor_B","330 Ohm Resistor'2'"},
        {"330_Ohm_Resistor_C","330 Ohm Resistor'3'"},
        {"photoresistor1D","Photoresistor"},
        {"10k Ohm Potentiometer","Potentiometer"},
        {"GND1","UNO Pin 'GND'"},
        {"GND2","UNO Pin 'GND'"},
        {"GND3","UNO Pin 'GND'"},
        {"R 0","UNO Digital Pin '0'"},
        {"R 1","UNO Digital Pin '1'"},
        {"R 2","UNO Digital Pin '2'"},
        {"R 3","UNO Digital Pin '3'"},
        {"R 4","UNO Digital Pin '4'"},
        {"R 5","UNO Digital Pin '5'"},
        {"R 6","UNO Digital Pin '6'"},
        {"R 7","UNO Digital Pin '7'"},
        {"R 8","UNO Digital Pin '8'"},
        {"R 9","UNO Digital Pin '9'"},
        {"R 10","UNO Digital Pin '10'"},
        {"R 11","UNO Digital Pin '11'"},
        {"R 12","UNO Digital Pin '12'"},
        {"R 13","UNO Digital Pin '13'"},
        {"R A0","UNO Analog Pin 'A0'"},
        {"R A1","UNO Analog Pin 'A1'"},
        {"R A2","UNO Analog Pin 'A2'"},
        {"R A3","UNO Analog Pin 'A3'"},
        {"R A4","UNO Analog Pin 'A4'"},
        {"R A5","UNO Analog Pin 'A5'"},
        {"5V","UNO Pin '5V'"},
        {"3.3V","UNO Pin '3.3V'"},
        {"RESET","UNO Pin 'RESET'"},
        {"IO","UNO Pin 'IO'"},
        {"SCL","UNO Pin 'SCL'"},
        {"SDA","UNO Pin 'SDA'"},
        {"AREF","UNO Pin 'AREF'"},
        {"NC","UNO Pin 'NC'"},
        {"VIN","UNO Pin 'VIN'"},
        {"push button Blue","Blue Push Button"},
        {"push button Yellow","Yellow Push Button"},
        {"push button Red","Red Push Button"},
        {"push button Green","Green Push Button"},
        {"piezo Buzzer","Buzzer"},
        {"ultrasonic sensor","Ultrasonic Sensor"},
        {"servo motor complete assem","Servomotor"},
        {"TemperatureSensor","Temperature Sensor"},
        {"Data pin 0","LCD Data Pin '0'"},
        {"Data pin 1","LCD Data Pin '1'"},
        {"Data pin 2","LCD Data Pin '2'"},
        {"Data pin 3","LCD Data Pin '3'"},
        {"Data pin 4","LCD Data Pin '4'"},
        {"Data pin 5","LCD Data Pin '5'"},
        {"Data pin 6","LCD Data Pin '6'"},
        {"Data pin  7","LCD Data Pin '7'"},
        {"Ground pin lcd","LCD Pin 'GND'"},
        {"+5V pin lcd","LCD Pin '5V'"},
        {"Register select pin lcd","LCD Pin 'Register'"},
        {"Read/ Write pin lcd","LCD Pin 'Read/Write'"},
        {"Enable pin lcd","LCD Pin 'Enable'"},
        {"LED +5V pin","LED Pin '5V'"},
        {"LED - Ground pin","LED Pin 'GND'"},
        {"VCC IR ","IR Sensor Pin '5V'"},
        {"GND IR","IR Sensor Pin 'GND'"},
        {"Out IR","IR Sensor Pin 'OUT'"},
        {"IR sensor","IR Sensor"},
        {"Switch","Switch"},
        {"MotorDriver","Motordriver"},
        {"robot top","RobotTop Sheet"},
        {"robot base","RobotBottom Sheet"},
        {"Breadboard","Breadboard"},
        {"CasterBall","CasterBall"},
        {"motor 1","Motor'1'"},
        {"motor 2","Motor'2'"},
        {"pow","Ultrasonic Sensor Pin 'POW'"},
        {"GND ultrasonic","Ultrasonic Sensor Pin 'GND'"},
        {"Trig","Ultrasonic Sensor Pin 'TRIG'"},
        {"Echo","Ultrasonic Sensor Pin 'ECHO'"},
        {"arduino uno","Arduino"},
        {"MOTAPin1","Motordriver Pin 'MOTAPin1'"},
        {"MOTAPin2","Motordriver Pin 'MOTAPin2'"},
        {"MOTBPin2","Motordriver Pin 'MOTBPin2'"},
        {"MOTBPin1","Motordriver Pin 'MOTBPin1'"},
        {"IN1","Motordriver Pin 'IN1'"},
        {"IN2","Motordriver Pin 'IN2'"},
        {"IN3","Motordriver Pin 'IN3'"},
        {"IN4","Motordriver Pin 'IN4'"},
        {"ENA","Motordriver Pin 'ENA'"},
        {"ENB","Motordriver Pin 'ENB'"},
        {"Motor driver 5V","Motordriver Pin '5V'"},
        {"Motor driver GND","Motordriver Pin 'GND'"},
        {"5V motor","Servomotor Pin '5V'"},
        {"GND PIN","Servomotor Pin 'GND'"},
        {"CONTROL","Servomotor Pin 'CONTROL'"},
        {"Bluetooth Module","Bluetooth Module"},
        {"VccBluetooth ","Bluetooth Module Pin '5V'"},
        {"GndBluetooth ","Bluetooth Module Pin 'GND'"},
        {"TXDBluetooth ","Bluetooth Module Pin 'TXD'"},
        {"RXDBluetooth ","Bluetooth Module Pin 'RXD'"},
        {"StateBluetooth","Bluetooth Module Pin 'STATE'"},
        {"VccIR1","IR Sensor'1' Pin '5V'"},
        {"GndIR1","IR Sensor'1' Pin 'GND'"},
        {"OutIR1","IR Sensor'1' Pin 'OUT'"},
        {"VccIR2","IR Sensor'2' Pin '5V'"},
        {"GndIR2","IR Sensor'2' Pin 'GND'"},
        {"OutIR2","IR Sensor'2' Pin 'OUT'"},
        {"VccIR3","IR Sensor'3' Pin '5V'"},
        {"GndIR3","IR Sensor'3' Pin 'GND'"},
        {"OutIR3","IR Sensor'3' Pin 'OUT'"},
        {"IRsensor1","IR Sensor'1'"},
        {"IRsensor2","IR Sensor'2'"},
        {"IRsensor3","IR Sensor'3'"},
    };
    
    [HideInInspector]
    public static Dictionary<string, string> LineRendererParent = new Dictionary<string, string>();
    private static string wireColor = "None",wireColorforcablescript = "None";
    
    [HideInInspector]
    public static string RecentClickObject = "None";
    private static GameObject newBornBaby;
    private static List<string> wireEndsName = new List<string>();
    private static int loop = 0;
    [HideInInspector]
    public static bool usedbybutton = false;

    void Start()
    {
        Debug.Log("Adding Script Start");
        DAD = GameObject.FindObjectOfType(typeof(DragandDrop)) as DragandDrop;
        pintextscript = GameObject.FindObjectOfType(typeof(TextScript)) as TextScript; 
    }
    void Awake(){
        Debug.Log("Adding Script Awake");
        DAD = GameObject.FindObjectOfType(typeof(DragandDrop)) as DragandDrop;
        pintextscript = GameObject.FindObjectOfType(typeof(TextScript)) as TextScript; 
    }

    void OnMouseOver(){
        ///Debug.Log("999999 : Name "+gameObject.name+" tag "+gameObject.tag+":validation "+DAD.BreadBoardPinExist(gameObject.tag));
        if(DAD.ArduinoPinExist(gameObject.name) || DAD.CollectableObjectExist(gameObject.tag) || DAD.BreadBoardPinExist(gameObject.tag)){
            try{
                string objectName = "";
                try{
                    objectName = Namechanger[gameObject.name];
                }catch(System.Exception e){}
                if(objectName.Length>0){
                    pintextscript.changePinTextState(true);
                    pintextscript.SetPinText(Namechanger[gameObject.name]);
                }else{
                    if(gameObject.tag.Contains("P (1)")){
                        pintextscript.changePinTextState(true);
                        pintextscript.SetPinText("Breadboard Power Rail");
                    }else{
                        if(gameObject.tag.Contains("N (1)")){
                            pintextscript.changePinTextState(true);
                            pintextscript.SetPinText("Breadboard Ground Rail");
                        }else{
                            pintextscript.changePinTextState(true);
                            pintextscript.SetPinText(gameObject.name);
                        }   
                    }

                }
                
            }catch(System.Exception e){}

        }
    }

    public static string getwirecolor(){
        return wireColorforcablescript;
    }

    public static bool returnLenghtOfNodes(){
        if(wireEndsName.Count == 2){
            return true;
        }else{
            return false;
        }
    }


    void OnMouseDown(){
        // Debug.Log("404 : "+CircuitSettings.placeKeywordignore);
        if(!CircuitSettings.placeKeywordignore){
            if(gameObject.name.Contains("PositiveButton")){
                wireColor = "positive";
            }
            if(!wireColor.Contains("None")){
                if(DAD.ArduinoPinExist(gameObject.name) || DAD.CollectableObjectExist(gameObject.tag) ||DAD.BreadBoardPinExist(gameObject.tag)){
                    wireEndsName.Add(gameObject.name);
                    ///Debug.Log(gameObject.name+"??");
                    CCS = GameObject.FindObjectOfType(typeof(CircuitSettings)) as CircuitSettings;
                    try{
                        if((RecentClickObject.Contains("None") || (gameObject.GetComponent<CableComponent>() && gameObject.GetComponent<CableComponent>().endPoint)) && (CCS.ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex][DragandDrop.mostInternalIndex].Contains(gameObject.name) || CCS.ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex][DragandDrop.mostInternalIndex].Contains(gameObject.tag))){
                            CircuitSettings.FirstEndOfWire = gameObject.tag;
                            DAD.changeWireAssistanceState(false);
                            if(CircuitSettings.NumberofobjectiveAchieved == 0){
                                CircuitSettings.previousObj = "Blank";
                            }
                            CCS.Connectivity(gameObject);
                            newBornBaby =addNewNode(GameObject.Find(gameObject.name));
                            newBornBaby.AddComponent<CableComponent>();
                            newBornBaby.GetComponent<CableComponent>().enabled=false;
                            RecentClickObject = newBornBaby.name;
                            if(usedbybutton){
                                DragandDrop.labinstructionNumberIndex = DragandDrop.labinstructionNumberIndex -1;
                                usedbybutton = false;
                            }
                            usedbybutton = true;
                        }else{
                            if((!RecentClickObject.Contains("None")) && (CCS.ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex][DragandDrop.mostInternalIndex].Contains(gameObject.name) || CCS.ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex][DragandDrop.mostInternalIndex].Contains(gameObject.tag))){
                                //usedbybutton = true;
                                if(CircuitSettings.NumberofobjectiveAchieved == 0){
                                CircuitSettings.previousObj = "Blank";
                                }
                                CCS.Connectivity(gameObject);
                                usedbybutton = false;
                                GameObject.Find(RecentClickObject).GetComponent<CableComponent>().endPoint = gameObject.transform;
                                GameObject.Find(RecentClickObject).GetComponent<CableComponent>().enabled=true;    
                                LineRendererParent[RecentClickObject] = gameObject.name;
                                RecentClickObject = "None";
                                wireColorforcablescript=wireColor;
                                wireColor = "None";
                            }
                        }
                    }catch(System.Exception e){}
                }
            }
        }
    }
    public static GameObject getnewBornBaby(){
        return newBornBaby;
    }

    private GameObject addNewNode(GameObject parentOb)
    {
        var number = Random.Range(1,254);
        GameObject childOb;
        try{
            childOb = new GameObject(parentOb.name+""+number);
            childOb.transform.SetParent(parentOb.transform);
        }catch(System.Exception e){
            var num = Random.Range(1,254);
            while(num == number){
                num = Random.Range(1,254);
            }
            childOb = new GameObject(parentOb.name+""+num);
            childOb.transform.SetParent(parentOb.transform);
        }

        childOb.transform.position = new Vector3(parentOb.transform.position.x,parentOb.transform.position.y,parentOb.transform.position.z);
        return childOb;
    }

    void OnMouseExit(){
        pintextscript.changePinTextState(false);
    }
}
