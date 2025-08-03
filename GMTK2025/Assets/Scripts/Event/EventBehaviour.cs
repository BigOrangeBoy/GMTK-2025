using UnityEngine;

public class EventBehaviour : MonoBehaviour
{
    public static EventBehaviour instance;

    [Header("Data")]
    public bool isFirstDay = true;
    public int numberOfRepeatedDays = 0;

    [Header("Events Stats")]
    public bool hasBoughtGroceries = false;
    public bool hasTalkedWithJohn = false;
    public bool hasDoneWorkout = false;
    public bool hasLitBurner = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Event Behaviour Instance Already Exists!");
            Destroy(this);
        }

        DontDestroyOnLoad(gameObject);
    }
}