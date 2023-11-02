using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    public void Easy()
    {
        SceneManager.LoadScene(1);
    }
    public void Medium()
    {
        SceneManager.LoadScene(2);
    }
    public void Difficult()
    {
        SceneManager.LoadScene(3);
    }
}
