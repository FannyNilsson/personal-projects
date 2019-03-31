using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPieceScript : MonoBehaviour
{
    public GameObject player;
    public GameObject towerScript;
    public bool activated;
    private TowerScript tS;

	// Use this for initialization
	void Start ()
    {
        activated = false;
        tS = towerScript.GetComponent<TowerScript>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && activated == false)
        {
            activated = true;
            tS.AddTowerPiece(false);
        }
    }
}
