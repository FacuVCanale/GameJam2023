using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour 
{
  public float stepDelay;

  private Vector3 moveDirection;
  private float timer;

  private void Update()
  {
    timer += Time.deltaTime;

    if(timer >= stepDelay)
    {
      transform.position += moveDirection;
      timer -= stepDelay; 
    }
  }

  public void MoveUp()
  {
    moveDirection = Vector3.down;
  }

  public void MoveDown()
  {
    moveDirection = Vector3.up;
  }

  public void MoveLeft()
  {
    moveDirection = Vector3.left;
  }

  public void MoveRight()
  {
    moveDirection = Vector3.right; 
  }
}
