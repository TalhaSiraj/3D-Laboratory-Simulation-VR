using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastScript : MonoBehaviour
{
    private string CollidedObjectName = "", CollidedObjecttag = "";
    private Ray ray;
    // "hit" variable stores information.
    private RaycastHit hit;
    // drawing vector's direction.
    private Vector3 direction = new Vector3(1f, 0f, 0f);
    private Vector3 direction1 = new Vector3(0f, 0f, 1f);
    // distance of vector.
    private static float distance = 0.2f;
    // using offsetY for ignoring gameObject itself. If you do not want to offset the ray, you can use layerMask as Physics.Raycast method's 4th parameter.
    private float offsetY = 0f;

    void Start () {
        Debug.Log("RaycastScript Start");
        //ray = new Ray(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + offsetY, gameObject.transform.position.z), direction);
    }

    void Awake () {
        Debug.Log("RaycastScript Awake");
        //ray = new Ray(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + offsetY, gameObject.transform.position.z), direction);
    }
    public void GenerateRay(){
        if(DragandDrop.labinstructionNumber == 18){
            ray = new Ray(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + offsetY, gameObject.transform.position.z),new Vector3(GameObject.Find("ultrasonic sensor").transform.position.x,0f, -1));
        // gameObject's position is changing over time.
            ray.origin = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + offsetY, gameObject.transform.position.z);
        }else{
            ray = new Ray(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + offsetY, gameObject.transform.position.z), direction);
        // gameObject's position is changing over time.
            ray.origin = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + offsetY, gameObject.transform.position.z);
        }
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.green, distance);

        if (Physics.Raycast(ray, out hit, distance)) {
            CollidedObjectName = hit.collider.gameObject.name;
            // if(DragandDrop.labinstructionNumber == 18){
            //     if(!hit.collider.gameObject.name.Contains("Obsticle") || !hit.collider.gameObject.tag.Contains("Obsticle")){
            //         Debug.Log("Nothing");
            //         CollidedObjectName = "";
            //         CollidedObjecttag  = "";
            //     }
            //     if(hit.collider.gameObject.name.Contains("Obsticle") || hit.collider.gameObject.tag.Contains("Obsticle")){
            //         CollidedObjectName = hit.collider.gameObject.name;            
            //         CollidedObjecttag = hit.collider.gameObject.tag;
            //         Debug.Log("Script = " +CollidedObjecttag);
            //     }

            // }else{
            //     Debug.Log("Raycast length ="+distance);
            //     CollidedObjectName = hit.collider.gameObject.name;            
            // }

        }
    }

    public void setDistance(float dist){
        distance = dist;
    }
    public float getDistance(){
        return distance;
    }

    public string getName(){
        return CollidedObjectName;
    }

    public string getTag(){
        return CollidedObjecttag;
    }
    public void resetvalueofcollider(){
        CollidedObjectName = "";
    }
}
