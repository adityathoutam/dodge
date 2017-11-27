using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {

	void Start ()
    {
	    GetComponent<Rigidbody2D> ().gravityScale += Time.timeSinceLevelLoad / 20f;
	}
	void Update ()
    {
	    if(transform.position.y < -5f)
		{
			Destroy (gameObject);
		}
	}
}
