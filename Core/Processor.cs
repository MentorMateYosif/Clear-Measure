using System;
using System.Text;

namespace Core
{
    public static class Processor
    {
        #region Constants

        private const string FIZZ = "fizz";
        private const string BUZZ = "buzz";

        #endregion

        public static string Execute(short startIndex, short endIndex)
        {
            var values = new StringBuilder();

            for (var index = startIndex; index <= endIndex; index++)
            {
                var isDividedByThree = IsDividedWithoutResidue(index, 3);
                var isDividedByFive = IsDividedWithoutResidue(index, 5);
                var nextIndex = index + 1;
                var nextIsDividedByThree = IsDividedWithoutResidue(nextIndex, 3);
                var nextIsDividedByFive = IsDividedWithoutResidue(nextIndex, 5);
                var formattedFizz = FormatText(FIZZ, isDividedByThree, isDividedByFive || nextIsDividedByFive);

                if (!string.IsNullOrWhiteSpace(formattedFizz))
                {
                    values.Append(formattedFizz);
                }

                if (isDividedByThree && isDividedByFive)
                {
                    values.Append(string.Format(" {0}{1}", BUZZ, Environment.NewLine));

                    continue;
                }

                var formattedBuzz = FormatText(BUZZ, isDividedByFive, isDividedByThree || nextIsDividedByThree);

                if (!string.IsNullOrWhiteSpace(formattedBuzz))
                {
                    values.Append(formattedBuzz);
                }

                if (isDividedByThree || isDividedByFive)
                {
                    continue;
                }

                var formattedIndex = AppendIndex(index, nextIsDividedByThree || nextIsDividedByFive);

                values.Append(formattedIndex);
            }

            return values.ToString().Trim();
        }

        #region Helper methods

        private static bool IsDividedWithoutResidue(int index, int divider)
        {
            return index % divider == 0;
        }

        private static string FormatText(string text, bool isDividable, bool formatCondition)
        {
            if (!isDividable)
            {
                return null;
            }

            return formatCondition
                ? string.Format(" {0}", text)
                : string.Format(" {0}{1}", text, Environment.NewLine);
        }

        private static string AppendIndex(int index, bool formatCondition)
        {
            return formatCondition
                ? index.ToString()
                : string.Format("{0}{1}", index, Environment.NewLine);
        }

        #endregion
    }
}