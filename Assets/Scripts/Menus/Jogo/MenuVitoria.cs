using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class MenuVitoria : MonoBehaviour
{
    public Pontua�ao pontos;
    public EstadoDoJogo estadoDoJogo;
    public GameObject menuVitoria, menuGeral;
    public TMP_Text text;
    private float tempo;
    private void OnEnable()
    {
        DislayPontua�ao();
    }
    private void DislayPontua�ao()
    {
        tempo = pontos.tempo;
        pontos.FinalizarPlacar();
        text.text = pontos.pontua�aoFinal.ToString();
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
        pontos.SalvarPontua�ao();
        menuVitoria.SetActive(false);
        menuGeral.SetActive(false);
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }
}
