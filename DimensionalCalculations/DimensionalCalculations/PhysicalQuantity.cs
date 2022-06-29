using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics.PhysicalDimensions
{
    /// <summary>
    /// Физическая величина. Имеет числовое значение и размерность.
    /// </summary>
    public class PhysicalQuantity
    {
        public double Value;

        public List<Dimension> Dimension;


        public PhysicalQuantity(double value, List<Dimension> dimensions)
        {
            this.Value = value;
            this.Dimension = dimensions;
        }

        public PhysicalQuantity(double value, params Dimension[] dimensions)
        {
            this.Value = value;
            this.Dimension = dimensions.ToList();
        }

        // TODO: [CG, 2022.06.28] Хрень, плохая сигнатура - неочевидная
        public PhysicalQuantity(double value, params Tuple<DimensionName, int>[] dimensions)
        {
            this.Value = value;

            Dimension[] dimensionsArray = new Dimension[dimensions.Length];
            for (int i = 0; i < dimensions.Length; i++)
            {
                dimensionsArray[i] = new Dimension(dimensions[i].Item1, dimensions[i].Item2);
            }
            // Исключить повторения возможных единиц измерения 
            this.Dimension = dimensionsArray.ToList();
        }


        public double ToSI()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            // Есть ли размерности в знаменателе?
            bool AreDividers = false;

            int dimensionIndex = 0;
            while ((AreDividers == false) && (dimensionIndex < this.Dimension.Count))
            {
                if (Dimension[dimensionIndex].Power < 0)
                {
                    AreDividers = true;
                }
                dimensionIndex++;
            }

            

            string outStr = "";
            // Заполняем строчку числителя
            for (int i = 0; i < this.Dimension.Count; i++)
            {
                if (this.Dimension[i].Power >= 0)
                {
                    string powerStr = "";
                    if (this.Dimension[i].Power > 1)
                    {
                        powerStr = "^(" + this.Dimension[i].Power.ToString() + ")";
                    }
                    outStr += " " + DimensionDictionaries.UnitsDictionary[this.Dimension[i].Unit].Name + powerStr;
                }
            }

            if (AreDividers)
            {
                outStr += @" /";
                // А теперь знаменатель
                for (int i = 0; i < this.Dimension.Count; i++)
                {
                    if (this.Dimension[i].Power < 0)
                    {
                        string powerStr = "";
                        if (this.Dimension[i].Power < -1)
                        {
                            powerStr = "^(" + (-this.Dimension[i].Power).ToString() + ")";
                        }
                        outStr += " " + DimensionDictionaries.UnitsDictionary[this.Dimension[i].Unit].Name + powerStr;
                    }
                }
            }

            return this.Value + outStr;
        }
    }
}
