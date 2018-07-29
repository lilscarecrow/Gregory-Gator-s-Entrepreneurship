using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController cam;
    public Collider2D colliderUp, colliderDown, colliderLeft, colliderRight;

    void Awake()
    {
        if (cam == null)
        {
            cam = this;
        }
        else if (cam != this)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
