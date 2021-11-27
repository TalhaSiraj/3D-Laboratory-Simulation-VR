using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ObjectDetector : MonoBehaviour
{

    private GameObject ChildCollidedGameObject;
    private GameObject ParentCollidedGameObject;
    private DragandDrop DAD;
    private WheelMotorControl WMC;
    private ResetobjectsScrpt_ ROS;
    private bool placedRobot = false,move = false,DifferentDirection = false,hitWalls = false,movestraight = false,left = false, right = false;
    private DelayScript CS;
    private CircuitSettings circuitsetting;
    private RaycastScript RCS;
    private TextScript ts;
    private LED_Control_Script LCS;

    float VerticalMotion = 0.005f,RawDistance = 0.4f,horizontalmotion = 1.3f;
    int HorizontalMotion = 1,Robotdirection = 1,previousDirection = 0,counter = 0,innercounter = 0,finishedTimer = 5,inerFinishedTimer = 2,ledshutdown = 0;

    [HideInInspector]
    public static bool DisbaleRobotCatch = false,blockautomove = false; 

    void Start(){
        Debug.Log("Object Detector Start");
        try{
            DAD = GameObject.FindObjectOfType(typeof(DragandDrop)) as DragandDrop;
        }catch(System.Exception e){}
        try{
            WMC = GameObject.FindObjectOfType(typeof(WheelMotorControl)) as WheelMotorControl;
        }catch(System.Exception e){}
        try{
            CS = GameObject.FindObjectOfType(typeof(DelayScript)) as DelayScript;
        }catch(System.Exception e){}
        try{
            ROS = GameObject.FindObjectOfType(typeof(ResetobjectsScrpt_)) as ResetobjectsScrpt_;
        }catch(System.Exception e){}
        try{
            circuitsetting = GameObject.FindObjectOfType(typeof(CircuitSettings)) as CircuitSettings;
        }catch(System.Exception e){}
        try{
            ts = GameObject.FindObjectOfType(typeof(TextScript)) as TextScript;
        }catch(System.Exception e){}
        try{
            LCS = GameObject.FindObjectOfType(typeof(LED_Control_Script)) as LED_Control_Script;
        }catch(System.Exception e){}
    }
    void Awake(){
        Debug.Log("Object Detector Awake");
        try{
            DAD = GameObject.FindObjectOfType(typeof(DragandDrop)) as DragandDrop;
        }catch(System.Exception e){}
        try{
            WMC = GameObject.FindObjectOfType(typeof(WheelMotorControl)) as WheelMotorControl;
        }catch(System.Exception e){}
        try{
            CS = GameObject.FindObjectOfType(typeof(DelayScript)) as DelayScript;
        }catch(System.Exception e){}
        try{
            ROS = GameObject.FindObjectOfType(typeof(ResetobjectsScrpt_)) as ResetobjectsScrpt_;
        }catch(System.Exception e){}
        try{
            circuitsetting = GameObject.FindObjectOfType(typeof(CircuitSettings)) as CircuitSettings;
        }catch(System.Exception e){}
        try{
            ts = GameObject.FindObjectOfType(typeof(TextScript)) as TextScript;
        }catch(System.Exception e){}
        try{
            LCS = GameObject.FindObjectOfType(typeof(LED_Control_Script)) as LED_Control_Script;
        }catch(System.Exception e){}
    }

    void Update(){
        RaycastHit hit;
        if(DisbaleRobotCatch){
            if(DragandDrop.labinstructionNumber == 19){
                if (Physics.Raycast(GameObject.Find("IRDectector1").transform.position, GameObject.Find("IRDectector1").transform.TransformDirection(Vector3.forward), out hit, RawDistance))
                {
                    if(hit.collider.gameObject.tag.Contains("Obsticle")){
                        //Debug.Log("Move Straight");
                        movestraight = true;
                    }
                    else{
                        if(hit.collider.gameObject.tag.Contains("corner") ){
                            movestraight = true;
                        }
                    }
                    Debug.DrawRay(GameObject.Find("IRDectector1").transform.position, GameObject.Find("IRDectector1").transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                }
                if (Physics.Raycast(GameObject.Find("IRDectector2").transform.position, GameObject.Find("IRDectector2").transform.TransformDirection(Vector3.forward), out hit, RawDistance))
                {
                    if(hit.collider.gameObject.tag.Contains("Obsticle")){
                        //Debug.Log("Move Straight");
                        right = true;
                    }
                    else{
                        if(hit.collider.gameObject.tag.Contains("corner")){
                            right = true;
                        }else{
                            right = false;
                        }
                    }
                    Debug.DrawRay(GameObject.Find("IRDectector2").transform.position, GameObject.Find("IRDectector2").transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                }
                if (Physics.Raycast(GameObject.Find("IRDectector3").transform.position, GameObject.Find("IRDectector3").transform.TransformDirection(Vector3.forward), out hit, RawDistance))
                {
                    if(hit.collider.gameObject.tag.Contains("Obsticle")){
                        //Debug.Log("Move Straight");
                        left = true;
                    }
                    else{
                        if(hit.collider.gameObject.tag.Contains("corner")){
                            left = true;
                        }else{
                            left = false;
                        }
                    }
                    Debug.DrawRay(GameObject.Find("IRDectector3").transform.position, GameObject.Find("IRDectector3").transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                }
                else{
                    Debug.DrawRay(GameObject.Find("IRDectector1").transform.position, GameObject.Find("IRDectector1").transform.TransformDirection(Vector3.forward)*1, Color.green);
                    Debug.DrawRay(GameObject.Find("IRDectector2").transform.position, GameObject.Find("IRDectector2").transform.TransformDirection(Vector3.forward)*1, Color.green);
                    Debug.DrawRay(GameObject.Find("IRDectector3").transform.position, GameObject.Find("IRDectector3").transform.TransformDirection(Vector3.forward)*1, Color.green);
                }


                if(counter<finishedTimer){
                    counter = counter +1;
                    move = false;
                }else{
                    move = true;
                    if(move){
                        if(innercounter < inerFinishedTimer){
                            innercounter = innercounter +1;
                            MoveRobot();        
                        }else{
                            move = false;
                            counter = 0;
                            innercounter = 0;                                    
                        }

                    }
                }

            }
            if(DragandDrop.labinstructionNumber == 18){
                if (Physics.Raycast(GameObject.Find("USDetector").transform.position, GameObject.Find("USDetector").transform.TransformDirection(Vector3.forward), out hit, RawDistance))
                {
                    List<string> Border = new List<string>{"Obsticle Parent","ObsticalBorder","ObsticalBorder (1)","ObsticalBorder (2)","ObsticalBorder (3)","Obstical","Obstical (1)","Obstical (2)","Obstical (3)","Obstical (4)","Obstical (5)","Obstical (6)","Obstical (7)"};
                    //Debug.Log("F1 Hit : "+hit.collider.gameObject.name+" -- "+Border.Contains(hit.collider.gameObject.name));
                    if(Border.Contains(hit.collider.gameObject.name)){
                        hitWalls = true;
                    }else{
                        hitWalls = false;
                    }
                    Debug.DrawRay(GameObject.Find("USDetector").transform.position, GameObject.Find("USDetector").transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                }
                else
                {
                    hitWalls = false;
                    Debug.DrawRay(GameObject.Find("robot top").transform.position, GameObject.Find("robot top").transform.TransformDirection(Vector3.forward) * 1000, Color.green);
                }
                if(counter<finishedTimer){
                    counter = counter +1;
                    move = false;
                }else{
                    move = true;
                    if(move){
                        if(hitWalls){
                            //Debug.Log("F1 hitwals = true Direction ="+Robotdirection+" previous = "+previousDirection);
                            if(Robotdirection == previousDirection){
                                if(innercounter < inerFinishedTimer){
                                    innercounter = innercounter +1;
                                    MoveRobot();        
                                }else{
                                    move = false;
                                    counter = 0;
                                    innercounter = 0;                                    
                                }
                            }else{
                                if(blockautomove){
                                    previousDirection = Robotdirection;
                                    if(innercounter < inerFinishedTimer){
                                        innercounter = innercounter +1;
                                        MoveRobot();        
                                    }else{
                                        move = false;
                                        counter = 0;
                                        innercounter = 0;                                    
                                    }
                                }else{
                                    Robotdirection = Random.Range(3, 4);
                                    previousDirection = Robotdirection;
                                    if(innercounter < inerFinishedTimer){
                                        innercounter = innercounter +1;
                                        MoveRobot();        
                                    }else{
                                        move = false;
                                        counter = 0;
                                        innercounter = 0;                                    
                                    }
                                }

                            }
                        }else{
                            Robotdirection = 1;
                            previousDirection = 0;
                            MoveRobot();
                            move = false;
                            counter = 0;
                        }
                    }
                }   
            }
            if(DragandDrop.labinstructionNumber == 17 || DragandDrop.labinstructionNumber == 20 || DragandDrop.labinstructionNumber == 21){
                if(DragandDrop.labinstructionNumber == 20){
                    List<string> Border = new List<string>{"A","B","C","D","E","F","G","ObsticalBorder","ObsticalBorder (1)","ObsticalBorder (2)","ObsticalBorder (3)"};
                    string ObjectCollided = "";
                    if (Physics.Raycast(GameObject.Find("RaycastObject").transform.position, GameObject.Find("RaycastObject").transform.TransformDirection(Vector3.forward), out hit, RawDistance+0.1f))
                    {
                        ts.changeObsticleNameTextState(true);
                        if(hit.collider.gameObject.tag.Contains("Obsticle1")){
                           if(Border.Contains(hit.collider.gameObject.name)){
                                ObjectCollided = hit.collider.gameObject.name;
                                ts.SetObsticleNameText("Collided with "+ObjectCollided);
                            }
                        }else{
                            ts.SetObsticleNameText("");
                        }
                        
                        Debug.DrawRay(GameObject.Find("RaycastObject").transform.position, GameObject.Find("RaycastObject").transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                    }
                    if(!Border.Contains(ObjectCollided)){
                        if (Input.GetKeyDown(KeyCode.UpArrow))  
                        {  

                            GameObject.Find("robot top").transform.Translate(Vector3.forward * VerticalMotion);
                            GameObject.Find("robot base").transform.Translate(Vector3.forward * VerticalMotion);
                            try{
                                WMC.MovementKeyDown = "Up";
                                WMC.setWheelone_name("RightWheel");
                                WMC.setWheeltwo_name("LeftWheel");
                            }catch(System.Exception e){
                                WMC = GameObject.FindObjectOfType(typeof(WheelMotorControl)) as WheelMotorControl;
                                WMC.MovementKeyDown = "Up";
                                WMC.setWheelone_name("RightWheel");
                                WMC.setWheeltwo_name("LeftWheel");   
                            }
                        }else{
                            if(!CS.getTimerState()){
                                WMC.MovementKeyDown = "None";
                                WMC.setWheelone_name("None");
                                WMC.setWheeltwo_name("None");
                            }
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.DownArrow))  
                    {  
                        GameObject.Find("robot top").transform.Translate(Vector3.back * VerticalMotion);
                        GameObject.Find("robot base").transform.Translate(Vector3.back * VerticalMotion);
                        try{
                            WMC.MovementKeyDown = "Down";
                            WMC.setWheelone_name("RightWheel");
                            WMC.setWheeltwo_name("LeftWheel");
                        }catch(System.Exception e){
                            WMC = GameObject.FindObjectOfType(typeof(WheelMotorControl)) as WheelMotorControl;
                            WMC.MovementKeyDown = "Down";
                            WMC.setWheelone_name("RightWheel");
                            WMC.setWheeltwo_name("LeftWheel");   
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {  
                        GameObject.Find("robot top").transform.Rotate(Vector3.up, -HorizontalMotion);
                        GameObject.Find("robot base").transform.Rotate(Vector3.up, -HorizontalMotion);
                        try{
                            WMC.MovementKeyDown = "Left";
                            WMC.setWheelone_name("None");
                            WMC.setWheeltwo_name("LeftWheel");
                        }catch(System.Exception e){
                            WMC = GameObject.FindObjectOfType(typeof(WheelMotorControl)) as WheelMotorControl;
                            WMC.MovementKeyDown = "Left";
                            WMC.setWheelone_name("None");
                            WMC.setWheeltwo_name("LeftWheel");   
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.RightArrow))  
                    {  
                        GameObject.Find("robot top").transform.Rotate(Vector3.up, HorizontalMotion);
                        GameObject.Find("robot base").transform.Rotate(Vector3.up, HorizontalMotion); 
                        try{
                            WMC.MovementKeyDown = "Right";
                            WMC.setWheelone_name("RightWheel");
                            WMC.setWheeltwo_name("None");
                        }catch(System.Exception e){
                            WMC = GameObject.FindObjectOfType(typeof(WheelMotorControl)) as WheelMotorControl;
                            WMC.MovementKeyDown = "Up";
                            WMC.setWheelone_name("RightWheel");
                            WMC.setWheeltwo_name("None");   
                        }
                    }else{
                        if(!CS.getTimerState()){
                            WMC.MovementKeyDown = "None";
                            WMC.setWheelone_name("None");
                            WMC.setWheeltwo_name("None");
                        }
                    }
                }
                if(DragandDrop.labinstructionNumber == 21){
                    if (Input.GetKeyDown(KeyCode.UpArrow))  
                    {  
                        GameObject.Find("robot top").transform.Translate(Vector3.forward * VerticalMotion);
                        GameObject.Find("robot base").transform.Translate(Vector3.forward * VerticalMotion);
                        LCS.EnabledLED("LED 5mm ON");
                        ledshutdown = 0;
                        try{
                            WMC.MovementKeyDown = "Up";
                            WMC.setWheelone_name("RightWheel");
                            WMC.setWheeltwo_name("LeftWheel");
                        }catch(System.Exception e){} 
                    }  
                    if (Input.GetKeyDown(KeyCode.DownArrow))  
                    {  
                        GameObject.Find("robot top").transform.Translate(Vector3.back * VerticalMotion);
                        GameObject.Find("robot base").transform.Translate(Vector3.back * VerticalMotion);
                        LCS.EnabledLED("LED 5mm ON");
                        ledshutdown = 0;
                        try{
                            WMC.MovementKeyDown = "Down";
                            WMC.setWheelone_name("RightWheel");
                            WMC.setWheeltwo_name("LeftWheel");
                        }catch(System.Exception e){}
                    }  
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {  
                        GameObject.Find("robot top").transform.Rotate(Vector3.up, -HorizontalMotion);
                        GameObject.Find("robot base").transform.Rotate(Vector3.up, -HorizontalMotion);
                        LCS.EnabledLED("LED 5mm ON");
                        ledshutdown = 0;
                        try{
                            WMC.MovementKeyDown = "Left";
                            WMC.setWheelone_name("None");
                            WMC.setWheeltwo_name("LeftWheel");
                        }catch(System.Exception e){}
                        
                    }  
                    if (Input.GetKeyDown(KeyCode.RightArrow))  
                    {  
                        GameObject.Find("robot top").transform.Rotate(Vector3.up, HorizontalMotion);
                        GameObject.Find("robot base").transform.Rotate(Vector3.up, HorizontalMotion); 
                        LCS.EnabledLED("LED 5mm ON");
                        ledshutdown = 0;
                        try{
                            WMC.MovementKeyDown = "Right";
                            WMC.setWheelone_name("RightWheel");
                            WMC.setWheeltwo_name("None");
                        }catch(System.Exception e){}
                        
                    }else{
                        if(!CS.getTimerState()){
                            WMC.MovementKeyDown = "None";
                            WMC.setWheelone_name("None");
                            WMC.setWheeltwo_name("None");
                        }
                        if(ledshutdown == 2){
                            LCS.DisableLED("LED 5mm ON");
                        }

                    }
                    ledshutdown = ledshutdown +1;

                }
                else{
                    if (Input.GetKeyDown(KeyCode.UpArrow))  
                    {  
                        GameObject.Find("robot top").transform.Translate(Vector3.forward * VerticalMotion);
                        GameObject.Find("robot base").transform.Translate(Vector3.forward * VerticalMotion);
                        try{
                            WMC.MovementKeyDown = "Up";
                            WMC.setWheelone_name("RightWheel");
                            WMC.setWheeltwo_name("LeftWheel");
                        }catch(System.Exception e){}    
                    }  
                    if (Input.GetKeyDown(KeyCode.DownArrow))  
                    {  
                        GameObject.Find("robot top").transform.Translate(Vector3.back * VerticalMotion);
                        GameObject.Find("robot base").transform.Translate(Vector3.back * VerticalMotion);
                        try{
                            WMC.MovementKeyDown = "Down";
                            WMC.setWheelone_name("RightWheel");
                            WMC.setWheeltwo_name("LeftWheel");
                        }catch(System.Exception e){}
                    }  
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {  
                        GameObject.Find("robot top").transform.Rotate(Vector3.up, -HorizontalMotion);
                        GameObject.Find("robot base").transform.Rotate(Vector3.up, -HorizontalMotion);
                        try{
                            WMC.MovementKeyDown = "Left";
                            WMC.setWheelone_name("None");
                            WMC.setWheeltwo_name("LeftWheel");
                        }catch(System.Exception e){}
                    }  
                    if (Input.GetKeyDown(KeyCode.RightArrow))  
                    {  
                        GameObject.Find("robot top").transform.Rotate(Vector3.up, HorizontalMotion);
                        GameObject.Find("robot base").transform.Rotate(Vector3.up, HorizontalMotion); 
                        try{
                            WMC.MovementKeyDown = "Right";
                            WMC.setWheelone_name("RightWheel");
                            WMC.setWheeltwo_name("None");
                        }catch(System.Exception e){}
                    }else{
                        if(!CS.getTimerState()){
                            WMC.MovementKeyDown = "None";
                            WMC.setWheelone_name("None");
                            WMC.setWheeltwo_name("None");
                        }
                    }

                }
                
            }
            
        }
    }

    void OnCollisionEnter(Collision Col){
        List<string> Border = new List<string>{"Obsticle Parent","ObsticalBorder","ObsticalBorder (1)","ObsticalBorder (2)","ObsticalBorder (3)","Obstical","Obstical (1)","Obstical (2)","Obstical (3)","Obstical (4)","Obstical (5)","Obstical (6)","Obstical (7)"};
        if(DragandDrop.labinstructionNumber == 18 && DisbaleRobotCatch && Border.Contains(Col.collider.name)){
            Robotdirection = 3;
            counter = 0;
            innercounter = 0;
            blockautomove = true;
        }
        if(DragandDrop.labinstructionNumber == 18 && DisbaleRobotCatch && !Border.Contains(Col.collider.name)){
            blockautomove = false;
        }
        
        
        try{ 
            if(Col.collider.name.Contains("motor 1")  && (DragandDrop.CurentCaringObjectname.Contains("motor 1") || DragandDrop.CurentCaringObjecttag.Contains("MOTOR1")) && (circuitsetting.ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex][DragandDrop.mostInternalIndex].Contains(Col.collider.tag) || circuitsetting.ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex][DragandDrop.mostInternalIndex].Contains(Col.collider.name))){
                ChildCollidedGameObject = GameObject.Find("motor 1");
                ParentCollidedGameObject = GameObject.Find("LeftMotorLocation");
                try{
                    ROS.AddObjects_(GameObject.Find(Col.collider.name),new Vector3(GameObject.Find(Col.collider.name).transform.position.x,GameObject.Find(Col.collider.name).transform.position.y,GameObject.Find(Col.collider.name).transform.position.z),
                    new Vector3(GameObject.Find(Col.collider.name).transform.rotation.eulerAngles.x,GameObject.Find(Col.collider.name).transform.rotation.eulerAngles.y,GameObject.Find(Col.collider.name).transform.rotation.eulerAngles.z));
                }catch(System.Exception e){}

                ChildCollidedGameObject.transform.rotation = Quaternion.Euler(180f,ParentCollidedGameObject.transform.rotation.y,-90f);
                
                try{
                    GameObject.Find("motor 1").GetComponent<ParentConstraint>().constraintActive = true;
                }catch(System.Exception e){}finally{GameObject.Find("motor 1").GetComponent<ParentConstraint>().constraintActive = true;}


                bool contraintsActive = GameObject.Find("motor 1").GetComponent<ParentConstraint>().constraintActive;
                if(contraintsActive){
                    if(circuitsetting.ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex].Count>( DragandDrop.mostInternalIndex +1)){
                        DragandDrop.mostInternalIndex = DragandDrop.mostInternalIndex +1;
                    }else{
                        DragandDrop.mostInternalIndex=0;
                        DragandDrop.labinstructionNumberIndex = DragandDrop.labinstructionNumberIndex +1;
                    }

                    DAD.updateInstruction();
                }

            }
            if(Col.collider.name.Contains("motor 2") && (DragandDrop.CurentCaringObjectname.Contains("motor 2") || DragandDrop.CurentCaringObjecttag.Contains("MOTOR2"))  && (circuitsetting.ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex][DragandDrop.mostInternalIndex].Contains(Col.collider.tag) || circuitsetting.ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex][DragandDrop.mostInternalIndex].Contains(Col.collider.name))){
                ChildCollidedGameObject = GameObject.Find("motor 2");
                ParentCollidedGameObject = GameObject.Find("RightMotorLocation");
                try{
                    ROS.AddObjects_(GameObject.Find(Col.collider.name),new Vector3(GameObject.Find(Col.collider.name).transform.position.x,GameObject.Find(Col.collider.name).transform.position.y,GameObject.Find(Col.collider.name).transform.position.z),
                    new Vector3(GameObject.Find(Col.collider.name).transform.rotation.eulerAngles.x,GameObject.Find(Col.collider.name).transform.rotation.eulerAngles.y,GameObject.Find(Col.collider.name).transform.rotation.eulerAngles.z));
                }catch(System.Exception e){}


                ChildCollidedGameObject.transform.rotation = Quaternion.Euler(180f,360f,90f);
                
                try{
                    GameObject.Find("motor 2").GetComponent<ParentConstraint>().constraintActive = true;
                }catch(System.Exception e){}finally{GameObject.Find("motor 2").GetComponent<ParentConstraint>().constraintActive = true;}

                bool contraintsActive = GameObject.Find("motor 2").GetComponent<ParentConstraint>().constraintActive;
                if(contraintsActive){
                    if(circuitsetting.ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex].Count>( DragandDrop.mostInternalIndex +1)){
                        DragandDrop.mostInternalIndex = DragandDrop.mostInternalIndex +1;
                    }else{
                        DragandDrop.mostInternalIndex=0;
                        DragandDrop.labinstructionNumberIndex = DragandDrop.labinstructionNumberIndex +1;
                    }
                    DAD.updateInstruction();
                }

            }

            if(Col.collider.name.Contains("CasterBall") && (DragandDrop.CurentCaringObjectname.Contains("robot base") || DragandDrop.CurentCaringObjecttag.Contains("robotbase")) && (circuitsetting.ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex][DragandDrop.mostInternalIndex].Contains(Col.collider.tag) || circuitsetting.ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex][DragandDrop.mostInternalIndex].Contains(Col.collider.name))){
                try{
                    ROS.AddObjects_(GameObject.Find(Col.collider.name),new Vector3(GameObject.Find(Col.collider.name).transform.position.x,GameObject.Find(Col.collider.name).transform.position.y,GameObject.Find(Col.collider.name).transform.position.z),
                    new Vector3(GameObject.Find(Col.collider.name).transform.rotation.eulerAngles.x,GameObject.Find(Col.collider.name).transform.rotation.eulerAngles.y,GameObject.Find(Col.collider.name).transform.rotation.eulerAngles.z));
                }catch(System.Exception e){}
                
                
                try{
                    GameObject.Find("CasterBall").GetComponent<ParentConstraint>().constraintActive = true;
                }catch(System.Exception e){Debug.Log("Caster E="+e);}finally{ GameObject.Find("CasterBall").GetComponent<ParentConstraint>().constraintActive = true;} 

                bool contraintsActive = GameObject.Find("CasterBall").GetComponent<ParentConstraint>().constraintActive;
                Debug.Log("Constraints = "+contraintsActive+" actual value = "+GameObject.Find("CasterBall").GetComponent<ParentConstraint>().constraintActive);
                Debug.Log("Isactive enabled called = "+GameObject.Find("CasterBall").GetComponent<ParentConstraint>().isActiveAndEnabled);
                if(contraintsActive){
                    if(circuitsetting.ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex].Count>(DragandDrop.mostInternalIndex+1)){
                        DragandDrop.mostInternalIndex = DragandDrop.mostInternalIndex +1;
                    }else{
                        DragandDrop.mostInternalIndex=0;
                        DragandDrop.labinstructionNumberIndex = DragandDrop.labinstructionNumberIndex +1;
                    }
                    if(GameObject.Find("arduino uno").transform.localScale.x>1f){
                        DAD.ResizeBreadBOard();
                    }
                    
                    DAD.updateInstruction();
                }

            }

            if((Col.collider.name.Contains("RightRod") || Col.collider.name.Contains("LeftRod") || Col.collider.tag.Contains("robottop")) && (circuitsetting.ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex][DragandDrop.mostInternalIndex].Contains(Col.collider.tag) || circuitsetting.ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex][DragandDrop.mostInternalIndex].Contains(Col.collider.name))){
                try{
                    ROS.AddObjects_(GameObject.Find("robot top"),new Vector3(GameObject.Find("robot top").transform.position.x,GameObject.Find("robot top").transform.position.y,GameObject.Find("robot top").transform.position.z),
                    new Vector3(GameObject.Find("robot top").transform.rotation.eulerAngles.x,GameObject.Find("robot top").transform.rotation.eulerAngles.y,GameObject.Find("robot top").transform.rotation.eulerAngles.z));
                }catch(System.Exception e){}
            
                
                try{
                    GameObject.Find("robot base").GetComponent<ParentConstraint>().constraintActive = true;
                }catch(System.Exception e){}finally{GameObject.Find("robot base").GetComponent<ParentConstraint>().constraintActive = true;}

                bool contraintsActive = GameObject.Find("robot base").GetComponent<ParentConstraint>().constraintActive;
                if(contraintsActive){
                    if(circuitsetting.ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex].Count>( DragandDrop.mostInternalIndex +1)){
                        DragandDrop.mostInternalIndex = DragandDrop.mostInternalIndex +1;
                    }else{
                        DragandDrop.mostInternalIndex=0;
                        DragandDrop.labinstructionNumberIndex = DragandDrop.labinstructionNumberIndex +1;
                    }
                    DAD.updateInstruction();
                }
            }

            if(Col.collider.name.Contains("Breadboard") && (circuitsetting.ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex][DragandDrop.mostInternalIndex].Contains(Col.collider.tag) || circuitsetting.ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex][DragandDrop.mostInternalIndex].Contains(Col.collider.name))){
                try{
                    ROS.AddObjects_(GameObject.Find(Col.collider.name),new Vector3(GameObject.Find(Col.collider.name).transform.position.x,GameObject.Find(Col.collider.name).transform.position.y,GameObject.Find(Col.collider.name).transform.position.z),
                    new Vector3(GameObject.Find(Col.collider.name).transform.rotation.eulerAngles.x,GameObject.Find(Col.collider.name).transform.rotation.eulerAngles.y,GameObject.Find(Col.collider.name).transform.rotation.eulerAngles.z));
                }catch(System.Exception e){}
                try{
                    GameObject.Find("Breadboard").GetComponent<ParentConstraint>().constraintActive = true;
                    GameObject.Find("000").GetComponent<ParentConstraint>().constraintActive = true;
                }catch(System.Exception e){}finally{
                    GameObject.Find("Breadboard").GetComponent<ParentConstraint>().constraintActive = true;
                    GameObject.Find("000").GetComponent<ParentConstraint>().constraintActive = true;
                }
                bool contraintsActive = GameObject.Find("000").GetComponent<ParentConstraint>().constraintActive;
                if(contraintsActive){
                    placedRobot = true;
                    if(circuitsetting.ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex].Count>( DragandDrop.mostInternalIndex +1)){
                        DragandDrop.mostInternalIndex = DragandDrop.mostInternalIndex +1;
                    }else{
                        DragandDrop.mostInternalIndex=0;
                        DragandDrop.labinstructionNumberIndex = DragandDrop.labinstructionNumberIndex +1;
                    }
                    DAD.updateInstruction();
                }
                
            }
            if(Col.collider.name.Contains("arduino uno") && (circuitsetting.ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex][DragandDrop.mostInternalIndex].Contains(Col.collider.tag) || circuitsetting.ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex][DragandDrop.mostInternalIndex].Contains(Col.collider.name))){
                try{
                    ROS.AddObjects_(GameObject.Find(Col.collider.name),new Vector3(GameObject.Find(Col.collider.name).transform.position.x,GameObject.Find(Col.collider.name).transform.position.y,GameObject.Find(Col.collider.name).transform.position.z),
                    new Vector3(GameObject.Find(Col.collider.name).transform.rotation.eulerAngles.x,GameObject.Find(Col.collider.name).transform.rotation.eulerAngles.y,GameObject.Find(Col.collider.name).transform.rotation.eulerAngles.z));
                }catch(System.Exception e){}
                
                try{
                    GameObject.Find("arduino uno").GetComponent<ParentConstraint>().constraintActive = true;
                    if(DragandDrop.labinstructionNumber == 21){
                        GameObject.Find("LED 5mm ON").GetComponent<ParentConstraint>().constraintActive = true;
                    }
                }catch(System.Exception e){}finally{
                    GameObject.Find("arduino uno").GetComponent<ParentConstraint>().constraintActive = true;
                    if(DragandDrop.labinstructionNumber == 21){
                        GameObject.Find("LED 5mm ON").GetComponent<ParentConstraint>().constraintActive = true;
                    }
                }
                bool contraintsActive = GameObject.Find("arduino uno").GetComponent<ParentConstraint>().constraintActive;
                if(contraintsActive){
                    if(circuitsetting.ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex].Count>( DragandDrop.mostInternalIndex +1)){
                        DragandDrop.mostInternalIndex = DragandDrop.mostInternalIndex +1;
                    }else{
                        DragandDrop.mostInternalIndex=0;
                        DragandDrop.labinstructionNumberIndex = DragandDrop.labinstructionNumberIndex +1;
                    }

                    DAD.updateInstruction();
                }
            }
            if(Col.collider.name.Contains("ultrasonic sensor") && (circuitsetting.ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex][DragandDrop.mostInternalIndex].Contains(Col.collider.tag) || circuitsetting.ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex][DragandDrop.mostInternalIndex].Contains(Col.collider.name))){
                try{
                    ROS.AddObjects_(GameObject.Find(Col.collider.name),new Vector3(GameObject.Find(Col.collider.name).transform.position.x,GameObject.Find(Col.collider.name).transform.position.y,GameObject.Find(Col.collider.name).transform.position.z),
                    new Vector3(GameObject.Find(Col.collider.name).transform.rotation.eulerAngles.x,GameObject.Find(Col.collider.name).transform.rotation.eulerAngles.y,GameObject.Find(Col.collider.name).transform.rotation.eulerAngles.z));
                }catch(System.Exception e){}
                
                try{
                    GameObject.Find("ultrasonic sensor").GetComponent<ParentConstraint>().constraintActive = true;
                }catch(System.Exception e){}finally{GameObject.Find("ultrasonic sensor").GetComponent<ParentConstraint>().constraintActive = true;}

                Debug.Log("Isactive US enabled called = "+GameObject.Find("ultrasonic sensor").GetComponent<ParentConstraint>().isActiveAndEnabled);
                bool contraintsActive = GameObject.Find("ultrasonic sensor").GetComponent<ParentConstraint>().constraintActive;
                if(contraintsActive){
                    if(circuitsetting.ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex].Count>( DragandDrop.mostInternalIndex +1)){
                        DragandDrop.mostInternalIndex = DragandDrop.mostInternalIndex +1;
                    }else{
                        DragandDrop.mostInternalIndex=0;
                        DragandDrop.labinstructionNumberIndex = DragandDrop.labinstructionNumberIndex +1;
                    }
                    DAD.updateInstruction();
                }

            }
            if(Col.collider.name.Contains("MotorDriver") && (circuitsetting.ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex][DragandDrop.mostInternalIndex].Contains(Col.collider.tag) || circuitsetting.ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex][DragandDrop.mostInternalIndex].Contains(Col.collider.name))){
                try{
                    ROS.AddObjects_(GameObject.Find(Col.collider.name),new Vector3(GameObject.Find(Col.collider.name).transform.position.x,GameObject.Find(Col.collider.name).transform.position.y,GameObject.Find(Col.collider.name).transform.position.z),
                    new Vector3(GameObject.Find(Col.collider.name).transform.rotation.eulerAngles.x,GameObject.Find(Col.collider.name).transform.rotation.eulerAngles.y,GameObject.Find(Col.collider.name).transform.rotation.eulerAngles.z));
                }catch(System.Exception e){}
                
                try{
                    GameObject.Find("MotorDriver").GetComponent<ParentConstraint>().constraintActive = true;
                }catch(System.Exception e){}finally{GameObject.Find("MotorDriver").GetComponent<ParentConstraint>().constraintActive = true;}
                Debug.Log("Isactive motordriver enabled called = "+GameObject.Find("MotorDriver").GetComponent<ParentConstraint>().isActiveAndEnabled);
                bool contraintsActive = GameObject.Find("MotorDriver").GetComponent<ParentConstraint>().constraintActive;
                if(contraintsActive){
                    if(circuitsetting.ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex].Count>( DragandDrop.mostInternalIndex +1)){
                        DragandDrop.mostInternalIndex = DragandDrop.mostInternalIndex +1;
                    }else{
                        DragandDrop.mostInternalIndex=0;
                        DragandDrop.labinstructionNumberIndex = DragandDrop.labinstructionNumberIndex +1;
                    }
                    DAD.updateInstruction();

                }
            }
            if(Col.collider.name.Contains("Bluetooth Module") && (circuitsetting.ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex][DragandDrop.mostInternalIndex].Contains(Col.collider.tag))){
                try{
                    ROS.AddObjects_(GameObject.Find(Col.collider.name),new Vector3(GameObject.Find(Col.collider.name).transform.position.x,GameObject.Find(Col.collider.name).transform.position.y,GameObject.Find(Col.collider.name).transform.position.z),
                    new Vector3(GameObject.Find(Col.collider.name).transform.rotation.eulerAngles.x,GameObject.Find(Col.collider.name).transform.rotation.eulerAngles.y,GameObject.Find(Col.collider.name).transform.rotation.eulerAngles.z));
                }catch(System.Exception e){}
                try{
                    GameObject.Find("Bluetooth Module").GetComponent<ParentConstraint>().constraintActive = true;
                    GameObject.Find("BluetoothModulepins").GetComponent<ParentConstraint>().constraintActive = false;
                    GameObject parent = GameObject.Find("BluetoothModulepins");
                    foreach (Transform child in parent.transform){
                        child.GetComponent<ParentConstraint>().constraintActive = true;
                    }
                }catch(System.Exception e){}finally{
                    GameObject.Find("Bluetooth Module").GetComponent<ParentConstraint>().constraintActive = true;
                    GameObject.Find("BluetoothModulepins").GetComponent<ParentConstraint>().constraintActive = false;
                    GameObject parent = GameObject.Find("BluetoothModulepins");
                    foreach (Transform child in parent.transform){
                        child.GetComponent<ParentConstraint>().constraintActive = true;
                    }
                }
                bool activateBlueetoothModule = GameObject.Find("Bluetooth Module").GetComponent<ParentConstraint>().constraintActive;
                if(activateBlueetoothModule){
                    if(circuitsetting.ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex].Count>( DragandDrop.mostInternalIndex +1)){
                        DragandDrop.mostInternalIndex = DragandDrop.mostInternalIndex +1;
                    }else{
                        DragandDrop.mostInternalIndex=0;
                        DragandDrop.labinstructionNumberIndex = DragandDrop.labinstructionNumberIndex +1;
                    }
                    DAD.ResizeBluetoothModule();
                    DAD.updateInstruction();

                }
            }

            if(Col.collider.name.Contains("IRsensor1") && (circuitsetting.ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex][DragandDrop.mostInternalIndex].Contains(Col.collider.tag) || circuitsetting.ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex][DragandDrop.mostInternalIndex].Contains(Col.collider.name))){
                try{
                    ROS.AddObjects_(GameObject.Find(Col.collider.name),new Vector3(GameObject.Find(Col.collider.name).transform.position.x,GameObject.Find(Col.collider.name).transform.position.y,GameObject.Find(Col.collider.name).transform.position.z),
                    new Vector3(GameObject.Find(Col.collider.name).transform.rotation.eulerAngles.x,GameObject.Find(Col.collider.name).transform.rotation.eulerAngles.y,GameObject.Find(Col.collider.name).transform.rotation.eulerAngles.z));
                }catch(System.Exception e){}
                
                try{
                    GameObject.Find("IRsensor1").GetComponent<ParentConstraint>().constraintActive = true;
                }catch(System.Exception e){}finally{GameObject.Find("IRsensor1").GetComponent<ParentConstraint>().constraintActive = true;}

                bool contraintsActive = GameObject.Find("IRsensor1").GetComponent<ParentConstraint>().constraintActive;
                if(contraintsActive){
                    if(circuitsetting.ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex].Count>( DragandDrop.mostInternalIndex +1)){
                        DragandDrop.mostInternalIndex = DragandDrop.mostInternalIndex +1;
                    }else{
                        DragandDrop.mostInternalIndex=0;
                        DragandDrop.labinstructionNumberIndex = DragandDrop.labinstructionNumberIndex +1;
                    }
                    DAD.updateInstruction();
                }

            }
            if(Col.collider.name.Contains("IRsensor2") && (circuitsetting.ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex][DragandDrop.mostInternalIndex].Contains(Col.collider.tag) || circuitsetting.ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex][DragandDrop.mostInternalIndex].Contains(Col.collider.name))){
                try{
                    ROS.AddObjects_(GameObject.Find(Col.collider.name),new Vector3(GameObject.Find(Col.collider.name).transform.position.x,GameObject.Find(Col.collider.name).transform.position.y,GameObject.Find(Col.collider.name).transform.position.z),
                    new Vector3(GameObject.Find(Col.collider.name).transform.rotation.eulerAngles.x,GameObject.Find(Col.collider.name).transform.rotation.eulerAngles.y,GameObject.Find(Col.collider.name).transform.rotation.eulerAngles.z));
                }catch(System.Exception e){}

                
                try{
                    GameObject.Find("IRsensor2").GetComponent<ParentConstraint>().constraintActive = true;
                }catch(System.Exception e){}finally{ GameObject.Find("IRsensor2").GetComponent<ParentConstraint>().constraintActive = true; }

                bool contraintsActive = GameObject.Find("IRsensor2").GetComponent<ParentConstraint>().constraintActive;
                if(contraintsActive){
                    if(circuitsetting.ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex].Count>( DragandDrop.mostInternalIndex +1)){
                        DragandDrop.mostInternalIndex = DragandDrop.mostInternalIndex +1;
                    }else{
                        DragandDrop.labinstructionNumberIndex = DragandDrop.labinstructionNumberIndex +1;
                        DragandDrop.mostInternalIndex=0;
                    }
                    DAD.updateInstruction();
                }

            }
            if(Col.collider.name.Contains("IRsensor3") && (circuitsetting.ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex][DragandDrop.mostInternalIndex].Contains(Col.collider.tag) || circuitsetting.ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex][DragandDrop.mostInternalIndex].Contains(Col.collider.name))){
                try{
                    ROS.AddObjects_(GameObject.Find(Col.collider.name),new Vector3(GameObject.Find(Col.collider.name).transform.position.x,GameObject.Find(Col.collider.name).transform.position.y,GameObject.Find(Col.collider.name).transform.position.z),
                    new Vector3(GameObject.Find(Col.collider.name).transform.rotation.eulerAngles.x,GameObject.Find(Col.collider.name).transform.rotation.eulerAngles.y,GameObject.Find(Col.collider.name).transform.rotation.eulerAngles.z));
                }catch(System.Exception e){}
                
                try{
                    GameObject.Find("IRsensor3").GetComponent<ParentConstraint>().constraintActive = true;
                }catch(System.Exception e){}finally{GameObject.Find("IRsensor3").GetComponent<ParentConstraint>().constraintActive = true;}

                bool contraintsActive = GameObject.Find("IRsensor3").GetComponent<ParentConstraint>().constraintActive;
                if(contraintsActive){
                    if(circuitsetting.ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex].Count>( DragandDrop.mostInternalIndex +1)){
                        DragandDrop.mostInternalIndex = DragandDrop.mostInternalIndex +1;
                    }else{
                        DragandDrop.labinstructionNumberIndex = DragandDrop.labinstructionNumberIndex +1;
                        DragandDrop.mostInternalIndex=0;
                    }
                    DAD.updateInstruction();
                }
            }
            if(Col.collider.name.Contains("Servo Motor") && (circuitsetting.ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex][DragandDrop.mostInternalIndex].Contains(Col.collider.tag) || circuitsetting.ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex][DragandDrop.mostInternalIndex].Contains(Col.collider.name))){
                try{
                    ROS.AddObjects_(GameObject.Find(Col.collider.name),new Vector3(GameObject.Find(Col.collider.name).transform.position.x,GameObject.Find(Col.collider.name).transform.position.y,GameObject.Find(Col.collider.name).transform.position.z),
                    new Vector3(GameObject.Find(Col.collider.name).transform.rotation.eulerAngles.x,GameObject.Find(Col.collider.name).transform.rotation.eulerAngles.y,GameObject.Find(Col.collider.name).transform.rotation.eulerAngles.z));
                }catch(System.Exception e){}
                
                try{
                    GameObject.Find("Servo Motor").GetComponent<ParentConstraint>().constraintActive = true;
                }catch(System.Exception e){}finally{GameObject.Find("Servo Motor").GetComponent<ParentConstraint>().constraintActive = true;}


                bool contraintsActive = GameObject.Find("Servo Motor").GetComponent<ParentConstraint>().constraintActive;
                if(contraintsActive){
                    if(circuitsetting.ObjectivesItemNames[DragandDrop.labinstructionNumber][DragandDrop.labinstructionNumberIndex].Count>( DragandDrop.mostInternalIndex +1)){
                        DragandDrop.mostInternalIndex = DragandDrop.mostInternalIndex +1;
                    }else{
                        DragandDrop.labinstructionNumberIndex = DragandDrop.labinstructionNumberIndex +1;
                        DragandDrop.mostInternalIndex=0;
                    }
                    DAD.updateInstruction();
                }
            }
            if(placedRobot){
                placedRobotBottom();
                placedRobot = false;
            }
        }catch(System.Exception e){}

    }
    void placedRobotBottom(){
        if(DragandDrop.labinstructionNumber == 20 || DragandDrop.labinstructionNumber == 18){
            GameObject.Find("robot top").transform.position = new Vector3(-0.5f,0.15f,1f);
            EnabledobjsticleCollider_mesh();
        }else{
            if(DragandDrop.labinstructionNumber == 19){
                float zOFF = 0.3396f , xOFF = -0.063f;
                GameObject.Find("robot top").transform.position = new Vector3(GameObject.Find("Plane").transform.position.x+xOFF,0.15f,GameObject.Find("Plane").transform.position.z);
                EnabledpathBoxCollider();
            }else{
                GameObject.Find("robot top").transform.position = new Vector3(-0.5f,0.15f,1f);
            }
        }
        DisbaleRobotCatch = true;
    }


    // public void testingMethof(){
    //     GameObject.Find("robot base").GetComponent<ParentConstraint>().constraintActive = true;
    //     GameObject.Find("Breadboard").GetComponent<ParentConstraint>().constraintActive = true;
    //     GameObject.Find("000").GetComponent<ParentConstraint>().constraintActive = true;
    //     placedRobot = true;
    //     //Debug.Log(DragandDrop.labinstructionNumber);
    // }

    void EnabledpathBoxCollider(){
        List<string> Path = new List<string>{"Plane","Plane (2)","corner1","corner2","corner3","corner4","Plane (3)","corner1 (1)","corner2 (1)","corner3 (1)","corner4 (1)","Plane (4)","corner1 (2)","corner2 (2)","corner3 (2)","corner4 (2)"};
            foreach(string child in Path){
                GameObject.Find(child).GetComponent<BoxCollider>().enabled = true;
                GameObject.Find(child).GetComponent<MeshRenderer>().enabled = true;
            } 
        }

    void EnabledobjsticleCollider_mesh(){
        if(DragandDrop.labinstructionNumber == 20){
            List<string> Border = new List<string>{"A","B","C","D","E","F","G","ObsticalBorder","ObsticalBorder (1)","ObsticalBorder (2)","ObsticalBorder (3)"};
            foreach(string child in Border){
                GameObject.Find(child).GetComponent<BoxCollider>().enabled = true;
                GameObject.Find(child).GetComponent<MeshRenderer>().enabled = true;
            }
        }
        if(DragandDrop.labinstructionNumber == 18){
            List<string> Border = new List<string>{"ObsticalBorder","ObsticalBorder (1)","ObsticalBorder (2)","ObsticalBorder (3)","Obstical","Obstical (1)","Obstical (2)","Obstical (3)","Obstical (4)","Obstical (5)","Obstical (6)","Obstical (7)"};
            foreach(string child in Border){
                GameObject.Find(child).GetComponent<BoxCollider>().enabled = true;
                GameObject.Find(child).GetComponent<MeshRenderer>().enabled = true;
            }
        }

    }

    void disabledobjsticleCollider_mesh(){
        List<string> Border = new List<string>{"A","B","C","D","E","F","G","ObsticalBorder","ObsticalBorder (1)","ObsticalBorder (2)","ObsticalBorder (3)"};
        foreach(string child in Border){
            GameObject.Find(child).GetComponent<BoxCollider>().enabled =  false;
            GameObject.Find(child).GetComponent<MeshRenderer>().enabled = false;
        }
    }

    void DisabledpathBoxCollider(){
        List<string> Path = new List<string>{"Plane","Plane (2)","corner1","corner2","corner3","corner4","Plane (3)","corner1 (1)","corner2 (1)","corner3 (1)","corner4 (1)","Plane (4)","corner1 (2)","corner2 (2)","corner3 (2)","corner4 (2)"};
        try{
            foreach(string child in Path){
                GameObject.Find(child).GetComponent<BoxCollider>().enabled = false;
                GameObject.Find(child).GetComponent<MeshRenderer>().enabled = false;
            }
        }catch(System.Exception e){}
    }
    public void DisableAllConstraints(){
        
        try{
            GameObject.Find("motor 1").GetComponent<ParentConstraint>().constraintActive = false;
            GameObject.Find("motor 2").GetComponent<ParentConstraint>().constraintActive = false;
            GameObject.Find("MotorDriver").GetComponent<ParentConstraint>().constraintActive = false;
            GameObject.Find("arduino uno").GetComponent<ParentConstraint>().constraintActive = false;
            GameObject.Find("000").GetComponent<ParentConstraint>().constraintActive = false;
            GameObject.Find("robot base").GetComponent<ParentConstraint>().constraintActive = false;
            GameObject.Find("CasterBall").GetComponent<ParentConstraint>().constraintActive = false;
            GameObject.Find("Breadboard").GetComponent<ParentConstraint>().constraintActive = false;
            GameObject.Find("Breadboardpins").GetComponent<ParentConstraint>().constraintActive = false;
        }catch(System.Exception e){}
        try{
            GameObject.Find("IRsensor1").GetComponent<ParentConstraint>().constraintActive = false;
            GameObject.Find("IRsensor2").GetComponent<ParentConstraint>().constraintActive = false;
            GameObject.Find("IRsensor3").GetComponent<ParentConstraint>().constraintActive = false;
        }catch(System.Exception e){}
        try{
            GameObject.Find("Switch").GetComponent<ParentConstraint>().constraintActive = false;
        }catch(System.Exception e){}
        try{
            if(DragandDrop.labinstructionNumber == 21){
                GameObject.Find("Servo Motor").GetComponent<ParentConstraint>().constraintActive = false;
            }
            
        }catch(System.Exception e){}
        try{
            GameObject.Find("ultrasonic sensor").GetComponent<ParentConstraint>().constraintActive = false;
        }catch(System.Exception e){}
        // try{
        //     GameObject.Find("LED 5mm ON").GetComponent<ParentConstraint>().constraintActive = false;
        // }catch(System.Exception e){}
        // try{
        //     GameObject.Find("Bluetooth Module").GetComponent<ParentConstraint>().constraintActive = false;
        //     GameObject.Find("BluetoothModulepins").GetComponent<ParentConstraint>().constraintActive = true;
        //     GameObject parent = GameObject.Find("BluetoothModulepins");
        //     foreach (Transform child in parent.transform){
        //         child.GetComponent<ParentConstraint>().constraintActive = false;
        //     }
        // }catch(System.Exception e){}
        DisabledpathBoxCollider();
        disabledobjsticleCollider_mesh();
    }


    void MoveRobot(){
        if(DragandDrop.labinstructionNumber == 19){
            if(movestraight && left && right)  
            {  
                GameObject.Find("robot top").transform.Translate(Vector3.forward * VerticalMotion);
                GameObject.Find("robot base").transform.Translate(Vector3.forward * VerticalMotion);
                try{
                    WMC.MovementKeyDown = "Up";
                    WMC.setWheelone_name("RightWheel");
                    WMC.setWheeltwo_name("LeftWheel");
                }catch(System.Exception e){
                    WMC = GameObject.FindObjectOfType(typeof(WheelMotorControl)) as WheelMotorControl;
                    WMC.MovementKeyDown = "Up";
                    WMC.setWheelone_name("RightWheel");
                    WMC.setWheeltwo_name("LeftWheel");   
                }
                movestraight = false;
            }
            if((movestraight && !left && right) || (!movestraight && !left && right)){
                GameObject.Find("robot top").transform.Translate(Vector3.forward * VerticalMotion);
                GameObject.Find("robot base").transform.Translate(Vector3.forward * VerticalMotion);
                GameObject.Find("robot top").transform.Rotate(Vector3.up, horizontalmotion);
                GameObject.Find("robot base").transform.Rotate(Vector3.up, horizontalmotion);
                
                try{
                    WMC.MovementKeyDown = "Right";
                    WMC.setWheelone_name("RightWheel");
                    WMC.setWheeltwo_name("None");
                }catch(System.Exception e){
                    WMC = GameObject.FindObjectOfType(typeof(WheelMotorControl)) as WheelMotorControl;
                    WMC.MovementKeyDown = "Up";
                    WMC.setWheelone_name("RightWheel");
                    WMC.setWheeltwo_name("None");   
                }
                right=false;
            }
            if((movestraight && left && !right) || (!movestraight && left && !right)){
                GameObject.Find("robot top").transform.Translate(Vector3.forward * VerticalMotion);
                GameObject.Find("robot base").transform.Translate(Vector3.forward * VerticalMotion);
                GameObject.Find("robot top").transform.Rotate(Vector3.up, -horizontalmotion);
                GameObject.Find("robot base").transform.Rotate(Vector3.up, -horizontalmotion);
                
                try{
                    WMC.MovementKeyDown = "Right";
                    WMC.setWheelone_name("RightWheel");
                    WMC.setWheeltwo_name("None");
                }catch(System.Exception e){
                    WMC = GameObject.FindObjectOfType(typeof(WheelMotorControl)) as WheelMotorControl;
                    WMC.MovementKeyDown = "Up";
                    WMC.setWheelone_name("RightWheel");
                    WMC.setWheeltwo_name("None");   
                }
                right=false;
            }
        }else{
            if(Robotdirection == 1)  
            {  
                GameObject.Find("robot top").transform.Translate(Vector3.forward * VerticalMotion);
                GameObject.Find("robot base").transform.Translate(Vector3.forward * VerticalMotion);
                try{
                    WMC.MovementKeyDown = "Up";
                    WMC.setWheelone_name("RightWheel");
                    WMC.setWheeltwo_name("LeftWheel");
                }catch(System.Exception e){
                    WMC = GameObject.FindObjectOfType(typeof(WheelMotorControl)) as WheelMotorControl;
                    WMC.MovementKeyDown = "Up";
                    WMC.setWheelone_name("RightWheel");
                    WMC.setWheeltwo_name("LeftWheel");   
                }
            }
            if (Robotdirection == 2)  
            {  
                GameObject.Find("robot top").transform.Translate(Vector3.back * VerticalMotion);
                GameObject.Find("robot base").transform.Translate(Vector3.back * VerticalMotion);
                try{
                    WMC.MovementKeyDown = "Down";
                    WMC.setWheelone_name("RightWheel");
                    WMC.setWheeltwo_name("LeftWheel");
                }catch(System.Exception e){
                    WMC = GameObject.FindObjectOfType(typeof(WheelMotorControl)) as WheelMotorControl;
                    WMC.MovementKeyDown = "Down";
                    WMC.setWheelone_name("RightWheel");
                    WMC.setWheeltwo_name("LeftWheel");   
                }
            }  
            if (Robotdirection == 3)
            {  
                GameObject.Find("robot top").transform.Rotate(Vector3.up, -HorizontalMotion);
                GameObject.Find("robot base").transform.Rotate(Vector3.up, -HorizontalMotion);
                try{
                    WMC.MovementKeyDown = "Left";
                    WMC.setWheelone_name("None");
                    WMC.setWheeltwo_name("LeftWheel");
                }catch(System.Exception e){
                    WMC = GameObject.FindObjectOfType(typeof(WheelMotorControl)) as WheelMotorControl;
                    WMC.MovementKeyDown = "Left";
                    WMC.setWheelone_name("None");
                    WMC.setWheeltwo_name("LeftWheel");   
                }
            }  
            if (Robotdirection == 4)  
            {  
                GameObject.Find("robot top").transform.Rotate(Vector3.up, HorizontalMotion);
                GameObject.Find("robot base").transform.Rotate(Vector3.up, HorizontalMotion); 
                try{
                    WMC.MovementKeyDown = "Right";
                    WMC.setWheelone_name("RightWheel");
                    WMC.setWheeltwo_name("None");
                }catch(System.Exception e){
                    WMC = GameObject.FindObjectOfType(typeof(WheelMotorControl)) as WheelMotorControl;
                    WMC.MovementKeyDown = "Up";
                    WMC.setWheelone_name("RightWheel");
                    WMC.setWheeltwo_name("None");   
                }
            }else{
                if(!CS.getTimerState()){
                    WMC.MovementKeyDown = "None";
                    WMC.setWheelone_name("None");
                    WMC.setWheeltwo_name("None");
                }
            }

        }
    }
}
