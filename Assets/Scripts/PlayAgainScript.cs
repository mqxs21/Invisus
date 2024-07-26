using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayAgainScript : MonoBehaviour
{
    void Awake(){
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
    }
    public void PlayAgainFuncLoadMainLevel(){
        
        SceneManager.LoadScene("MainLevel");
        
    }
}
