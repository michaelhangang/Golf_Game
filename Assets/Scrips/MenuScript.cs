using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuScript : MonoBehaviour
{
	

	void Awake()
	{
		
	}

	//This function gets called by the save button 


    //This function gets called by the load button 
    

    //This function gets called by the play button 
    public void PlayGame()
	{
		SceneManager.LoadScene("Main");
	}

	public void Exit(){
		//SceneManager.UnloadSceneAsync ("Main");
		//SceneManager.UnloadSceneAsync ("Menu");
		Debug.Log("Quit");
		Application.Quit();
	}




}
