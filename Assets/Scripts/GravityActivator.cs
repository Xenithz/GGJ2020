using UnityEngine;

public class GravityActivator : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pillar"))
        {
            Rigidbody rigidBody = other.GetComponent<Rigidbody>();
            rigidBody.constraints &= ~RigidbodyConstraints.FreezePositionY;
            rigidBody.isKinematic = false;
        }
    }



}