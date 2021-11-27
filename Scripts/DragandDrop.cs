using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class DragandDrop : MonoBehaviour
{ 
    [HideInInspector]
    public static List<string> musicName = new List<string>();
    private List<string> Lab4C_words = new List<string>{"BUZZER","LED","ARDUINO","PAUSE","BREAK","INSERT","DELETE","END"};
    private List<string> pinLocation =new List<string>{"A (1)","A (2)","A (3)","A (4)","A (5)","A (6)","A (7)","A (8)","A (9)","A (10)","A (11)","A (12)","A (13)","A (14)","A (15)","A (16)","A (17)","A (18)","A (19)","A (20)","A (21)","A (22)","A (23)","A (24)","A (25)","A (26)","A (27)","A (28)","A (29)","A (30)","F (1)","F (2)","F (3)","F (4)","F (5)","F (6)","F (7)","F (8)","F (9)","F (10)","F (11)","F (12)","F (13)","F (14)","F (15)","F (16)","F (17)","F (18)","F (19)","F (20)","F (21)","F (22)","F (23)","F (24)","F (25)","F (26)","F (27)","F (28)","F (29)","F (30)","P (1)","P (2)","N (1)","N (2)"};
    private List<string> unopins =new List<string>{"SCL","SDA","AREF","GND1","GND2","GND3","R 13","R 12","R 11","R 10","R 9","R 8","R 7","R 6","R 5","R 4","R 3","R 2","R 1","R 0","R A5","R A4","R A3","R A2","R A1","R A0","VIN","5V","3.3V","RESET","IO","NC"};
    private List<string> CollectableObjects =new List<string>{"MotorDriver","robot top","robot base","ENA","CasterBall","MotorDriver","Obsticle","Ground pin lcd","+5V pin lcd","Contrast control pin lcd","Register select pin lcd","readwrite","Enable pin lcd","Data pin 0","Data pin 1","Data pin 2","Data pin 3","Data pin 4","Data pin 5","Data pin 6","Data pin 7","LED +5V pin","LED Ground pin","+5V pin lcd","Signal pin","GND PIN","5V motor","CONTROL","LR_twopin","10k_ohm_resister","10k_ohm_potientiometer","Buzzer","push button Yellow","push button Green","push button Blue","push button Red","photoresister1D","LR_threepin","330_ohm_resister","330ResistorDup1","330ResistorDup2","servo motor","ultrasonic sensor","lcd display","TemperatureSensor","VCC IR","GND IR","Out IR","Switch","Motor","LED  Green","LED  Yellow","LED  Blue","MOTAPin1","MOTAPin2","MOTBPin1","MOTBPin2","MotorDriver5V","MotorDriverGND","IN1","IN2","IN3","IN4","ENA","ENB","Trig","pow","Echo","GND ultrasonic","robottop","robotbase","flange","MOTOR1","MOTOR2","BluetoothModule","IR sensor1","IR sensor2","IR sensor3","VccIR1","VccIR2","VccIR3","GndIR1","GndIR2","GndIR3","OutIR1","OutIR2","OutIR3","KeyBluetooth","VccBluetooth","GndBluetooth","TXDBluetooth","RXDBluetooth","StateBluetooth"};
    private List<string> Lcdpins= new List<string>{"Ground pin lcd","+5V pin lcd","Contrast control pin lcd","Register select pin lcd","readwrite","Enable pin lcd","Data pin 0","Data pin 1","Data pin 2","Data pin 3","Data pin 4","Data pin 5","Data pin 6","Data pin 7","LED +5V pin","LED Ground pin","+5V pin lcd","Signal pin"};
    Dictionary<string,int> numberofrulesperlab = new Dictionary<string, int>{
        {"Lesson1",0},
        {"Lesson2",4},
        {"Lesson3",7},
        {"Lesson4",10},
        {"Lesson5",13},
        {"Lesson6",16},
        {"Lesson7",19},
    };
    
    Dictionary<int,int> CircuitRuleIndex = new Dictionary<int, int>{
        {0,3},
        {4,6},
        {7,9},
        {10,12},
        {13,15},
        {16,18},
        {19,21}
    };
    
    [HideInInspector]
    public List<List<string>> LabObjects =new List<List<string>>{
        new List<string>{"LESSON 1 A \n 1. Place (Red LED) on Breadboard.","2. Place (330 Ohm Resistor) on Breadboard & Connect (Red LED) with (330 Ohm Resistor).","3. Connect (330 Ohm Resistor) with (UNO Digital Pin '7').","4. Connect (Red LED) with (UNO Pin 'GND'),\n(RED LED SHOULD GLOW NOW)."},
        
        new List<string>{"LESSON 1 B \n 1. Place (Red LED) on Breadboard.","2. Place (330 Ohm Resistor) on Breadboard & Connect (Red LED) with (330 Ohm Resistor).","3. Place (Potentiometer) on Breadboard.","4. Connect (330 Ohm Resistor) with (UNO Digital Pin '7').","5. Connect (Red LED) with (UNO Pin 'GND').","6. Connect (Potentiometer) with (UNO Analog Pin 'A0').","7. Connect (Potentiometer) with (Breadboard Ground Rail).","8. Connect (Potentiometer) with (Breadboard Power Rail),\n(GLOW INTENSITY OF RED LED WILL CHANGE BY ROTATING POTENTIOMETER KNOB)."},
        
        new List<string>{"LESSON 1 C \n 1. Place (Red LED) on Breadboard.","2. Place (330 Ohm Resistor) on Breadboard & Connect (Red LED) with (330 Ohm Resistor).","3. Place (Photoresistor) on Breadboard.","4. Connect (330 Ohm Resistor) with (UNO Digital Pin '7').","5. Connect (Red LED) with (UNO Pin 'GND').","6. Place (10K Ohm Resistor) on Breadboard & Connect (Photoresistor) with (10K Ohm Resistor).","7. Connect (10K Ohm Resistor) with (UNO Analog Pin 'A0').","8. Connect (10K Ohm Resistor) with (Breadboard Ground Rail).","9. Connect (Photoresistor) with (Breadboard Power Rail).","10. Press (LIGHTS OFF) button,\n(RED LED SHOULD GLOW NOW)."},
        
        new List<string>{"LESSON 1 D \n 1. Connect (Breadboard Ground Rail) with (UNO Pin 'GND').","2. Place (Photoresistor) on BreadBoard.","3. Connect (Breadboard Power Rail) with (UNO Pin '5V').","4. Place (10K Ohm Resistor) on Breadboard & Connect (Photoresistor) with (10K Ohm Resistor).","5. Connect (10K Ohm Resistor) with (UNO Analog Pin 'A0').","6. Connect (10K Ohm Resistor) with (Breadboard Ground Rail).","7. Place (Potentiometer) on Breadboard.","8. Connect (Potentiometer) with (UNO Analog Pin 'A1').","9. Connect (Potentiometer) with (Breadboard Ground Rail).","10. Connect (Potentiometer) with (Breadboard Power Rail).","11. Place (RGB LED) on Breadboard.","12. Connect (RGB LED) with (Breadboard Ground Rail).","13. Place (330 Ohm Resistor'1') then (330 Ohm Resistor'2') then (330 Ohm Resistor'3') on Breadboard.","14. Connect (RGB LED) with (330 Ohm Resistor'1').","15. Connect (RGB LED) with (330 Ohm Resistor'2').","16. Connect (RGB LED) with (330 Ohm Resistor'3').","17. Connect (RGB LED) with (UNO Digital Pin '9').","18. Connect (RGB LED) with (UNO Digital Pin '10').","19. Connect (RGB LED) with (UNO Digital Pin '11').","20. Press (LIGHTS OFF) button,\n(RGB LED WILL CHANGE COLOUR BY ROTATING POTENTIOMETER KNOB)."},
        
        new List<string>{"LESSON 2 A \n 1. Place (Potentiometer) on Breadboard.","2. Place (Buzzer) on Breadboard.","3. Connect (Potentiometer) with (UNO Pin 'GND').","4. Connect (Buzzer) with (UNO Digital Pin '10').","5. Connect (Potentiometer) with (Buzzer),\n(TUNE WILL PLAY AND TO REPLAY PRESS RESET BUTTON ON ARDUINO AND CONTROL VOLUME BY ROTATING POTENTIOMETER KNOB)."},
        
        new List<string>{"LESSON 2 B \n 1. Place (Potentiometer) on Breadboard.","2. Place (Buzzer) on Breadboard.","3. Connect (Potentiometer) with (UNO Pin 'GND').","4. Connect (Buzzer) with (UNO Digital Pin '10').","5. Connect (Potentiometer) with (Buzzer).","6. Place (Blue Push Button) on Breadboard.","7. Place (Yellow Push Button) on Breadboard.","8. Place (Red Push Button) on Breadboard.","9. Connect (Blue Push Button) with (UNO Digital Pin '2').","10. Connect (Yellow Push Button) with (UNO Digital Pin '3').","11. Connect (Red Push Button) with (UNO Digital Pin '4').","12. Connect (Breadboard Ground Rail) with (Blue Push Button).","13. Connect (Breadboard Ground Rail) with (Yellow Push Button).","14. Connect (Breadboard Ground Rail) with (Red Push Button),\n(DIFFERENT TUNES WILL PLAY AND CONTROL VOLUME BY ROTATING POTENTIOMETER KNOB)."},  

        new List<string>{"LESSON 2 C \n 1. Place (Potentiometer) on Breadboard.","2. Place (Buzzer) on Breadboard.","3. Connect (Potentiometer) with (UNO Pin 'GND').","4. Connect (Buzzer) with (UNO Digital Pin '10').","5. Connect (Potentiometer) with (Buzzer).","6. Place (Blue LED) on breadboard.","7. Place (Yellow LED) on breadboard.","8. Place (Red LED) on breadboard.","9. Place (Green LED) on breadboard.","10. Place (Blue Push Button) on Breadboard.","11. Place (Yellow Push Button) on Breadboard.","12. Place (Red Push Button) on Breadboard.","13. Place (Green Push Button) on Breadboard.","14. Connect (Blue Push Button) with (UNO Digital Pin '2').","15. Connect (Blue LED) with (UNO Digital Pin '3').","16. Connect (Yellow Push Button) with (UNO Digital Pin '4').","17. Connect (Yellow LED) with (UNO Digital Pin '5').","18. Connect (Red Push Button) with (UNO Digital Pin '6').","19. Connect (Red LED) with (UNO Digital Pin '7').","20. Connect (Green Push Button) with (UNO Digital Pin '8').","21. Connect (Green LED) with (UNO Digital Pin '9').","22. Connect (Breadboard Ground Rail) with (Blue Push Button).","23. Connect (Breadboard Ground Rail) with (Yellow Push Button).","24. Connect (Breadboard Ground Rail) with (Red Push Button).","25. Connect (Breadboard Ground Rail) with (Green Push Button).","26. Connect (Breadboard Ground Rail) with (Blue LED).","27. Connect (Breadboard Ground Rail) with (Yellow LED).","28. Connect (Breadboard Ground Rail) with (Red LED).","29. Connect (Breadboard Ground Rail) with (Green LED),\n(REMEMBER THE PATTERN IN WHICH LEDS GLOW AND REPEAT BY PRESSING PUSH BUTTONS IN SAME PATTERN)."},

        new List<string>{"LESSON 3 A \n 1. Place (Potentiometer) on Breadboard.","2. Connect (Breadboard Ground Rail) with (UNO Pin 'GND').","3. Connect (Breadboard Power Rail) with (UNO Pin '5V').","4.	Connect (Potentiometer) with (Breadboard Power Rail).","5.	Connect (Potentiometer) with (Breadboard Ground Rail).","6. Connect (Potentiometer) with (UNO Analog Pin 'A0').","7. Connect (Servomotor Pin '5V') with (Breadboard Power Rail).","8. Connect (Servomotor Pin 'GND') with (Breadboard Ground Rail).","9. Connect (Servomotor Pin 'CONTROL') with (UNO Digital Pin '9'),\n(SERVOMOTOR BLADE WILL CHANGE DIRECTION BY ROTATING POTENTIOMETER KNOB)."},

        new List<string>{"LESSON 3 B \n 1. Place (Ultrasonic Sensor) on Breadboard.","2. Connect (Breadboard Ground Rail) with (UNO Pin 'GND').","3. Connect (Breadboard Power Rail) with (UNO Pin '5V').","4. Connect (Ultrasonic Sensor Pin 'POW') with (Breadboard Power Rail).","5. Connect (Ultrasonic Sensor Pin 'GND') with (Breadboard Ground Rail).","6.	Connect (Ultrasonic Sensor Pin 'ECHO') with (UNO Digital Pin '11').","7. Connect (Ultrasonic Sensor Pin 'TRIG') with (UNO Digital Pin '12').","8. Place (RGB LED) on Breadboard.","9. Connect (RGB LED) with (UNO Digital Pin '3').","10. Connect (RGB LED) with (UNO Digital Pin '5').","11. Connect (RGB LED) with (UNO Digital Pin '6').","12. Connect (RGB LED) with (Breadboard Ground Rail),\n(RGB LED WILL CHANGE COLOUR BY INCREASING DISTANCE FROM ULTRASONIC SENSOR)."},       

        new List<string>{"LESSON 3 C \n 1. Place (Ultrasonic Sensor) on Breadboard.","2. Connect (Breadboard Ground Rail) with (UNO Pin 'GND').","3. Connect (Breadboard Power Rail) with (UNO Pin '5V').","4. Connect (Ultrasonic Sensor Pin 'POW') with (Breadboard Power Rail).","5. Connect (Ultrasonic Sensor Pin 'GND') with (Breadboard Ground Rail).","6.	Connect (Ultrasonic Sensor Pin 'ECHO') with (UNO Digital Pin '11').","7. Connect (Ultrasonic Sensor Pin 'TRIG') with (UNO Digital Pin '12').","8. Place (RGB LED) on Breadboard.","9. Connect (RGB LED) with (UNO Digital Pin '3').","10. Connect (RGB LED) with (UNO Digital Pin '5').","11. Connect (RGB LED) with (UNO Digital Pin '6').","12. Connect (RGB LED) with (Breadboard Ground Rail).","13. Connect (Servomotor Pin '5V') with (Breadboard Power Rail).","14. Connect (Servomotor Pin 'GND') with (Breadboard Ground Rail).","15. Connect (Servomotor Pin 'CONTROL') with (UNO Digital Pin '9').","16. Place (Buzzer) on Breadboard.","17. Connect (Buzzer) with (Breadboard Ground Rail).","18. Connect (Buzzer) with (UNO Digital Pin '10'),\n(TUNE WILL PLAY AND SERVOMOTOR BLADE WILL ROTATE BY INCREASING DISTANCE FROM ULTRASONIC SENSOR)."},       
        
        new List<string>{"LESSON 4 A \n 1. Place (Potentiometer) on Breadboard.","2. Connect (Breadboard Ground Rail) with (UNO Pin 'GND').","3. Connect (Breadboard Power Rail) with (UNO Pin '5V').","4.	Connect (Potentiometer) with (Breadboard Power Rail).","5.	Connect (Potentiometer) with (Breadboard Ground Rail).","6. Connect (Potentiometer) with (LCD Data Pin '3').","7. Connect (LCD Pin 'GND') with (Breadboard Ground Rail).","8. Connect (LCD Pin '5V') with (Breadboard Power Rail).","9. Connect (LCD Pin 'Register') with (UNO Digital Pin '13').","10. Connect (LCD Pin 'Read/Write') with (Breadboard Ground Rail).","11. Connect (LCD Pin 'Enable') with (UNO Digital Pin '12').","12. Connect (LCD Data Pin '4') with (UNO Digital Pin '11').","13. Connect (LCD Data Pin '5') with (UNO Digital Pin '10').","14. Connect (LCD Data Pin '6') with (UNO Digital Pin '9').","15. Connect (LCD Data Pin '7') with (UNO Digital Pin '8').","16. Connect (LED Pin '5V') with (Breadboard Power Rail).","17. Connect (LED Pin 'GND') with (Breadboard Ground Rail),\n(LCD SHOWS TEXT AND YOU CAN CONTROL LCD BRIGHTNESS BY ROTATING POTENTIOMETER KNOB)."},
  
        new List<string>{"LESSON 4 B \n 1. Place (Potentiometer) on Breadboard.","2. Connect (Breadboard Ground Rail) with (UNO Pin 'GND').","3. Connect (Breadboard Power Rail) with (UNO Pin '5V').","4.	Connect (Potentiometer) with (Breadboard Power Rail).","5.	Connect (Potentiometer) with (Breadboard Ground Rail).","6. Connect (Potentiometer) with (LCD Data Pin '3').","7. Connect (LCD Pin 'GND') with (Breadboard Ground Rail).","8. Connect (LCD Pin '5V') with (Breadboard Power Rail).","9. Connect (LCD Pin 'Register') with (UNO Digital Pin '13').","10. Connect (LCD Pin 'Read/Write') with (Breadboard Ground Rail).","11. Connect (LCD Pin 'Enable') with (UNO Digital Pin '12').","12. Connect (LCD Data Pin '4') with (UNO Digital Pin '11').","13. Connect (LCD Data Pin '5') with (UNO Digital Pin '10').","14. Connect (LCD Data Pin '6') with (UNO Digital Pin '9').","15. Connect (LCD Data Pin '7') with (UNO Digital Pin '8').","16. Connect (LED Pin '5V') with (Breadboard Power Rail).","17. Connect (LED Pin 'GND') with (Breadboard Ground Rail).","18. Place (Temperature Sensor) on Breadboard.","19. Connect (Temperature Sensor) with (Breadboard Ground Rail)."," 20. Connect (Temperature Sensor) with (Breadboard Power Rail).", "21. Connect (Temperature Sensor) with (UNO Analog Pin 'A0'),\n(LCD SHOWS TEMPERATURE IN CELSIUS AND FAHRENHEIT)."},

        new List<string>{"LESSON 4 C \n 1. Place (Potentiometer) on Breadboard.","2. Connect (Breadboard Ground Rail) with (UNO Pin 'GND').","3. Connect (Breadboard Power Rail) with (UNO Pin '5V').","4.	Connect (Potentiometer) with (Breadboard Power Rail).","5.	Connect (Potentiometer) with (Breadboard Ground Rail).","6. Connect (Potentiometer) with (LCD Data Pin '3').","7. Connect (LCD Pin 'GND') with (Breadboard Ground Rail).","8. Connect (LCD Pin '5V') with (Breadboard Power Rail).","9. Connect (LCD Pin 'Register') with (UNO Digital Pin '13').","10. Connect (LCD Pin 'Read/Write') with (Breadboard Ground Rail).","11. Connect (LCD Pin 'Enable') with (UNO Digital Pin '12').","12. Connect (LCD Data Pin '4') with (UNO Digital Pin '11').","13. Connect (LCD Data Pin '5') with (UNO Digital Pin '10').","14. Connect (LCD Data Pin '6') with (UNO Digital Pin '9').","15. Connect (LCD Data Pin '7') with (UNO Digital Pin '8').","16. Connect (LED Pin '5V') with (Breadboard Power Rail).","17. Connect (LED Pin 'GND') with (Breadboard Ground Rail).","18. Place (Blue Push Button) on Breadboard.","19. Connect (Blue Push Button) with (Breadboard Ground Rail).","20. Connect (Blue Push Button) with (UNO Digital Pin '2').","21. Place (Buzzer) on Breadboard.","22. Connect (Buzzer) with (Breadboard Ground Rail).","23. Connect (Buzzer) with (UNO Digital Pin '6'),\n(REMEMBER THE TEXT WHICH LCD SHOWS AND REPEAT FROM KEYBOARD CORRECTLY THEN YOU WILL HEAR A TUNE)."},

        new List<string>{"LESSON 5 A \n 1. Place (Blue LED) on Breadboard.","2. Place (330 Ohm Resistor) on Breadboard & Connect (Blue LED) with (330 Ohm Resistor).","3. Connect (IR Sensor Pin '5V') with (UNO Pin '5V').","4. Connect (IR Sensor Pin 'GND') with (UNO Pin 'GND').","5. Connect (IR Sensor Pin 'OUT') with (UNO Analog Pin 'A5').","6. Connect (330 Ohm Resistor) with (UNO Digital Pin '13').","7. Connect (Blue LED) with (UNO Pin 'GND'),\n(BLUE LED WILL GLOW WHEN THE BOX IS PLACED IN FRONT OF IR SENSOR)."},

        new List<string>{"LESSON 5 B \n 1. Place (Buzzer) on Breadboard.","2. Connect (IR Sensor Pin '5V') with (UNO Pin '5V').","3. Connect (IR Sensor Pin 'GND') with (UNO Pin 'GND').","4. Connect (IR Sensor Pin 'OUT') with (UNO Analog Pin 'A5').","5. Connect (Buzzer) with (UNO Digital Pin '13').","6. Connect (Buzzer) with (Breadboard Ground Rail),\n(GIVE DISTANCE VALUE BY ROTATING IR SENSOR KNOB THEN TUNE WILL PLAY WHEN THE BOX IS PLACED IN FRONT OF IR SENSOR)."},

        new List<string>{"LESSON 5 C \n 1. Connect (IR Sensor Pin '5V') with (UNO Pin '5V').","2. Connect (IR Sensor Pin 'GND') with (UNO Pin 'GND').","3. Connect (IR Sensor Pin 'OUT') with (UNO Digital Pin '4'),\n(VALUE SHOWN IN MONITOR WILL INCREASE EACH TIME THE BOX IS IN FRONT OF IR SENSOR)."}, 
  
        new List<string>{"LESSON 6 A \n 1. Connect (Breadboard Power Rail) with (UNO Pin '5V').","2. Connect (Breadboard Ground Rail) with (UNO Pin 'GND').","3. Place (Switch) on Breadboard.","4. Connect (Switch) with (Breadboard Ground Rail).","5. Connect (Switch) with (UNO Digital Pin '7').","6. Connect (Motordriver Pin '5V') with (Breadboard Power Rail).","7. Connect (Motordriver Pin 'GND') with (Breadboard Ground Rail).","8. Connect (Motordriver Pin 'MOTAPin1') with (Motor'1').","9. Connect (Motordriver Pin 'MOTAPin2') with (Motor'1').","10. Connect (Motordriver Pin 'ENA') with (UNO Digital Pin '10').","11. Connect (Motordriver Pin 'ENB') with (UNO Digital Pin '11').","12. Connect (Motordriver Pin 'IN1') with (UNO Digital Pin '13').","13. Connect (Motordriver Pin 'IN2') with (UNO Digital Pin '12').","14. Connect (Motordriver Pin 'IN3') with (UNO Digital Pin '8').","15. Connect (Motordriver Pin 'IN4') with (UNO Digital Pin '9'),\n(PRESS SWITCH BUTTON TO MAKE THE WHEEL OF MOTOR ROTATE)."},

        new List<string>{"LESSON 6 B \n 1. Connect (Breadboard Power Rail) with (UNO Pin '5V').","2. Connect (Breadboard Ground Rail) with (UNO Pin 'GND').","3. Place (Switch) on Breadboard.","4. Connect (Switch) with (Breadboard Ground Rail).","5. Connect (Switch) with (UNO Digital Pin '7').","6. Connect (Motordriver Pin '5V') with (Breadboard Power Rail).","7. Connect (Motordriver Pin 'GND') with (Breadboard Ground Rail).","8. Connect (Motordriver Pin 'MOTAPin1') with (Motor'1').","9. Connect (Motordriver Pin 'MOTAPin2') with (Motor'1').","10. Connect (Motordriver Pin 'ENA') with (UNO Digital Pin '10').","11. Connect (Motordriver Pin 'ENB') with (UNO Digital Pin '11').","12. Connect (Motordriver Pin 'IN1') with (UNO Digital Pin '13').","13. Connect (Motordriver Pin 'IN2') with (UNO Digital Pin '12').","14. Connect (Motordriver Pin 'IN3') with (UNO Digital Pin '8').","15. Connect (Motordriver Pin 'IN4') with (UNO Digital Pin '9').","16. Connect (Motordriver Pin 'MOTBPin1') with (Motor'2').","17. Connect (Motordriver Pin 'MOTBPin2') with (Motor'2').","18. Attach (RobotBottom Sheet) with (CasterBall)","19. Attach (Motor'1') with (RobotBottom Sheet).","20. Attach (Motor'2') with (RobotBottom Sheet).","21. Attach (RobotTop Sheet) with (RobotBottom Sheet).","22. Attach (Arduino) with (RobotTop Sheet).","23. Attach (Motordriver) with (RobotTop Sheet).","24. Attach (Breadboard) with (RobotTop Sheet),\n(SEE ASSEMBLED ROBOT BEHIND YOU AND CONTROL ITS MOVEMENT WITH ARROW KEYS)."},
 
        new List<string>{"LESSON 6 C \n 1. Connect (Breadboard Power Rail) with (UNO Pin '5V').","2. Connect (Breadboard Ground Rail) with (UNO Pin 'GND').","3. Place (Switch) on Breadboard.","4. Connect (Switch) with (Breadboard Ground Rail).","5. Connect (Switch) with (UNO Digital Pin '7').","6. Connect (Motordriver Pin '5V') with (Breadboard Power Rail).","7. Connect (Motordriver Pin 'GND') with (Breadboard Ground Rail).","8. Connect (Motordriver Pin 'MOTAPin1') with (Motor'1').","9. Connect (Motordriver Pin 'MOTAPin2') with (Motor'1').","10. Connect (Motordriver Pin 'ENA') with (UNO Digital Pin '10').","11. Connect (Motordriver Pin 'ENB') with (UNO Digital Pin '11').","12. Connect (Motordriver Pin 'IN1') with (UNO Digital Pin '13').","13. Connect (Motordriver Pin 'IN2') with (UNO Digital Pin '12').","14. Connect (Motordriver Pin 'IN3') with (UNO Digital Pin '8').","15. Connect (Motordriver Pin 'IN4') with (UNO Digital Pin '9').","16. Connect (Motordriver Pin 'MOTBPin1') with (Motor'2').","17. Connect (Motordriver Pin 'MOTBPin2') with (Motor'2').","18. Connect (Ultrasonic Sensor Pin 'POW') with (Breadboard Power Rail).","19. Connect (Ultrasonic Sensor Pin 'GND') with (Breadboard Ground Rail).","20. Connect (Ultrasonic Sensor Pin 'TRIG') with (UNO Digital Pin '6').","21. Connect (Ultrasonic Sensor Pin 'ECHO') with (UNO Digital Pin '5').","22. Attach (RobotBottom Sheet) with (CasterBall)","23. Attach (Motor'1') with (RobotBottom Sheet).","24. Attach (Motor'2') with (RobotBottom Sheet).","25. Attach (RobotTop Sheet) with (RobotBottom Sheet).","26. Attach (Arduino) with (RobotTop Sheet).","27. Attach (Ultrasonic Sensor) with (RobotTop Sheet).","28. Attach (Motordriver) with (RobotTop Sheet).","29. Attach (Breadboard) with (RobotTop Sheet),\n(SEE ASSEMBLED ROBOT BEHIND YOU CHANGE DIRECTION AS IT DETECTS OBJECT IN ITS PATH)."},

        new List<string>{"Lesson 7 A \n 1. Connect (Breadboard Power Rail) with (UNO Pin '5V').","2. Connect (Breadboard Ground Rail) with (UNO Pin 'GND').","3. Connect (IR Sensor'1' Pin '5V') with (Breadboard Power Rail).","4. Connect (IR Sensor'2' Pin '5V') with (Breadboard Power Rail).","5. Connect (IR Sensor'3' Pin '5V') with (Breadboard Power Rail).","6. Connect (IR Sensor'1' Pin 'GND') with (Breadboard Ground Rail).","7. Connect (IR Sensor'2' Pin 'GND') with (Breadboard Ground Rail).","8. Connect (IR Sensor'3' Pin 'GND') with (Breadboard Ground Rail).","9. Connect (IR Sensor'1' Pin 'OUT') with (UNO Analog Pin 'A0').","10. Connect (IR Sensor'2' Pin 'OUT') with (UNO Analog Pin 'A1').","11. Connect (IR Sensor'3' Pin 'OUT') with (UNO Analog Pin 'A2').","12. Connect (Motordriver Pin '5V') with (Breadboard Power Rail).","13. Connect (Motordriver Pin 'IN1') with (UNO Digital Pin '13').","14. Connect (Motordriver Pin 'IN2') with (UNO Digital Pin '12').","15. Connect (Motordriver Pin 'IN3') with (UNO Digital Pin '11').","16. Connect (Motordriver Pin 'IN4') with (UNO Digital Pin '10').","17. Connect (Motordriver Pin 'MOTAPin1') with (Motor'1').","18. Connect (Motordriver Pin 'MOTAPin2') with (Motor'1').","19. Connect (Motordriver Pin 'MOTBPin1') with (Motor'2').","20. Connect (Motordriver Pin 'MOTBPin2') with (Motor'2').","21. Attach (RobotBottom Sheet) with (CasterBall)","22. Attach (Motor'1') with (RobotBottom Sheet).","23. Attach (Motor'2') with (RobotBottom Sheet).","24. Attach (RobotTop Sheet) with (RobotBottom Sheet).","25. Attach (Arduino) with (RobotTop Sheet).","26. Attach (Motordriver) with (RobotTop Sheet).","27. Attach (IR Sensor'1') with (RobotTop Sheet)","28. Attach (IR Sensor'2') with (RobotTop Sheet)","29. Attach (IR Sensor'3') with (RobotTop Sheet)","30. Attach (Breadboard) with (RobotTop Sheet),\n(SEE ASSEMBLED ROBOT BEHIND YOU FOLLOWING ITS PATH BY DETECTING THE LINE)."},

        new List<string>{"Lesson 7 B \n 1. Connect (Breadboard Power Rail) with (UNO Pin '5V').","2. Connect (Breadboard Ground Rail) with (UNO Pin 'GND').","3. Connect (Servomotor Pin '5V') with (Breadboard Power Rail).","4. Connect (Ultrasonic Sensor Pin 'POW') with (Breadboard Power Rail).","5. Connect (Servomotor Pin 'GND') with (Breadboard Ground Rail).","6. Connect (Ultrasonic Sensor Pin 'GND') with (Breadboard Ground Rail).","7. Connect (Servomotor Pin 'CONTROL') with (UNO Digital Pin '10').","8. Connect (Ultrasonic Sensor Pin 'TRIG') with (UNO Digital Pin '1').","9. Connect (Ultrasonic Sensor Pin 'ECHO') with (UNO Digital Pin '2').","10. Connect (Motordriver Pin 'IN1') with (UNO Digital Pin '7').","11. Connect (Motordriver Pin 'IN2') with (UNO Digital Pin '6').","12.  Connect (Motordriver Pin 'IN3') with (UNO Digital Pin '5').","13. Connect (Motordriver Pin 'IN4') with (UNO Digital Pin '4').","14. Connect (Motordriver Pin 'MOTAPin1') with (Motor'1').","18. Connect (Motordriver Pin 'MOTAPin2') with (Motor'1').","19. Connect (Motordriver Pin 'MOTBPin1') with (Motor'2').","20. Connect (Motordriver Pin 'MOTBPin2') with (Motor'2').","21. Attach (RobotBottom Sheet) with (CasterBall)","22. Attach (Motor'1') with (RobotBottom Sheet).","23. Attach (Motor'2') with (RobotBottom Sheet).","24. Attach (RobotTop Sheet) with (RobotBottom Sheet).","25. Attach (Arduino) with (RobotTop Sheet).","23. Attach (Ultrasonic Sensor) with (RobotTop Sheet).","24. Attach (Servomotor) with (RobotTop Sheet).","25.Attach (Motordriver) with (RobotTop Sheet).","26. Attach (Breadboard) with (RobotTop Sheet),\n(SEE ASSEMBLED ROBOT BEHIND YOU AND CONTROL ITS MOVEMENT WITH ARROW KEYS TO DETECT OBJECTS)."},

        new List<string>{"Lesson 7 C \n 1. Connect (Breadboard Power Rail) with (UNO Pin '5V').","2. Connect (Breadboard Ground Rail) with (UNO Pin 'GND').","3. Place (Red LED) on Breadboard.","4. Connect (Red LED) with (UNO Digital Pin '9').","5. Connect (Red LED) with (UNO Pin '3.3V').","6. Connect (Bluetooth Module Pin '5V') with with (UNO Pin '5V').","7. Connect (Bluetooth Module Pin 'GND') with with (UNO Pin 'GND').","8. Connect (Motordriver Pin '5V') with (Breadboard Power Rail).","9. Connect (Motordriver Pin 'GND') with (Breadboard Ground Rail).","10. Connect (Motordriver Pin 'MOTAPin1') with (Motor'1').","11. Connect (Motordriver Pin 'MOTAPin2') with (Motor'1').","12. Connect (Motordriver Pin 'MOTBPin1') with (Motor'2').","13. Connect (Motordriver Pin 'MOTBPin2') with (Motor'2').","14. Connect (Motordriver Pin 'ENA') with (UNO Digital Pin '10').","15. Connect (Motordriver Pin 'ENB') with (UNO Digital Pin '11').","16. Connect (Motordriver Pin 'IN1') with (UNO Digital Pin '13').","17. Connect (Motordriver Pin 'IN2') with (UNO Digital Pin '12').","18. Connect (Bluetooth Module Pin 'TXD') with with (UNO Digital Pin '0').","19. Connect (Bluetooth Module Pin 'RXD') with with (UNO Digital Pin '1').","20. Attach (Bluetooth Module) with (RobotTop Sheet).","21. Attach (RobotBottom Sheet) with (CasterBall)","22. Attach (Motor'1') with (RobotBottom Sheet).","23. Attach (Motor'2') with (RobotBottom Sheet).","24. Attach (RobotTop Sheet) with (RobotBottom Sheet).","25. Attach (Arduino) with (RobotTop Sheet).","26. Attach (Motordriver) with (RobotTop Sheet).","27. Attach (Breadboard) with (RobotTop Sheet),\n(SEE ASSEMBLED ROBOT BEHIND YOU AND CONTROL ITS MOVEMENT WITH ARROW KEYS TO DETECT OBJECTS)."}
  };

    private float mZCoord , CurrentTime = 0.0f , Delay_ = 2.0f;
    private Vector3 mOffset,ObjectPosition;
    private static Vector3 TwoPinLEdScale = new Vector3(11f,6f,9f),ArduinoScale = new Vector3(9f,6f,8f),IRsensorScale1  = new Vector3(5f,5f,5f) ,IRsensorScale2 = new Vector3(5f,5f,5f),IRsensorScale3 = new Vector3(5f,5f,5f), BreadBoardScale,BreadBoardpinScale , MotorDriveScale,SwitchScale,ServoMotorScale = new Vector3(6f,6f,7f),Bluetooth_Module = new Vector3(5f,5f,5f);

    [HideInInspector]
    public static int labinstructionNumber = 0,labinstructionNumberIndex = 0,labinstructionNumberlimit,mostInternalIndex = 0;
    private static int loop = 0 ;
    public static int fixervalue ,garbagevalue_1 = 0;
    //static float Current_time;
    private static GameObject lastmovedobject;
    private static  bool CheckArduino = false ,Musicplay = false;
    private bool handingObject = false , breadboadbase  ,wire_assistance_recomanded = false;
    [HideInInspector]
    public static bool labselectionfixer = false,Fixer = false;
    public static string CurentCaringObjectname = "",CurentCaringObjecttag = "";

    private LED_Control_Script LCS;
    private ResetobjectsScrpt_ ROS;
    private TextScript ts;
    private ObjectDetector OD;
    private animation ascript;
    private VoiceControl VCScript;

    private CircuitSettings circuitSetting;
    Scene scene;
    int garbagevalue = 0;



    void Start(){
        circuitSetting = GameObject.FindObjectOfType(typeof(CircuitSettings)) as CircuitSettings;
        LCS = GameObject.FindObjectOfType(typeof(LED_Control_Script)) as LED_Control_Script;
        ts = GameObject.FindObjectOfType(typeof(TextScript)) as TextScript;
        ROS = GameObject.FindObjectOfType(typeof(ResetobjectsScrpt_)) as ResetobjectsScrpt_;
        ascript = GameObject.FindObjectOfType(typeof(animation)) as animation;
        VCScript = GameObject.FindObjectOfType(typeof(VoiceControl)) as VoiceControl;

        if(Pausemenu.NextLabClick){
            labinstructionNumber = Pausemenu.NextLabvalue;
            Pausemenu.NextLabClick = false;
            Pausemenu.NextLabvalue = 0;
            //Debug.Log("11111 Start "+labinstructionNumber );
            updateInstruction();
        }else{
            scene = SceneManager.GetActiveScene();
            labinstructionNumber = numberofrulesperlab[scene.name];
            labinstructionNumberlimit = CircuitRuleIndex[numberofrulesperlab[scene.name]];
            garbagevalue = numberofrulesperlab[scene.name];
            if(labselectionfixer){
                fixervalue = labinstructionNumber;
                Fixer = false;
            }
        }
        
        try{
            ts.SetScreenText(LabObjects[labinstructionNumber][labinstructionNumberIndex]);
        }catch(System.Exception e){}
        
        try{
            if(LabObjects[labinstructionNumber][labinstructionNumberIndex].Contains("wire") || LabObjects[labinstructionNumber][labinstructionNumberIndex].Contains("Connect")){
                wire_assistance_recomanded = true;
            }
        }catch(System.Exception e){}
        try{
            if(GameObject.Find("Light (1)").GetComponent<Light>().enabled == false){
                GameObject.Find("Light (1)").GetComponent<Light>().enabled = true;
                GameObject.Find("Light (2)").GetComponent<Light>().enabled = true;
                GameObject.Find("Light (3)").GetComponent<Light>().enabled = true;
            }
        }catch(System.Exception e){}
    }
    void Update(){
        if(garbagevalue_1 <=130){
            garbagevalue_1 = garbagevalue_1+1;
        }
        if(garbagevalue_1 == 130){
            ascript.makemove();
            VCScript.SpeakRule();
        }
            // Debug.Log("0000 = 1 = "+labinstructionNumber);
            // Debug.Log("0000 = 2 = "+labinstructionNumberIndex);
            // Debug.Log("0000 = 3 = "+mostInternalIndex);
            // Debug.Log("0000 ///////////////");
        if(Pausemenu.NextLabClick){
            labinstructionNumber = Pausemenu.NextLabvalue;
            Pausemenu.NextLabClick = false;
            Pausemenu.NextLabvalue = 0;
            updateInstruction();
        }
        if(fixervalue != labinstructionNumber){
            labinstructionNumber = fixervalue ;
            updateInstruction();
        }
        if(labselectionfixer){
            if(garbagevalue < labinstructionNumberlimit){
                
                labinstructionNumber = labinstructionNumber+1;
                updateInstruction();
                labinstructionNumber = labinstructionNumber-1;
                
                updateInstruction();
                labselectionfixer = false;
            }
        }
        
    }

    public void updateInstruction(){
        try{
            if(labinstructionNumber <= labinstructionNumberlimit){
                if(LabObjects[labinstructionNumber][labinstructionNumberIndex].Contains("wire") || LabObjects[labinstructionNumber][labinstructionNumberIndex].Contains("Connect")){
                    wire_assistance_recomanded = true;
                }
                if(LabObjects[labinstructionNumber][labinstructionNumberIndex].Contains("Place")){
                    CircuitSettings.placeKeywordignore = true;
                }else{
                    CircuitSettings.placeKeywordignore = false;
                }
                try{
                    if(garbagevalue_1 >= 130){
                        ascript.makemove();
                        VCScript.SpeakRule();
                    }
                    ts.SetScreenText(LabObjects[labinstructionNumber][labinstructionNumberIndex]);
                    fixervalue = labinstructionNumber;
                }catch(System.Exception e){}
            }else{
                try{
                    ts.SetScreenText("All Labs Has Been Performed.");
                }catch(System.Exception e){}
            }
        }catch(System.Exception e){}
    }

    void OnMouseDown(){
        try{
            ROS.AddObjects_(gameObject,new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,gameObject.transform.position.z),
            new Vector3(gameObject.transform.rotation.eulerAngles.x,gameObject.transform.rotation.eulerAngles.y,gameObject.transform.rotation.eulerAngles.z));
        }catch(System.Exception e){}

        if(unopins.Contains(gameObject.name)){
            CheckArduino = true;
        }

        if(gameObject.name.Contains("ResetButton")){
            try{ROS.ResetObject_(lastmovedobject);}catch(System.Exception e){}
            try{
                AudioManager AM =  GameObject.FindObjectOfType(typeof(AudioManager)) as AudioManager;
                AM.StopMusic();
            }catch(System.Exception e){}
            AudioListener.volume = 1f;

        }

        if(gameObject.name.Contains("ADReset")){
            if((labinstructionNumber == 4) && Musicplay){
                FindObjectOfType<AudioManager>().StopMusic();
                FindObjectOfType<AudioManager>().Play("Buzzerlab1");
            }
        }
        if(gameObject.name.Contains("NextLab")){
            garbagevalue_1 = 0;
            labinstructionNumberIndex = 0;
            mostInternalIndex = 0;
            Pausemenu.NextLabClick = true;
            Pausemenu.NextLabvalue = labinstructionNumber+1;
            labinstructionNumber = labinstructionNumber+1;
            CircuitSettings.previousObj="";
            CircuitSettings.FirstEndOfWire="None";
            fixervalue = labinstructionNumber;
            try{
                SceneManager.LoadScene(scene.name, LoadSceneMode.Single);
            }catch(System.Exception e){Debug.Log("Scene Log issue = "+e);}
        
            Musicplay = false;
            AudioListener.volume = 1f;
            ts.changeobjectplacedSuccessfullyState(false);
            ts.SetobjectplacedSuccessfullyText("");
            try{
                if(LabObjects[labinstructionNumber][labinstructionNumberIndex].Contains("wire") || LabObjects[labinstructionNumber][labinstructionNumberIndex].Contains("Connect")){
                    wire_assistance_recomanded = true;
                }
            }catch(System.Exception e){}
            try{
                ts.changeLCDTextState(false);
                ts.SetLCDScreenText("");
            }catch(System.Exception e){}
            try{
                ts.changeIR_DistanceTextState(false);
            }catch(System.Exception e){}
            try{
                ts.changemoniterTXTTextState(false);
            }catch(System.Exception e){}
            try{
                GameObject.Find("potentiometerRotater").transform.rotation = Quaternion.Euler(0,-90,90);
            }catch(System.Exception e){}
            try{
                LCS.DisableLED("LED 5mm ON");
                LCS.DisableLED("Led RGB light 5mm1D ON");
                TriggerMusic(false);
                LED_Control_Script.CheckPattern = false;
            }catch(System.Exception e){}
            try{
                if(GameObject.Find("Light (1)").GetComponent<Light>().enabled == false){
                    GameObject.Find("Light (1)").GetComponent<Light>().enabled = true;
                    GameObject.Find("Light (2)").GetComponent<Light>().enabled = true;
                    GameObject.Find("Light (3)").GetComponent<Light>().enabled = true;
                }
            }catch(System.Exception e){}
            try{
                PotentiometerScript_.Increment = 0.0f;
                PotentiometerScript_.satisfy = false;
            }catch(System.Exception e){}
            try{
                AudioManager AM =  GameObject.FindObjectOfType(typeof(AudioManager)) as AudioManager;
                AM.StopMusic();
            }catch(System.Exception e){}
            try{
                if(!GameObject.Find("SwitchButton0").GetComponent<MeshRenderer>().enabled){
                    GameObject.Find("SwitchButton1").GetComponent<MeshRenderer>().enabled = false;
                    GameObject.Find("SwitchButton0").GetComponent<MeshRenderer>().enabled = true;
                }
            }catch(System.Exception e){}
            try{
                if((labinstructionNumber == 18 || labinstructionNumber == 20 || labinstructionNumber == 21) && GameObject.Find("000").GetComponent<Rigidbody>() && ObjectDetector.DisbaleRobotCatch){
                    ResetGameObjectSize();
                }
                ObjectDetector.DisbaleRobotCatch = false;
            }catch(System.Exception e){}

            try{ROS.ResetAll();}catch(System.Exception e){}
            try{
                if((labinstructionNumber == 17) && (labinstructionNumberIndex == 0)){
                    if(GameObject.Find("switch part 5 (1)").GetComponent<MeshRenderer>().enabled){
                        GameObject.Find("switch part 5 (1)").GetComponent<MeshRenderer>().enabled = false;
                        GameObject.Find("switch part 5").GetComponent<MeshRenderer>().enabled = true;
                    }                }
            }catch(System.Exception e){}        
            updateInstruction();
        }
        if(LED_Control_Script.CheckPattern && (labinstructionNumber == 6)){
            LCS.ValidateLedPattern(gameObject.name);
        }
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        // Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
        try{
            if(gameObject.tag.Contains("LR_twopin") && (gameObject.transform.rotation.eulerAngles.x != 270)){
                gameObject.transform.rotation = Quaternion.Euler(270,0,0);
               }
            if(gameObject.tag.Contains("LED  Blue") && (gameObject.transform.rotation.eulerAngles.x != 270)){
                gameObject.transform.rotation = Quaternion.Euler(270,0,0);
               }
            if(gameObject.tag.Contains("LED  Yellow") && (gameObject.transform.rotation.eulerAngles.x != 270)){
                gameObject.transform.rotation = Quaternion.Euler(270,0,0);
               }
            if(gameObject.tag.Contains("LED  Green") && (gameObject.transform.rotation.eulerAngles.x != 270)){
                gameObject.transform.rotation = Quaternion.Euler(270,0,0);
               }                                             
            if(gameObject.tag.Contains("photoresister1D") && (gameObject.transform.rotation.eulerAngles.z != 180)){
                gameObject.transform.rotation = Quaternion.Euler(0,90,180);
            }
            if(gameObject.tag.Contains("LR_threepin") && (gameObject.transform.rotation.eulerAngles.x != 0)){
                gameObject.transform.rotation = Quaternion.Euler(0,0,0);
            }
            try{
                if(gameObject.tag.Contains("servo motor") && (gameObject.transform.rotation.eulerAngles.x != 0)){
                    gameObject.transform.rotation = Quaternion.Euler(0,0,0);
                }
            }catch(System.Exception e){}
            try{
                if(gameObject.tag.Contains("ServoMoter") && (gameObject.transform.rotation.eulerAngles.x != 0)){
                    gameObject.transform.rotation = Quaternion.Euler(0,180,0);
                }
            }catch(System.Exception e){}
            if(gameObject.tag.Contains("ultrasonic sensor") && (gameObject.transform.rotation.eulerAngles.x != 90)){
                gameObject.transform.rotation = Quaternion.Euler(90,180,0);
            }
            if(gameObject.tag.Contains("TemperatureSensor") && (gameObject.transform.rotation.eulerAngles.x != 0)){
                gameObject.transform.rotation = Quaternion.Euler(0,0,0);
            }
            if(gameObject.name.Contains("Bluetooth Module") && (gameObject.transform.rotation.eulerAngles.x != 180)){
                gameObject.transform.rotation = Quaternion.Euler(180,90,-90);
            }
        }catch(System.Exception e){}
        try{
            if(((labinstructionNumber == 16) && (labinstructionNumberIndex == 15)) || ((labinstructionNumber == 17) && (labinstructionNumberIndex == 24))){
                if(GameObject.Find("switch part 5").GetComponent<MeshRenderer>().enabled){
                    GameObject.Find("switch part 5").GetComponent<MeshRenderer>().enabled = false;
                    GameObject.Find("switch part 5 (1)").GetComponent<MeshRenderer>().enabled = true;
                    labinstructionNumberIndex = labinstructionNumberIndex+1;
                }else{
                    if(!GameObject.Find("switch part 5 (1)").GetComponent<MeshRenderer>().enabled){
                        GameObject.Find("switch part 5 (1)").GetComponent<MeshRenderer>().enabled = false;
                        GameObject.Find("switch part 5").GetComponent<MeshRenderer>().enabled = true;
                    }
                }
            }
        }catch(System.Exception e){}
        
    }

    private void ResetGameObjectSize(){

        try{
            Destroy(GameObject.Find("robot top").GetComponent<CircuitSettings>());
            GameObject.Find("robot base").AddComponent<CircuitSettings>();
        }catch(System.Exception e){}
        try{
            try{
                OD = GameObject.FindObjectOfType(typeof(ObjectDetector)) as ObjectDetector;
                OD.DisableAllConstraints();
                GameObject.Find("Breadboard").transform.parent = null;
                GameObject.Find("Breadboardpins").transform.parent = null;
                GameObject.Find("Breadboard").transform.localScale = BreadBoardScale;
                GameObject.Find("Breadboardpins").transform.localScale = BreadBoardpinScale;
                Destroy(GameObject.Find("Breadboard").GetComponent<DragandDrop>());
                Destroy(GameObject.Find("Breadboard").GetComponent<Rigidbody>());
                Destroy(GameObject.Find("000").GetComponent<Rigidbody>());
            }catch(System.Exception e){}
            try{
                //Debug.Log("1");
                GameObject.Find("Breadboard").GetComponent<BoxCollider>().enabled = false;
                GameObject.Find("arduino uno").transform.localScale = ArduinoScale;
                GameObject.Find("MotorDriver").transform.localScale = MotorDriveScale;
            }catch(System.Exception e){}
            try{
                //Debug.Log("2");
                GameObject.Find("MotorDriver").GetComponent<MeshCollider>().enabled = false;
                GameObject.Find("Breadboard").GetComponent<BoxCollider>().enabled = false;
                GameObject.Find("000").GetComponent<BoxCollider>().enabled = false;
            }catch(System.Exception e){}

        }catch(System.Exception e){}

        try{
            GameObject.Find("Switch").transform.parent = null;
            GameObject.Find("Switch").transform.localScale = SwitchScale;
        }catch(System.Exception e){}
        
        
        try{
            GameObject.Find("IRsensor1").transform.localScale = IRsensorScale1;
            GameObject.Find("IRsenor_1_pins").transform.parent = null;
        }catch(System.Exception e){}
        try{
            GameObject.Find("OutIR1").GetComponent<ParentConstraint>().constraintActive = false;
            GameObject.Find("GndIR1").GetComponent<ParentConstraint>().constraintActive = false;
            GameObject.Find("VccIR1").GetComponent<ParentConstraint>().constraintActive = false;
            Destroy(GameObject.Find("IRsensor1").GetComponent<Rigidbody>());
            GameObject.Find("IRsensor1").GetComponent<BoxCollider>().enabled = false;
            Destroy(GameObject.Find("IRsensor1").GetComponent<DragandDrop>());
        }catch(System.Exception e){}
        try{
            GameObject.Find("IRsensor2").transform.localScale = IRsensorScale1;
            GameObject.Find("IRsenor_2_pins").transform.parent = null;
        }catch(System.Exception e){}
        try{
            GameObject.Find("OutIR2").GetComponent<ParentConstraint>().constraintActive = false;
            GameObject.Find("GndIR2").GetComponent<ParentConstraint>().constraintActive = false;
            GameObject.Find("VccIR2").GetComponent<ParentConstraint>().constraintActive = false;
            Destroy(GameObject.Find("IRsensor2").GetComponent<Rigidbody>());
            GameObject.Find("IRsensor2").GetComponent<BoxCollider>().enabled = false;
            Destroy(GameObject.Find("IRsensor2").GetComponent<DragandDrop>());
        }catch(System.Exception e){}
        try{
            GameObject.Find("IRsensor3").transform.localScale = IRsensorScale1;
            GameObject.Find("IRsenor_3_pins").transform.parent = null;
        }catch(System.Exception e){}
        try{
            GameObject.Find("OutIR3").GetComponent<ParentConstraint>().constraintActive = false;
            GameObject.Find("GndIR3").GetComponent<ParentConstraint>().constraintActive = false;
            GameObject.Find("VccIR3").GetComponent<ParentConstraint>().constraintActive = false;
            Destroy(GameObject.Find("IRsensor3").GetComponent<Rigidbody>());
            GameObject.Find("IRsensor3").GetComponent<BoxCollider>().enabled = false;
            Destroy(GameObject.Find("IRsensor2").GetComponent<DragandDrop>());
        }catch(System.Exception e){}
        try{
            Destroy(GameObject.Find("Servo Motor").GetComponent<DragandDrop>());
            Destroy(GameObject.Find("Servo Motor").GetComponent<ObjectDetector>());
            Destroy(GameObject.Find("Servo Motor").GetComponent<Rigidbody>());
            GameObject.Find("Servo Motor").GetComponent<BoxCollider>().enabled = false;
            GameObject.Find("Servo Motor").transform.localScale = ServoMotorScale;
            GameObject.Find("CONTROL").GetComponent<PositionConstraint>().constraintActive =  true;
            GameObject.Find("5V motor").GetComponent<PositionConstraint>().constraintActive = true;
            GameObject.Find("GND PIN").GetComponent<PositionConstraint>().constraintActive =  true;
        }catch(System.Exception e){}
        
        try{
            if(GameObject.Find("LED 5mm ON").transform.localScale.x<TwoPinLEdScale.x){
                GameObject.Find("LED 5mm ON").transform.localScale = TwoPinLEdScale;
                GameObject.Find("LED 5mm ON").transform.parent = null;
            }
            
        }catch(System.Exception e){}
    }

    private Vector3 GetMouseAsWorldPoint(){
        // Pixel coordinates of mouse (x,y)

        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen

        mousePoint.z = mZCoord;

        // Convert it to world points
        
        return Camera.main.ScreenToWorldPoint(mousePoint);

    }
    void OnCollisionExit(Collision other){
        try{
            if(pinLocation.Contains(other.transform.name) || unopins.Contains(other.transform.name)){
				 GameObject.Find(other.transform.name).GetComponent<MeshRenderer>().material.color =new Color32(173,173,173,200);
            }
        }catch(System.Exception e){}

    }
    
    void OnCollisionEnter(Collision Col_Obj){
        try{
        if(pinLocation.Contains(Col_Obj.collider.name)){
            handingObject = true;
        }
        if(Col_Obj.collider.tag.Contains("Comp")){
            breadboadbase = true;
        }
        }catch(System.Exception e){}

    }

    public bool ArduinoPinExist(string pinname){
        if(unopins.Contains(pinname)){
            return true;
        }else{
            return false;
        }
    }
    public bool BreadBoardPinExist(string pinname){
        if(pinLocation.Contains(pinname)){
            return true;
        }else{
            return false;
        }
    }
    public bool CollectableObjectExist(string Objtag){
        if(CollectableObjects.Contains(Objtag)){
            return true;
        }else{
            return false;
        }
    }

    public void TriggerMusic(bool state){
        Musicplay = state;
    }

    public bool getMusicState(){
        return Musicplay;
    }


    void OnMouseDrag(){

        if(!gameObject.tag.Contains("ADReset") || (gameObject.tag.Contains("000") && !ObjectDetector.DisbaleRobotCatch)){
            if(CollectableObjects.Contains(gameObject.tag) || (!gameObject.name.Contains("Null"))){
                lastmovedobject = gameObject;
            }
            if((!gameObject.name.Contains("GND PIN")) || (!gameObject.name.Contains("5V motor")) || (!gameObject.name.Contains("CONTROL")) || (Lcdpins.Contains(gameObject.tag))){
                ObjectPosition = GetMouseAsWorldPoint() + mOffset;
                if(!handingObject){
                    transform.position = ObjectPosition;
                    handingObject = false;
                }
                CurentCaringObjectname = gameObject.name;
                CurentCaringObjecttag = gameObject.tag;
                try{
                if(gameObject.transform.position.y <= 1.039731f){
                    Physics.IgnoreCollision(this.GetComponent<Collider>(),GetComponent<Collider>());
                }
                }catch(System.Exception e){}finally{
                    Physics.IgnoreCollision(this.GetComponent<Collider>(),GetComponent<Collider>());
                    transform.position = ObjectPosition;
                    if(gameObject.transform.position.y<1.02358f){
                        gameObject.transform.position = new Vector3(ObjectPosition.x,1.02358f,ObjectPosition.z);
                    }

                }
            }

        }


    }

    public string getWords_lab4c(){
         var number = Random.Range(0,(Lab4C_words.Count-1));
         return Lab4C_words[number].Trim();
    }

    public void ResizeBreadBOard(){
        try{
            ROS.AddObjects_(GameObject.Find("Breadboard"),new Vector3(GameObject.Find("Breadboard").transform.position.x,GameObject.Find("Breadboard").transform.position.y,GameObject.Find("Breadboard").transform.position.z),
            new Vector3(GameObject.Find("Breadboard").transform.rotation.eulerAngles.x,GameObject.Find("Breadboard").transform.rotation.eulerAngles.y,GameObject.Find("Breadboard").transform.rotation.eulerAngles.z));
        }catch(System.Exception e){}
        try{
            ROS.AddObjects_(GameObject.Find("Breadboardpins"),new Vector3(GameObject.Find("Breadboardpins").transform.position.x,GameObject.Find("Breadboardpins").transform.position.y,GameObject.Find("Breadboardpins").transform.position.z),
            new Vector3(GameObject.Find("Breadboardpins").transform.rotation.eulerAngles.x,GameObject.Find("Breadboardpins").transform.rotation.eulerAngles.y,GameObject.Find("Breadboardpins").transform.rotation.eulerAngles.z));
        }catch(System.Exception e){}


        BreadBoardScale = GameObject.Find("Breadboard").transform.localScale;
        BreadBoardpinScale = GameObject.Find("Breadboardpins").transform.localScale;
        GameObject.Find("Breadboard").AddComponent<Rigidbody>();
        GameObject.Find("Breadboard").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        GameObject.Find("Breadboard").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        GameObject.Find("Breadboard").AddComponent<DragandDrop>();
        GameObject.Find("Breadboard").GetComponent<BoxCollider>().enabled = true;

        ResizeArduino();
        ResizeMotorDriver();
        if((labinstructionNumber != 19) || (labinstructionNumber == 20)){
            ResizeUltraSonicSensor();
        }
        if(labinstructionNumber == 19){
            ResizeIRsensor();
        }
        if(labinstructionNumber == 20){
            ResizeServoMotor();
        }

    }
    void ResizeIRsensor(){
        if(labinstructionNumber == 19){
            try{
                ROS.AddObjects_(GameObject.Find("IRsensor1"),new Vector3(GameObject.Find("IRsensor1").transform.position.x,GameObject.Find("IRsensor1").transform.position.y,GameObject.Find("IRsensor1").transform.position.z),
                new Vector3(GameObject.Find("IRsensor1").transform.rotation.eulerAngles.x,GameObject.Find("IRsensor1").transform.rotation.eulerAngles.y,GameObject.Find("IRsensor1").transform.rotation.eulerAngles.z));
            }catch(System.Exception e){}
            try{
                IRsensorScale1 = GameObject.Find("IRsensor1").transform.localScale;
                GameObject.Find("IRsensor1").transform.localScale = new Vector3(1f,1f,1f);
                GameObject.Find("IRsenor_1_pins").transform.SetParent(GameObject.Find("IRsensor1").transform,false);
            }catch(System.Exception e){}
            try{
                GameObject.Find("OutIR1").GetComponent<ParentConstraint>().constraintActive = true;
                GameObject.Find("GndIR1").GetComponent<ParentConstraint>().constraintActive = true;
                GameObject.Find("VccIR1").GetComponent<ParentConstraint>().constraintActive = true;
                GameObject.Find("IRsensor1").AddComponent<Rigidbody>();
                GameObject.Find("IRsensor1").GetComponent<Rigidbody>().constraints =RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
                GameObject.Find("IRsensor1").GetComponent<BoxCollider>().enabled = true;
                GameObject.Find("IRsensor1").AddComponent<DragandDrop>();
            }catch(System.Exception e){}
            try{
                ROS.AddObjects_(GameObject.Find("IRsensor2"),new Vector3(GameObject.Find("IRsensor2").transform.position.x,GameObject.Find("IRsensor2").transform.position.y,GameObject.Find("IRsensor2").transform.position.z),
                new Vector3(GameObject.Find("IRsensor2").transform.rotation.eulerAngles.x,GameObject.Find("IRsensor2").transform.rotation.eulerAngles.y,GameObject.Find("IRsensor2").transform.rotation.eulerAngles.z));
            }catch(System.Exception e){}
            try{
                IRsensorScale2 = GameObject.Find("IRsensor2").transform.localScale;
                GameObject.Find("IRsensor2").transform.localScale = new Vector3(1f,1f,1f);
                GameObject.Find("IRsenor_2_pins").transform.SetParent(GameObject.Find("IRsensor2").transform,false);
            }catch(System.Exception e){}
            try{
                GameObject.Find("OutIR2").GetComponent<ParentConstraint>().constraintActive = true;
                GameObject.Find("GndIR2").GetComponent<ParentConstraint>().constraintActive = true;
                GameObject.Find("VccIR2").GetComponent<ParentConstraint>().constraintActive = true;
                GameObject.Find("IRsensor2").AddComponent<Rigidbody>();
                GameObject.Find("IRsensor2").GetComponent<Rigidbody>().constraints =RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
                GameObject.Find("IRsensor2").GetComponent<BoxCollider>().enabled = true;
                GameObject.Find("IRsensor2").AddComponent<DragandDrop>();
            }catch(System.Exception e){}
            try{
                ROS.AddObjects_(GameObject.Find("IRsensor3"),new Vector3(GameObject.Find("IRsensor3").transform.position.x,GameObject.Find("IRsensor3").transform.position.y,GameObject.Find("IRsensor3").transform.position.z),
                new Vector3(GameObject.Find("IRsensor3").transform.rotation.eulerAngles.x,GameObject.Find("IRsensor3").transform.rotation.eulerAngles.y,GameObject.Find("IRsensor3").transform.rotation.eulerAngles.z));
            }catch(System.Exception e){}
            try{
                IRsensorScale3 = GameObject.Find("IRsensor3").transform.localScale;
                GameObject.Find("IRsensor3").transform.localScale = new Vector3(1f,1f,1f);
                GameObject.Find("IRsenor_3_pins").transform.SetParent(GameObject.Find("IRsensor3").transform,false);
            }catch(System.Exception e){}
            try{
                GameObject.Find("OutIR3").GetComponent<ParentConstraint>().constraintActive = true;
                GameObject.Find("GndIR3").GetComponent<ParentConstraint>().constraintActive = true;
                GameObject.Find("VccIR3").GetComponent<ParentConstraint>().constraintActive = true;
                GameObject.Find("IRsensor3").AddComponent<Rigidbody>();
                GameObject.Find("IRsensor3").GetComponent<Rigidbody>().constraints =RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
                GameObject.Find("IRsensor3").GetComponent<BoxCollider>().enabled = true;
                GameObject.Find("IRsensor3").AddComponent<DragandDrop>();
            }catch(System.Exception e){}
        }
    }
     
    void ResizeArduino(){
        try{
            ROS.AddObjects_(GameObject.Find("arduino uno"),new Vector3(GameObject.Find("arduino uno").transform.position.x,GameObject.Find("arduino uno").transform.position.y,GameObject.Find("arduino uno").transform.position.z),
            new Vector3(GameObject.Find("arduino uno").transform.rotation.eulerAngles.x,GameObject.Find("arduino uno").transform.rotation.eulerAngles.y,GameObject.Find("arduino uno").transform.rotation.eulerAngles.z));
        }catch(System.Exception e){}
        try{
            ArduinoScale = GameObject.Find("arduino uno").transform.localScale;
            GameObject.Find("arduino uno").transform.localScale = new Vector3(1f,1f,1f);
            SetParent();
        }catch(System.Exception e){}

    }

    void ResizeMotorDriver(){
        if(labinstructionNumber == 17 || labinstructionNumber == 18 || labinstructionNumber == 19 || labinstructionNumber == 20 || labinstructionNumber == 21){
            try{
                ROS.AddObjects_(GameObject.Find("MotorDriver"),new Vector3(GameObject.Find("MotorDriver").transform.position.x,GameObject.Find("MotorDriver").transform.position.y,GameObject.Find("MotorDriver").transform.position.z),
                new Vector3(GameObject.Find("MotorDriver").transform.rotation.eulerAngles.x,GameObject.Find("MotorDriver").transform.rotation.eulerAngles.y,GameObject.Find("MotorDriver").transform.rotation.eulerAngles.z));
            }catch(System.Exception e){}


            try{
                GameObject.Find("MotorDriver").GetComponent<MeshCollider>().enabled = true;
                MotorDriveScale = GameObject.Find("MotorDriver").transform.localScale;
                GameObject.Find("MotorDriver").transform.localScale = new Vector3(1.5f,2f,1.5f);
            }catch(System.Exception e){}
            if(labinstructionNumber == 17 || labinstructionNumber == 18 || labinstructionNumber == 21){
                Fixer = true;
                fixervalue = labinstructionNumber;
            }
            
        }
    }

    void ResizeUltraSonicSensor(){
        if((labinstructionNumber == 18) || (labinstructionNumber == 20)){
            try{
                ROS.AddObjects_(GameObject.Find("ultrasonic sensor"),new Vector3(GameObject.Find("ultrasonic sensor").transform.position.x,GameObject.Find("ultrasonic sensor").transform.position.y,GameObject.Find("ultrasonic sensor").transform.position.z),
                new Vector3(GameObject.Find("ultrasonic sensor").transform.rotation.eulerAngles.x,GameObject.Find("ultrasonic sensor").transform.rotation.eulerAngles.y,GameObject.Find("ultrasonic sensor").transform.rotation.eulerAngles.z));
            }catch(System.Exception e){}


            try{
                GameObject.Find("ultrasonic sensor").AddComponent<DragandDrop>();
                GameObject.Find("ultrasonic sensor").AddComponent<Rigidbody>();
                GameObject.Find("ultrasonic sensor").GetComponent<Rigidbody>().constraints =RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
                GameObject.Find("ultrasonic sensor").GetComponent<MeshCollider>().enabled = true;
                MotorDriveScale = GameObject.Find("ultrasonic sensor").transform.localScale;
                GameObject.Find("ultrasonic sensor").transform.localScale = new Vector3(2f,3f,2f);
            }catch(System.Exception e){}
            if(labinstructionNumber == 18){
                Fixer = true;
            }
            
        }
    }

    void ResizeServoMotor(){
        try{
                ROS.AddObjects_(GameObject.Find("Servo Motor"),new Vector3(GameObject.Find("Servo Motor").transform.position.x,GameObject.Find("Servo Motor").transform.position.y,GameObject.Find("Servo Motor").transform.position.z),
                new Vector3(GameObject.Find("Servo Motor").transform.rotation.eulerAngles.x,GameObject.Find("Servo Motor").transform.rotation.eulerAngles.y,GameObject.Find("Servo Motor").transform.rotation.eulerAngles.z));
            }catch(System.Exception e){}


            try{
                GameObject.Find("Servo Motor").AddComponent<DragandDrop>();
                GameObject.Find("Servo Motor").AddComponent<ObjectDetector>();
                GameObject.Find("Servo Motor").AddComponent<Rigidbody>();
                GameObject.Find("Servo Motor").GetComponent<Rigidbody>().constraints =RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
                GameObject.Find("Servo Motor").GetComponent<BoxCollider>().enabled = true;
                GameObject.Find("Servo Motor").transform.localScale = new Vector3(1.5f,1.5f,1.5f);
                GameObject.Find("CONTROL").GetComponent<PositionConstraint>().constraintActive = false;
                GameObject.Find("5V motor").GetComponent<PositionConstraint>().constraintActive = false;
                GameObject.Find("GND PIN").GetComponent<PositionConstraint>().constraintActive = false;
            }catch(System.Exception e){}
    }

    public void ResizeBluetoothModule(){
        GameObject.Find("Bluetooth Module").transform.localScale = new Vector3(1f,1f,1f);
    }

    void SetParent(){
        //Set breadboard and arduino parent
        GameObject.Find("Breadboard").transform.SetParent(GameObject.Find("000").transform,false);
        GameObject.Find("Breadboardpins").transform.SetParent(GameObject.Find("000").transform,false);
        try{
            if(labinstructionNumber == 16 || labinstructionNumber == 17 || labinstructionNumber == 18){
                SwitchScale = GameObject.Find("Switch").transform.localScale;
                GameObject.Find("Switch").transform.SetParent(GameObject.Find("000").transform,false);
            }
        }catch(System.Exception e){}

        GameObject.Find("Breadboardpins").GetComponent<ParentConstraint>().constraintActive = true;
        try{
            if(labinstructionNumber == 16 || labinstructionNumber == 17 || labinstructionNumber == 18){
                GameObject.Find("Switch").GetComponent<ParentConstraint>().constraintActive = true;
            }
        }catch(System.Exception e){}
        if(labinstructionNumber == 21){
            GameObject.Find("LED 5mm ON").transform.SetParent(GameObject.Find("000").transform,false);
        }
        Resizeparent();
    }

    
    void Resizeparent(){
        GameObject.Find("000").AddComponent<Rigidbody>();
        GameObject.Find("000").GetComponent<Rigidbody>().constraints =RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        GameObject.Find("000").transform.localScale = new Vector3(0.08f,0.08f,0.1f);
        GameObject.Find("000").GetComponent<BoxCollider>().enabled = true;

    }

    public bool WireAssistance(){
        return wire_assistance_recomanded;
    }
    public void changeWireAssistanceState(bool state){
        wire_assistance_recomanded = state;
    }

}