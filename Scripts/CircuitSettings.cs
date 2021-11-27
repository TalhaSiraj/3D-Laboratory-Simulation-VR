using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class CircuitSettings : MonoBehaviour
{
    [HideInInspector]
    public List<List<List<string>>> ObjectivesItemNames =new List<List<List<string>>>{
        new List<List<string>>{
            new List<string>{"LR_twopin"},
            new List<string>{"330_ohm_resister","LR_twopin","330_ohm_resister"},
            new List<string>{"330_ohm_resister","R 7"},
            new List<string>{"LR_twopin","GND1"},
        },
        new List<List<string>>{
            new List<string>{"LR_twopin"},
            new List<string>{"330_ohm_resister","LR_twopin","330_ohm_resister"},
            new List<string>{"10k_ohm_potientiometer"},
            new List<string>{"330_ohm_resister","R 7"},
            new List<string>{"LR_twopin","GND1"},
            new List<string>{"10k_ohm_potientiometer","R A0"},
            new List<string>{"10k_ohm_potientiometer","N (1)"},
            new List<string>{"10k_ohm_potientiometer","P (1)"},
        },
        new List<List<string>>{
            new List<string>{"LR_twopin"},
            new List<string>{"330_ohm_resister","LR_twopin","330_ohm_resister"},
            new List<string>{"photoresister1D"},
            new List<string>{"330_ohm_resister","R 7"},
            new List<string>{"LR_twopin","GND1"},
            new List<string>{"10k_ohm_resister","photoresister1D","10k_ohm_resister"},
            new List<string>{"10k_ohm_resister","R A0"},
            new List<string>{"10k_ohm_resister","N (1)"},
            new List<string>{"photoresister1D","P (1)"},
            new List<string>{"False"},
        },
        new List<List<string>>{
            new List<string>{"N (1)","GND1"},
            new List<string>{"photoresister1D"},
            new List<string>{"P (1)","5V"},
            new List<string>{"10k_ohm_resister","photoresister1D","10k_ohm_resister"},
            new List<string>{"10k_ohm_resister","R A0"},
            new List<string>{"10k_ohm_resister","N (1)"},
            new List<string>{"10k_ohm_potientiometer"},
            new List<string>{"10k_ohm_potientiometer","R A1"},
            new List<string>{"10k_ohm_potientiometer","N (1)"},
            new List<string>{"10k_ohm_potientiometer","P (1)"},
            new List<string>{"LR_threepin"},
            new List<string>{"LR_threepin","N (1)"},
            new List<string>{"330_Ohm_Resistor_A","330_Ohm_Resistor_B","330_Ohm_Resistor_C"},
            new List<string>{"Led RGB light 5mm1D ON","330_Ohm_Resistor_A"},
            new List<string>{"Led RGB light 5mm1D ON","330_Ohm_Resistor_B"},
            new List<string>{"Led RGB light 5mm1D ON","330_Ohm_Resistor_C"},
            new List<string>{"LR_threepin","R 9"},
            new List<string>{"LR_threepin","R 10"},
            new List<string>{"LR_threepin","R 11"},
            new List<string>{"False"},    
        },
        //2nd lab (4 index)
        new List<List<string>>{
            new List<string>{"10k_ohm_potientiometer"},
            new List<string>{"Buzzer"},
            new List<string>{"10k_ohm_potientiometer","GND1"},
            new List<string>{"Buzzer","R 10"},
            new List<string>{"10k_ohm_potientiometer","Buzzer"},
        },
        new List<List<string>>{
            new List<string>{"10k_ohm_potientiometer"},
            new List<string>{"Buzzer"},
            new List<string>{"10k_ohm_potientiometer","GND1"},
            new List<string>{"Buzzer","R 10"},
            new List<string>{"10k_ohm_potientiometer","Buzzer"},
            new List<string>{"push button Blue"},
            new List<string>{"push button Yellow"},
            new List<string>{"push button Red"},
            new List<string>{"push button Blue","R 2"},
            new List<string>{"push button Yellow","R 3"},
            new List<string>{"push button Red","R 4"},
            new List<string>{"N (1)","push button Blue"},
            new List<string>{"N (1)","push button Yellow"},
            new List<string>{"N (1)","push button Red"}, 
        },
        new List<List<string>>{
            new List<string>{"10k_ohm_potientiometer"},
            new List<string>{"Buzzer"},
            new List<string>{"10k_ohm_potientiometer","GND1"},
            new List<string>{"Buzzer","R 10"},
            new List<string>{"10k_ohm_potientiometer","Buzzer"},
            new List<string>{"LED  Blue"},
            new List<string>{"LED  Yellow"},
            new List<string>{"LR_twopin"},
            new List<string>{"LED  Green"},
            new List<string>{"push button Blue"},
            new List<string>{"push button Yellow"},
            new List<string>{"push button Red"},
            new List<string>{"push button Green"},
            new List<string>{"push button Blue","R 2"},
            new List<string>{"LED  Blue","R 3"},
            new List<string>{"push button Yellow","R 4"},
            new List<string>{"LED  Yellow","R 5"},
            new List<string>{"push button Red","R 6"},
            new List<string>{"LR_twopin","R 7"},
            new List<string>{"push button Green","R 8"},
            new List<string>{"LED  Green","R 9"},
            new List<string>{"N (1)","push button Blue"},
            new List<string>{"N (1)","push button Yellow"},
            new List<string>{"N (1)","push button Red"},
            new List<string>{"N (1)","push button Green"}, 
            new List<string>{"N (1)","LED  Blue"},
            new List<string>{"N (1)","LED  Yellow"},
            new List<string>{"N (1)","LR_twopin"},
            new List<string>{"N (1)","LED  Green"},
        },
        //3rd lab (7 index)
        new List<List<string>>{
            new List<string>{"10k_ohm_potientiometer"},
            new List<string>{"N (1)","GND1"},
            new List<string>{"P (1)","5V"},
            new List<string>{"10k_ohm_potientiometer","P (1)"},
            new List<string>{"10k_ohm_potientiometer","N (1)"},
            new List<string>{"10k_ohm_potientiometer","R A0"},
            new List<string>{"5V motor","P (1)"},
            new List<string>{"GND PIN","N (1)"},
            new List<string>{"CONTROL","R 9"},
        },
        new List<List<string>>{
            new List<string>{"ultrasonic sensor"},
            new List<string>{"N (1)","GND1"},
            new List<string>{"P (1)","5V"},
            new List<string>{"ultrasonic sensor","P (1)"},
            new List<string>{"ultrasonic sensor","N (1)"},
            new List<string>{"ultrasonic sensor","R 11"},
            new List<string>{"ultrasonic sensor","R 12"},
            new List<string>{"LR_threepin"},
            new List<string>{"LR_threepin","R 3"},
            new List<string>{"LR_threepin","R 5"},
            new List<string>{"LR_threepin","R 6"},
            new List<string>{"LR_threepin","N (1)"},
        },
        new List<List<string>>{
            new List<string>{"ultrasonic sensor"},
            new List<string>{"N (1)","GND1"},
            new List<string>{"P (1)","5V"},
            new List<string>{"ultrasonic sensor","P (1)"},
            new List<string>{"ultrasonic sensor","N (1)"},
            new List<string>{"ultrasonic sensor","R 11"},
            new List<string>{"ultrasonic sensor","R 12"},
            new List<string>{"LR_threepin"},
            new List<string>{"LR_threepin","R 3"},
            new List<string>{"LR_threepin","R 5"},
            new List<string>{"LR_threepin","R 6"},
            new List<string>{"LR_threepin","N (1)"},
            new List<string>{"5V motor","P (1)"},
            new List<string>{"GND PIN","N (1)"},
            new List<string>{"CONTROL","R 9"},
            new List<string>{"Buzzer"},
            new List<string>{"Buzzer","N (1)"},
            new List<string>{"Buzzer","R 10"},
        },
        //4th lab (10 index)
        new List<List<string>>{
            new List<string>{"10k_ohm_potientiometer"},
            new List<string>{"N (1)","GND1"},
            new List<string>{"P (1)","5V"},
            new List<string>{"10k_ohm_potientiometer","P (1)"},
            new List<string>{"10k_ohm_potientiometer","N (1)"},
            new List<string>{"10k_ohm_potientiometer","Data pin 3"},
            new List<string>{"Ground pin lcd","N (1)"},
            new List<string>{"+5V pin lcd","P (1)"},
            new List<string>{"Register select pin lcd","R 13"},
            new List<string>{"readwrite","N (1)"},
            new List<string>{"Enable pin lcd","R 12"},
            new List<string>{"Data pin 4","R 11"},
            new List<string>{"Data pin 5","R 10"},
            new List<string>{"Data pin 6","R 9"},
            new List<string>{"Data pin 7","R 8"},
            new List<string>{"LED +5V pin","P (1)"},
            new List<string>{"LED Ground pin","N (1)"}
        },
        new List<List<string>>{
            new List<string>{"10k_ohm_potientiometer"},
            new List<string>{"N (1)","GND1"},
            new List<string>{"P (1)","5V"},
            new List<string>{"10k_ohm_potientiometer","P (1)"},
            new List<string>{"10k_ohm_potientiometer","N (1)"},
            new List<string>{"10k_ohm_potientiometer","Data pin 3"},
            new List<string>{"Ground pin lcd","N (1)"},
            new List<string>{"+5V pin lcd","P (1)"},
            new List<string>{"Register select pin lcd","R 13"},
            new List<string>{"readwrite","N (1)"},
            new List<string>{"Enable pin lcd","R 12"},
            new List<string>{"Data pin 4","R 11"},
            new List<string>{"Data pin 5","R 10"},
            new List<string>{"Data pin 6","R 9"},
            new List<string>{"Data pin 7","R 8"},
            new List<string>{"LED +5V pin","P (1)"},
            new List<string>{"LED Ground pin","N (1)"},
            new List<string>{"TemperatureSensor"},
            new List<string>{"TemperatureSensor","N (1)"},
            new List<string>{"TemperatureSensor","P (1)"},
            new List<string>{"TemperatureSensor","R A0"}
        }, 
          new List<List<string>>{
            new List<string>{"10k_ohm_potientiometer"},
            new List<string>{"N (1)","GND1"},
            new List<string>{"P (1)","5V"},
            new List<string>{"10k_ohm_potientiometer","P (1)"},
            new List<string>{"10k_ohm_potientiometer","N (1)"},
            new List<string>{"10k_ohm_potientiometer","Data pin 3"},
            new List<string>{"Ground pin lcd","N (1)"},
            new List<string>{"+5V pin lcd","P (1)"},
            new List<string>{"Register select pin lcd","R 13"},
            new List<string>{"readwrite","N (1)"},
            new List<string>{"Enable pin lcd","R 12"},
            new List<string>{"Data pin 4","R 11"},
            new List<string>{"Data pin 5","R 10"},
            new List<string>{"Data pin 6","R 9"},
            new List<string>{"Data pin 7","R 8"},
            new List<string>{"LED +5V pin","P (1)"},
            new List<string>{"LED Ground pin","N (1)"},
            new List<string>{"push button Blue"},
            new List<string>{"push button Blue", "N (1)"},
            new List<string>{"push button Blue","R 2"},
            new List<string>{"Buzzer"},
            new List<string>{"Buzzer", "N (1)"},
            new List<string>{"Buzzer","R 6"}
        },
        //5lab (13 index)
        new List<List<string>>{
            new List<string>{"LR_twopin"},
            new List<string>{"330_ohm_resister","LR_twopin","330_ohm_resister"},
            new List<string>{"VCC IR","5V"},
            new List<string>{"GND IR","GND1"},
            new List<string>{"Out IR","R A5"},
            new List<string>{"330_ohm_resister","R 13"},
            new List<string>{"LR_twopin","GND1"}
        },
         new List<List<string>>{
            new List<string>{"Buzzer"},
            new List<string>{"VCC IR","5V"},
            new List<string>{"GND IR","GND1"},
            new List<string>{"Out IR","R A5"},
            new List<string>{"Buzzer","R 13"},
            new List<string>{"Buzzer","N (1)"}
            
        },
         new List<List<string>>{
            new List<string>{"VCC IR","5V"},
            new List<string>{"GND IR","GND1"},
            new List<string>{"Out IR","R 4"}    
        },
        //LAB 6 (16 index)
        new List<List<string>>{
            new List<string>{"P (1)","5V"},
            new List<string>{"N (1)","GND1"},
            new List<string>{"Switch"},
            new List<string>{"Switch","N (1)"},
            new List<string>{"Switch","R 7"},
            new List<string>{"MotorDriver5V","P (1)"},
            new List<string>{"MotorDriverGND","N (1)"},
            new List<string>{"MOTAPin1","MOTOR1"},
            new List<string>{"MOTAPin2","MOTOR1"},
            new List<string>{"ENA","R 10"},
            new List<string>{"ENB","R 11"},
            new List<string>{"IN1","R 13"},
            new List<string>{"IN2","R 12"},
            new List<string>{"IN3","R 8"},
            new List<string>{"IN4","R 9"},
            new List<string>{"true"}
        },
        new List<List<string>>{
            new List<string>{"P (1)","5V"},
            new List<string>{"N (1)","GND1"},
            new List<string>{"Switch"},
            new List<string>{"Switch","N (1)"},
            new List<string>{"Switch","R 7"},
            new List<string>{"MotorDriver5V","P (1)"},
            new List<string>{"MotorDriverGND","N (1)"},
            new List<string>{"MOTAPin1","MOTOR1"},
            new List<string>{"MOTAPin2","MOTOR1"},
            new List<string>{"ENA","R 10"},
            new List<string>{"ENB","R 11"},
            new List<string>{"IN1","R 13"},
            new List<string>{"IN2","R 12"},
            new List<string>{"IN3","R 8"},
            new List<string>{"IN4","R 9"},
            new List<string>{"MOTBPin1","MOTOR2"},
            new List<string>{"MOTBPin2","MOTOR2"},
            new List<string>{"CasterBall"},
            new List<string>{"MOTOR1"},
            new List<string>{"MOTOR2"},
            new List<string>{"robottop"},
            new List<string>{"Arduino"},
            new List<string>{"MotorDriver"},
            new List<string>{"Breadboard"}
        },
        new List<List<string>>{
            new List<string>{"P (1)","5V"},
            new List<string>{"N (1)","GND1"},
            new List<string>{"Switch"},
            new List<string>{"Switch","N (1)"},
            new List<string>{"Switch","R 7"},
            new List<string>{"MotorDriver5V","P (1)"},
            new List<string>{"MotorDriverGND","N (1)"},
            new List<string>{"MOTAPin1","MOTOR1"},
            new List<string>{"MOTAPin2","MOTOR1"},
            new List<string>{"ENA","R 10"},
            new List<string>{"ENB","R 11"},
            new List<string>{"IN1","R 13"},
            new List<string>{"IN2","R 12"},
            new List<string>{"IN3","R 8"},
            new List<string>{"IN4","R 9"},
            new List<string>{"MOTBPin1","MOTOR2"},
            new List<string>{"MOTBPin2","MOTOR2"},
            new List<string>{"pow","P (1)"},
            new List<string>{"GND ultrasonic","N (1)"},
            new List<string>{"Trig","R 6"},
            new List<string>{"Echo","R 5"},
            new List<string>{"CasterBall"},
            new List<string>{"MOTOR1"},
            new List<string>{"MOTOR2"},
            new List<string>{"robottop"},
            new List<string>{"Arduino"},
            new List<string>{"ultrasonic sensor"},
            new List<string>{"MotorDriver"},
            new List<string>{"Breadboard"}
        },
        //LAB7 19 index
        new List<List<string>>{
            new List<string>{"P (1)","5V"},
            new List<string>{"N (1)","GND1"},
            new List<string>{"VccIR1","P (1)"},
            new List<string>{"VccIR2","P (1)"},
            new List<string>{"VccIR3","P (1)"},
            new List<string>{"GndIR1","N (1)"},
            new List<string>{"GndIR2","N (1)"},
            new List<string>{"GndIR3","N (1)"},
            new List<string>{"OutIR1","R A0"},
            new List<string>{"OutIR2","R A1"},
            new List<string>{"OutIR3","R A2"},
            new List<string>{"MotorDriver5V","P (1)"},
            new List<string>{"IN1","R 13"},
            new List<string>{"IN2","R 12"},
            new List<string>{"IN3","R 11"},
            new List<string>{"IN4","R 10"},
            new List<string>{"MOTAPin1","MOTOR1"},
            new List<string>{"MOTAPin2","MOTOR1"},
            new List<string>{"MOTBPin1","MOTOR2"},
            new List<string>{"MOTBPin2","MOTOR2"},
            new List<string>{"CasterBall"},
            new List<string>{"MOTOR1"},
            new List<string>{"MOTOR2"},
            new List<string>{"robottop"},
            new List<string>{"Arduino"},
            new List<string>{"MotorDriver"},
            new List<string>{"IR sensor1"},
            new List<string>{"IR sensor2"},
            new List<string>{"IR sensor3"},
            new List<string>{"Breadboard"}
        },
         new List<List<string>>{
            new List<string>{"P (1)","5V"},
            new List<string>{"N (1)","GND1"},
            new List<string>{"5V motor","P (1)"},
            new List<string>{"pow","P (1)"},
            new List<string>{"GND PIN","N (1)"},
            new List<string>{"GND ultrasonic","N (1)"},
            new List<string>{"CONTROL","R 10"},
            new List<string>{"Trig","R 1"},
            new List<string>{"Echo","R 2"},
            new List<string>{"IN1","R 7"},
            new List<string>{"IN2","R 6"},
            new List<string>{"IN3","R 5"},
            new List<string>{"IN4","R 4"},
            new List<string>{"MOTAPin1","MOTOR1"},
            new List<string>{"MOTAPin2","MOTOR1"},
            new List<string>{"MOTBPin1","MOTOR2"},
            new List<string>{"MOTBPin2","MOTOR2"},
            new List<string>{"CasterBall"},
            new List<string>{"MOTOR1"},
            new List<string>{"MOTOR2"},
            new List<string>{"robottop"},
            new List<string>{"Arduino"},
            new List<string>{"ultrasonic sensor"},
            new List<string>{"ServoMoter"},
            new List<string>{"MotorDriver"},
            new List<string>{"Breadboard"}
        },
        new List<List<string>>{
            new List<string>{"P (1)","5V"},
            new List<string>{"N (1)","GND1"},
            new List<string>{"LR_twopin"},
            new List<string>{"LR_twopin","R 9"},
            new List<string>{"LR_twopin","3.3V"},
            new List<string>{"VccBluetooth","5V"},
            new List<string>{"GndBluetooth","GND1"},
            new List<string>{"MotorDriver5V","P (1)"},
            new List<string>{"MotorDriverGND","N (1)"},
            new List<string>{"MOTAPin1","MOTOR1"},
            new List<string>{"MOTAPin2","MOTOR1"},
            new List<string>{"MOTBPin1","MOTOR2"},
            new List<string>{"MOTBPin2","MOTOR2"},
            new List<string>{"ENA","R 10"},
            new List<string>{"ENB","R 11"},
            new List<string>{"IN1","R 13"},
            new List<string>{"IN2","R 12"},
            new List<string>{"TXDBluetooth","R 0"},
            new List<string>{"RXDBluetooth","R 1"},
            new List<string>{"BluetoothModule"},
            new List<string>{"CasterBall"},
            new List<string>{"MOTOR1"},
            new List<string>{"MOTOR2"},
            new List<string>{"robottop"},
            new List<string>{"Arduino"},
            new List<string>{"MotorDriver"},
            new List<string>{"Breadboard"}
        }
    };

    private int loop = 0;
    private static float helpingRange = 0.0f;
    private static bool helpinggate = true;
    [HideInInspector]
    public static int  NumberofobjectiveAchieved = 0;
    [HideInInspector]
    public static string previousObj = "",FirstEndOfWire = "None";
    private GameObject parent;
    private DragandDrop DAD;
    private ResetobjectsScrpt_ RES;
    private TextScript ts;
    private PotentiometerScript_ PS;
    private IRSensorScript_ IRS;
    private RaycastScript RCS;
    private KeyboardInputScript KIS_;
    private LED_Control_Script LCS;
    private WheelMotorControl WMC;
    private AddingScript AS;

    private bool playtune = true;
    [HideInInspector]
    public static bool placeKeywordignore = false;
    void Start(){
        try{
            ts = GameObject.FindObjectOfType(typeof(TextScript)) as TextScript;
            AS = GameObject.FindObjectOfType(typeof(AddingScript)) as AddingScript;
            LCS = GameObject.FindObjectOfType(typeof(LED_Control_Script)) as LED_Control_Script;
        }catch(System.Exception e){}

    }
    void Awake(){
        try{
            ts = GameObject.FindObjectOfType(typeof(TextScript)) as TextScript;
            AS = GameObject.FindObjectOfType(typeof(AddingScript)) as AddingScript;
            LCS = GameObject.FindObjectOfType(typeof(LED_Control_Script)) as LED_Control_Script;
        }catch(System.Exception e){}

    }

    void Update(){
        try{
            if(DAD.LabObjects[DragandDrop.labinstructionNumber].Count == DragandDrop.labinstructionNumberIndex){
                RES = GameObject.FindObjectOfType(typeof(ResetobjectsScrpt_)) as ResetobjectsScrpt_;
                try{
                    if(DragandDrop.labinstructionNumber == 0){
                        parent = GameObject.Find("LED 5mm ON");
                        foreach (Transform child in parent.transform){
                            if(child.name.Contains("Spot Light")){
                                child.GetComponent<Light>().range = 0.5f;
                                child.GetComponent<Light>().enabled = true;
                            }
                        }
                    }
                    if(DragandDrop.labinstructionNumber == 1){
                    PotentiometerScript_.satisfy = true;
                    }
                    if((DragandDrop.labinstructionNumber == 2) && (!GameObject.Find("Light (1)").GetComponent<Light>().enabled)){
                        parent = GameObject.Find("LED 5mm ON");
                        foreach (Transform child in parent.transform){
                            if(child.name.Contains("Spot Light")){
                                child.GetComponent<Light>().range = 0.5f;
                                child.GetComponent<Light>().enabled = true;
                            }
                        }
                    }
                    if(DragandDrop.labinstructionNumber == 3){
                        PotentiometerScript_.satisfy = true;
                        Debug.Log("999 circuit ");
                    }
                    if((DragandDrop.labinstructionNumber == 4) && playtune){
                        PotentiometerScript_.satisfy = true;
                        FindObjectOfType<AudioManager>().Play("Buzzerlab1");
                        playtune = false;
                        DAD.TriggerMusic(true);
                    }
                    if(DragandDrop.labinstructionNumber == 5 ){
                        DAD.TriggerMusic(true);
                        PotentiometerScript_.satisfy = true;
                    }
                    
                    if(DragandDrop.labinstructionNumber == 6 ){
                        if(helpinggate){
                            helpinggate = false;
                            FindObjectOfType<AudioManager>().Play("Buzzerlab1");
                            playtune = false;
                            DAD.TriggerMusic(true);
                            try{
                                LCS.ChangeTimerStart(true);
                            }catch(System.Exception e){}
                        }
                        PotentiometerScript_.satisfy = true;
                    }
                    if(DragandDrop.labinstructionNumber == 7){
                        PotentiometerScript_.satisfy = true;
                    }
                    if(DragandDrop.labinstructionNumber == 8){
                        PS = GameObject.FindObjectOfType(typeof(PotentiometerScript_)) as PotentiometerScript_;
                        PS.ChangeLEDColor(GameObject.Find("FPSController").transform.position.x);
                    }
                    if(DragandDrop.labinstructionNumber == 9){
                        float dist = Vector3.Distance(GameObject.Find("FPSController").transform.position, GameObject.Find("Led RGB light 5mm1D ON").transform.position);
                        dist =(float) Math.Round(dist , 1);
                        if(helpingRange == 0.0f){
                            helpingRange = dist;
                            PS = GameObject.FindObjectOfType(typeof(PotentiometerScript_)) as PotentiometerScript_;
                            PS.ChangeLEDColor(helpingRange);
                        }else{
                            if(helpingRange != dist){
                                helpingRange = dist;
                                PS = GameObject.FindObjectOfType(typeof(PotentiometerScript_)) as PotentiometerScript_;
                                PS.ChangeLEDColor(helpingRange);
                            }
                        }
                    }
                    if(DragandDrop.labinstructionNumber == 10){
                        if(PotentiometerScript_.Increment == 2f){
                            PotentiometerScript_.Increment = 0f;
                        }
                        PotentiometerScript_.satisfy = true;
                        ts.changeLCDTextState(true);
                        ts.SetLCDScreenText("LAB 10");
                    }
                    if(DragandDrop.labinstructionNumber == 11){
                        if(PotentiometerScript_.Increment == 2f){
                            PotentiometerScript_.Increment = 0f;
                        }
                        PotentiometerScript_.satisfy = true;
                        ts.changeLCDTextState(true);
                        ts.SetLCDScreenText("21 Celsius and 69.8 Fahrenheit");
                    }
                    if(DragandDrop.labinstructionNumber == 12){
                        LCDScript_.EnabledDisplay = true;
                    }
                    if(DragandDrop.labinstructionNumber == 13){
                        
                        RCS = GameObject.FindObjectOfType(typeof(RaycastScript)) as RaycastScript;
                        RCS.GenerateRay();
                        if(RCS.getName().Contains("Obsticle")){
                            IRS = GameObject.FindObjectOfType(typeof(IRSensorScript_)) as IRSensorScript_;
                            IRS.ChangeLEDColor(RCS.getDistance(),RCS.getName());
                            RCS.resetvalueofcollider();
                        }else{
                            IRS = GameObject.FindObjectOfType(typeof(IRSensorScript_)) as IRSensorScript_;
                            IRS.ChangeLEDColor(RCS.getDistance(),RCS.getName());
                        }
                    }
                    if(DragandDrop.labinstructionNumber == 14){
                        if(PotentiometerScript_.Increment == 2f){
                            PotentiometerScript_.Increment = 0.3f;
                        }
                        PotentiometerScript_.satisfy = true;
                        RCS = GameObject.FindObjectOfType(typeof(RaycastScript)) as RaycastScript;
                        RCS.GenerateRay();
                        if(RCS.getName().Contains("Obsticle")){
                            float dist = RCS.getDistance();
                            if(helpingRange == 0.0f){
                                helpingRange = dist;
                                IRS = GameObject.FindObjectOfType(typeof(IRSensorScript_)) as IRSensorScript_;
                                IRS.ChangeLEDColor(helpingRange,RCS.getName());
                                RCS.resetvalueofcollider();
                            }else{
                                if(helpingRange != dist){
                                    helpingRange = dist;
                                    IRS = GameObject.FindObjectOfType(typeof(IRSensorScript_)) as IRSensorScript_;
                                    IRS.ChangeLEDColor(helpingRange,RCS.getName());
                                }
                                helpingRange = helpingRange+.01f;
                            }
                        }
                    }
                    if(DragandDrop.labinstructionNumber == 15){
                        RCS = GameObject.FindObjectOfType(typeof(RaycastScript)) as RaycastScript;
                        RCS.GenerateRay();
                        if(RCS.getName().Contains("Obsticle")){
                            float dist = RCS.getDistance();
                            if(helpingRange == 0.0f){
                                helpingRange = dist;
                                IRS = GameObject.FindObjectOfType(typeof(IRSensorScript_)) as IRSensorScript_;
                                IRS.ChangeLEDColor(helpingRange,RCS.getName());
                            }else{
                                if(helpingRange != dist){
                                    helpingRange = dist;
                                    IRS = GameObject.FindObjectOfType(typeof(IRSensorScript_)) as IRSensorScript_;
                                    IRS.ChangeLEDColor(helpingRange,RCS.getName());
                                }
                            }
                        }else{
                            helpingRange = helpingRange+1;
                        }
                    }
                    if(DragandDrop.labinstructionNumber == 16 && GameObject.Find("switch part 5 (1)").GetComponent<MeshRenderer>().enabled){
                        WMC = GameObject.FindObjectOfType(typeof(WheelMotorControl)) as WheelMotorControl;
                        WMC.setWheelone_name("RightWheel");
                        if(!WMC.getWheelone_name().Contains("None") && (!WheelMotorControl.enableWheel)){
                            WheelMotorControl.enableWheel = true;
                        }
                    }
                    if(DragandDrop.labinstructionNumber == 17 || DragandDrop.labinstructionNumber == 18 || DragandDrop.labinstructionNumber == 19){
                        WMC = GameObject.FindObjectOfType(typeof(WheelMotorControl)) as WheelMotorControl;
                        WheelMotorControl.enableWheel = true;
                    }
                }catch(System.Exception e){}
            }       
        }catch(System.Exception e){}
        if(!placeKeywordignore){
           ts.changeNoteTextState(true); 
        }
        if(placeKeywordignore){
            ts.changeNoteTextState(false);
        }

    }


    void OnCollisionEnter(Collision collisionPin){
        Debug.Log("");
        DAD = GameObject.FindObjectOfType(typeof(DragandDrop)) as DragandDrop;
        try{
            if(DAD.LabObjects[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex].Contains("Place") && placeKeywordignore){
                ConditionA(collisionPin);
            }
            if((!DAD.LabObjects[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex].Contains("wire") || !DAD.LabObjects[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex].Contains("Connect")) && !placeKeywordignore ){
                ConditionB(collisionPin);
            }
        }catch(System.Exception e){}
        
    }
    void ConditionA(Collision collisionPin){
        try{
            //Debug.Log("0000 - A"+collisionPin.collider.tag+" Valid = "+ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex][DragandDrop.mostInternalIndex].Contains(collisionPin.collider.tag));
            if(ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex][DragandDrop.mostInternalIndex].Contains(collisionPin.collider.tag) || ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex][DragandDrop.mostInternalIndex].Contains(collisionPin.collider.name)){
                if(DragandDrop.labinstructionNumber == 3 && DragandDrop.labinstructionNumberIndex == 12){
                    if(!previousObj.Contains(collisionPin.collider.name)){
                        previousObj = collisionPin.collider.name;
                        NumberofobjectiveAchieved = NumberofobjectiveAchieved+1;
                        placeKeywordignore = false;
                        DAD = GameObject.FindObjectOfType(typeof(DragandDrop)) as DragandDrop;
                        string objectName = "";
                        try{
                            objectName = AS.Namechanger[collisionPin.collider.name];
                        }catch(System.Exception e){}
                        if(objectName.Length>0){
                            ts.changeobjectplacedSuccessfullyState(true);
                            ts.SetobjectplacedSuccessfullyText(AS.Namechanger[collisionPin.collider.name]+" placed");
                        }else{
                            ts.changeobjectplacedSuccessfullyState(true);
                            ts.SetobjectplacedSuccessfullyText(collisionPin.collider.name+" placed");
                        }
                        if(NumberofobjectiveAchieved == ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex].Count){
                            NumberofobjectiveAchieved = 0;
                            DragandDrop.mostInternalIndex = 0;
                            if((DragandDrop.labinstructionNumberIndex+1)<ObjectivesItemNames[DragandDrop.labinstructionNumber].Count){
                                DragandDrop.labinstructionNumberIndex = DragandDrop.labinstructionNumberIndex+1;
                            }
                            DAD.updateInstruction();                    
                        }else{
                            DragandDrop.mostInternalIndex = DragandDrop.mostInternalIndex +1;
                        }
                    }
                    }else{
                        if(!previousObj.Contains(collisionPin.collider.tag)){
                            previousObj = collisionPin.collider.tag;
                            NumberofobjectiveAchieved = NumberofobjectiveAchieved+1;
                            placeKeywordignore = false;
                            DAD = GameObject.FindObjectOfType(typeof(DragandDrop)) as DragandDrop;
                            string objectName = "";
                            try{
                            objectName = AS.Namechanger[collisionPin.collider.name];
                            }catch(System.Exception e){}
                            if(objectName.Length>0){
                                ts.changeobjectplacedSuccessfullyState(true);
                                ts.SetobjectplacedSuccessfullyText(AS.Namechanger[collisionPin.collider.name]+" Placed");
                            }else{
                                ts.changeobjectplacedSuccessfullyState(true);
                                ts.SetobjectplacedSuccessfullyText(collisionPin.collider.name+" Placed");
                            }
                            if(NumberofobjectiveAchieved == ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex].Count){
                                NumberofobjectiveAchieved = 0;
                                DragandDrop.mostInternalIndex = 0;
                                if((DragandDrop.labinstructionNumberIndex+1)<ObjectivesItemNames[DragandDrop.labinstructionNumber].Count){
                                    DragandDrop.labinstructionNumberIndex = DragandDrop.labinstructionNumberIndex+1;
                                }
                                DAD.updateInstruction();
                            }else{
                                DragandDrop.mostInternalIndex = DragandDrop.mostInternalIndex +1;
                            }
                        }
                        if(DragandDrop.labinstructionNumber == 16 && collisionPin.collider.tag.Contains("Motor")){
                            WMC = GameObject.FindObjectOfType(typeof(WheelMotorControl)) as WheelMotorControl;
                            WMC.setWheelone_name(collisionPin.collider.name);
                        }
                }
            }
        }catch(System.Exception e){}
    }

    void ConditionB(Collision collisionPin){
        try{
            ///Debug.Log("0000 B- "+collisionPin.collider.tag+" Valid = "+ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex][DragandDrop.mostInternalIndex].Contains(collisionPin.collider.tag));
            if(ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex][DragandDrop.mostInternalIndex].Contains(collisionPin.collider.tag) || ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex][DragandDrop.mostInternalIndex].Contains(collisionPin.collider.name)){
                if(DragandDrop.labinstructionNumber == 3 && DragandDrop.labinstructionNumberIndex == 12){
                    if(!previousObj.Contains(collisionPin.collider.name)){
                        previousObj = collisionPin.collider.name;
                        try{
                            NumberofobjectiveAchieved = NumberofobjectiveAchieved+1;
                            placeKeywordignore = false;
                        }catch(System.Exception e){}
                        DAD = GameObject.FindObjectOfType(typeof(DragandDrop)) as DragandDrop;
                        string objectName = "";
                        try{
                            objectName = AS.Namechanger[collisionPin.collider.name];
                        }catch(System.Exception e){}
                        
                        if(objectName.Length>0){
                            ts.changeobjectplacedSuccessfullyState(true);
                            ts.SetobjectplacedSuccessfullyText(AS.Namechanger[collisionPin.collider.name]+" Placed");
                        }else{
                            ts.changeobjectplacedSuccessfullyState(true);
                            ts.SetobjectplacedSuccessfullyText(collisionPin.collider.name+" Placed");
                        }
                        if(NumberofobjectiveAchieved == ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex].Count){
                            NumberofobjectiveAchieved = 0;
                            DragandDrop.mostInternalIndex = 0;
                            if((DragandDrop.labinstructionNumberIndex+1)<ObjectivesItemNames[DragandDrop.labinstructionNumber].Count){
                                DragandDrop.labinstructionNumberIndex = DragandDrop.labinstructionNumberIndex+1;
                            }
                            DAD.updateInstruction();                    
                        }else{
                            DragandDrop.mostInternalIndex = DragandDrop.mostInternalIndex +1;
                        }
                    }
                }else{
                    if(!previousObj.Contains(collisionPin.collider.tag)){
                        previousObj = collisionPin.collider.tag;
                        try{
                            NumberofobjectiveAchieved = NumberofobjectiveAchieved+1;
                        }catch(System.Exception e){}
                        DAD = GameObject.FindObjectOfType(typeof(DragandDrop)) as DragandDrop;
                        string objectName = "";
                        try{
                            objectName = AS.Namechanger[collisionPin.collider.name];
                        }catch(System.Exception e){}
                        if(objectName.Length>0){
                            ts.changeobjectplacedSuccessfullyState(true);
                            ts.SetobjectplacedSuccessfullyText(AS.Namechanger[collisionPin.collider.name]+" Placed");
                        }else{
                            ts.changeobjectplacedSuccessfullyState(true);
                            ts.SetobjectplacedSuccessfullyText(collisionPin.collider.name+" Placed");
                        }
                        if(NumberofobjectiveAchieved == ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex].Count){
                            NumberofobjectiveAchieved = 0;
                            DragandDrop.mostInternalIndex = 0;
                            if((DragandDrop.labinstructionNumberIndex+1)<ObjectivesItemNames[DragandDrop.labinstructionNumber].Count){
                                DragandDrop.labinstructionNumberIndex = DragandDrop.labinstructionNumberIndex+1;
                            }
                            DAD.updateInstruction();                    
                        }else{
                            DragandDrop.mostInternalIndex = DragandDrop.mostInternalIndex +1;
                        }
                    }
                    if(DragandDrop.labinstructionNumber == 16 && collisionPin.collider.tag.Contains("Motor")){
                        WMC = GameObject.FindObjectOfType(typeof(WheelMotorControl)) as WheelMotorControl;
                        WMC.setWheelone_name(collisionPin.collider.name);
                    }
                }
            }
            }catch(System.Exception e){}
    }

    void OnMouseDown(){
        ts = GameObject.Find("ObjectPlacedText").GetComponent<TextScript>();
        if(NumberofobjectiveAchieved == 0){
            previousObj = "Blank";
        }
        try{
            if(!DAD.LabObjects[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex].Contains("wire")){
                if(!AddingScript.usedbybutton){
                    Connectivity(gameObject);
                }
            }
        }catch(System.Exception e){}

    }

    public void Connectivity(GameObject gameobject_){
        try{
            if(ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex][DragandDrop.mostInternalIndex].Contains(gameobject_.name) || ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex][DragandDrop.mostInternalIndex].Contains(gameobject_.tag)){
                DAD = GameObject.FindObjectOfType(typeof(DragandDrop)) as DragandDrop;
                if(DragandDrop.labinstructionNumber == 3 && (DragandDrop.labinstructionNumberIndex == 13 || DragandDrop.labinstructionNumberIndex == 14 || DragandDrop.labinstructionNumberIndex == 15)){
                    if(!previousObj.Contains(gameobject_.name)){
                        previousObj = gameobject_.name;
                        NumberofobjectiveAchieved = NumberofobjectiveAchieved+1;
                        if(NumberofobjectiveAchieved == ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex].Count){
                            NumberofobjectiveAchieved = 0;
                            DragandDrop.mostInternalIndex = 0;
                            previousObj ="Blank";
                            if((DragandDrop.labinstructionNumberIndex+1)<=ObjectivesItemNames[DragandDrop.labinstructionNumber].Count){
                                DragandDrop.labinstructionNumberIndex = DragandDrop.labinstructionNumberIndex+1;
                            }
                            DAD.updateInstruction();
                        }else{
                            DragandDrop.mostInternalIndex = DragandDrop.mostInternalIndex +1;
                        }
                        string objectName = "";
                        try{
                            objectName = AS.Namechanger[gameobject_.name];
                        }catch(System.Exception e){}
                        if(objectName.Length>0){
                            ts.changeobjectplacedSuccessfullyState(true);
                            ts.SetobjectplacedSuccessfullyText(AS.Namechanger[gameobject_.name]+" Connected");
                        }else{
                            ts.changeobjectplacedSuccessfullyState(true);
                            ts.SetobjectplacedSuccessfullyText(gameobject_.name+" Connected");
                        }
                    }
                }else{
                    if(!previousObj.Contains(gameobject_.tag)){
                        previousObj = gameobject_.tag;
                        NumberofobjectiveAchieved = NumberofobjectiveAchieved+1;
                        if(NumberofobjectiveAchieved == ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex].Count){
                            NumberofobjectiveAchieved = 0;
                            DragandDrop.mostInternalIndex = 0;
                            previousObj ="Blank";
                            try{
                                if((DragandDrop.labinstructionNumberIndex+1)<=ObjectivesItemNames[DragandDrop.labinstructionNumber].Count){
                                    DragandDrop.labinstructionNumberIndex = DragandDrop.labinstructionNumberIndex+1;
                                }
                                DAD.updateInstruction();
                            }catch(System.Exception e){}

                        }else{
                            DragandDrop.mostInternalIndex = DragandDrop.mostInternalIndex +1;
                        }
                        string objectName = "";
                        try{
                            objectName = AS.Namechanger[gameobject_.name];
                        }catch(System.Exception e){}
                        if(objectName.Length>0){
                            ts.changeobjectplacedSuccessfullyState(true);
                            ts.SetobjectplacedSuccessfullyText(AS.Namechanger[gameobject_.name]+" Connected");
                        }else{
                            ts.changeobjectplacedSuccessfullyState(true);
                            ts.SetobjectplacedSuccessfullyText(gameobject_.name+" Connected");
                        }
                    }
                }
                
            }
        }catch(System.Exception e){}
    }

    public void increseAchieved(){
        if(NumberofobjectiveAchieved < ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex].Count){
            NumberofobjectiveAchieved = NumberofobjectiveAchieved+1;
        }
    }
}