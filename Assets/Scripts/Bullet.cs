﻿using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer.Equals(LayerMask.NameToLayer("Target")))
        {
            Destroy(collision.gameObject);

            Player player = FindObjectOfType<Player>();

            if (player != null)
            {
                player.AddScore();
            }
        }

        Destroy(gameObject);
    }
}