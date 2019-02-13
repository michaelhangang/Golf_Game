using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour
{

	// Update is called once per frame
	void Update ()
    {
        //Press the 1 key to load the menu scene
		if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene(0);
        }

        //Press the 2 key to load the main menu
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene(1);
        }
    }
}
