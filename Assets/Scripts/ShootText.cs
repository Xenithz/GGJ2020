using UnityEngine;

public class ShootText : MonoBehaviour
{
    public GameObject brokenText;

    public float force;
    private Rigidbody rigidbody1;


    private void Start()
    {
        rigidbody1 = brokenText.GetComponent<Rigidbody>();
    }

    public void Shoot()
    {
        rigidbody1.isKinematic = false;
        rigidbody1.AddForce(transform.forward * force, ForceMode.Impulse);
    }
}