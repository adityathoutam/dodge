using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class colorbg : MonoBehaviour {
	Camera c;
	static Color bg;
	public Color32[] colors;
    public Sprite[] sprites;
    public static Color32 colortype;
    public static Sprite spritetype;
	public static Sprite playertype;
	

	void Start () 
	{

        bg =GetComponent<Camera> ().backgroundColor = colorbg.colortype;
	}

	public void colorChooserFunc()
	{  
		colortype=colors[Random.Range(0,30)];
			
	}

	void Update()
	{
		c = GameObject.Find ("Main Camera").GetComponent<Camera> ();
		c.backgroundColor = bg;
     }
	public void shapeChooserFunc()
	{
		spritetype = sprites [Random.Range (0, sprites.Length)];
	}

	public void playerChooserFunc()
	{
		playertype = sprites [Random.Range (0, sprites.Length)];
		Time.timeScale = 1f;
		SceneManager.LoadScene ("play");
	}
}