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

        if (count >= 3)//Collectables.total)
        {
            SceneController.instance.NextLevel();
        }

    }

    void UpdateCount()
    {
        text.text = $"{count} / {Collectables.total}";
    }


}
