using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public ParticleSystem pickUpParticle;
    public AudioSource keyCollectSource;

    public bool findTheOneLevel;
    public bool genuineKey;

    private void OnTriggerEnter(Collider other)
    {
        if(findTheOneLevel)
        {
            if(other.transform.root.tag == "Player")
            {
                pickUpParticle.transform.SetParent(null, false);
                pickUpParticle.transform.position = transform.position;
                pickUpParticle.Play();

                keyCollectSource.Play();

                Destroy(pickUpParticle, 3f);

                if(genuineKey) FindObjectOfType<GameController>().KeyCollected();
                Destroy(gameObject);            
            }
            return;
        }

        if(other.transform.root.tag == "Player")
        {
            pickUpParticle.transform.SetParent(null, false);
            pickUpParticle.transform.position = transform.position;
            pickUpParticle.Play();

            keyCollectSource.Play();

            Destroy(pickUpParticle, 3f);

            FindObjectOfType<GameController>().KeyCollected();
            Destroy(gameObject);            
        }
    }
}
