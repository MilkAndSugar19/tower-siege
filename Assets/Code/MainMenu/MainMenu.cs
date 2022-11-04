using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject campaignCanvas, mainMenuCanvas;



    public void Campaign()
    {
        mainMenuCanvas.SetActive(false);
        campaignCanvas.SetActive(true);
    }
    public void BackButton()
    {
        mainMenuCanvas.SetActive(true);
        campaignCanvas.SetActive(false);
    }


    public void EndlessMode()
    {
        SceneManager.LoadScene("EndlessRun");
    }
    public void LeaveGame()
    {
        Application.Quit();
    }
}
