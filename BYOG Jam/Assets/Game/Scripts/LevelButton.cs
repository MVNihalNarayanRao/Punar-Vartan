using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public int number;
    public Text levelNumberText;
    private Button button;

    public void Init(int id, bool unlocked)
    {
        number = id;
        levelNumberText.text = (number).ToString();

        button = GetComponent<Button>();
        button.onClick.AddListener(() => FindObjectOfType<MainMenuScript>().LoadLevel(number));
        if(!unlocked)
        {
            button.interactable = false;
        }
    }
}
