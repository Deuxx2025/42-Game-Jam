using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("target"))
        {
            print("hit" + collision.gameObject.name);
            gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("wall"))
        {
            print("hit" + collision.gameObject.name);
            gameObject.SetActive(false);
        }
    }
}