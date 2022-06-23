using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuSelecionarDificuldade : MonoBehaviour
{
    public Palavras palavras;
    public Pontua�ao pontua�ao;
    public GameObject menuDificuldade, menuInicial;
    public void Voltar()
    {
        menuDificuldade.SetActive(false);
        menuInicial.SetActive(true);

    }
    public void Facil()
    {
        palavras.CarregarPalavrasFaceis();
        SetPontua�ao(0,10f);
        CarregarJogo();
    }
    public void Medio()
    {
        palavras.CarregarPalavrasMedias(); ;
        SetPontua�ao(1,20f);
        CarregarJogo();
    }
    public void Dificil()
    {
        palavras.CarregarPalavrasDificeis();
        SetPontua�ao(2, 30f);
        CarregarJogo();
    }


    private void SetPontua�ao(int dificuldade, float tLimite)
    {
        pontua�ao.ZerarPlacar();
        pontua�ao.limiteTempo = tLimite;
        pontua�ao.multiplicador = palavras.Silabas.Count;
        pontua�ao.dificuldade = 0;
    }

    //Talvez usar isso se adicionar mais coisa pra come�ar o jogo
    private void CarregarJogo()
    {
        pontua�ao.ZerarPlacar();
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }
}
