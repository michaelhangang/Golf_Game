using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceScript : MonoBehaviour {

    public static Text forceText;

	// Use this for initialization
	void Start ()
    {
        forceText = GameObject.Find("Force").GetComponent<Text>();

        DisplayForce(0.0f);
	}
	
    public static void DisplayForce(float forceValue)
    {
        forceText.text = "FORCE: " + forceValue;
    }
}
