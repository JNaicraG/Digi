using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    /*
    private Vector3 _dragOffset;
    private Camera _cam;
    [SerializeField] private float _speed = 100.0f;
    private void Awake()
    {
        _cam = Camera.main;
    }

    private void OnMouseDown()
    {
        _dragOffset = transform.position - GetMousePos();
    }

    private void OnMouseDrag()
    {
        transform.position = Vector3.MoveTowards(transform.position, GetMousePos() + _dragOffset, _speed * Time.deltaTime);
    }

    private Vector3 GetMousePos()
    {
        var mousePos = _cam.ScreenToViewportPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }*/
    
        
    private Camera _cam;
    private Vector3 screenPoint = new Vector3(); //pega posição  do mouse
    private Vector3 offset = new Vector3(); //distância da posição atual at� onde o mouse está apontando
    private float _xLimite = 7f;
    private float _yLimite =6f; //limites horizontal e vertical do nível
    private float _boundaries;
    public EstadoDoJogo estado;
    public bool podeMover, click;
    private void Awake()
    {
        _cam = Camera.main;
        podeMover = true;
    }

    /*
    private void Start()
    {
        _boundaries = _cam.orthographicSize - 0.5f;// -1 para manter a peça dentro do jogo, tem que ser no minimo 1
    }
    */
    private void OnMouseDown()
    {
        /*
        var screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        Vector2 offset = new Vector2();
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));*/
        click = true;
        screenPoint = _cam.WorldToScreenPoint(transform.position); //pega posição do mouse

        //pega a distância da posição atual para o posição do mouse em relação a câmera //talvez não precise do screePoint por ser 2D // testar depois
        offset = transform.position - _cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

    }



        private void OnMouseDrag() //quando o mouse é arrastado
        {
        click = true;
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z); //nova posição do mouse
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset; //posição que a peça terá de mover -> em relação à câmera + até o mouse

            //curPosition.x = Mathf.Clamp(curPosition.x, -_boundaries, _boundaries); //pos horizontal
            //curPosition.y = Mathf.Clamp(curPosition.y, -_boundaries, _boundaries); //pos vertical
            curPosition.x = Mathf.Clamp(curPosition.x, -_xLimite, _xLimite); //pos horizontal
            curPosition.y = Mathf.Clamp(curPosition.y, -_yLimite, _yLimite); //pos vertical
            //Debug.Log("CurScreen " + curPosition.ToString());
            //não precisa necessariamente separar em x e y, eu só achei mais fácil pra escrever e ler
            //Mathf.Clamp vai limitar a posição da peça entre os limites estabelecidos -> se a nova posição for fora dos limites, segura ela nestes limites estabelecidos
            if (!estado.jogoPausado && podeMover)
                transform.position = curPosition;//Vector3.MoveTowards(transform.position, curPosition, 100f * Time.deltaTime); //finalmente, a posi��o atual da peça será movida para a posição calculada
        }
    private void OnMouseUp()
    {
        click = false;
    }
}
