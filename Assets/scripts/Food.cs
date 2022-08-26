using UnityEngine;

public class Food : MonoBehaviour
{
 public void ChangePosition()
   {
    int randomX = Random.Range(-23, 24);
    int randomY = Random.Range(-11, 12);
    transform.position = new Vector3(randomX, randomY, 0);
   }
}
