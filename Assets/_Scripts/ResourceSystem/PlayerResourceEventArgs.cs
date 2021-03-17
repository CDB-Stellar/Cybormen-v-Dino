using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class PlayerResourceEventArgs
{
    public int WoodValue { get; }
    public int StoneValue { get; }
    public int IronValue { get; }
    public int ElectronicsValue { get; }
    public PlayerResourceEventArgs(int woodCost, int stoneCost, int ironCost, int electronicsCost)
    {
        WoodValue = woodCost;
        StoneValue = stoneCost;
        IronValue = ironCost;
        ElectronicsValue = electronicsCost;
    }
}

