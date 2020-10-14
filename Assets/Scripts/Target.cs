using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    private AudioSource destructionSFX;

    [SerializeField]
    private ParticleSystem destructionVFX;

    public float rotationSpeed = 5F;

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (destructionSFX != null)
        {
            Instantiate<AudioSource>(destructionSFX, transform.position, Quaternion.identity).Play(); 
        }

        if (destructionVFX != null)
        {
            Instantiate(destructionVFX, transform.position, transform.rotation); 
        }
        
        Destroy(gameObject);
    }
}