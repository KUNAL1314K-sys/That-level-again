using System.Collections;
using UnityEngine;

public class PressurePlatelv5 : MonoBehaviour
{
    public Transform gate;

    public float pressDistance = 0.31f;
    public float gateMoveDistance = 2f;
    public int requiredPresses = 1;

    private Vector3 originalPos;
    private int pressCount = 0;
    private bool gateOpened = false;
    private bool isPressed = false;

    void Start()
    {
        originalPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isPressed)
        {
            isPressed = true;

            // Move plate down
            Vector3 pos = transform.position;
            pos.y = originalPos.y - pressDistance;
            transform.position = pos;

            pressCount++;

            // Open gate after 1 presses
            if (pressCount >= requiredPresses && !gateOpened)
            {
                Vector3 gatePos = gate.position;
                gatePos.x += gateMoveDistance;
                gate.position = gatePos;

                gateOpened = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ResetPlate());
        }
    }

    IEnumerator ResetPlate()
    {
        yield return new WaitForSeconds(1f);

        // Return to original position
        transform.position = originalPos;

        isPressed = false;
    }
}