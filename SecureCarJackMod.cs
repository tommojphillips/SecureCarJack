using UnityEngine;
using HutongGames.PlayMaker;
using MSCLoader;
using ModApi.Attachable;

namespace SecureCarJack
{
    public class SecureCarJackMod : Mod
    {
        // Written, 07.03.2019

        public override string ID => "SecureCarJack"; //Your mod ID (unique)
        public override string Name => "Secure Car Jack"; //You mod name
        public override string Author => "tommojphillips"; //Your Username
        public override string Version => "0.1"; //Version


        private GameObject carJackItemx;
        private bool carJackOpen
        {
            get
            {
                return PlayMakerFSM.FindFsmOnGameObject(this.carJackItemx, "Fold").FsmVariables.FindFsmBool("Open").Value;
            }
        }

        public override void OnLoad()
        {
            // Written, 07.03.2019
            // Called once, when mod is loading after game is fully loaded

            carJackItemx = GameObject.Find("car jack(itemx)");                       
        }
    }
}
