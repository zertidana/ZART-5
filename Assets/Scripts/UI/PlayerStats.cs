using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement; 

public class PlayerStats : MonoBehaviour
{
    public List<int> maxStats; //0 is oxygen, 1 is food, 2 is thirst, 3 is health
    List<int> currentStats;

    Coroutine oxygenCo;
    Coroutine hungerCo;

    bool swimCheck;

    [Header("UI")]
    public List<Slider> statBars;
    public List<TextMeshProUGUI> statNums;

    // Start is called before the first frame update
    void Start()
    {
        //initialize currentStats to the max amount
        currentStats = new List<int>(maxStats);

        //start decreasing the values of hunger and thirst
        hungerCo = StartCoroutine(DecreaseStats(1, 20, 1));

        //initialize the statBars
        for (int i = 0; i < maxStats.Count; i++)
        {
            statBars[i].maxValue = maxStats[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerController.isSwimming && swimCheck == true)
        {
            swimCheck = false;
            StopCoroutine(oxygenCo);
            ChangeStat(0, maxStats[0]);
        }
        if (PlayerController.isSwimming && swimCheck == false)
        {
            swimCheck = true;
            oxygenCo = StartCoroutine(DecreaseStats(0, 3, 3));
        }

        //display current stats in stat UI
        for(int i = 0; i < maxStats.Count; i++)
        {
            statBars[i].value = currentStats[i];
            statNums[i].text = currentStats[i].ToString();
        }

        // Check if health or oxygen reaches zero
        if (currentStats[0] <= 0 || currentStats[3] <= 0)
        {
            GameOver();
        }
    }

    IEnumerator DecreaseStats(int stat, int interval, int amount)
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);

            if(currentStats[stat] > 0)
            {
                currentStats[stat] = Mathf.Max(currentStats[stat] - amount, 0);
            }
        }
    }

    public void ChangeStat(int stat, int refreshAmount)
    {
        if(refreshAmount > 0)
        {
            currentStats[stat] = Mathf.Min(currentStats[stat] + refreshAmount, maxStats[stat]);
        }
        else
        {
            currentStats[stat] = Mathf.Max(currentStats[stat] + refreshAmount, 0);
        }
    }

    void GameOver()
    {
        // Load the Game Over scene
        SceneManager.LoadScene(4); 
    }
}
