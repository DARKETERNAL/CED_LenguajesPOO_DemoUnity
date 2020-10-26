using UnityEngine;

public class SpawnController_E1 : MonoBehaviour
{
    [SerializeField]
    private GameObject targetBase;

    [Range(0.5F, 5F)]
    [SerializeField]
    private float spawnRate;

    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating("SpawnObject", 0, spawnRate);
    }

    private void SpawnObject()
    {
        Vector3 spawnPoint = Camera.main.ViewportToWorldPoint(new Vector3(
                Random.Range(0F, 1F), 1F, 1F));

        GameObject instance = Instantiate(targetBase, spawnPoint, Quaternion.identity);
    }
}