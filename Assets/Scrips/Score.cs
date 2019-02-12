using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	public static Text scoreText;
	private static int score;

	// Use this for initialization
	void Start ()
	{
		score = 0;
		scoreText = GameObject.Find("Stroke").GetComponent<Text>();

	}

	//You can call this code anywhere using Score.ResetPoints();
	public static void ResetPoints()
	{
		score = 0;
		scoreText.text = "Stroke: 0";
	}

	//You can call this code anywhere using Score.AddPoints(POINT VALUE);
	public static void AddPoints()
	{
		score++;
		scoreText.text = "Stroke:" + score;
	}
}
