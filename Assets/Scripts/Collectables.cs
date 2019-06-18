using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public int points;
    private SpriteRenderer sprite;
    private HUD hud;
    private float pointdisplay;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        hud = FindObjectOfType<HUD>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            hud.currentPoints += points;
            sprite.enabled = !sprite.enabled;

            gameObject.SetActive(false);
        }
    }
}
