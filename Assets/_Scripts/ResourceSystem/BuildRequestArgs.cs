using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class BuildRequestArgs : PlayerResourceEventArgs
{
    public bool CanBuild { get; set; }
    public BuildRequestArgs(int woodCost, int stoneCost, int ironCost, int electronicsCost) : base(woodCost, stoneCost, ironCost, electronicsCost)
    {
        CanBuild = false;
    }
}

