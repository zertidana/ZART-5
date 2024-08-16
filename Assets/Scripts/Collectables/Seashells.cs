using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Seashells : MonoBehaviour
{
    TMPro.TMP_Text text;
    int count;

    private SceneController sceneController;

    void Awake ()
    {
        text = GetComponent<TMPro.TMP_Text>();
    }

    //void Start() => UpdateCount();
    void OnEnable() => Collectables.OnCollected += OnCollectableCollected;
    void OnDisable() => Collectables.OnCollected -= OnCollectableCollected;

    public void Start()
    {
        UpdateCount();
        sceneController = FindObjectOfType<SceneController>();
    }

    void OnCollectableCollected()
    {
        count++;
        UpdateCount();

        if (count >= 3)//Collectables.total)
        {
            sceneController.LoadNextScene();
        }

    }

    void UpdateCount()
    {
        text.text = $"{count} / {Collectables.total}";
    }


}
