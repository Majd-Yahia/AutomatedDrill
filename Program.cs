using Sandbox.Game.EntityComponents;
using Sandbox.ModAPI.Ingame;
using Sandbox.ModAPI.Interfaces;
using SpaceEngineers.Game.ModAPI.Ingame;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using VRage;
using VRage.Collections;
using VRage.Game;
using VRage.Game.Components;
using VRage.Game.GUI.TextPanel;
using VRage.Game.ModAPI.Ingame;
using VRage.Game.ModAPI.Ingame.Utilities;
using VRage.Game.ObjectBuilders.Definitions;
using VRageMath;

namespace IngameScript
{
    partial class Program : MyGridProgram
    {
        private double TotalMassOfShip;             // Define the total weight(mass) of the ship.

        IMyCockpit Cockpit;                         // Define a Cockpit variable
        List<IMyThrust> Thrusters;                  // Define thrusters list.

        // This file contains your actual script.
        //
        // You can either keep all your code here, or you can create separate
        // code files to make your program easier to navigate while coding.
        //
        // In order to add a new utility class, right-click on your project, 
        // select 'New' then 'Add Item...'. Now find the 'Space Engineers'
        // category under 'Visual C# Items' on the left hand side, and select
        // 'Utility Class' in the main area. Name it in the box below, and
        // press OK. This utility class will be merged in with your code when
        // deploying your final script.
        //
        // You can also simply create a new utility class manually, you don't
        // have to use the template if you don't want to. Just do so the first
        // time to see what a utility class looks like.
        // 
        // Go to:
        // https://github.com/malware-dev/MDK-SE/wiki/Quick-Introduction-to-Space-Engineers-Ingame-Scripts
        //
        // to learn more about ingame scripts.


        // Refer to this API
        // https://github.com/malware-dev/MDK-SE/wiki/Api-Index



        public Program()
        {
            // Define varaibles that are used a lot.



            // Example on Defining blocks:

            // ====================================================================================================================================
            // Example 1:
            // This looks for a block of type IMyTerminalBlock and with the name Timer Block and treats it as a variable with the name timer.
            // ====================================================================================================================================
            // IMyTerminalBlock timer = GridTerminalSystem.GetBlockWithName("Timer Block") as IMyTerminalBlock


            // ====================================================================================================================================
            // Example 2:
            // This makes a block list called timers_list, and fills it with every block called Timer Block.
            // ====================================================================================================================================
            // List<IMyTerminalBlock> timers_list = new List<IMyTerminalBlock>();  
            // GridTerminalSystem.SearchBlocksOfName("Timer Block", timers_list);

            // ====================================================================================================================================
            // Example 3:
            // his fills a list with all the blocks of type IMyTimerBlock.
            // ====================================================================================================================================
            // GridTerminalSystem.GetBlocksOfType<IMyTimerBlock>(timers_list);

            Cockpit = GridTerminalSystem.GetBlockWithName("Cockpit") as IMyCockpit;     // Grab a block of type cockpit named cockpit.

            Thrusters = new List<IMyThrust>();                                          // create an empty list of thrusters.
            GridTerminalSystem.GetBlocksOfType<IMyThrust>(Thrusters);                   // populate the list with thrusters.

            if(Cockpit != null)
            {
                TotalMassOfShip = Cockpit.CalculateShipMass().TotalMass;
            }


        }

        public void Save()
        {
            // Save the stats of the porgram.
        }

        public void Main(string argument, UpdateType updateSource)
        {
            // The main entry point of the script, invoked every time
            // one of the programmable block's Run actions are invoked,
            // or the script updates itself. The updateSource argument
            // describes where the update came from. Be aware that the
            // updateSource is a  bitfield  and might contain more than 
            // one update type.
            // 
            // The method itself is required, but the arguments above
            // can be removed if not needed.

            PrintTotalMassOfShip();
        }


        public void PrintTotalMassOfShip()
        {
            Echo(TotalMassOfShip.ToString());
        }
        
    }
}
