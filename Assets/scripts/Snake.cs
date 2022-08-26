using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;
    [SerializeField]
    private GameObject _snakeBody;
    [SerializeField]
    private GameObject _snakeBodyParent;

    List<Transform> snakeBodies;

    public int _lives = 2;
    
    private void Start()
    {
        snakeBodies = new List<Transform>();
        snakeBodies.Add(this.gameObject.transform);
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))&& _direction != Vector2.down)
        {
            _direction = Vector2.up;
        }
        else if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))&& _direction != Vector2.right)
        {
            _direction = Vector2.left;
        }
        else if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))&& _direction != Vector2.up)
        {
            _direction = Vector2.down;
        }
        else if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))&& _direction != Vector2.left)
        {
            _direction = Vector2.right;
        }

        if(_lives == 0){
        GameObject.Find("GameManager").GetComponent<GameManager>().onGameOver();
        }

    }

    private void FixedUpdade()
    {
        transform.position = new Vector3(
        Mathf.Round(transform.position.x + _direction.x),
        Mathf.Round(transform.position.y + _direction.y),
        0
        );
        for (int i = snakeBodies.Count - 1; i > 0; i--)
        {
            snakeBodies[i].position = snakeBodies[i - 1].position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        string gameObjectName = collider.gameObject.transform.name;
        if (collider.gameObject.transform.name == "Food")
        {
            collider.gameObject.transform.GetComponent<Food>().ChangePosition();
            growSnake();
        }
        else if (gameObjectName == "Wall Top" ||gameObjectName == "Wall Bottom" ||gameObjectName == "Wall Left" ||gameObjectName == "Wall Right" )
        {
           //print("Game Over"); 
           _lives --;
        }
        else if(collider.gameObject.transform.parent.transform.name == "SnakeBodyParent")
        {
           //print("Game Over");
           _lives --;
        }

    }

    private void growSnake()
    {
        GameObject segment = Instantiate(_snakeBody,snakeBodies[snakeBodies.Count -1].position, Quaternion.identity);
        segment.transform.parent = _snakeBodyParent.transform;
        snakeBodies.Add(segment.transform);
    }

}
