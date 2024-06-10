using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Player player;
    public GameObject healthBar1;
    public GameObject healthBar2;
    public GameObject healthBar3;
    public GameObject healthBar4;
    public GameObject healthBar5;
    public GameObject healthBar6;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        if (player.health < 50) healthBar1.gameObject.SetActive(false);
        if (player.health < 40) healthBar2.gameObject.SetActive(false);
        if (player.health < 30) healthBar3.gameObject.SetActive(false);
        if (player.health < 20) healthBar4.gameObject.SetActive(false);
        if (player.health < 10) healthBar5.gameObject.SetActive(false);
        if (player.health < 0) healthBar6.gameObject.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("BurningWall"))
            player.health -= 0.5f;
    }
}
