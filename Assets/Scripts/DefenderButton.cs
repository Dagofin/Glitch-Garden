using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;

    private void OnMouseDown()
    {
        //assemble collection of all buttons
        var buttons = FindObjectsOfType<DefenderButton>();
        //set all buttons to gray
        foreach(DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(63,63,63,255);
        }
        //set clicked button to white
        GetComponent<SpriteRenderer>().color = Color.white;
        //set the currently selected defender to the spawner
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
    }
}
