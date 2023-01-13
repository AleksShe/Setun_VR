using AosSdk.Core.Utils;
using UnityEngine;

namespace AosSdk.Core.PlayerModule
{
    public class PlayerSpawnPoint : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            Gizmos.DrawIcon(transform.position, "../aossdk/Resources/pin.png", true);
        }

        private void OnEnable()
        {
            if (Launcher.Instance != null)
            {
                return;
            }

            var thisTransform = transform;
            var prefab = Resources.Load("Prefabs/AOSSDK");

            Instantiate(prefab, thisTransform.position, thisTransform.rotation);
        }
    }
}