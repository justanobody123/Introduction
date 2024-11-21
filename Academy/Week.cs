using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
	static internal class Week
	{
		static readonly string[] DayNames = new string[] { "Пн", "Вт", "Ср", "Чт", "Пт", "Сб", "Вс" };
		public static string ExtractDaysToString(byte days)
		{
			string result = "";
			for (int i = 0; i < 7; i++)
			{
				if ((days & (1 << i)) != 0)
				{
					result += DayNames[i] + ", ";
				}
				
			}

			if (!string.IsNullOrEmpty(result))
			{
				result = result.Remove(result.LastIndexOf(", ")); 
			}
			return result;
		}
		public static byte CompressStringToByte(string assignedDays)
		{
			byte days = 0;
			for (int i = 0; i < 7; i++)
			{
				if (assignedDays.Contains(DayNames[i]))
				{
					days |= (byte)(1 << i);
				}
			}
			return days;

		}

	}
}
