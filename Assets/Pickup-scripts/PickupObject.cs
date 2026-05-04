using UnityEngine;

public class PickupObject : MonoBehaviour
{
    public Transform holdPoint; // punto donde se sostendrá el objeto
    private GameObject heldObject;
    private GameObject nearbyObject; // objeto que está tocando el Player

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObject == null && nearbyObject != null)
                Pickup(nearbyObject);
            else if (heldObject != null)
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

    // 🔥 Si es espada la acomodamos diferente
    if (heldObject.CompareTag("Sword"))
    {
        heldObject.transform.localPosition = Vector3.zero;
        heldObject.transform.localRotation = Quaternion.identity;

        // Ajusta estos valores hasta que quede bien en la mano
        heldObject.transform.localPosition = new Vector3(0f, 0f, 0f);
        heldObject.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
    }
    else
    {
        // Para cajas y demás objetos
        heldObject.transform.position = holdPoint.position;
        heldObject.transform.rotation = holdPoint.rotation;
    }
}

void Drop()
{
    Rigidbody rb = heldObject.GetComponent<Rigidbody>();
    rb.isKinematic = true;  // bloquea física
    rb.detectCollisions = true;
    rb.useGravity = false;

    heldObject.transform.SetParent(null);

    // Posición sobre el plano
    Vector3 dropPosition = transform.position + transform.forward * 1f;
    dropPosition.y = 0.5f; // altura sobre el suelo
    heldObject.transform.position = dropPosition;

    heldObject = null;
}


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickable"))
            nearbyObject = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pickable"))
            nearbyObject = null;
    }
}
