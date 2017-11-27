using UnityEngine;
using System.Collections;

public class playerScript : MonoBehaviour
{
	public AudioSource bgmusic;
    public float speed = 15f;
    private Rigidbody2D rb;
	public  GameObject Panel;
    void Start()
	{  
		bgmusic = GetComponent<AudioSource> ();
		bgmusic.Play ();
        rb = GetComponent<Rigidbody2D>();
		rb.GetComponent<SpriteRenderer> ().sprite = colorbg.playertype;
		Panel.gameObject.SetActive(false);
	}

    void Update()
	{ 
        
        float x1 = 0;
		float x = Input.GetAxis ("Horizontal") * Time.fixedDeltaTime * speed;
		Vector2 newPosition = rb.position + Vector2.right * x;
		newPosition.x = Mathf.Clamp (newPosition.x, -3.5f, 3.5f);
		rb.MovePosition (newPosition);

		if (Input.GetMouseButton (0) && Input.mousePosition.x < Screen.width / 2)
        {
			x1 = -0.20f;
			Vector2 newPosition1 = rb.position + Vector2.right * x1;
			newPosition1.x = Mathf.Clamp (newPosition1.x, -3.5f, 3.5f);
			rb.MovePosition (newPosition1);

		}

		if (Input.GetMouseButton (0) && Input.mousePosition.x > Screen.width / 2)
        {
			x1 = 0.20f;
			Vector2 newPosition1 = rb.position + Vector2.right * x1;
			newPosition1.x = Mathf.Clamp (newPosition1.x, -3.5f, 3.5f);
			rb.MovePosition (newPosition1);
		}
    }
	void OnCollisionEnter2D ()

	{ 
		
		FindObjectOfType<GameManager>().EndGame();
		bgmusic.Stop ();
	}
}