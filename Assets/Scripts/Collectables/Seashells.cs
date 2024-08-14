using UnityEngine;

public class Seashells : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Collectables collectables = other.GetComponent<Collectables>();

        if (collectables != null)
        {
            collectables.SeashellsCollected();
            gameObject.SetActive(false);
        }
    }
}
