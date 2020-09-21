using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float movementSpeed = 5F;

    public float runFactor = 1.5F;
    public float rotationSpeed = 2F;
    public float jumpFactor = 10F;

    [Header("Shoot")]
    public Rigidbody bulletBase;

    public Transform spawnLocation;
    public float shootForce = 20F;

    [Header("Game")]
    public float playTime = 180F;

    private float rotationFactor = 3F;
    private float currentRunFactor;
    private float currentRotFactor;

    private float horizontalValue;
    private float verticalValue;

    private bool isGrounded = true;

    private float currentPlayTime;
    private bool isPlaying = true;

    private int totalTargets;
    private int score;

    private Rigidbody myRigidbody;
    private MeshRenderer mesh;

    // Start is called before the first frame update
    private void Start()
    {
        ResetMovementFactors();

        currentPlayTime = playTime;

        totalTargets = GameObject.FindGameObjectsWithTag("Target").Length;

        mesh = GetComponent<MeshRenderer>();
        myRigidbody = GetComponent<Rigidbody>();
        InvokeRepeating("PrintPlayTime", 0F, 1F);
    }

    private void PrintPlayTime()
    {
        print(currentPlayTime);
    }

    public void AddScore()
    {
        score += 1;

        if (score == totalTargets)
        {
            StopGame(true);
        }
    }

    private void StopGame(bool wonGame = false)
    {
        enabled = false;
        CancelInvoke("PrintPlayTime");
        print(wonGame ? "You Win" : "Game Over");

        //if (wonGame)
        //{
        //    print("You win");
        //}
        //else
        //{
        //    print("Game Over");
        //}
    }

    private void ResetMovementFactors()
    {
        currentRunFactor = 1F;
        currentRotFactor = 1F;
    }

    // Update is called once per frame
    private void Update()
    {
        currentPlayTime -= Time.deltaTime;
        isPlaying = currentPlayTime > 0F;

        if (isPlaying)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                mesh.material.color = new Vector4(Random.Range(0F, 1F), Random.Range(0F, 1F), Random.Range(0F, 1F), 1F);
            }

            //LeftShift para correr
            if (Input.GetButtonDown("Run"))
            {
                currentRunFactor = runFactor;
                currentRotFactor = rotationFactor;
            }

            if (Input.GetButtonUp("Run"))
            {
                ResetMovementFactors();
            }

            //WS: Movimiento adelante/atrás
            verticalValue = Input.GetAxis("Vertical");

            if (verticalValue != 0F)
            {
                //myRigidbody.AddForce(transform.forward * movementSpeed * currentRunFactor * verticalValue * Time.deltaTime);
                transform.Translate(transform.forward * movementSpeed * currentRunFactor * verticalValue * Time.deltaTime, Space.World);
            }

            //AD: Rotación Izqda/Derecha.
            horizontalValue = Input.GetAxis("Horizontal");

            if (horizontalValue != 0F)
            {
                transform.Rotate(transform.up * rotationSpeed * currentRotFactor * horizontalValue * Time.deltaTime);
            }

            if (Input.GetAxis("Jump") != 0F && isGrounded)
            {
                isGrounded = false;
                myRigidbody.AddForce(transform.up * jumpFactor, ForceMode.Impulse);
            }

            if (Input.GetButtonUp("Fire1"))
            {
                Shoot();
            }
        }
        else
        {
            StopGame();
        }
    }

    private void Shoot()
    {
        if (bulletBase != null && spawnLocation != null)
        {
            Instantiate<Rigidbody>(bulletBase, spawnLocation.position, spawnLocation.rotation).AddForce(spawnLocation.forward * shootForce, ForceMode.Impulse);

            //Rigidbody bulletClone = Instantiate<Rigidbody>(bulletBase, spawnLocation.position, spawnLocation.rotation);
            //bulletClone.AddForce(bulletClone.transform.forward * shootForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}