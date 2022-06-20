using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{

    public GameObject menuPausa, menuGeral;
    public EstadoDoJogo estadoDoJogo;
    public Pontuaçao pontos;
    public void Pausar()
    {
        estadoDoJogo.jogoPausado = true;
        menuGeral.SetActive(true);
        menuPausa.SetActive(true);
    }

    public void Continuar()
    {
        estadoDoJogo.jogoPausado = false;
        menuPausa.SetActive(false);
        menuGeral.SetActive(false);
    }

    public void SelecionarNivel()
    {
        ControladorJogo.Instance.ResetarEstadosDoJogo();
        pontos.SalvarPontuaçao();
        menuPausa.SetActive(false);
        menuGeral.SetActive(false);
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }

    public void VolarAoInicio()
    {
        ControladorJogo.Instance.ResetarEstadosDoJogo();
        pontos.SalvarPontuaçao();
        menuPausa.SetActive(false);
        menuGeral.SetActive(false);
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }

}
