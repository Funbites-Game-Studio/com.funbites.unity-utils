using System.Text;
namespace Funbites.UnityUtils
{
    public static class StringUtils
    {
        public static string FormatMinutesToClockTime(this int minutes)
        {
            int hours = (minutes / 60);
            StringBuilder sb = new StringBuilder();
            sb.AppendTwoDigitNumber(hours);
            sb.Append(':');
            minutes %= 60;
            sb.AppendTwoDigitNumber(minutes);
            return sb.ToString();
        }

        private static void AppendTwoDigitNumber(this StringBuilder sb, int number)
        {
            if (number > 10)
            {
                sb.Append(number);
            } else
            {
                sb.Append('0');
                sb.Append(number);
            }
        }
    }
}