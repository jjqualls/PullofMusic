using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialText : MonoBehaviour
{
    private float shownTime = 0f;
    [SerializeField] private TextMeshProUGUI movementText;


    private void OnTriggerEnter(Collider other)
    {
        if(movementText != null)
        {
            movementText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(movementText != null)
        {
            movementText.gameObject.SetActive(false);
        }
    }

}
