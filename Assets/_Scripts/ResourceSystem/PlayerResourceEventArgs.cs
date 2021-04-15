using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class PlayerResourceEventArgs
{
    public int WoodValue;
    public int StoneValue;
    public int IronValue;
    public int ElectronicsValue;
    public PlayerResourceEventArgs(int woodCost, int stoneCost, int ironCost, int electronicsCost)
    {
        WoodValue = woodCost;
        StoneValue = stoneCost;
        IronValue = ironCost;
        ElectronicsValue = electronicsCost;
    }
    public PlayerResourceEventArgs(ResourceAmounts resource)
    {
        WoodValue = resource.wood;
        StoneValue = resource.stone;
        IronValue = resource.iron;
        ElectronicsValue = resource.electronics;
    }
}

