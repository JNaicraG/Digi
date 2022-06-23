using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Unity.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "Pontuação", menuName = "ScriptableObjects/Pontuação")]
public class Pontuaçao : ScriptableObject
{
    public float pontos;
    public float multiplicador;
    public float multiplicadorSilabas;
    public int round;
    public float tempo,t;
    private float tempoF;
    public int dificuldade, pontuaçaoFinal;
    public float limiteTempo = 10f;
    public string nomeJogador = "Caju";
    public List<PontuaçaoData> list;
    public void DiminuirMultiplicador()
    {
        multiplicador -= 0f;
    }
    public void AdicionarPontos()
    {
        switch (dificuldade)
        {
            case 0:
                pontos = 250;
                break;
            case 1:
                pontos = 500;
                break;
            case 2:
                pontos = 800;
                break;
            default:
                pontos = 450;
                break;
        }

        if (multiplicador < 1)
            multiplicador = 1; //pra não diminuir valor
        pontos += pontos*multiplicador;
        multiplicador += 0.2f;
    }
    /*
    public void AdicionarPontos(float p)
    {
        switch (dificuldade)
        {
            case 0:
                pontos = 125;
                break;
            case 1:
                pontos = 250;
                break;
            case 2:
                pontos = 500;
                break;
            default:
                pontos = 200;
                break;
        }

        if (multiplicador < 1)
            multiplicador = 1; //pra não diminuir valor
        pontos += pontos * multiplicador + p;
        multiplicador += 0.2f;
    }
    */

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
        pontos += 500; //bônus por terminar
        if (t <= limiteTempo)
            pontos *= 2;
        pontos *= multiplicadorSilabas;
        tempoF = tempo;
        pontuaçaoFinal = (int)(pontos + tempoF);
        round++;
    }

    public void SalvarPontuaçao()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "Pontuaçao.save";
        PontuaçaoData data = new PontuaçaoData(nomeJogador,pontuaçaoFinal,round,tempoF);
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    //public List<PontuaçaoData> CarregarPontuaçao()
    public void CarregarPontuaçao()
    {
        List<PontuaçaoData> lista = new List<PontuaçaoData>();
        string path = Application.persistentDataPath + "Pontuaçao.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PontuaçaoData data = formatter.Deserialize(stream) as PontuaçaoData;
            lista = formatter.Deserialize(stream) as List<PontuaçaoData>;
            stream.Close();
            /*
            nomeJogador = data.nomeJogador;
            pontuaçaoFinal = data.pontuaçao;
            round = data.round;
            tempoF = data.tempoTotal;
            */
            foreach (var n in lista)
                Debug.Log("LISTA AAA: " + n.nomeJogador);
            if (list != null)
                list = lista;
        }
        else
        {
            Debug.LogError("Caminho para carregar dados de Pontuação não existem. Caminho: " + path);
            //PontuaçaoData data = new PontuaçaoData();
        }
    }

}
