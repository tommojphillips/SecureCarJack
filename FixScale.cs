using MSCLoader;
using UnityEngine;

namespace TommoJProductions.SecureCarJack
{
    public class FixScale : MonoBehaviour
    {
        public Vector3 modifier = Vector3.one;
        public bool onAwake = false;
        public bool onStart = false;
        public bool onDisable = false;
        public bool onEnable = false;
        public bool onUpdate = false;
        public bool onFixedUpdate = false;

        void Awake()
        {
            if (onAwake)
                checkFixScale();
        }
        void Start()
        {
            if (onStart)
                checkFixScale();
        }
        void OnEnable()
        {
            if (onEnable)
                checkFixScale();
        }
        void OnDisable()
        {
            if (onDisable)
                checkFixScale();
        }
        void Update()
        {
            if (onUpdate)
                checkFixScale();
        }
        void FixedUpdate()
        {
            if (onFixedUpdate)
                checkFixScale();
        }

        private void checkFixScale()
        {
            if (transform.hasChanged)
            {
                transform.localScale = modifier;
            }
        }
    }
}