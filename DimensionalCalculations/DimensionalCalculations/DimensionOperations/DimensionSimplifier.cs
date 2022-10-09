using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimensionalCalculations.DimensionOperations
{
    public static class DimensionSimplifier
    {
        public static string ConvertToString(PhysicalQuantity pq, SystemOfUnits systemOfUnits)
        {
            IEnumerable<AbstractUnit> baseUnits = UnitsBase.GetUnits(systemOfUnits).
                OrderByDescending(unit => GetDimensionVectorLength(unit.Dimension));

            IEnumerable<(AbstractUnit Unit, int Power)> unitsInPowers = 
                DecomposeDimension(pq.Dimension, baseUnits);


            IEnumerable<(AbstractUnit Unit, int Power)> nominatorUnits = unitsInPowers.Where(x => x.Power >= 1);
            IEnumerable<(AbstractUnit Unit, int Power)> denominatorUnits = unitsInPowers.Where(x => x.Power <= -1);

            string nom = ConvertToString(nominatorUnits, baseUnits, false);
            string denom = ConvertToString(denominatorUnits, baseUnits, true); ;

            // HACK: [CG, 2022.10.09] Value will change because of system of units
            if (nom.Length == 0 && denom.Length == 0)
            {
                return $"{ pq.Value }";
            }
            else if(nom.Length == 0)
            {
                return $"{ pq.Value } 1 / ({ denom })";
            }
            else if(denom.Length == 0)
            {
                return $"{ pq.Value } { nom }";
            }
            else
            {
                return $"{ pq.Value }";
            }            
        }

        private static string ConvertToString(IEnumerable<(AbstractUnit Unit, int Power)> units,
            IEnumerable<AbstractUnit> baseUnits, bool inversePowers)
        {
            string output = "";

            foreach(var item in units)
            {
                string unitStr = UnitsBase.GetAlias(item.Unit.GetType());
                string prefix = GetMetricPrefix(item.Unit, baseUnits);

                int power = inversePowers ? -item.Power : item.Power;

                if (power == 1)
                {
                    output += $"{prefix + unitStr}";
                }
                else
                {
                    output += $"{prefix + unitStr}^({power})";
                }

                output += " ";
            }

            return output;
        }

        private static string GetMetricPrefix(AbstractUnit unit, IEnumerable<AbstractUnit> baseUnits)
        {
            AbstractUnit baseUnit = baseUnits
                .Where(bu => unit.Dimension == bu.Dimension)
                .First();

            if(unit.ToSI(1) == baseUnit.ToSI(1))
            {
                return "";
            }
            else
            {
                double multiplier = unit.ToSI(1) / baseUnit.ToSI(1);
                int power = GetPowerOfTen(multiplier);
                MetricPrefix prefix = MetricPrefixes.GetMetricPrefix(power);
                return MetricPrefixes.GetMetricPrefixAliases(prefix).First();
            }
        }   

        private static int GetPowerOfTen(double number)
        {
            if (number == 1)
            {
                return 0;
            }
            else if (number > 1)
            {
                int num = (int)number;
                if((double)num == number)
                {
                    return GetPowerOfTen(num);
                }
                else
                {
                    throw new ArgumentException($"Number must be a power of ten. Actual number = { number }.");
                }
            }
            else if (number < 1)
            {
                int num = (int)(1.0 / number);
                return -GetPowerOfTen(num);
            }
            else
            {
                throw new ArgumentException($"Number must be a power of ten. Actual number = {number}.");
            }
        }

        private static int GetPowerOfTen(int number)
        {
            int power = 1;

            if(number % 10 == 0)
            {
                while (number/10 > 1)
                {
                    number = number / 10;
                    power++;
                }

                return power;
            }
            else
            {
                throw new ArgumentException($"Number must be a power of ten. Actual number = { number }.");
            }
        }
            
        private static IEnumerable<(AbstractUnit, int)> DecomposeDimension(DimensionVector dimension, IEnumerable<AbstractUnit> baseUnits)
        {
            if(GetDimensionVectorLength(dimension) == 0)
            {
                return Array.Empty<(AbstractUnit, int)>();
            }

            IEnumerable<AbstractUnit> orderedBaseUnits = baseUnits.
                OrderByDescending(unit => GetDimensionVectorLength(unit.Dimension));

            Dictionary<AbstractUnit, int> output = new Dictionary<AbstractUnit, int>();

            DimensionVector remainingDimension = dimension;
            while(GetDimensionVectorLength(remainingDimension) > 1)
            {
                AbstractUnit minDistUnit = orderedBaseUnits
                    .MinBy(unit => DimensionVector.GetDistance(unit.Dimension, remainingDimension));

                if(!output.ContainsKey(minDistUnit))
                {
                    output.Add(minDistUnit, 0);
                }

                double dist = DimensionVector.GetDistance(minDistUnit.Dimension, remainingDimension);
                if (dist > 0)
                {
                    output[minDistUnit] += 1;
                    remainingDimension -= minDistUnit.Dimension;
                }
                else
                {
                    output[minDistUnit] -= 1;
                    remainingDimension += minDistUnit.Dimension;
                }
            }

            var remainsUnit = orderedBaseUnits
                .Where(unit => unit.Dimension == remainingDimension || unit.Dimension == -remainingDimension)
                .First();
            if (!output.ContainsKey(remainsUnit))
            {
                output.Add(remainsUnit, 0);
            }

            if(remainsUnit.Dimension == remainingDimension)
            {
                output[remainsUnit] += 1;
            }
            else
            {
                output[remainsUnit] -= 1;
            }

            return output.Select(item => (item.Key, item.Value));
        }

        private static int GetDimensionVectorLength(DimensionVector dimension)
        {
            return
                Math.Abs(dimension.AmountOfSubstance) +
                Math.Abs(dimension.Current) +
                Math.Abs(dimension.Length) +
                Math.Abs(dimension.LuminousIntensity) +
                Math.Abs(dimension.Mass) +
                Math.Abs(dimension.Temperature) +
                Math.Abs(dimension.Time);
        }
    }
}
