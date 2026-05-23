using System.Collections.Generic;
using UnityEngine;

public class CameraObstacleFade : MonoBehaviour
{
    public Transform player;

    public Material transparentMaterial;

    private Dictionary<Renderer, Material[]> originalMaterials =
        new Dictionary<Renderer, Material[]>();

    private List<Renderer> currentHidden =
        new List<Renderer>();

    void Update()
    {
        // Restaurar materiales originales
        foreach (Renderer r in currentHidden)
        {
            if (r != null && originalMaterials.ContainsKey(r))
            {
                r.materials = originalMaterials[r];
            }
        }

        currentHidden.Clear();

        Vector3 direction =
            player.position - transform.position;

        float distance =
            Vector3.Distance(transform.position, player.position);

        RaycastHit[] hits =
            Physics.RaycastAll(
                transform.position,
                direction.normalized,
                distance
            );

        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.CompareTag("Obstacle"))
            {
                Renderer[] renderers =
                    hit.collider.GetComponentsInChildren<Renderer>();

                foreach (Renderer r in renderers)
                {
                    if (r != null)
                    {
                        if (!originalMaterials.ContainsKey(r))
                        {
                            originalMaterials[r] = r.materials;
                        }

                        Material[] transparentMats =
                            new Material[r.materials.Length];

                        for (int i = 0; i < transparentMats.Length; i++)
                        {
                            transparentMats[i] = transparentMaterial;
                        }

                        r.materials = transparentMats;

                        currentHidden.Add(r);
                    }
                }
            }
        }
    }
}