
using System.Linq;
using ModApi.Attachable;
using UnityEngine;

namespace SecureCarJack
{
    internal class CarJackPart : Part
    {
        #region Properties

        public override GameObject rigidPart
        {
            get;
            set;
        }
        public override GameObject activePart
        {
            get;
            set;
        }
        /// <summary>
        /// Represents the default info for the carjack part.
        /// </summary>
        public override PartSaveInfo defaultPartSaveInfo => new PartSaveInfo()
        {
            installed = true,
        };
        /// <summary>
        /// Represents whether the car jack is folded or not.
        /// </summary>
        private bool carJackOpen
        {
            get
            {
                return PlayMakerFSM.FindFsmOnGameObject(this.activePart, "Fold").FsmVariables.FindFsmBool("Open").Value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of car jack part.
        /// </summary>
        /// <param name="inPartSaveInfo">The part save info.</param>
        /// <param name="inPart">The part's game object.</param>
        /// <param name="inParent">The parent of the part. (installed)</param>
        /// <param name="inPartTrigger">The trigger for the part.</param>
        /// <param name="inPartPosition">The position for  the part's installed location</param>
        /// <param name="inPartRotation">The rotion for  the part's installed location</param>
        public CarJackPart(PartSaveInfo inPartSaveInfo, GameObject inPart, GameObject inParent, Trigger inPartTrigger, Vector3 inPartPosition, Quaternion inPartRotation) : base(inPartSaveInfo, inPart, inParent, inPartTrigger, inPartPosition, inPartRotation)
        {
            // Written, 08.03.2019

            // Setting names of the rigid game object.
            this.rigidPart.name = "car jack(clone)";
            // Destorying all objects on the rigid part (installed instance of the car jack).
            foreach (Object _obj in this.rigidPart.GetComponents<Object>().Where(_obj => !(_obj is BoxCollider) && !(_obj is Rigid)))
                Object.Destroy(_obj);
            // Adding fix to rigid part.. untagging gameobject on rigid start
            this.rigidPart.AddComponent<DontPickThisGameObjectMono>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Overrided for a check to see if the carjack has been folded.
        /// </summary>
        /// <param name="inStartup">startup sequ</param>
        protected override void assemble(bool inStartup = false)
        {
            // Written, 09.03.2019

            if (!this.carJackOpen) // Only run assemble logic if car jack is folded.
                base.assemble(inStartup);
        }
        /// <summary>
        /// Overrided for a check to see if the carjack has been folded.
        /// </summary>
        /// <param name="inCollider">The collider that stays in the trigger.</param>
        protected override void onTriggerStay(Collider inCollider)
        {
            // Written, 16.03.2019
            /* 
             * Note, as overriding this method, thus the logic and adding any extra branches/paths that the code can take on game exeucution. 
             * You must add some checks/logic to make the code only run when the collider is the part's active gameobject's collider.
            */
            if (this.isPartCollider(inCollider))
                if (this.isPlayerHoldingPart) // Only want to run logic if the player is hold the part, car jack.            
                    if (carJackOpen)
                    {
                        // Displaying an interaction to the player for some supportive feedback..
                        ModApi.ModClient.guiInteract("Close handle to install", ModApi.GuiInteractSymbolEnum.Disassemble); return;
                    }
            base.onTriggerStay(inCollider); // calling base to get disassemble logic, (IMPORTANT).
        }
        /// <summary>
        /// Overrided for a check to see if the carjack has been folded.
        /// </summary>
        /// <param name="inCollider">The collider that enters the trigger.</param>
        protected override void onTriggerExit(Collider inCollider)
        {
            // Written, 16.03.2019
            /* 
             * Note, as overriding this method, thus the logic and adding any extra branches/paths that the code can take on game exeucution. 
             * You must add some checks/logic to make the code only run when the collider is the part's active gameobject's collider.
            */

            if (this.isPartCollider(inCollider)) // checking that the collider is the part's active box collider.
                if (carJackOpen)
                    ModApi.ModClient.guiInteract(); // resetting gui interaction
                else
                    base.onTriggerExit(inCollider); // calling base to get disassemble logic; on trigger exit cleans up gui interact.
        }

        #endregion
    }
}
