using UnityEngine;
using UnityEngine.UI;

public class DialougeBehaviour : MonoBehaviour
{
    public static DialougeBehaviour instance;
    [Header("Dialouge Panel Settings")]
    [SerializeField] private CanvasGroup dialougePanel;
    [SerializeField] private Text speakerText;
    [SerializeField] private Text dialougeText;
    [SerializeField] private int activeDialougeID = 0;
    [SerializeField] private int activeStageID = 0;
    [SerializeField] private GameObject player;

    [Header("John Stage 1 Dialouge")]
    [SerializeField] private string johnLine1;
    [SerializeField] private string johnLine2;
    [SerializeField] private string johnLine3;

    [SerializeField] private string beanLine1;
    [SerializeField] private string beanLine2;

    private bool isDialougeActive = false;
    private int dialougeIndex = 0;

    private PlayerMovement plrMovement = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        plrMovement = player.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (!isDialougeActive)
        {
            return;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            NextDialouge();
        }
    }

    public void ToggleDialougePanel(bool state)
    {
        dialougePanel.interactable = state;
        dialougePanel.blocksRaycasts = state;
        dialougePanel.alpha = state ? 1 : 0;
        isDialougeActive = state;
    }

    public void StartDialouge(int npcID)
    {
        ToggleDialougePanel(true);

        if (npcID == 1)
        {
            activeDialougeID = 1;
            if (EventBehaviour.instance.isFirstDay)
            {
                StartJohnDialouge(1);
                activeStageID = 1;
            }
            else if (!EventBehaviour.instance.isFirstDay && EventBehaviour.instance.numberOfRepeatedDays == 1)
            {
                ///Stage 2
                ///activeStageID = 2
            }
            else if (!EventBehaviour.instance.isFirstDay && EventBehaviour.instance.numberOfRepeatedDays == 2)
            {
                ///Stage 3
                ///activeStageID = 3
            }
        }
    }

    public void StartJohnDialouge(int stage)
    {
        if (!isDialougeActive)
        {
            return;
        }

        if (stage == 1)
        {
            if (dialougeIndex == 0)
            {
                speakerText.text = "John:";
                dialougeText.text = johnLine1;
            }
            else if (dialougeIndex == 1)
            {
                speakerText.text = "Bean:";
                dialougeText.text = beanLine1;
            }
            else if (dialougeIndex == 2)
            {
                speakerText.text = "John:";
                dialougeText.text = johnLine2;
            }
            else if (dialougeIndex == 1)
            {
                speakerText.text = "Bean:";
                dialougeText.text = beanLine2;
            }
            else if (dialougeIndex == 1)
            {
                speakerText.text = "John:";
                dialougeText.text = johnLine3;
            }
            else
            {
                EndDialouge();
            }
            dialougeIndex++;
        }
    }

    public void NextDialouge()
    {
        if (activeDialougeID == 1)
        {
            StartJohnDialouge(activeStageID);
        }
    }

    private void EndDialouge()
    {
        ToggleDialougePanel(false);

        speakerText.text = "";
        dialougeText.text = "";
        dialougeIndex = -1;

        plrMovement.isFroze = false;
    }
}