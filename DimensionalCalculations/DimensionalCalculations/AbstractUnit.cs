using System.Collections.Generic;

namespace Physics.PhysicalDimensions
{
    public abstract class AbstractUnit
    {
        public abstract int[] DimArray
        {
            get;// return new int[7]; }
            //protected set { DimArray = value; }
        }

        public int Length
        {
            get { return DimArray[0]; }
        }

        public int Mass
        {
            get { return DimArray[1]; }
        }

        public int Time
        {
            get { return DimArray[2]; }
        }

        public int Temperature
        {
            get { return DimArray[3]; }
        }

        public int Current
        {
            get { return DimArray[4]; }
        }

        public int Candela
        {
            get { return DimArray[5]; }
        }

        public int Mole
        {
            get { return DimArray[6]; }
        }


        public abstract string Name { get; }

        public List<Dimension> Dimension { get; protected set; }

        public abstract double ToSI(double value);

        public abstract double ToCGS(double value);
    }
}
