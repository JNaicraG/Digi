using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class MenuVitoria : MonoBehaviour
{
    public Pontuaçao pontos;
    public EstadoDoJogo estadoDoJogo;
    public GameObject menuVitoria, menuGeral;
    public TMP_Text text;
    private float tempo;
    private void OnEnable()
    {
        DislayPontuaçao();
    }
    private void DislayPontuaçao()
    {
        tempo = pontos.tempo;
        pontos.FinalizarPlacar();
        text.text = pontos.pontuaçaoFinal.ToString();
    }
    public void ContinuarJogo()
    {
        ControladorJogo.Instance.ResetarEstadosDoJogo();
        estadoDoJogo.continuarJogo = true;
        pontos.tempo = tempo;
        pontos.t = 0;
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
