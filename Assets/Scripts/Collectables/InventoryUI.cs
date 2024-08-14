using UnityEngine;
using TMPro;


public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI Text;

    // Start is called before the first frame update
    void Start()
    {
        seashellText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateSeashellText(Collectables collectables)
    {
        seashellText.text = collectables.NumberOfSeashells.ToString();
    }
}
