using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    public NPC.Symbol symbol;
    private bool _canBeOpened = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        _canBeOpened = true;
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        _canBeOpened = false;
    }

    private void Update()
    {
        //PUT TS IN THE GAME MANAGER UNDER SOME WIN CONDITION
        if (_canBeOpened && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("GAME MANAGER: " + GameManager.instance.GreatestSymbol());
            if (GameManager.instance.GreatestSymbol() == symbol)
            {
                Debug.Log("YOU WON!!!");
                GameManager.instance.gui.text = "YOU WON!";
                GameManager.instance.gui.gameObject.SetActive(true);
            }
            else
            {
                Debug.Log("UNC LOST THE PLOT");
                GameManager.instance.gui.text = "YOU LOST!";
                GameManager.instance.gui.gameObject.SetActive(true);
            }
            Debug.Log("DOOR HAS BEEN OPENED");
        }
    }
}
