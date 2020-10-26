using System;
using System.Collections.Generic;
using System.Text;

namespace testJuryNumberProject
{
    public class NumberPrinter
    {
        bool IsDotNeed { get; set; }
        int DisplayAfterDot { get; set; }
        public NumberPrinter(bool isNeedDot, int countAfterDot)
        {
            IsDotNeed = isNeedDot;
            DisplayAfterDot = countAfterDot;
        }

        public string Print(double valueToPrint)
        {
            valueToPrint = Math.Round(valueToPrint, DisplayAfterDot);
            string result = string.Empty;
            string pattern = $"F{DisplayAfterDot}";

            result = valueToPrint.ToString(pattern, System.Globalization.CultureInfo.InvariantCulture);
            if (IsDotNeed)
            {
                if ((valueToPrint % 1) == 0)
                    result = result.Split('.')[0] + ".";
            }
            else
            {
                if ((valueToPrint % 1) == 0)
                    result = result.Split('.')[0];
            }
            result.TrimEnd('0');
            return result;
        }
    }
}
