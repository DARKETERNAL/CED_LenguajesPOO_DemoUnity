using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class BulletP1 : MonoBehaviour
{
    public EColor color;

    public float autoDestroyTime = 10F;

    public Rigidbody TargetRigidbody { get; private set; }

    private void Awake()
    {
        TargetRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Destroy(gameObject, autoDestroyTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        TargetP1 target = collision.gameObject.GetComponent<TargetP1>();

        if (target != null && target.color == /*my*/color)
        {
            Destroy(collision.gameObject);
        }

        Destroy(gameObject);
    }
}