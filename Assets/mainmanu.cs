using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class mainmanu : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioMixer audioMixer;
    public void PlayGame (){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
     public void quitGame (){
         Application.Quit();
     }
     public void SetVolume (float volume){
         Debug.Log(volume);
         audioMixer.SetFloat("a", volume);
     }
}
