using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class PlayerResourceEventArgs
{
    public float WoodValue { get; }
    public float StoneValue { get; }
    public float IronValue { get; }
    public float ElectronicsValue { get; }
    public PlayerResourceEventArgs(float woodCost, float stoneCost, float ironCost, float electronicsCost)
    {
        WoodValue = woodCost;
        StoneValue = stoneCost;
        IronValue = ironCost;
        ElectronicsValue = electronicsCost;
    }
}

