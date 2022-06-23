using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPontuaçao : MonoBehaviour
{
    public GameObject menuPontuaçao, menuInicial,bloco,content;
    //public Pontos pontos;
    public Pontuaçao pontuaçao;

    public void Voltar()
    {
        menuPontuaçao.SetActive(false);
        menuInicial.SetActive(true);
    }
    private List<GameObject> list;
    private void OnEnable()
    {
        list = new List<GameObject>();
        foreach(var n in pontuaçao.list)
        {
            GameObject theTile = Instantiate(bloco, transform);
            theTile.transform.parent = content.transform;
            theTile.GetComponent<pontosTemplate>().nome.text = n.nomeJogador;
            theTile.GetComponent<pontosTemplate>().pontuaçao.text = n.pontuaçao.ToString();
            theTile.GetComponent<pontosTemplate>().niveis.text = n.round.ToString();
            theTile.GetComponent<pontosTemplate>().tempo.text = n.tempoTotal.ToString();
            list.Add(theTile);
        }
    }

    private void OnDisable()
    {
        foreach (var n in list)
            Destroy(n);
        list.Clear();
    }

}

