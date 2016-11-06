using Improbable.Ship;
using Improbable.Unity.Visualizer;
using UnityEngine;

namespace Assets.Gamelogic.Pirates.Behaviours {
    public class SinkingBehaviour : MonoBehaviour {
    
        [Require] protected HealthReader Health;
    
        public Animation SinkingAnimation;
    
        void OnEnable()
        {
            // Register your callbacks in OnEnable.
            Health.CurrentUpdated += OnCurrentHealthUpdated;
        }
    
        private void OnCurrentHealthUpdated(int currentHealth)
        {
            if (currentHealth <= 0)
            {
                SinkingAnimation.Play();
            }
        }
    
        void OnDisable()
        {
            // Deregister your callbacks and rewind animations inside OnDisable.
            SinkingAnimation.Rewind();
            Health.CurrentUpdated -= OnCurrentHealthUpdated;
        }
    }
}