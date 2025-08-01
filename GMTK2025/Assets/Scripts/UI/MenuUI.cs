using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    [Header("Essential Objects")]
    [SerializeField] private Button startGame;

    public void StartGame()
    {
        startGame.interactable = false;
        SceneManager.LoadScene("GamePlay");
    }

    public void QuitGame()
    {
        Debug.Log("Application terminated!");
        Application.Quit();
    }
}