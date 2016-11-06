using Improbable.Unity;
using Improbable.Unity.Visualizer;
using UnityEngine;
using UnityEngine.UI;
using Improbable.Ship;

namespace Assets.Gamelogic.Pirates.Behaviours
{    
    [EngineType(EnginePlatform.Client)]
    public class NumberOfKillsGUI : MonoBehaviour
    {
        private Text numberOfKillsGUI;
        [Require] private ScoreReader score;
        [Require] private PlayerControlsWriter PlayerControls;

        private void Awake()
        {
            numberOfKillsGUI = GameObject.Find("Canvas").GetComponentInChildren<Text>();
            GameObject.Find("Background").GetComponent<Image>().color = Color.clear;
        }

        private void OnEnable()
        {
            score.NumberOfKillsUpdated += updateGUI;
        }

        void updateGUI(int newNumberOfKills)
        {
            if (newNumberOfKills > 0)
            {
                GameObject.Find("Background").GetComponent<Image>().color = Color.white;
                var text = "Score/number of kills: " + newNumberOfKills.ToString() + " ";
                numberOfKillsGUI.text = text;
            }
            else
            {
                GameObject.Find("Background").GetComponent<Image>().color = Color.clear;
            }
        }
    }
}