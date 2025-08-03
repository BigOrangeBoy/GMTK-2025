using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GamePlayUI : MonoBehaviour
{
    public static GamePlayUI instance;

    [Header("Essential Objects")]
    [SerializeField] private GameObject escapePanel = null;
    [SerializeField] private GameObject plrObject = null;
    [SerializeField] private Animator questAnimator = null;

    private PlayerInputManager plrInput = null;
    private PlayerMovement plrMovement = null;

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
        plrMovement = plrObject.GetComponent<PlayerMovement>();
    }

    private void Start()
    {
        Invoke("StartFirstQuest", 3f);
    }

    internal void TogglePause()
    {
        isPaused = !isPaused;
        escapePanel.SetActive(isPaused);
    }

    public void ReturnToMenu()
    {
        Destroy(EventBehaviour.instance.gameObject);
        Debug.Log("Destroyed Event Behaviour!");

        SceneManager.LoadScene("Menu");
    }

    private void StartFirstQuest()
    {
        if (EventBehaviour.instance.isFirstDay)
        {
            questAnimator.SetBool("isActive", true);
        }
        else
        {
            // Display Dialouge
        }

        StartCoroutine(ActivateGamePlay());
    }

    IEnumerator ActivateGamePlay()
    {
        yield return new WaitForSeconds(1.5f);
        plrInput.isInEvent = false;
        plrMovement.moveAllowed = true;
    }
}