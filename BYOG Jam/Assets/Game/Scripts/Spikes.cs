using UnityEngine;
using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.root.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            if(FindObjectOfType<GameBGM>()) GameBGM.instance.PlayDeathClip();
        }
    }
}
