using MSCLoader;
using TommoJProductions.ModApi;
using TommoJProductions.ModApi.Attachable;
using UnityEngine;
using static TommoJProductions.ModApi.Attachable.Part;

namespace TommoJProductions.SecureCarJack
{
    public class SecureCarJackMod : Mod
    {
        // Written, 07.03.2019

        public const string FILE_NAME = "SecureCarJack.txt";

        public override string ID => "SecureCarJack";
        public override string Name => "Secure Car Jack";
        public override string Author => "tommojphillips";
        public override string Version => VersionInfo.version;

        private Part carJackPart;

        private PlayMakerFSM foldFsm;

        /// <summary>
        /// Occurs on game start.
        /// </summary>
        public override void OnLoad()
        {
            // Written, 07.03.2019 | Modified, 25.09.2021


            GameObject.Find("ITEMS").GetPlayMaker("SaveItems").GetState("Save game").prependNewAction(fixTransform);

            GameObject satsuma = GameObject.Find("SATSUMA(557kg, 248)");
            GameObject carJackGo = GameObject.Find("car jack(itemx)");

            foldFsm = carJackGo.GetPlayMaker("Fold");

            Trigger trigger = new Trigger("carJackTrigger", satsuma, new Vector3(-0.3770001f, 0f, -1.42f), new Vector3(0, 285, 0), new Vector3(0.2f, 0.2f, 0.24f));
            AssemblyTypeJointSettings atjs = new AssemblyTypeJointSettings(satsuma.GetComponent<Rigidbody>());
            PartSettings partSettings = new PartSettings() { assembleType = AssembleType.joint, assemblyTypeJointSettings = atjs, setPositionRotationOnInitialisePart = false };
            carJackPart = carJackGo.AddComponent<Part>();
            carJackPart.defaultSaveInfo = new PartSaveInfo() { installed = true };
            carJackPart.initPart(loadData(), partSettings, trigger);
            ModConsole.Print(string.Format("{0} v{1}: Loaded.", Name, Version));
        }

        private void fixTransform()
        {
            carJackPart.transform.localScale = Vector3.one;
        }

        /// <summary>
        /// Occurs on game save. (player at toilet)
        /// </summary>
        public override void OnSave()
        {
            // Written, 11.03.2019

            try
            {
                SaveLoad.SerializeSaveFile(this, carJackPart.getSaveInfo(), FILE_NAME);
            }
            catch (System.Exception ex)
            {
                ModConsole.Error("<b>[SecureCarJackMod]</b> - an error occured while attempting to save part info.. see: " + ex.ToString());
            }
        }

        /// <summary>
        /// Loads save data.
        /// </summary>
        private PartSaveInfo loadData()
        {
            // Written, 12.10.2018

            try
            {
                return SaveLoad.DeserializeSaveFile<PartSaveInfo>(this, FILE_NAME);
            }
            catch (System.NullReferenceException)
            {
                // no save file exists.. // setting/loading default save data.

                return null;
            }
        }
    }
}
