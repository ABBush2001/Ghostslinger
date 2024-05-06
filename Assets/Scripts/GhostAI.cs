using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostAI : MonoBehaviour
{
    /*private GameObject player;
    private GameObject ghostSpawner;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        ghostSpawner = GameObject.FindWithTag("GameController");
        StartCoroutine(destroyGhost());
    }

    private void FixedUpdate()
    {
        if (this.gameObject.tag == "Ghost")
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, 0.1f);
        }
        else if(this.gameObject.tag == "HatchetGhost")
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, 0.2f);
        }
        else if(this.gameObject.tag == "DevilGhost")
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, 0.05f);
        }
    }*/

    [SerializeField] private GameObject player;
    [SerializeField] private NavMeshAgent agent;
    private GameObject ghostSpawner;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        ghostSpawner = GameObject.FindWithTag("GameController");
        StartCoroutine(destroyGhost());
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);
    }

    IEnumerator destroyGhost()
    {
        yield return new WaitForSeconds(60);
        ghostSpawner.GetComponent<GhostSpawner>().ghostCounter -= 1;
        Destroy(this.gameObject);
    }
}
