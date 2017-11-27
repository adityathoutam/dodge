 using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BlockSpawner : MonoBehaviour {
	public Transform[] spwanPoints; 
	public GameObject blockPrefab; 
	public float timeBetweenWaves = 1f; 
	public float timeToSpawn =2f; 
	private int score; 
	public Text countText;
	public static int highScore = 0; 
	public Text HighScoreText; 
void Start()
	{  
        highScore = 0; 
		highScore = PlayerPrefs.GetInt ("HighScore", 0); 
		HighScoreText.text = ""+highScore;
		score = 0;
		SetCountText ();

	}
	void Update()
	{
		if (Time.time >= timeToSpawn) {
			timeToSpawn = Time.time + timeBetweenWaves;
			score = score + 1;
			SpawnBlocks ();
			SetCountText ();

			}
	}
 void SpawnBlocks ()
	{
		int randomIndex = Random.Range (0, spwanPoints.Length);

        for (int i = 0; i < spwanPoints.Length; i++)
		{ blockPrefab.GetComponent<SpriteRenderer> ().sprite = colorbg.spritetype;
			if (randomIndex != i) {
				
				Instantiate (blockPrefab, spwanPoints [i].position, Quaternion.identity); 
				}}
		
	}
void SetCountText()
	{
		countText.text = "" + score;
		if (score > highScore) {
			highScore = score;
			HighScoreText.text = ""+highScore;
		}
	}
}