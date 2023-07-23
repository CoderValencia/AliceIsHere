using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingZone : MonoBehaviour
{
    int counter = 0;
    public string sceneName;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            counter = 1;
            Camera.main.GetComponent<CameraFade>().StartFade();
            collision.gameObject.GetComponent<PlayerMovement>().enabled = false;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, collision.gameObject.GetComponent<Rigidbody2D>().velocity.y);
            collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y, 0);
        }
    }
    void FixedUpdate()
    {
        if(counter > 0)
        {
            counter++;
        }
        if(counter == 50)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
