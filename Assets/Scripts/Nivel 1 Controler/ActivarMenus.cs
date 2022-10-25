using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivarMenus : MonoBehaviour
{
    public GameObject panelPausa;
    public GameObject panelGameOver;



    public void ActivarPausa()
    {
        panelPausa.SetActive(true);
        Time.timeScale = 0;

    }
    public void DesactivarPausa()
    {
        panelPausa.SetActive(false);
        Time.timeScale = 1;

    }

    public void Reiniciar()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        

    }
    public void IrAlMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;

    }
    public void GameOver()
    {
        panelGameOver.SetActive(true);
        Time.timeScale = 0;

    }




}
