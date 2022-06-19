using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuVitoria : MonoBehaviour
{
    public Pontuaçao pontos;
    public EstadoDoJogo estadoDoJogo;
    public GameObject menuVitoria, menuGeral;

    public void ContinuarJogo()
    {
        ControladorJogo.Instance.ResetarEstadosDoJogo();
        estadoDoJogo.continuarJogo = true;
        menuVitoria.SetActive(false);
        menuGeral.SetActive(false);
    }
    public void TerminarJogo()
    {
        ControladorJogo.Instance.ResetarEstadosDoJogo();
        pontos.SalvarPontuaçao();
        menuVitoria.SetActive(false);
        menuGeral.SetActive(false);
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }
}
