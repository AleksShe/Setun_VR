using AosSdk.Core.PlayerModule;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AosSdk.Core.Interaction.UIInteraction
{
    public class UiInput : MonoBehaviour
    {
        private void Start()
        {
            SceneManager.sceneLoaded += SceneManagerOnSceneLoaded;
            HandleCanvases();
        }

        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= SceneManagerOnSceneLoaded;
        }

        private static void SceneManagerOnSceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            HandleCanvases();
        }

        private static void HandleCanvases()
        {
            foreach (var canvas in FindObjectsOfType<Canvas>())
            {
                if (canvas.renderMode != RenderMode.WorldSpace)
                {
                    continue;
                }

                var interactableCanvas = canvas.gameObject.GetComponent<InteractableCanvas>();
                if (!interactableCanvas)
                {
                    interactableCanvas = canvas.gameObject.AddComponent<InteractableCanvas>();
                }

                interactableCanvas.CanvasComponent.worldCamera = Player.Instance.EventCamera;
            }
        }
    }
}