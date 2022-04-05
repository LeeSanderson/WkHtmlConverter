using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace WkHtmlConverter
{
    public class Margins
    {
        public double? Top { get; set;  }
        public double? Bottom { get; set;  }
        public double? Left { get; set; }
        public double? Right { get; set; }
        public MarginUnits Units { get; set; }

        internal string? WithUnitsFor(double? dimension) =>
            (dimension, Units) switch
            {
                (null, _) => null,
                (_, MarginUnits.Millimeters) => dimension + "mm",
                (_, MarginUnits.Centimeters) => dimension + "cm",
                _ => dimension + "in"
            };
    }
}
