using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeKeyItem : MonoBehaviour
{
    [SerializeField]
    private int keysToAdd;

    private void OnCollisionEnter(Collision collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if (player != null)
        {
            player.AddKey(keysToAdd);

            Destroy(gameObject);
        }
    }
}
