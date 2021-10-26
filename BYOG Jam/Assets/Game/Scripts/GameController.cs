using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using BayatGames.SaveGameFree;

public class GameController : MonoBehaviour
{
    public bool patienceLavel;

    [Header("Door")]
    public GameObject doorObj;
    public Material doorMat;
    public Color doorDefaultColor;
    public Color doorUnlockedColor;
    public AudioClip doorOpenClip;
    private AudioSource doorSource;

    private void Start()
    {
        doorMat.color = doorDefaultColor;
        doorSource = gameObject.AddComponent<AudioSource>();
        doorSource.playOnAwake = false;

        if(patienceLavel)
        {
            Invoke(nameof(KeyCollected), 10f);
        }
    }

    public void NextLevel()
    {
        // if(SceneManager.sceneCount <= SceneManager.GetActiveScene().buildIndex + 1)
        // return;

        if(SceneManager.GetActiveScene().buildIndex == 16)
        return;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        SaveGame.Save<int>("LevelUnlock", SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void KeyCollected()
    {
        StartCoroutine(DoorOpen());
    }

    private IEnumerator DoorOpen()
    {
        yield return new WaitForSeconds(0.75f);
        doorSource.clip = doorOpenClip;
        doorSource.Play();

        float timer = 1f;
        while(timer >= 0f)
        {
            timer -= Time.deltaTime;
            Color doorCol = Color.Lerp(doorDefaultColor, doorUnlockedColor, 1f - timer);
            doorMat.color = doorCol;
            yield return null;          
        }

        doorObj.SetActive(false);
        yield break;
    }
}
