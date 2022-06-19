using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //Confirmar funcionamento e modificar c�digo para uso
    [Tooltip("Margem entre cada pe�a que ser� instanciada na grid (M�nimo 1.0)")]
    public float tileMargin;

    [Tooltip("Empty de Pe�as e Respostas para organiza�~~ao no inspetor")]
    public GameObject p, r;

    [Tooltip("Rows and cols for the map grid")]
    private int _myGrid;

    [Tooltip("Prefabs dimensions in Unity units")]
    public Vector3 tileDimensions;

    [Tooltip("Limite para possivel spawn das pe�as dentro da area do jogo")]
    public float limite;
    /*
    TileMargin - margem entre cada bloco
    MyGrid - quantidade de linhas (X) e colunas (Y)
    Tile Dimensions - escala dos blocos gerados em rela��o � eles mesmos. Deixar em 1.0.
    */

    [Tooltip("Objeto do Bloco de Respostas")]
    public GameObject blocoResp; //anteriormente PrefabTiles
    //o bloco de resposta

    [Tooltip("Objeto das Pe�as")]
    public GameObject pe�a; //anteriormente PrefabTiles
    //As pe�as
    /*
    // storing the map tiles in a list could be useful
    public static List<GameObject> respList = new List<GameObject>();

    // storing the map tiles in a list could be useful
    public static List<GameObject> pe�aList = new List<GameObject>();
    */
    public ListaBlocosPe�as listaBlocos;

    public Palavras escolherPalavra;
    public EstadoDoJogo estadoDoJogo;

    // Use this for initialization
    void Start()
    {
        SpawnResposta();
        SpawnPe�as();
        //efeito tremilique do c�digo original
        //InvokeRepeating("FunkyTiles", 0f, 0.05f);
    }

    private void Update()
    {
        if (estadoDoJogo.continuarJogo)
        {
            ControladorJogo.Instance.ResetarEstadosDoJogo();
            SpawnResposta();
            SpawnPe�as();
        }
    }


    //(ArrayList pal)
    private void SpawnResposta() //Criar grid com blocos
    {
        listaBlocos.LimparBlocos();
        //configura�~~oes da grid
        ArrayList silabas = new ArrayList(); //Lista de silabas que sera carregada
        silabas = escolherPalavra.Silabas; //pegando silabas j��a separadas
        _myGrid = escolherPalavra.nSilabas; //Configurando o tamanho horizontal da grid

        //for (int row = 1; row <= myGrid.y; row++) //coluna (no nosso caso 1, mas vai que)
        for (int col = 1; col <= _myGrid; col++) // para cada linha at� o n�mero delimitado de linhas
        {
            {
                // spawns the tile/bloco
                GameObject theTile = Instantiate(blocoResp, transform); //o objeto a ser instanciado
                theTile.transform.parent = r.transform;
                theTile.GetComponent<BlocoResposta>().id = col; //d� id
                theTile.GetComponent<BlocoResposta>().sil = silabas[col - 1].ToString(); //d� s�laba a ser mostrada
                //theTile.GetComponent<BlocoResposta>().AlterarTexto(); //lembrete que isso ta aqui para teste, depois retirar.
                theTile.name = "Resp_" + col + "_";// + row; //nome do bloco gerado que ser� vv�sivel no inspetor //pode ser substitu�do pelo id do bloco...nah           
                /*
                    entao, como cada resposta gerada sera dado um offset horizontal da posi�ao inicial do empty de respostas, PARA CENTRALIZAR
                tudo isso eu estou ja gerando os blocos de resposta COM o espa�o total que eles vao gerar e tirando isso da posi�ao deles, em 
                rela�ao a cada um dos blocos.
                Entao, se o primeiro bloco ia ser gerado em X, ele agora vai ser gerado em X - Margem * tamanho dele mesmo * o quanto ainda
                falta de blocos (tileMargin * (_myGrid - col) * tileDimensions.x). E no theTile.transform.localPosition eu so to retirando esse valor de 
                offset pra ele centralizar
                */
                float larguraRemover = tileMargin * (_myGrid - col) * tileDimensions.x;
                theTile.transform.localPosition = new Vector3(((col - 1) * tileDimensions.x * tileMargin) - larguraRemover, 0f, tileDimensions.z);
                //A posi��o do bloco local (em rela��o ao pai no inspetor) = (x,y,z) -> ((coluna atual) * largura do bloco * margem, linha * altura do bloco, o z n�o faz diferen�a, sinceramente)

                // stores the tile in the List
                listaBlocos.blocoResps.Add(theTile);
            }
        }
        //print(mapList.Count + " tiles in the map"); //confirmar se gerou a quantia correta

    }

    //a mesma coisa mas para as pe�as
    private void SpawnPe�as()
    {
        listaBlocos.LimparPe�as();
        //configura�~~oes da grid
        ArrayList silabas = new ArrayList(); //Lista de silabas que sera carregada
        silabas = escolherPalavra.Silabas; //pegando silabas j��a separadas
        _myGrid = escolherPalavra.nSilabas; //Configurando o tamanho horizontal da grid


        //for (int row = 1; row <= myGrid.y; row++) //coluna (no nosso caso 1, mas vai que)
        for (int col = 1; col <= _myGrid; col++) // para cada linha at� o n�mero delimitado de linhas
        {
            {
                // spawns the tile/bloco
                GameObject theTile = Instantiate(pe�a, transform); //o objeto a ser instanciado
                theTile.transform.parent = p.transform;
                theTile.GetComponent<Pe�a>().id = col; //d� id
                theTile.GetComponent<Pe�a>().sil = silabas[col - 1].ToString(); //d� s�laba a ser mostrada
                theTile.GetComponent<Pe�a>().AlterarTexto();
                theTile.name = "Pe�a_" + col + "_";// + row; //nome do bloco gerado que ser� vv�sivel no inspetor //pode ser substitu�do pelo id do bloco...nah           
                theTile.transform.localPosition = new Vector3((col - 1) * tileDimensions.x * tileMargin, 0f, tileDimensions.z);
                theTile.GetComponent<SpriteRenderer>().sortingOrder = _myGrid - col;
                theTile.GetComponentInChildren<Canvas>().sortingOrder = _myGrid - col;
                //float a = Camera.main.orthographicSize - limite;
                //float x = Random.Range(-a, a);
                float x = Random.Range(-7f, 7f); //limite de X, pego de Mover.cs
                float y = RandomY(4f); //limite de Y, funciona melhor com 4, j� que ele tem um offset pra cima
                theTile.transform.localPosition= new Vector3(x, y, 0); //usar .position e nao .localPosition
                //theTile.transform.localPosition = 
                // stores the tile in the List
                listaBlocos.pe�as.Add(theTile);
            }
        }
        //print(mapList.Count + " tiles in the map"); //confirmar se gerou a quantia correta
    }

    private float RandomY(float valor)
    {
        float a = Random.Range(-valor, valor);
        //Debug.Log("Antes de Refazer: " + a);
        if (a >= 0.75f && a <= 4.12f)
            RandomY(valor);
        //Debug.Log("Depois de Refazer: " + a);
        return a;
    }

    //Ignorar
    // just for some extra fun ;)
    void FunkyTiles()
    {
        int n = Random.Range(0, listaBlocos.blocoResps.Count);
        GameObject theTile = listaBlocos.pe�as[n];
        Vector3 temp = theTile.transform.localPosition;
        temp.y = Random.Range(-0.25f, 0.25f);
        theTile.transform.localPosition = temp;
    }

}
