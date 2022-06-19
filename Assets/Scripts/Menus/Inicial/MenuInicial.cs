using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInicial : MonoBehaviour
{

    public GameObject menuInicial, menuPontuaçao, menuConfiguraçao, menuSeleçaoDeNivel;
    public void Jogar()
    {
        TrocarMenu(menuSeleçaoDeNivel);
    }

    public void Pontuaçao()
    {
        TrocarMenu(menuPontuaçao);
    }

    public void Configuraçao()
    {
        TrocarMenu(menuConfiguraçao);
    }

    private void TrocarMenu(GameObject menu)
    {
        menuInicial.SetActive(false);
        menu.SetActive(true);
    }

    public Configuraçao configuraçao;
    private void Start()
    {
        configuraçao.CarregarDados();
    }


}
