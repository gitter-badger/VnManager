using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace VisualNovelManager.Helpers
{
    public class MeasureStringSize
    {
        public static double SetMaxStringWidth(IEnumerable<string> collection)
        {
            string longestString = collection.OrderByDescending(s => s.Length).First();
            FormattedText formattedText = new FormattedText(
                longestString, CultureInfo.InvariantCulture, FlowDirection.LeftToRight,
                new Typeface(new FontFamily("Segoe UI"), FontStyles.Normal, FontWeights.Bold, FontStretches.Normal),
                13, Brushes.Black);
            //add 10 for some extra padding
            return formattedText.Width + 25;
        }
    }
}
