using UnityEngine;
using UnityEngine.SceneManagement;
using BayatGames.SaveGameFree;

public class MainMenuScript : MonoBehaviour
{
    public GameObject levelButtonPrefab;
    public Transform levelButtonParent;
    public int numberForLevels = 15;

    private void Start()
    {
        if(SaveGame.Load<int>("First") == 0)
        {
            SaveGame.Clear();
            SaveGame.Save<int>("LevelUnlock", 1);
            SaveGame.Save<int>("First", 1);
        }

        for(int i = 0; i < numberForLevels; i++)
        {
            GameObject levelButIns = Instantiate(levelButtonPrefab, Vector3.zero, Quaternion.identity, levelButtonParent);
            bool unlock = SaveGame.Load<int>("LevelUnlock") - 1 >= i;
            levelButIns.GetComponent<LevelButton>().Init(i + 1, unlock);
        }        
    }

    public void LoadLevel(int number)
    {
        SceneManager.LoadScene(number);
    }
}
