using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LCDScript_ : MonoBehaviour
{
    private Renderer render;
    
    private KeyboardInputScript KIS_;
    private TextScript ts;
    private DragandDrop DAD;
    



    [HideInInspector]
    public static bool EnabledDisplay = false , blocked = false, stopTimer = false , disabled = false;

    private static string testingword = "";
    private string useranswer= "";
    int Increment = 0;
    int questiontime =110;
    int answertime = 500 ;
    int restart = 90;
    

    void Start(){
        Debug.Log("LCS Script Start ");
        ts = GameObject.FindObjectOfType(typeof(TextScript)) as TextScript;
        KIS_ = GameObject.FindObjectOfType(typeof(KeyboardInputScript)) as KeyboardInputScript;
        DAD = GameObject.FindObjectOfType(typeof(DragandDrop)) as DragandDrop;            
    }

    void Awake(){
        Debug.Log("LCS Script Awake ");
        ts = GameObject.FindObjectOfType(typeof(TextScript)) as TextScript;
        KIS_ = GameObject.FindObjectOfType(typeof(KeyboardInputScript)) as KeyboardInputScript;
        DAD = GameObject.FindObjectOfType(typeof(DragandDrop)) as DragandDrop;            
    }

    void Update(){
        if(EnabledDisplay && (!blocked)){
            setQuestion();
        }else{
            if(blocked && (!stopTimer)){
                QuestionDelay();
            }else{
                if(stopTimer && (!disabled)){
                    AnswerDelay();
                }else{
                    if(disabled){
                        Restartpattern();
                    }
                }
            }
        }
        
    }

    void setQuestion(){
        if(EnabledDisplay && (!blocked)){
            testingword = DAD.getWords_lab4c().Trim();
            ts.changeLCDTextState(true);
            ts.SetLCDScreenText(testingword);
            blocked = true;
        }
    }
    void QuestionDelay(){
        Increment +=1;
        if(Increment == questiontime){
            ts.SetLCDScreenText("");
            stopTimer = true;
            Increment = 0;
            KIS_.changetakeinput(true);
        }
    }
    void AnswerDelay(){
        Increment +=1;
        if(Increment == answertime){
            useranswer = KIS_.getword();
            if(useranswer.Contains(testingword)){
                KIS_.Clearword();
                testingword = "";
                ts.SetLCDScreenText("WIN");
            }else{
                KIS_.Clearword();
                testingword = "";
                ts.SetLCDScreenText("LOSE");
            }
            disabled = true;
            KIS_.changetakeinput(false);
            Increment = 0;
        }
    }

    void Restartpattern(){
        Increment +=1;
        if(Increment == restart){
            ts.SetLCDScreenText("RESET !!!!");
            blocked = false;
            stopTimer = false;
            disabled = false;
            Increment = 0;
        }
    }

    public void changeMetallicColorLCD(float MetalicValue){
        try{
        GameObject p1 = GameObject.Find("lcd display");
        foreach(Transform child in p1.transform){
            if(child.name.Contains("2")){
                Renderer render = child.GetComponent<Renderer>();
                render.material.SetFloat("_Metallic", MetalicValue);
            }
    
        }
        }catch(System.Exception e){}
    }

}
