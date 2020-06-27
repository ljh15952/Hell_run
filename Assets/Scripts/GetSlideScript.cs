using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Slide_type
{
    Left,
    Right,
    Up,
    Down,
    Default
}

public class GetSlideScript : MonoBehaviour
{
    public Vector2 Down_MousePos;
    public Vector2 Up_MousePos;

    public Slide_type State;

    private void Start()
    {
        State = Slide_type.Default;
        Down_MousePos = Vector2.zero;
        Up_MousePos = Vector2.zero;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Mouse_down();
        }
        else if(Input.GetMouseButtonUp(0))
        {
            Mouse_Up();
            switch (State)
            {
                case Slide_type.Left:
                    transform.position += new Vector3(-1, 0, 0);
                    break;
                case Slide_type.Right:
                    transform.position += new Vector3(1, 0, 0);
                    break;
                case Slide_type.Up:
                    transform.position += new Vector3(0, 1, 0);
                    break;
                case Slide_type.Down:
                    transform.position += new Vector3(0, -1, 0);
                    break;

            }
       

        }
    }

    private void Mouse_down()
    {
        Down_MousePos = Input.mousePosition;
    }

    private void Mouse_Up()
    {
        Up_MousePos = Input.mousePosition;
        Vector2 diff = getMouseDiff();
        State = getSlideState(diff);
    }

    private Vector2 getMouseDiff()
    {
        return Down_MousePos - Up_MousePos;
    }

    private Slide_type getSlideState(Vector2 diff)
    {
        Debug.Log(diff);
        if(Mathf.Abs(diff.x) > Mathf.Abs(diff.y))
        {
            return diff.x > 0 ? Slide_type.Left : Slide_type.Right;
        }
        else
        {
            return diff.y > 0 ? Slide_type.Down : Slide_type.Up;
        }
    }

}
