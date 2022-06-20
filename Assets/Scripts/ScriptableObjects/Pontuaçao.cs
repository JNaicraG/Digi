using System.Collections;
using System.Collections.Generic;
using Unity.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "Pontuação", menuName = "ScriptableObjects/Pontuação")]
public class Pontuaçao : ScriptableObject
{
    public float pontos;
    public float multiplicador;
    public float multiplicadorSilabas;
    public int round;
    public float tempo;

    public void AdicionarPontos(float p)
    {
        if (multiplicador < 1 && multiplicadorSilabas < 2)
            multiplicador = 1; //pra não diminuir valor
        pontos += p*multiplicador;
    }

    public void ZerarPlacar()
    {
        pontos = 0;
        multiplicador = 1;
        multiplicadorSilabas = 2;
        round = 0;
        tempo = 0;
    }

    public void FinalizarPlacar()
    {
        pontos *= multiplicadorSilabas;
        float tempoF = tempo;
    }

    public void SalvarPontuaçao()
    {

    }
}
