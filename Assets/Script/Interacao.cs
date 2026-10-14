using UnityEngine;
using TMPro;

public class Interacao : MonoBehaviour
{
    public float alcance = 2.5f;
    public float alturaDoOlho = 1.5f;
    public TextMeshProUGUI textoDica;
    public TextMeshProUGUI textoMensagem;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (textoDica != null) textoDica.text = "";
        if (textoMensagem != null) textoMensagem.text = "";

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 origem = transform.position + Vector3.up * alturaDoOlho;
        Debug.DrawRay(origem, transform.forward * alcance, Color.red);

        Porta porta = null;
        RaycastHit acerto;

        if (Physics.Raycast(origem, transform.forward, out acerto, alcance))
        {
            porta = acerto.collider.GetComponentInParent<Porta>();
        }

        if (porta != null && !porta.aberta)
        {
            if (textoDica != null) textoDica.text = "Pressione E para interagir";
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (textoMensagem != null) textoMensagem.text = porta.Interagir() ;
            }
            else
            {
            if (textoDica != null) textoDica.text = "";
            
            }
        }
        
    }
}
