using System.Collections;
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


}
