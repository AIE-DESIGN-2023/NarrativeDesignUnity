using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTag : MonoBehaviour
{
    public GameObject deathBox;
    public int enemy;
    public GameObject deathCamera;
    // Start is called before the first frame update

    void Start()
    {

    }

    //Check whether the player collides with a death box & load death screen upon collision
    private void OnCollisionEnter(Collision other)
    {
        //Check if the object the player collided with is an enemy
        if (other.gameObject.tag == "enemy")
        {
            //Load Death Scene
            SceneManager.LoadScene("SampleScene");
        }
    }

}