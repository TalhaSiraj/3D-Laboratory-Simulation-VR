using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetobjectsScrpt_ : MonoBehaviour
{

    //For reset objects to their original position
    private  Dictionary<GameObject, Vector3> Reset_Entities_positions =new Dictionary<GameObject, Vector3>();

    //For reset objects to their original rotation
    private  Dictionary<GameObject, Vector3> Reset_Entities_Rotation =new Dictionary<GameObject, Vector3>();

    //Name of object that has been moved.
    private List<GameObject> NameOfObjectsMoved = new List<GameObject>();

    public void AddObjects_(GameObject name , Vector3 trans , Vector3 rotate_){
        if(!Reset_Entities_positions.ContainsKey(name)){
            Reset_Entities_positions.Add(name , trans);
            Reset_Entities_Rotation.Add(name , rotate_);
            NameOfObjectsMoved.Add(name);
        }
    }

    public void ResetAll(){
        foreach(GameObject resetObject in NameOfObjectsMoved){
            ResetObject_(resetObject);
        }
    }

    //Selected game object will reset to its original state
    public void ResetObject_(GameObject CurrentObject){
        try{
            DestroyLineRendererObject(CurrentObject.name);
            CurrentObject.transform.position = (Vector3)Reset_Entities_positions[CurrentObject];
            CurrentObject.transform.rotation = Quaternion.Euler(Reset_Entities_Rotation[CurrentObject].x,Reset_Entities_Rotation[CurrentObject].y,Reset_Entities_Rotation[CurrentObject].z);            
        }catch(System.Exception e){}
    }

    void DestroyLineRendererObject(string name){
        try{
        GameObject parent = GameObject.Find(name);
        foreach (Transform child in parent.transform){
            if(AddingScript.LineRendererParent.ContainsKey(child.name)){
                Destroy(child.gameObject);
            }
        }
        foreach(KeyValuePair<string,string> attachStat in AddingScript.LineRendererParent)
        {
            if(name.Contains(attachStat.Value)){
                Destroy(GameObject.Find(attachStat.Key));
            }
        }
        }catch(System.Exception e){}        
        


    }

}
