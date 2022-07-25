using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DimensionalCalculations.Units.UnitsLength;
using DimensionalCalculations.Units.UnitsTime;

namespace DimensionalCalculations
{
    public enum DimensionName
    {
        Meter,
        Mile,

        Second,
    }

    public class DimensionDictionaries
    {
        public static Dictionary<DimensionName, AbstractUnit> UnitsDictionary = new Dictionary<DimensionName, AbstractUnit>
        {
            {DimensionName.Meter, new Meter()},
            {DimensionName.Mile,  new Mile()},

            {DimensionName.Second,  new Second()}
        };
    }
}
