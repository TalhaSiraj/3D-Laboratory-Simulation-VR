using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

 
    void Start()
    {
        Debug.Log("Audio Manager Start");
        foreach(Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }
    void Awake(){
        Debug.Log("Audio Manager Awake");
    }

    public void Play(string name){
        Debug.Log("?? -- "+DragandDrop.labinstructionNumber+"--"+DragandDrop.labinstructionNumberIndex);
        try{
            if(name.Contains("Objective")){
                string labnumberandinstruction = ""+DragandDrop.labinstructionNumber;
                labnumberandinstruction = labnumberandinstruction+DragandDrop.labinstructionNumberIndex;
                labnumberandinstruction = labnumberandinstruction.Trim();
                Sound s = Array.Find(sounds, sounds => sounds.name == labnumberandinstruction);
                if(s == null)
                    return;
                DragandDrop.musicName.Add(name);
                s.source.volume = 100f;
                s.source.pitch = 1f;
                s.source.Play();
            }else{
                Sound s = Array.Find(sounds, sounds => sounds.name == name);
                if(s == null)
                    return;
                DragandDrop.musicName.Add(name);
                s.source.volume = 0.1f;

                if(name.Contains("hello") || name.Contains("patterncompleted")){
                    s.source.pitch = 1.0f;
                }
                else{
                    s.source.pitch = 1000.0f;
                }
                if(DragandDrop.labinstructionNumber == 5){
                    s.source.loop = true;
                }


                s.source.Play();
            }
            

        }catch(System.Exception e){}
    }

    public void StopMusic(){
        try{
            foreach(string name in DragandDrop.musicName){
                Sound s = Array.Find(sounds, sounds => sounds.name == name);
                s.source.Pause();
            }
        }catch(System.Exception e){}
    }
}
