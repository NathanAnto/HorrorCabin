using UnityEditor;
using UnityEngine.SceneManagement;

namespace Interactables.Objects
{
    public class Door : Interactable {
        public override void InteractWith()
        {
            if (isInteractable) {
                // Change scene to appropriate room
                switch (name) {
                    case "Open Window":
                        SceneManager.LoadScene("CabinScene");
                        break;
                    case "Exit Window":
                        SceneManager.LoadScene("ForestScene");
                        break;
                }
                
                print("CHANGING SCENE");
            }
            else print("Can't interact with " + name);
        }
    }
}
