using UnityEngine;
using UnityEngine.Events;

public class Collectables : MonoBehaviour
{
    public int NumberOfSeashells { get; private set; }

    public UnityEvent<Collectables> OnSeashellsCollected;

    public void SeashellsCollected()
    {
        NumberOfSeashells++;
        OnSeashellsCollected.Invoke(this);
    }
}