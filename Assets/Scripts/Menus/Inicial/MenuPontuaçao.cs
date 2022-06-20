using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPontuaçao : MonoBehaviour
{
    public GameObject menuPontuaçao, menuInicial;
    public Pontuaçao pontuaçao;

    public void Voltar()
    {
        menuPontuaçao.SetActive(false);
        menuInicial.SetActive(true);
    }
}
