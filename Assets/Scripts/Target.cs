using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;
    public ParticleSystem explosionParticle;
    public int pointValue;

    private float minSpeed=10;
    private float maxSpeed=15;
    private float maxTorque=10;
    private float xRange=4;
    private float yRange=-1;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager= GameObject.Find("Game Manager").GetComponent<GameManager>();
        targetRb.AddForce(RandomForce(),ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(),RandomTorque(), ForceMode.Impulse);

        transform.position= RandomSpawnPosition();
    }

    // Update is called once per frame
    void Update()
    {
    /*    if (transform.position.y<-5)
        {
            Destroy(gameObject);
        }*/
    }

    private void OnMouseDown()
    {
        if (GameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
    }


    private void OnTriggerEnter(Collider other)    
    { 
        Destroy(gameObject);
        if(!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }  


    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed,maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque,maxTorque);
    }

    Vector3 RandomSpawnPosition()
    {
        return new Vector3(Random.Range(-xRange,xRange),yRange);
    }

}
