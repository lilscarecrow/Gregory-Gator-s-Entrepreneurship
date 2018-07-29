using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
        transform.position = new Vector3(PlayerController.player.transform.position.x + (0.4f * PlayerController.player.transform.localScale.x) , PlayerController.player.transform.position.y, PlayerController.player.transform.position.z);
        StartCoroutine(FireGun());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator FireGun()
    {
        AudioManager.audioManager.ChangeAudioSource("Explosion");
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
        yield return null;
    }
}
