using Improbable.Ship;
using Improbable.Unity.Visualizer;
using UnityEngine;

namespace Assets.Gamelogic.Pirates.Cannons
{
    public class CannonFirer : MonoBehaviour
    {
        private Cannon cannon;
        [Require] private PlayerControlsReader PlayerControls;


        private void Start()
        {
            cannon = gameObject.GetComponent<Cannon>();
        }

        private void FireCannons(Vector3 direction)
        {
            if (cannon != null)
            {
                cannon.Fire(direction);
            }
        }

        void OnEnable()
        {
            PlayerControls.FireLeft += OnFireLeft;
            PlayerControls.FireRight += OnFireRight;
        }
     
        private void OnFireLeft(FireLeft fireLeft)
        {
            FireCannons(-transform.right);
        }
        
        private void OnFireRight(FireRight fireRight)
        {
            FireCannons(transform.right);
        }

        void OnDisable()
        {
            PlayerControls.FireLeft -= OnFireLeft;
            PlayerControls.FireRight -= OnFireRight;
        }


    }
}