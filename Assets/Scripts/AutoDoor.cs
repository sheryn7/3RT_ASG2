using UnityEngine;

public class AutomaticDoor : MonoBehaviour
{
    [Header("Door Parts")]
    public Transform doorTop;
    public Transform doorBottom;

    [Header("Door Settings")]
    public float openDistance = 2.5f;
    public float openSpeed = 3f;

    private Vector3 topClosedPosition;
    private Vector3 bottomClosedPosition;

    private Vector3 topOpenPosition;
    private Vector3 bottomOpenPosition;

    private bool playerNearby = false;

    void Start()
    {
        // Remember original closed positions
        topClosedPosition = doorTop.localPosition;
        bottomClosedPosition = doorBottom.localPosition;

        // Calculate open positions
        topOpenPosition = topClosedPosition + Vector3.up * openDistance;
        bottomOpenPosition = bottomClosedPosition + Vector3.down * openDistance;
    }

    void Update()
    {
        if (playerNearby)
        {
            // Open door
            doorTop.localPosition = Vector3.Lerp(
                doorTop.localPosition,
                topOpenPosition,
                openSpeed * Time.deltaTime
            );

            doorBottom.localPosition = Vector3.Lerp(
                doorBottom.localPosition,
                bottomOpenPosition,
                openSpeed * Time.deltaTime
            );
        }
        else
        {
            // Close door
            doorTop.localPosition = Vector3.Lerp(
                doorTop.localPosition,
                topClosedPosition,
                openSpeed * Time.deltaTime
            );

            doorBottom.localPosition = Vector3.Lerp(
                doorBottom.localPosition,
                bottomClosedPosition,
                openSpeed * Time.deltaTime
            );
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }
}