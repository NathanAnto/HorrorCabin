using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuCutScene : MonoBehaviour
{
    [SerializeField] private CameraController cameraAnimationController;
    private bool cutsceneState = true;

    private void Start() {
        cameraAnimationController = GameObject.Find("StateCamera").GetComponent<CameraController>();
        
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("ForestScene")) {
            cameraAnimationController.TriggerCutscene("MainMenuCutScene", cutsceneState);
        }
    }

    public void TriggerCutscene() {
        cutsceneState = !cutsceneState;
        cameraAnimationController.TriggerCutscene("MainMenuCutScene", cutsceneState);
    }
}
