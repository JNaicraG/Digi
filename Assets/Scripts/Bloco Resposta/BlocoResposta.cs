using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoResposta : MonoBehaviour
{
    [Tooltip("ID da s�laba")]
    public int id;
    [Tooltip("S�laba que ser� exibida")]
    public string sil;
    // Start is called before the first frame update
    public bool blocoCorreto = false;
    public bool BlocoCorreto { get => blocoCorreto; }
    [Tooltip("Velocidade para pe�a tomar posi�ao do bloco de resposta correto ao entrar na colisao")]
    private float _speed = 100f;
    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("Objeto entrou com nome: " + collision.gameObject.name.ToString());
        if (collision.gameObject.CompareTag("Pe�a") && !blocoCorreto) //se o objeto que entrou atualmente no bloco for do tipo PE�A
        {
            GameObject obj = collision.gameObject;
            if ((obj.GetComponent<Pe�a>().id == id || obj.GetComponent<Pe�a>().sil == sil) && !obj.GetComponent<Mover>().click) //se o id/silaba for correto
            {
                //Debug.Log("Bloco Correto");
                //Debug.Log("Silaba Bloco: " + sil);
                //Debug.Log("Silaba Pe�a: " + obj.GetComponent<Pe�a>().sil);
                obj.GetComponent<Mover>().podeMover = false;
                blocoCorreto = true; //bloco/pe�a correto
                                      //obj.transform.position = Vector3.Lerp(obj.transform.position, transform.position, Time.deltaTime); //a posi�ao dele se torna a deste bloco

                obj.transform.localPosition = Vector3.MoveTowards(obj.transform.localPosition, transform.localPosition + new Vector3(0, 2.42f, 0), _speed * Time.deltaTime); //0,4 no y t� compensando uma altura ae
                //Vector3.MoveTowards(obj.transform.position, transform.position, _speed * Time.deltaTime);
            }
            else
                blocoCorreto = false;
        }
    }

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Objeto entrou com nome: " + collision.gameObject.name.ToString());
        if (collision.gameObject.CompareTag("Pe�a") && !_blocoCorreto) //se o objeto que entrou atualmente no bloco for do tipo PE�A
        {
            GameObject obj = collision.gameObject;
            if (obj.GetComponent<Pe�a>().id == id || obj.GetComponent<Pe�a>().sil == sil) //se o id/silaba for correto
            {
                Debug.Log("Bloco Correto");
                Debug.Log("Silaba Bloco: " + sil);
                Debug.Log("Silaba Pe�a: " + obj.GetComponent<Pe�a>().sil);
                obj.GetComponent<Mover>().podeMover = false;
                _blocoCorreto = true; //bloco/pe�a correto
                                      //obj.transform.position = Vector3.Lerp(obj.transform.position, transform.position, Time.deltaTime); //a posi�ao dele se torna a deste bloco

                obj.transform.localPosition = Vector3.MoveTowards(obj.transform.localPosition,transform.localPosition + new Vector3(0, 0.4f, 0), _speed); //0,4 no y t� compensando uma altura ae
                //Vector3.MoveTowards(obj.transform.position, transform.position, _speed * Time.deltaTime);
            }
            else
                _blocoCorreto = false;
        }
    }
    */

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pe�a")) //se o objeto que entrou atualmente no bloco for do tipo PE�A
        {
            GameObject obj = collision.gameObject;
            if (obj.GetComponent<Pe�a>().id == id) //se o id/silaba for correto
            {
                // if (_blocoCorreto)
                blocoCorreto = false;
            }
        }
    }
}


