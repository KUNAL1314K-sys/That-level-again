using UnityEngine;

public class ClickPressurePlate : MonoBehaviour
{
    public Transform gate;
    public float gateMoveDistance = 2f;

    private bool opened = false;

    void OnMouseDown()
    {
        if (opened) return;

        // Press plate down
        Vector3 platePos = transform.position;
        platePos.y -= 0.1f;
        transform.position = platePos;

        // Open gate
        Vector3 gatePos = gate.position;
        gatePos.x += gateMoveDistance;
        gate.position = gatePos;

        opened = true;
    }
}
