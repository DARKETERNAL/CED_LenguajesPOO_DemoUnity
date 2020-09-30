using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Player player;

    [Header("UI")]
    [SerializeField]
    private Text scoreLabel;

    [SerializeField]
    private Text playTimeLabel;

    [SerializeField]
    private Text endGameLabel;

    [SerializeField]
    private Image endGameBG;

    [SerializeField]
    private Button restartBtn;

    public void RestartLevel()
    {
        SceneManager.LoadScene("TestExample", LoadSceneMode.Single);
    }

    // Update is called once per frame
    private void Update()
    {
        if (player != null && scoreLabel != null && playTimeLabel != null)
        {
            if (player.IsPlaying)
            {
                scoreLabel.text = player.Score.ToString();
                playTimeLabel.text = player.CurrentPlayTime.ToString();
            }
            else
            {
                scoreLabel.gameObject.SetActive(false);

                if (endGameBG != null && endGameLabel != null && restartBtn != null)
                {
                    endGameLabel.gameObject.SetActive(true);
                    endGameBG.gameObject.SetActive(true);
                    restartBtn.gameObject.SetActive(true);
                }
            }
        }
    }
}