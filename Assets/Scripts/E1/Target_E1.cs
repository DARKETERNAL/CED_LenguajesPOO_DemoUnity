using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Target_E1 : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem destroyPS;

    [SerializeField]
    private AudioSource destroySFX;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Player_E1 player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_E1>();

            if (player != null)
            {
                player.AddScore(1);
            }

            Destroy(collision.gameObject);
        }

        if (destroyPS != null)
        {
            destroyPS.Play();
        }

        if (destroySFX != null)
        {
            destroySFX.Play();
        }

        Destroy(gameObject);
    }
}