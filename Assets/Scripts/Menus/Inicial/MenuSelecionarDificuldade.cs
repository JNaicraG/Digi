using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuSelecionarDificuldade : MonoBehaviour
{
    public Palavras palavras;
    public Pontuaçao pontuaçao;
    public GameObject menuDificuldade, menuInicial;
    public void Voltar()
    {
        menuDificuldade.SetActive(false);
        menuInicial.SetActive(true);

    }
    public void Facil()
    {
        palavras.CarregarPalavrasFaceis();
        SetPontuaçao(0,10f);
        CarregarJogo();
    }
    public void Medio()
    {
        palavras.CarregarPalavrasMedias(); ;
        SetPontuaçao(1,20f);
        CarregarJogo();
    }
    public void Dificil()
    {
        palavras.CarregarPalavrasDificeis();
        SetPontuaçao(2, 30f);
        CarregarJogo();
    }


    private void SetPontuaçao(int dificuldade, float tLimite)
    {
        pontuaçao.ZerarPlacar();
        pontuaçao.limiteTempo = tLimite;
        pontuaçao.multiplicador = palavras.Silabas.Count;
        pontuaçao.dificuldade = 0;
    }

    //Talvez usar isso se adicionar mais coisa pra começar o jogo
    private void CarregarJogo()
    {
        pontuaçao.ZerarPlacar();
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }
}
