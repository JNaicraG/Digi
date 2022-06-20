using System.Collections;
using UnityEngine.UIElements;
using TMPro;
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
    /*
    public menuConfigIndex;
    public menuConfigVolume;
    public menuConfigNome;
    private void SetConfiguraçao()
    {
        if (configuraçao.indexFonteTamanho > 0 && configuraçao.indexFonteTamanho < 0)
            menuConfigIndex = configuraçao.indexFonteTamanho;
        if (configuraçao.volume > -80 && configuraçao.volume < 0)
            menuConfigVolume = configuraçao.volume;
        if (configuraçao.nomeJogador != null)
            menuConfigNome = configuraçao.nomeJogador;
    }

    */
}
