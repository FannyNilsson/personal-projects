using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private Jump playerScript;
    private Highscore hsScript;

    void Start ()
    {
        playerScript = FindObjectOfType<Jump>();
        hsScript = FindObjectOfType<Highscore>();
    }
	

	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider col)
    {
        if(gameObject.tag == "ChickenPower")
        {
            Highscore.powerUpPoints = Highscore.powerUpPoints + 5;
            Destroy(gameObject);
        }
        else if(gameObject.tag == "ChipsPower")
        {
            Highscore.powerUpPoints = Highscore.powerUpPoints + 10;
            Destroy(gameObject);
        }
    }
}
