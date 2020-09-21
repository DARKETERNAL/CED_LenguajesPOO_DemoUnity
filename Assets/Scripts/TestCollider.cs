using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollider : MonoBehaviour
{
    public Color color;

    private void OnTriggerEnter(Collider other)
    {
        print(string.Format("Collided with {0}", other.gameObject.name));
    }
}
