using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCoins : MonoBehaviour
{
    private float coins = 0;
    public Text coinText;
    public AudioClip pickupSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Coin")
        {
            coins++;
            coinText.text = coins.ToString("00"); // Displays coin count in double digit format
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            Destroy(other.gameObject);
        }
    }
}
