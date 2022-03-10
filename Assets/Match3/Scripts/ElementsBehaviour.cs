using UnityEngine;

public class ElementsBehaviour : MonoBehaviour
{
    private Vector2 _mousePos;

    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _mousePos = Input.mousePosition;
            
            if(Mathf.Abs(_mousePos.x - transform.position.x) < 1)
            {
                gameObject.transform.position = new Vector2(_mousePos.x, gameObject.transform.position.y);
            }
        }
    }
}
