using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // This method will be called when the player completes the level
    public void LoadNextScene()
    {
        // Get the current active scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Check if there is another scene after the current one
        if (currentSceneIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            // Load the next scene in the Build Settings
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else
        {
            // If there are no more scenes, load the "Win" scene
            SceneManager.LoadScene("WinMenu");  
        }
    }
}


/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    //[SerializeField] Animator transitionAnim;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void NextLevel()
    {
        //StartCoroutine(LoadLevel());
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(2);

    }

    /*IEnumerator LoadLevel()
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        transitionAnim.SetTrigger("Start");

    
    }
}
*/