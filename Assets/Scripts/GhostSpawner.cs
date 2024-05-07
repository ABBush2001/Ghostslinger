using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    public GameObject ghost;
    public GameObject hatchetGhost;
    public GameObject devilGhost;

    public int ghostCounter;

    public GameObject eventSystem;

    private GameObject levelManager;

    private bool stopUpdate = false;

    // Start is called before the first frame update
    void Start()
    {
        ghostCounter = 0;
        levelManager = GameObject.Find("LevelManager");
    }

    // Update is called once per frame
    void Update()
    {
        if(eventSystem.GetComponent<LevelOpening>().getAnimFinished() && stopUpdate == false)
        {
            StartCoroutine(GhostSpawn());
            stopUpdate = true;
        }
    }

    IEnumerator GhostSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.RandomRange(1, 3));

            if (ghostCounter < 20)
            {

                //randomly generate ghost types based on level
                int randGhost;

                if(levelManager.GetComponent<LevelManager>().getLevel() == 1)
                {
                    randGhost = 1;
                }
                else if(levelManager.GetComponent<LevelManager>().getLevel() == 2)
                {
                    randGhost = Random.Range(1, 3);
                }
                else
                {
                    randGhost = Random.Range(1, 4);
                }
                
                GameObject g = new GameObject();

                if (randGhost == 1)
                {
                    g = Instantiate(ghost, this.transform.parent);
                }
                else if(randGhost == 2)
                {
                    g = Instantiate(hatchetGhost, this.transform.parent);
                }
                else if(randGhost == 3)
                {
                    g = Instantiate(devilGhost, this.transform.parent);
                }

                g.transform.SetLocalPositionAndRotation(new Vector3(this.transform.position.x + Random.RandomRange(-5, 5), 0, this.transform.position.z + Random.RandomRange(-5, 5)), new Quaternion());
            }
        }
    }
}
