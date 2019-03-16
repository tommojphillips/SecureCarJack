using UnityEngine;

namespace SecureCarJack
{
    /// <summary>
    /// sets gameobjects tag to "DontPickThis" when attached gameobject is enabled.
    /// </summary>
    internal class DontPickThisGameObjectMono : MonoBehaviour
    {
        // Written, 11.03.2019

        private void Start()
        {
            // Written, 16.03.2019

            this.gameObject.tag = "DontPickThis";
        }
        private void OnEnable()
        {
            // Written, 11.03.2019

            this.gameObject.tag = "DontPickThis";
        }
    }
}
