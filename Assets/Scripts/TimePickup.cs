using UnityEngine;

public class TimePickup : MonoBehaviour
{
    [SerializeField]
    private float timeToAdd = 5F;

    private void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, 10F * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();

        // Detectar si el jugador colisiona con este objeto
        if (player != null && player.TotalKeys >= 3)
        {
            // Sumar tiempo de juego
            player.AddPlayTime(timeToAdd);

            GameObject.FindGameObjectWithTag("PickupSFX").GetComponent<AudioSource>().Play();

            player.PlayPickupVFX();

            Destroy(gameObject);
        }
    }
}