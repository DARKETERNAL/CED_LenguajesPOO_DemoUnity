﻿using UnityEngine;

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

    [Header("VFX")]
    public ParticleSystem pickupVFX;    

    private float rotationFactor = 3F;
    private float currentRunFactor;
    private float currentRotFactor;

    private float horizontalValue;
    private float verticalValue;

    private bool isGrounded = true;

    private float currentPlayTime; // PascalCase
    private bool isPlaying = true;

    private int totalKeys = 0;

    private int totalTargets;
    private int score;

    private Rigidbody myRigidbody;
    private MeshRenderer mesh;

    private Animator animator;

    public int Score { get => score; } // CamelCase
    public bool IsPlaying { get => isPlaying; }
    public float CurrentPlayTime { get => currentPlayTime; }
    public int TotalKeys { get => totalKeys; }

    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();

        ResetMovementFactors();

        currentPlayTime = playTime;

        totalTargets = GameObject.FindGameObjectsWithTag("Target").Length;

        mesh = GetComponent<MeshRenderer>();
        myRigidbody = GetComponent<Rigidbody>();
        InvokeRepeating("PrintPlayTime", 0F, 1F);
    }

    private void PrintPlayTime() // CamelCase
    {
        print(currentPlayTime);
    }

    public void AddPlayTime(float value)
    {
        currentPlayTime += value;
    }

    public void AddScore()
    {
        score += 1;

        if (score == totalTargets)
        {
            StopGame(true);
        }
    }

    public void PlayPickupVFX()
    {
        if (pickupVFX != null)
        {
            pickupVFX.Play();
        }
    }

    public void AddKey(int val)
    {
        totalKeys += val;
    }

    private void StopGame(bool wonGame = false)
    {
        enabled = false;
        isPlaying = false;
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

            if (animator != null)
            {
                animator.SetFloat("Speed", verticalValue);
            }

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

                if (animator != null)
                {
                    animator.SetBool("Jumping", true);
                }
            }
            else
            {
                if (animator != null)
                {
                    animator.SetBool("Jumping", false);
                }
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