using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayUI : MonoBehaviour
{
    public static GamePlayUI instance;

    [Header("Essential Objects")]
    [SerializeField] private GameObject escapePanel = null;
    [SerializeField] private GameObject plrObject = null;

    private PlayerInputManager plrInput = null;

    private bool isPaused = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        plrInput = plrObject.GetComponent<PlayerInputManager>();
    }

    internal void TogglePause()
    {
        isPaused = !isPaused;
        escapePanel.SetActive(isPaused);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
