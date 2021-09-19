using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using Sandbox.Game.EntityComponents;
using Sandbox.ModAPI.Ingame;
using Sandbox.ModAPI.Interfaces;
using SpaceEngineers.Game.ModAPI.Ingame;
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
        private double maxDistance;                             // Define current max distance between ship and its waypoint.

        private double TotalMassOfShip;                         // Define the total weight(mass) of the ship.

        private float PowerConsumption;                         // Define the total power consumption.

        private List<string> CompileError;                      // Define a list of compile error messages.
        
        private List<string> Status;                            // Define a list of status messages.

        IMyCockpit Cockpit;                                     // Define a Cockpit variable.

        // =====================================================================================
        // Power related component.
        List<IMyReactor> Reactors;                              // Define a list of Reactors.

        List<IMyBatteryBlock> Batteries;                        // Define a list of Batteries.

        List<IMySolarPanel> SolarPanels;                        // Define a list of Solar panels.

        // =====================================================================================
        List<IMyThrust> Thrusters;                              // Define a list of thrusters.


        // this is a constructor.
        public Program()
        {
            Setup();
            PrintStatus();
        }

        public void Save()
        {
            // Save the stats of the porgram.
        }

        public void Main(string argument, UpdateType updateSource)
        {
            // Start of the program here.
        }

        // Returns the mass of the ship as a float.
        public float CalculateMasOfShip() { return Cockpit != null? Cockpit.CalculateShipMass().TotalMass: 0.0f; }

        public void Setup()
        {
            CompileError = new List<string>();                      // Initialize CompileError to an empty string list.

            // Grab a block of type cockpit named cockpit.
            Cockpit = GridTerminalSystem.GetBlockWithName("Main Cockpit") as IMyCockpit;
            if (Cockpit == null)
            {
                CompileError.Add("- Main Cockpit Not found");
            }

            // create an empty list of thrusters.
            Thrusters = new List<IMyThrust>(); 
            // populate the list with thrusters.
            GridTerminalSystem.GetBlocksOfType<IMyThrust>(Thrusters); 
            if(Thrusters.Count == 0) 
            {
                CompileError.Add("- Thrusters Not found");
            }

            // Grabs the power component in the ship.
            Reactors = new List<IMyReactor>();
            GridTerminalSystem.GetBlocksOfType<IMyReactor>(Reactors);

            Batteries = new List<IMyBatteryBlock>();
            GridTerminalSystem.GetBlocksOfType<IMyBatteryBlock>(Batteries);

            SolarPanels = new List<IMySolarPanel>();
            GridTerminalSystem.GetBlocksOfType<IMySolarPanel>(SolarPanels);
        }

        public void PrintStatus() 
        {
            if(CompileError.Count <= 0)                     // if compile error is less than zero.
            {
                Echo("Compiled Successfully");              // then echo compiled successfully and return.
            }
            else 
            {
                Echo("Compiled Erros:");
                // otherwise.
                foreach (string error in CompileError)
                {
                    Echo(error);
                }
            }
        }


        // return the maximum distance from ship to a waypoint
        public double CalculateMaxDistance(VRageMath.Vector3D waypoint )
        {
            VRageMath.Vector3D currentPosition = new VRageMath.Vector3D(0 ,0 ,0);

            if(Cockpit != null) 
            {
                currentPosition = Cockpit.Position;
            }
            
            return 3.14 * (VRageMath.Vector3D.Distance(currentPosition, waypoint) / 2);
        }

        // end of code.
    }
}
