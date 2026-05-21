using UnityEngine;
using UnityEngine.InputSystem;

public class PickupObject : MonoBehaviour
{
    public Transform holdPoint;

    private GameObject heldObject;
    private GameObject nearbyObject;

    public void OnPickup(InputValue value)
    {
        if (value.isPressed == false)
            return;

        if (heldObject == null && nearbyObject != null)
        {
            Pickup(nearbyObject);
        }
        else if (heldObject != null)
        {
            Drop();
        }
    }

    void Pickup(GameObject obj)
    {
        heldObject = obj;

        Rigidbody rb = heldObject.GetComponent<Rigidbody>();

        rb.isKinematic = true;
        rb.detectCollisions = false;
        rb.useGravity = false;

        heldObject.transform.SetParent(holdPoint);

        if (heldObject.CompareTag("Sword"))
        {
            heldObject.transform.localPosition = Vector3.zero;
            heldObject.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
        }
        else
        {
            heldObject.transform.localPosition = Vector3.zero;
            heldObject.transform.localRotation = Quaternion.identity;
        }
    }

  void Drop()
{
    Rigidbody rb = heldObject.GetComponent<Rigidbody>();

    heldObject.transform.SetParent(null);

    Vector3 dropPosition = transform.position + transform.forward * 1f;
    dropPosition.y = transform.position.y + 0.5f;

    heldObject.transform.position = dropPosition;

    rb.isKinematic = false;
    rb.detectCollisions = true;
    rb.useGravity = true;

    // lanzar lejos hacia enfrente y un poco hacia arriba
    rb.AddForce((transform.forward + Vector3.up * 0.4f) * 15f, ForceMode.Impulse);

    heldObject = null;
}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickable") || other.CompareTag("Sword"))
        {
            nearbyObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pickable") || other.CompareTag("Sword"))
        {
            nearbyObject = null;
        }
    }
}