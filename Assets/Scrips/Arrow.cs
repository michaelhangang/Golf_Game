﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Arrow : MonoBehaviour {

    public Transform PlayerTransform;
    public Transform ArrowTransform;
    public float forceScale;
    public Rigidbody rb;
    private float force;
	public GameObject ob;
	public AudioSource music;
	public AudioSource hit;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 playerPosition = PlayerTransform.position;

        //set the players heigh var to have the same y (height) as the ball
        playerPosition.y = transform.position.y;

        Vector3 lineFromPlayerToBall = transform.position - playerPosition;

        lineFromPlayerToBall.Normalize();

        //This will get us the angle from a top down perspective
        float angle = Mathf.Atan2(lineFromPlayerToBall.z, lineFromPlayerToBall.x) * Mathf.Rad2Deg;
        ArrowTransform.rotation = Quaternion.Euler(90.0f, -angle, 0.0f);

        lineFromPlayerToBall = lineFromPlayerToBall * 1.1f;

        //Position from ball adding the line from the player to ball
        ArrowTransform.position = transform.position + lineFromPlayerToBall;

        //Hit space to push the ball along
        if (Input.GetKey(KeyCode.Space))
        {
            force += forceScale * Time.deltaTime;

            ForceScript.DisplayForce(force);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.AddForce(lineFromPlayerToBall * force);
            force = 0.0f;
            ForceScript.DisplayForce(0.0f);
			Score.AddPoints ();
			music.Play ();
        }

		if (rb.IsSleeping ()) 
			ob.SetActive (true);

		else
			ob.SetActive (false);

	

    }
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name == "Flag") 
		{
			
			StartCoroutine(DelayedLoad());
		}
		if (collision.gameObject.name == "Flag1") 
		{
			StartCoroutine(DelayedLoad1());
		}
		if (collision.gameObject.name == "Flag2") 
		{
			StartCoroutine(DelayedLoad2());
		}
	}

	IEnumerator DelayedLoad()
	{
		//Play the clip once
		hit.Play ();

		//Wait until clip finish playing
		yield return new WaitForSeconds (0.5f);    

		//Load scene here
		SceneManager.LoadScene (2);
		Score.ResetPoints ();
	}
	IEnumerator DelayedLoad1()
	{
		//Play the clip once
		hit.Play ();

		//Wait until clip finish playing
		yield return new WaitForSeconds (0.5f);    


		//Load scene here
		SceneManager.LoadScene (3);
		Score.ResetPoints ();
	}

	IEnumerator DelayedLoad2()
	{
		//Play the clip once
		hit.Play ();

		//Wait until clip finish playing
		yield return new WaitForSeconds (0.5f);    

		//Load scene here
		SceneManager.LoadScene (0);
		Score.ResetPoints ();
		Cursor.visible = true;
	}

}
