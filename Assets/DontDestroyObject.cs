using UnityEngine;

public class DontDestroyObject : MonoBehaviour
{
    private static DontDestroyObject instance;

	void Start ()
    {
        //If this is the first instance of this script then it must be the first time the object exist
        if (instance == null)
        {
            instance = this;
        }
        //If it's not it already exist so destroy it!
        else
        {
            Destroy(this.gameObject);
        }

        //Make this game object live between scenes
        DontDestroyOnLoad(this.gameObject);
	}
}