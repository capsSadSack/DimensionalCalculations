namespace DimensionalCalculations.Units
{
    public class MetricPrefixDecorator : AbstractUnitDecorator
    {
        private double _multiplicationNumber;

        public double MultiplicationNumber
        {
            get => _multiplicationNumber;
        }

        public Type Type { get; }

        public override DimensionVector Dimension
        {
            get
            {
                return _instance.Dimension;
            }
            set
            {
                _instance.Dimension = value;
            }
        }


        public MetricPrefixDecorator(AbstractUnit instance, int powerOfTen) 
            : base(instance)
        {
            Type = instance.GetType();
            _multiplicationNumber = Math.Pow(10, powerOfTen);
        }


        public override double FromSI(double value)
        {
            return base.FromSI(value) / _multiplicationNumber;
        }

        public override double ToSI(double value)
        {
            return _multiplicationNumber * base.ToSI(value);
        }
    }
}
