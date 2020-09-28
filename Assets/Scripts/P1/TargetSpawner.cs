using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public TargetP1 redTarget;
    public TargetP1 yellowTarget;
    
    public float shootForce = 10F;

    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating("SpawnNextTarget", 0F, 2F);
    }

    private void SpawnNextTarget()
    {
        //TargetP1 nextTarget = Random.Range(0, 2) == 0 ? redTarget : yellowTarget;
        TargetP1 nextTarget = null;

        if (Random.Range(0, 2) == 0)
        {
            nextTarget = redTarget;
        }
        else
        {
            nextTarget = yellowTarget;
        }

        Instantiate<TargetP1>(nextTarget, transform.position, transform.rotation) // Instantiate target
            .TargetRigidbody // Access to target RB
            .AddForce(transform.forward * shootForce, ForceMode.Impulse); // add force to target RB
    }
}