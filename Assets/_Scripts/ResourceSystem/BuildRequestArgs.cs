using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class BuildRequestArgs : PlayerResourceEventArgs
{
    public bool CanBuild { get; set; }
    public BuildRequestArgs(float woodCost, float stoneCost, float ironCost, float electronicsCost) : base(woodCost, stoneCost, ironCost, electronicsCost)
    {
        ;
    }
}

