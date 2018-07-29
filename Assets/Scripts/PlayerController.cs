using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController player;
    public BoxCollider2D collider;
    public float moveSpeed;
    public GameObject bomb, gun;
    private Rigidbody2D body;

    void Awake()
    {
        if (player == null)
        {
            player = this;
        }
        else if (player != this)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start ()
    {
        body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetAxisRaw("Horizontal") != 0)//Left or Right
        {
            body.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, 0);
            transform.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1f,1f);
        }
        else if(Input.GetAxisRaw("Vertical") != 0)//Up or Down
        {
            body.velocity = new Vector2(0, Input.GetAxisRaw("Vertical") * moveSpeed);
        }
        else
        {
            body.velocity = new Vector2(0, 0);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bomb);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            var obj = Instantiate(gun);
            obj.transform.parent = transform;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == CameraController.cam.colliderLeft || CameraController.cam.colliderRight || CameraController.cam.colliderUp || CameraController.cam.colliderDown)
        {
            Debug.Log("GONE");
            body.velocity = new Vector2(0, 0);
        }
    }
}
