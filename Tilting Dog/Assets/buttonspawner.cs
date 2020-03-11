using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonspawner : MonoBehaviour
{
    public int buttonsAmount = 10;
    public GameObject button;
    public GameObject pepe;
    public float xrange = 5f;
    public float minfact = 0f;
    public float maxfact = 1f;
    public float minfact2 = 1f;
    public float maxfact2 = 1.1f;

    /*
     * 
     if (dir == 1)
                {
                    GameObject.Find("Button-emergency").transform.position = new Vector3(0f, -65f, -21f);
                    GameObject.Find("Button-emergency (1)").transform.position = new Vector3(0f, -51f, -2f);
                }
                else
                {
                    GameObject.Find("Button-emergency").transform.position = new Vector3(0f, -40f, -13f);
                    GameObject.Find("Button-emergency (1)").transform.position = new Vector3(0f, -48f, 8f);
                }
     * 
     * */
    // Start is called before the first frame update
    void Start()
    {
        SpawnButtons(-1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyButtons()
    {
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("spawnbutton");
        foreach (GameObject thing in buttons)
        {
            Destroy(thing);
        }

        GameObject[] balls = GameObject.FindGameObjectsWithTag("ball");
        foreach (GameObject thing in balls)
        {
           //if(Random.Range(0,1f)>0.5f) Destroy(thing);
        }
    }

    public void SpawnButtons(int dir)
    {
        for(int i=0; i<8; i++)
        {
            Vector3 position2;
            if (dir == 1) position2 = new Vector3(-xrange + i*2*xrange/8, -50f, 0f); 
            else position2 = new Vector3(-xrange + i * 2 * xrange / 8, -38f, -15f);
            
            Instantiate(button, position2, Quaternion.identity);
        }

        for(int i=0; i<buttonsAmount; i++)
        {
            Vector3 position;
            
            float fact = Random.Range(minfact, maxfact);

            if (dir == 1) position = new Vector3(Random.Range(-xrange, xrange), -51f - fact * (14f) + 2f, -2f - fact * 19f);
            else position = new Vector3(Random.Range(-xrange, xrange), -40f - fact * 8f + 2f, -13f + fact * 21f);
            
            Instantiate(pepe, position, Quaternion.identity);

        }

        buttonsAmount+=3;
    }
}
