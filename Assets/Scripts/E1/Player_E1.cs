using UnityEngine;

public class Player_E1 : MonoBehaviour
{
    [Header("Movement")]
    [Range(10F, 200F)]
    [SerializeField]
    private float moveSpeed;

    [Header("Shoot")]
    [SerializeField]
    private Rigidbody bulletBase;

    [Range(10F, 500F)]
    [SerializeField]
    private float shootForce;

    [SerializeField]
    private Transform spawnLocation;

    [Header("Effects")]
    [SerializeField]
    private ParticleSystem shootPS;

    private float moveValue;

    private int score;

    public int Score { get => score; }

    public void AddScore(int value)
    {
        score += value;
    }

    // Update is called once per frame
    private void Update()
    {
        moveValue = Input.GetAxis("Horizontal");

        if (moveValue != 0F)
        {
            transform.Translate(transform.right * moveValue * moveSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetMouseButtonUp(0) && bulletBase != null)
        {
            if (shootPS != null)
            {
                shootPS.Play();
            }

            Instantiate<Rigidbody>(bulletBase, spawnLocation.position, spawnLocation.rotation).AddForce(transform.up * shootForce);
        }
    }
}