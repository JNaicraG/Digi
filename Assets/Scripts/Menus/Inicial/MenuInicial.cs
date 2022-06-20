using System.Collections;
using UnityEngine.UIElements;
using TMPro;
using System.Collections.Generic;
using UnityEngine;

public class MenuInicial : MonoBehaviour
{

    public GameObject menuInicial, menuPontua�ao, menuConfigura�ao, menuSele�aoDeNivel;
    public void Jogar()
    {
        TrocarMenu(menuSele�aoDeNivel);
    }

    public void Pontua�ao()
    {
        TrocarMenu(menuPontua�ao);
    }

    public void Configura�ao()
    {
        TrocarMenu(menuConfigura�ao);
    }

    private void TrocarMenu(GameObject menu)
    {
        menuInicial.SetActive(false);
        menu.SetActive(true);
    }

    public Configura�ao configura�ao;
    private void Start()
    {
        configura�ao.CarregarDados();
    }
    /*
    public menuConfigIndex;
    public menuConfigVolume;
    public menuConfigNome;
    private void SetConfigura�ao()
    {
        if (configura�ao.indexFonteTamanho > 0 && configura�ao.indexFonteTamanho < 0)
            menuConfigIndex = configura�ao.indexFonteTamanho;
        if (configura�ao.volume > -80 && configura�ao.volume < 0)
            menuConfigVolume = configura�ao.volume;
        if (configura�ao.nomeJogador != null)
            menuConfigNome = configura�ao.nomeJogador;
    }

    */
}
