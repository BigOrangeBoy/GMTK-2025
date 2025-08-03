using UnityEngine;
using UnityEngine.UI;

public class QuestBehaviour : MonoBehaviour
{
    public static QuestBehaviour instance;

    public Text questBox;

    [TextArea(2, 6)]
    [SerializeField] private string day1Quest2;

    [TextArea(2, 6)]
    [SerializeField] private string day1Quest3;

    [TextArea(2, 6)]
    [SerializeField] private string day1Quest4;

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
    }

    public void ProcessFirstQuest()
    {
        Debug.Log("Processing Quest!");
        questBox.text = day1Quest2;
    }
}