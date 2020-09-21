using UnityEngine;

public class Target : MonoBehaviour
{
    public float rotationSpeed = 5F;

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}