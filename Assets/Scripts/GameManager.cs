using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public float slowness =10f;
	public Text DisplayHighScoreText;
    private static int count=0;
    public void EndGame()
    {
        PlayerPrefs.SetInt("HighScore", BlockSpawner.highScore);
        StartCoroutine(RestartLevel());
    }
    IEnumerator RestartLevel()
    {
        Time.timeScale = 1f / slowness;
        Time.fixedDeltaTime = Time.fixedDeltaTime / slowness;
        yield return new WaitForSeconds(1f / slowness);
		Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime * slowness;
		yield return new WaitForSeconds (0.01f);
		Time.timeScale = 0f;
		lol ();
    } 
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            count++;
            if (count==1)
            {
				SceneManager.LoadScene ("menu");   
            }
            else
            {
                Application.Quit();
            }
        }

    }
    public void lol()
	{
		Time.timeScale = 1f;
		Time.fixedDeltaTime = 0.02f * Time.timeScale;
		Time.timeScale = 0f;
		FindObjectOfType<playerScript> ().Panel.SetActive (true);
		}

    void Start()
	{
		if (DisplayHighScoreText != null) {
			DisplayHighScoreText.text = BlockSpawner.highScore.ToString ();	
		}

	}

	string body = "Hey! Check out this new game, it's cool.";
	string body1 = "https://play.google.com/store/apps/details?id=com.endlessdreams.dodge";

	public void shareText()
	{
		AndroidJavaClass intentClass = new AndroidJavaClass ("android.content.Intent");
		AndroidJavaObject intentObject = new AndroidJavaObject ("android.content.Intent");
		intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
		intentObject.Call<AndroidJavaObject>("setType", "text/plain");
		intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), body+" "+body1);
		AndroidJavaClass unity = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
		AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
		AndroidJavaObject jChooser = intentClass.CallStatic<AndroidJavaObject>("createChooser", intentObject, "Share Via");
		currentActivity.Call("startActivity", jChooser);

	}
	public void Rate()
	{
		Application.OpenURL ("https://play.google.com/store/apps/details?id=com.endlessdreams.dodge");
	}

   public void back ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))

            SceneManager.LoadScene("menu");
    }
    public void GameSceneChanger(int index)
	{
		switch (index) {
		case 0:
			BlockSpawner.highScore = 0;
			PlayerPrefs.SetInt ("HighScore", 0);
			SceneManager.LoadScene ("menu");
			break;
		case 1:
			SceneManager.LoadScene ("bg");
			break;
		case 2:
			Time.timeScale = 1f;
			SceneManager.LoadScene ("play");  
              break;
		case 4:
			
			SceneManager.LoadScene ("menu");
			Time.timeScale = 1f;
			break;
		}
	}

}
