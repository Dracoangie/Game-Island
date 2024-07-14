using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    public GameObject panel;
    private bool panelOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startGame(){
        SceneManager.LoadScene("Card_Scene");
    }

    public void OpenCloseIntructions(){
        if(!panelOpen){
            this.panel.SetActive(true);
            panelOpen = true;
        }else{
            this.panel.SetActive(false);
            panelOpen=false;
        }
    }

    public void exit(){
        Application.Quit();
    }
}
