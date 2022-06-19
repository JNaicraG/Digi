using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName ="Palavras",menuName ="ScriptableObjects/Palavras")]
public class Palavras : ScriptableObject
{
    [Tooltip("Caminho que a lista de palavras a ser utilizada est�")]
    public string loadWordListPathF, loadWordListPathM, loadWordListPathD;
    public EstadoDoJogo estadoJogo;
    private List<string> _listaPalavras = new List<string>();
    private string _palavraChave;
    private ArrayList _silabas = new ArrayList();
    private int _nSilabas = 0; //numero de silabas

    public string PalavraChave { get => _palavraChave; set { } }
    public ArrayList Silabas { get => _silabas; set { } }

    public int nSilabas { get => _nSilabas; set { } }

    public void CarregarPalavrasFaceis()
    {
        var stream = new StreamReader(loadWordListPathF);
        while (!stream.EndOfStream)
            _listaPalavras.Add(stream.ReadLine());
        EscolherPalavra();
    }
    public void CarregarPalavrasMedias()
    {
        var stream = new StreamReader(loadWordListPathM);
        while (!stream.EndOfStream)
            _listaPalavras.Add(stream.ReadLine());
        //Debug.Log("Lista " + _listaPalavras[2]);
        EscolherPalavra();
    }
    public void CarregarPalavrasDificeis()
    {
        var stream = new StreamReader(loadWordListPathD);
        while (!stream.EndOfStream)
            _listaPalavras.Add(stream.ReadLine());
        EscolherPalavra();
    }

    public void EscolherPalavra()
    {
        int nMax = _listaPalavras.Count;
        _palavraChave = _listaPalavras[Random.Range(0, nMax)];
        Debug.Log("Palavra-Chave escolhida: " + _palavraChave);
        SepararSilaba();
    }

    private void SepararSilaba()
    {
        if (_palavraChave != null)
        {
            Syllable syl = new Syllable();
            _silabas = syl.word2syllables(_palavraChave.ToLower());
            _nSilabas = _silabas.Count;
            /*foreach (var n in _silabas)
                Debug.Log("Silaba escolhida: " + n.ToString());*/
        }
        else
            Debug.Log("Palavra Chave ainda nao foi escolhida");
    }

    private void LimparLista()
    {
        if (estadoJogo.jogoAcabou)
        {
            _listaPalavras.Clear();
        }
    }

}
