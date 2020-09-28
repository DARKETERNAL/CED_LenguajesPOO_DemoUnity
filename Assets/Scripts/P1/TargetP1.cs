using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class TargetP1 : MonoBehaviour
{
    public EColor color;

    // C# Property
    public Rigidbody TargetRigidbody { get; private set; }

    private void Awake()
    {
        TargetRigidbody = GetComponent<Rigidbody>();
    }
}