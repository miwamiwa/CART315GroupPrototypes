using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformtrigger : MonoBehaviour
{
    public GameObject targetplatform;
    public BallSpawner spawner = null;
    public GameObject arrow;
    public GameObject ArrowTrigger;

    public int numberOfArrowTriggers = 10;

    float nextTime = 0f;
    public float interval = 8f;
    public float displayTime = 3f;
    bool displayed = false;
    Quaternion beamrot;

    // Start is called before the first frame update
    void Start()
    {
        arrow = GameObject.Find("arrow");
     //   arrow.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
     //   arrow.transform.rotation = beamrot;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "ThirdPersonController_LITE")
        {
            for(int i=0; i< numberOfArrowTriggers; i++)
            {
                GameObject newArrowTrigger = Instantiate(ArrowTrigger, transform.position, Quaternion.identity);
                Vector3 bounds = gameObject.GetComponent<Collider>().bounds.size;
                Vector3 pos = GameObject.Find("middlepoint").transform.position;
                Vector2 randpos = Random.insideUnitCircle * bounds.z * .3f;

                newArrowTrigger.transform.position = new Vector3(
                    pos.x + randpos.x,
                    pos.y + bounds.y + 2f,
                    pos.z + randpos.y
                    );
            }
            

            // platform fall.
            targetplatform
                .GetComponent<fallingscript>()
                .falling = true;
                Renderer renderer = GetComponent<Renderer>();

            spawner.SpawnBalls(renderer.material.color);
        }
    }
}
