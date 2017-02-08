using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorable : MonoBehaviour
{
    public int scoreToGive;
    AudioSource source;

    private void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<PinballBehvaiour>().IncScore(scoreToGive);
        source.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<PinballBehvaiour>().IncScore(scoreToGive);
        source.Play();
    }
}
