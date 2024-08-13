using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance { get; private set; }

    [Header("Internal Clock")]
    [SerializeField]
    GameTimeStamp timestamp;
    public float timeScale = 1.0f;

    [Header("Day and Night cycle")]
    //The transform of the directional light (sun)
    public Transform sunTransform;
    Vector3 sunAngle;

    //List of Objects to inform of changes to the time
    List<ITimeTracker> listeners = new List<ITimeTracker>();

    private void Awake()
    {
        //If there is more than one instance, destroy the extra
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            //Set the static instance to this instance
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Initialise the time stamp
        timestamp = new GameTimeStamp(1, 6, 0);
        StartCoroutine(TimeUpdate());

    }

    private void Update()
    {
        sunTransform.rotation = Quaternion.Slerp(sunTransform.rotation, Quaternion.Euler(sunAngle), 1f * Time.deltaTime);
    }


    IEnumerator TimeUpdate()
    {
        while (true)
        {
            Tick();

            yield return new WaitForSeconds(1 / timeScale);
        }

    }

    void Tick()
    {
        timestamp.UpdateClock();

        //Inform each of the listeners of the new time state 
        foreach (ITimeTracker listener in listeners)
        {
            listener.ClockUpdate(timestamp);
        }

        UpdateSunMovement();
    }

    //Day and night cycle
    void UpdateSunMovement()
    {

        //Convert the current time to minutes
        int timeInMinutes = GameTimeStamp.HoursToMinutes(timestamp.hour) + timestamp.minute;

        //during daytime
        //Sun moves .2 degrees in a minute
        //during nighttime
        //Sun moves .6 degrees in a minute
        //At midnight (0:00), the angle of the sun should be -90

        float sunAngle = 0;
        if(timeInMinutes <= 15 * 60) 
        {
            sunAngle = .2f * timeInMinutes;
        }
        else if(timeInMinutes > 15 * 60)
        {
            sunAngle = 180f + 0.6f * (timeInMinutes - (15 * 60));
        }

        //Apply the angle to the directional light
        //sunTransform.eulerAngles = new Vector3(sunAngle, 0, 0);
        this.sunAngle = new Vector3(sunAngle, 0, 0);
    }

    // function to skip time
    public void SkipTime(GameTimeStamp timeToSkipTo)
    {
        //Convert to minutes
        int timeToSkipInMinutes = GameTimeStamp.TimestampInMinutes(timeToSkipTo);
        Debug.Log("Time to skip to:" + timeToSkipInMinutes);
        int timeNowInMinutes = GameTimeStamp.TimestampInMinutes(timestamp);
        Debug.Log("Time now: " + timeNowInMinutes);

        int differenceInMinutes = timeToSkipInMinutes - timeNowInMinutes;
        Debug.Log(differenceInMinutes + " minutes will be advanced");

        //Check if the timestamp to skip to has already been reached
        if (differenceInMinutes <= 0) return;

        for (int i = 0; i < differenceInMinutes; i++)
        {
            Tick();
        }
    }

    //Get the timestamp
    public GameTimeStamp GetGameTimestamp()
    {
        //Return a cloned instance
        return new GameTimeStamp(timestamp);
    }


    //Handling Listeners

    //Add the object to the list of listeners
    public void RegisterTracker(ITimeTracker listener)
    {
        listeners.Add(listener);
    }

    //Remove the object from the list of listeners
    public void UnregisterTracker(ITimeTracker listener)
    {
        listeners.Remove(listener);
    }

}
