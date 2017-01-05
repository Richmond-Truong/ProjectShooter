using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // Use this for initialization
    private Rigidbody2D rb2d;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;

    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	public float speed;
	public float xMin, xMax, yMin, yMax;
	void FixedUpdate () {
		float moveH = Input.GetAxis ("Horizontal");
		float moveV = Input.GetAxis ("Vertical");
		Vector2 move = new Vector2(moveH, moveV);
        rb2d.velocity = move * speed; // replacing rb2d.AddForce(move * speed);
		//rigidbody2D.velocity = move * speed;
		//rigidbody2D.position = new Vector3 (
		//	Mathf.Clamp (rigidbody.position.x, xMin, xMax),
	//		Mathf.Clamp (rigidbody.position.y, yMin, yMax),
	//		0.0f
	//	);
		//transform.position += move * speed * Time.deltaTime;
	}

    private void Update()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }

    }
}
