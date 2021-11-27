using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceControl : MonoBehaviour
{
	 // Voice command vars
	private Dictionary<string, Action> keyActs = new Dictionary<string, Action>();
	private KeywordRecognizer recognizer;
	// Var needed for color manipulation
	private MeshRenderer cubeRend;
	//Var needed for spin manipulation
	private bool spinningRight;
	//Vars needed for sound playback.
	private AudioSource soundSource;
	public AudioClip[] sounds;

	private string soundName = "";
	private animation ascript;

    // Start is called before the first frame update
    void Start()
    {
		try{
        	cubeRend = GetComponent<MeshRenderer>();
			soundSource = GetComponent<AudioSource>();
						//Voice commands for changing color
			keyActs.Add("red", Red);
			keyActs.Add("green", Green);
			keyActs.Add("blue", Blue);
			keyActs.Add("white", White);
			//Voice commands for spinning
			keyActs.Add("spin right", SpinRight);
			keyActs.Add("spin left", SpinLeft);
			//Voice commands for playing sound
			keyActs.Add("hello", Talk);
			keyActs.Add("Objective", Talk);

			// keyActs.Add("One Cube",Gencube);
			//Voice command to show how complex it can get.
			keyActs.Add("pizza is a wonderful food that makes the world better", FactAcknowledgement);
			recognizer = new KeywordRecognizer(keyActs.Keys.ToArray());
			recognizer.OnPhraseRecognized += OnKeywordsRecognized;
			recognizer.Start();
		}catch(System.Exception w){}
		ascript = GameObject.FindObjectOfType(typeof(animation)) as animation;
        


        
    }

    // Update is called once per frame
    void Update()
    {
    }
           void Red()
{
	cubeRend.material.SetColor("_Color", Color.red);
}
void Green()
{
	cubeRend.material.SetColor("_Color", Color.green);
}
void Blue()
{
	cubeRend.material.SetColor("_Color", Color.blue);
}
void White()
{
	cubeRend.material.SetColor("_Color", Color.white);
}
        
void Talk()
{
	try{
		if(soundName.Contains("Objective")){
			ascript.makemove();
			SpeakRule();

		}else{
			FindObjectOfType<AudioManager>().Play(soundName);
		}
	}catch(System.Exception e){}

}

public void SpeakRule(){
	soundName = "Objective";
	FindObjectOfType<AudioManager>().Play(soundName);
}
    void SpinRight()
{
	spinningRight = true;
	StartCoroutine(RotateObject(1f));
}
void SpinLeft()
{
	spinningRight = false;
	StartCoroutine(RotateObject(1f));
}
private IEnumerator RotateObject(float duration)
{
	float startRot = transform.eulerAngles.x;
	float endRot;
	if (spinningRight)
		endRot = startRot - 360f;
	else
		endRot = startRot + 360f;
	float t = 0f;
	float yRot;
	while (t < duration)
	{
		t += Time.deltaTime;
		yRot = Mathf.Lerp(startRot, endRot, t / duration) % 360.0f;
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRot, transform.eulerAngles.z);
		yield return null;
	}
}
void FactAcknowledgement()
{
	Debug.Log("How right you are.");
}

void OnKeywordsRecognized(PhraseRecognizedEventArgs args)
{
	try{
		soundName = args.text;
		keyActs[args.text].Invoke();
	}catch(System.Exception e){}

}

    
}
