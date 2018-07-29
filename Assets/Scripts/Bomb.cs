using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Sprite bomb, explosion;
    private ParticleSystem particles;
    private SpriteRenderer spriteRenderer;
    // Use this for initialization
	void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        particles = GetComponent<ParticleSystem>();
        transform.position = PlayerController.player.transform.position;
        spriteRenderer.sprite = bomb;
        StartCoroutine(DetonateBomb());
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private IEnumerator DetonateBomb()
    {
        yield return new WaitForSeconds(5.0f);
        AudioManager.audioManager.ChangeAudioSource("Explosion");
        spriteRenderer.sprite = explosion;
        particles.Play();
        yield return new WaitForSeconds(2.0f);
        particles.Stop();
        Destroy(gameObject);
        yield return null;
    }
}
