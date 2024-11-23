using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text creditText;
    private int credits = 0;

    void Start()
    {
        UpdateUI();
    }

    public void AddCredits(int amount)
    {
        credits += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (creditText != null)
        {
            creditText.text = $"Credits: {credits}";
        }
    }
}
