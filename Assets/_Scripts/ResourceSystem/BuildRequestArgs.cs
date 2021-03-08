using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class BuildRequestArgs : EventArgs
{
    public bool CanBuild { get; set; }
    public float WoodCost { get; }
    public float StoneCost { get; }
    public float IronCost { get; }
    public float ElectronicsCost { get; }

    public BuildRequestArgs(float woodCost, float stoneCost, float ironCost, float electronicsCost) 
    {
        WoodCost = woodCost;
        StoneCost = stoneCost;
        IronCost = ironCost;
        ElectronicsCost = electronicsCost;
    }
}

