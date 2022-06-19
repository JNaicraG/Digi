using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Peça:MonoBehaviour
{
    [Tooltip("ID da sílaba")]
    public int id;
    [Tooltip("Sílaba que será exibida")]
    public string sil;
    [Tooltip("O texto da própria peça (Text TMP)")]
    public TMP_Text textMP;
    // Start is called before the first frame update 
    public void AlterarTexto()
    {
        if (sil != null)
            textMP.text = (string)sil;
        else
            Debug.Log("Silaba vazia, nao pode ser usada para gerar Bloco de Resposta");
        //Debug.Log("SIL: " + sil);
    }
}
