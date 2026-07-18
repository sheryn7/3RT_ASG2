using UnityEngine;

public class Teleporting : MonoBehaviour
{
    public Transform teleportTarget;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterController controller = other.GetComponent<CharacterController>();

            if (controller != null)
            {
                controller.enabled = false;

                other.transform.position = teleportTarget.position;
                other.transform.rotation = teleportTarget.rotation;

                controller.enabled = true;
            }
            else
            {
                other.transform.position = teleportTarget.position;
                other.transform.rotation = teleportTarget.rotation;
            }
        }
    }
}