using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PontuaçaoData
{
    public string nomeJogador;
    public int pontuaçao;
    public int round;
    public float tempoTotal;

    public PontuaçaoData() { }
    public PontuaçaoData(string nomeJogador, int pontuaçao, int round, float tempoTotal)
    {
        this.nomeJogador = nomeJogador;
        this.pontuaçao= pontuaçao;
        this.tempoTotal = tempoTotal;
        this.round = round;
    }

}
