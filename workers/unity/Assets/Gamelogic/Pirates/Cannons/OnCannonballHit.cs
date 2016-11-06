using Improbable.Ship;
using Improbable.Unity.Visualizer;
using UnityEngine;

namespace Assets.Gamelogic.Pirates.Cannons
{
    public class OnCannonballHit : MonoBehaviour
    {
        [Require] private HitByCannonballWriter hitByCannonballWriter;        
        
        private void OnTriggerEnter(Collider other)
        {            

            if (other.gameObject.tag == "Cannonball" && hitByCannonballWriter != null)
            {
                var firerEntityId = other.GetComponent<DestroyCannonball>().firerEntityId;
                hitByCannonballWriter.Update.TriggerHit(firerEntityId).FinishAndSend();
            }
        }
    }
}
