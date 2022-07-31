using System.Diagnostics.CodeAnalysis;

namespace DimensionalCalculations
{
    public struct DimensionVector
    {
        public int Length
        {
            get { return _dimArray[0]; }
            set { _dimArray[0] = value; }
        }

        public int Mass
        {
            get { return _dimArray[1]; }
            set { _dimArray[1] = value; }
        }

        public int Time
        {
            get { return _dimArray[2]; }
            set { _dimArray[2] = value; }
        }

        public int Temperature
        {
            get { return _dimArray[3]; }
            set { _dimArray[3] = value; }
        }

        public int Current
        {
            get { return _dimArray[4]; }
            set { _dimArray[4] = value; }
        }
        
        public int LuminousIntensity
        {
            get { return _dimArray[5]; }
            set { _dimArray[5] = value; }
        }

        public int AmountOfSubstance
        {
            get { return _dimArray[6]; }
            set { _dimArray[6] = value; }
        }


        private int[] _dimArray = new int[7];


        public DimensionVector()
        {

        }


        public static DimensionVector operator +(DimensionVector a, DimensionVector b)
        {
            return new DimensionVector()
            {
                Length = a.Length + b.Length,
                Mass = a.Mass + b.Mass,
                Time = a.Time + b.Time,
                Temperature = a.Temperature + b.Temperature,
                Current = a.Current + b.Current,
                LuminousIntensity = a.LuminousIntensity + b.LuminousIntensity,
                AmountOfSubstance = a.AmountOfSubstance + b.AmountOfSubstance
            };
        }

        public static DimensionVector operator -(DimensionVector a)
        {
            return new DimensionVector()
            {
                Length = -a.Length,
                Mass = -a.Mass,
                Time = -a.Time,
                Temperature = -a.Temperature,
                Current = -a.Current,
                LuminousIntensity = -a.LuminousIntensity,
                AmountOfSubstance = -a.AmountOfSubstance
            };
        }

        public static DimensionVector operator -(DimensionVector a, DimensionVector b)
        {
            return a + (-b);
        }

        public static bool operator ==(DimensionVector dv1, DimensionVector dv2)
        {
            return dv1.LuminousIntensity == dv2.LuminousIntensity
                && dv1.Current == dv2.Current
                && dv1.Length == dv2.Length
                && dv1.Mass == dv2.Mass
                && dv1.AmountOfSubstance == dv2.AmountOfSubstance
                && dv1.Time == dv2.Time
                && dv1.Temperature == dv2.Temperature;
        }

        public static bool operator !=(DimensionVector dv1, DimensionVector dv2)
            => !(dv1 == dv2);

        public bool IsDimensionless()
        {
            return LuminousIntensity == 0
                && Current == 0
                && Length == 0
                && Mass == 0
                && AmountOfSubstance == 0
                && Time == 0
                && Temperature == 0;
        }
    }
}
