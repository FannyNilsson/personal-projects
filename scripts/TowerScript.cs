using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    public GameObject player;
    public GameObject[] platformPrefabs;
    public GameObject[] platformsInGame;
    private GameObject instance;
    private int platformsInGameSize;
    // Use this for initialization
    void Start ()
    {
        platformsInGame = GameObject.FindGameObjectsWithTag("TowerPiece");
        platformsInGameSize = platformsInGame.Length-1;
        AddTowerPiece(true);
    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    public void AddTowerPiece(bool start)
    {
        if(start)
        {
            int random = Random.Range(0, 3);
            if(random == 0)
            {
                instance = Instantiate(platformPrefabs[0], new Vector3(platformsInGame[platformsInGameSize].gameObject.transform.localPosition.x, platformsInGame[platformsInGameSize].gameObject.transform.localPosition.y + 7.1f, platformsInGame[platformsInGameSize].gameObject.transform.localPosition.z), new Quaternion(0, 0, 0, 0));
            }
            else if(random == 1)
            {
                instance = Instantiate(platformPrefabs[2], new Vector3(platformsInGame[platformsInGameSize].gameObject.transform.localPosition.x, platformsInGame[platformsInGameSize].gameObject.transform.localPosition.y + 7.1f, platformsInGame[platformsInGameSize].gameObject.transform.localPosition.z), new Quaternion(0, 0, 0, 0));
            }
            else if(random == 2)
            {
                instance = Instantiate(platformPrefabs[10], new Vector3(platformsInGame[platformsInGameSize].gameObject.transform.localPosition.x, platformsInGame[platformsInGameSize].gameObject.transform.localPosition.y + 7.1f, platformsInGame[platformsInGameSize].gameObject.transform.localPosition.z), new Quaternion(0, 0, 0, 0));
            }
			TowerPieceScript tps = instance.GetComponent<TowerPieceScript>();
			tps.player = player;
			tps.towerScript = this.gameObject;
			platformsInGame = GameObject.FindGameObjectsWithTag("TowerPiece");
			platformsInGameSize = platformsInGame.Length - 1;
        }
        else
        {
            int random = Random.Range(0, platformPrefabs.Length - 1);
            instance = Instantiate(platformPrefabs[random], new Vector3(platformsInGame[platformsInGameSize].gameObject.transform.localPosition.x, platformsInGame[platformsInGameSize].gameObject.transform.localPosition.y + 7.1f, platformsInGame[platformsInGameSize].gameObject.transform.localPosition.z), new Quaternion(0, 0, 0, 0));
            TowerPieceScript tps = instance.GetComponent<TowerPieceScript>();
            tps.player = player;
            tps.towerScript = this.gameObject;
            platformsInGame = GameObject.FindGameObjectsWithTag("TowerPiece");
            platformsInGameSize = platformsInGame.Length - 1;
        }
        
    }
}
