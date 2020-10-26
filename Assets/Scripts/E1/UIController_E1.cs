using UnityEngine;
using UnityEngine.UI;

public class UIController_E1 : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;

    private Player_E1 playerRef;

    // Start is called before the first frame update
    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_E1>();

        if (playerRef == null)
        {
            enabled = false;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (playerRef != null)
        {
            scoreText.text = playerRef.Score.ToString();
        }
    }
}