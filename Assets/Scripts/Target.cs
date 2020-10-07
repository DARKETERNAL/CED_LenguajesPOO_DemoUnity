using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    private AudioSource destructionSFX;

    public float rotationSpeed = 5F;

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate<AudioSource>(destructionSFX, transform.position, Quaternion.identity).Play();
        Destroy(gameObject);
    }
}