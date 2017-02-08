using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballDeathZone : MonoBehaviour
{
    // Use this for initialization
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<PinballBehvaiour>().Lost();
        Destroy(collision.gameObject);
    }

}
