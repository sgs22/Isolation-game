using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour {

    /*public Slider[] volumeSliders;
    public Toggle[] graphicsToggles;*/
    public int[] screenWidth;
    public AudioMixer mixer;

    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    /*public void SetGraphics(int i)
    {
        if (graphicsToggles[i].isOn)
        {
            float aspectRatio = 16 / 9f;
            Screen.SetResolution(screenWidth[i], (int)(screenWidth[i] / aspectRatio), false);
        }
    }*/
   
    public void SetVolume(float volume)
    {
        mixer.SetFloat("volume", volume);
    }

    /*public float ConvertToDecibel(float value)
    {
        float decibel = -80f;
        if (value > 0)
        {
            decibel = Mathf.Log(value / 100f) * 17f;
        }
        return decibel;
    }*/

    public void Restart()
    {
        SceneManager.LoadScene("Menu");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
