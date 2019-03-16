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
        
        /// <summary>
        /// Represents the car jack part.
        /// </summary>
        private CarJackPart carJackPart;
        /// <summary>
        /// Represents the save file name.
        /// </summary>
        private const string fileName = "SecureCarJack.txt";
        /// <summary>
        /// Loads save data.
        /// </summary>
        private PartSaveInfo loadData()
        {
            // Written, 12.10.2018

            try
            {
                return SaveLoad.DeserializeSaveFile<PartSaveInfo>(this, fileName);
            }
            catch (System.NullReferenceException)
            {
                // no save file exists.. // setting/loading default save data.

                return this.carJackPart.defaultPartSaveInfo;
            }
        }
        /// <summary>
        /// Occurs on game start.
        /// </summary>
        public override void OnLoad()
        {
            // Written, 07.03.2019
            // Called once, when mod is loading after game is fully loaded

            GameObject parent = GameObject.Find("SATSUMA(557kg, 248)"); // gameobject that will be attached to car jack itemx, in this case the satsuma!.
            // Creating trigger for car jack itemx. and assigning the local location and scale of the trigger related to the parent. (in this case the satsuma).
            Trigger trigger = new Trigger("carJackTrigger", parent, new Vector3(-0.447f, 0, -1.48f), Quaternion.Euler(0, 285, 0), new Vector3(0.2f, 0.2f, 0.24f), false);
            // Creating a new instance of the carjackpart
            this.carJackPart = new CarJackPart(this.loadData(), // Loading saved or default data.
                GameObject.Find("car jack(itemx)"), // the car jack gameobject instance.
                parent,
                trigger,
                new Vector3(-0.447f, 0, -1.48f), // Install position
                Quaternion.Euler(0, 285, 0));// Install rotation
            ModConsole.Print(string.Format("{0} v{1}: Loaded.", this.Name, this.Version));
        }
        /// <summary>
        /// Occurs on game save. (player at toilet)
        /// </summary>
        public override void OnSave()
        {
            // Written, 11.03.2019

            try
            {
                SaveLoad.SerializeSaveFile(this, this.carJackPart.getSaveInfo(), fileName);
            }
            catch (System.Exception ex)
            {
                ModConsole.Error("<b>[SecureCarJackMod]</b> - an error occured while attempting to save part info.. see: " + ex.ToString());
            }
        }
    }
}
