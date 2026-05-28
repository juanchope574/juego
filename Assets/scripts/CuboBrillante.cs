using UnityEngine;

public class CuboBrillante : MonoBehaviour
{
    private Material mat;

    public Color colorBrillo = Color.cyan;
    public float intensidadMax = 5f;
    public float velocidad = 2f;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        float intensidad = Mathf.PingPong(Time.time * velocidad, intensidadMax);

        Color colorFinal = colorBrillo * intensidad;

        mat.SetColor("_EmissionColor", colorFinal);
    }
}