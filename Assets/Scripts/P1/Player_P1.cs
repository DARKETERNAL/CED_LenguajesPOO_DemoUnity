using UnityEngine;

public class Player_P1 : MonoBehaviour
{
    public Transform bulletSpawnPosition;
    public BulletP1 redBullet;
    public BulletP1 yellowBullet;

    public float movementSpeed;
    public float shootForce;

    private BulletP1 currentBullet; // = null;
    private float shootCooldown = 0.5F;
    private bool canShoot = true;

    private float hVal = 0F;

    // Start is called before the first frame update
    private void Start()
    {
        currentBullet = redBullet;
    }

    // Update is called once per frame
    private void Update()
    {
        hVal = Input.GetAxis("Horizontal");

        if (hVal != 0F)
        {
            transform.Translate(transform.right * movementSpeed * hVal * Time.deltaTime, Space.World);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentBullet = redBullet;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentBullet = yellowBullet;
        }

        if (Input.GetKeyUp(KeyCode.Space) && canShoot)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        canShoot = false;

        Instantiate<BulletP1>(currentBullet, bulletSpawnPosition.position, bulletSpawnPosition.rotation) // Instantiate target
           .TargetRigidbody // Access to target RB
           .AddForce(transform.forward * shootForce, ForceMode.Impulse); // add force to target RB

        Invoke("ResetShoot", shootCooldown);
    }

    private void ResetShoot()
    {
        canShoot = true;
    }
}