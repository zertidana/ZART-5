using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Seashells : MonoBehaviour
{
    TMPro.TMP_Text text;
    int count;

    void Awake ()
    {
        text = GetComponent<TMPro.TMP_Text>();
    }

    void Start() => UpdateCount();
    void OnEnable() => Collectables.OnCollected += OnCollectableCollected;
    void OnDisable() => Collectables.OnCollected -= OnCollectableCollected;

    void OnCollectableCollected()
    {
        count++;
        UpdateCount();

        if (count >= 10)
        {
            WinScreen();
        }
    }

    void UpdateCount()
    {
        text.text = $"{count} / {Collectables.total}";
    }

    void WinScreen()
    {
        SceneManager.LoadScene(4);
    }
/*
{
}
    private void OnTriggerEnter(Collider other)
    {
        Collectables collectables = other.GetComponent<Collectables>();

        if (collectables != null)
        {
            collectables.SeashellsCollected();
            gameObject.SetActive(false);
        }
    }

*/


}
