using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

public class RTL
{
	public enum PartMode
	{
		Arabic,
		English,
		LatinNumbers,
		ArabicNumbers,
		Punctuation
	}

	public static string punctuationMarks = "</>`~!!!@#$%^&*()_++÷×=:-\\|][}{<>/?.,;'\"";

	public static string latinChars = "0123456789abcdefghijklmnopqrstuvwxyz";

	public static string arabicIntegers = "٠٩٨٧٦٥٤٣٢١";

	public static string GetText(string input, bool convertNumbers = true, bool isLtrText = false, int wordWrapBias = 0, bool keepLtrClean = false)
	{
	    if (input != null)
	    {
	        if (wordWrapBias > 0)
	        {
	            input = RTL.a(input, wordWrapBias);
	        }
	        string[] array = input.Split(new char[]
	        {
	            '\n'
	        });
	        StringBuilder stringBuilder = new StringBuilder();
	        for (int i = 0; i < array.Length; i++)
	        {
	            stringBuilder.Append(RTL.a(array[i], convertNumbers, isLtrText, keepLtrClean));
	            if (i != array.Length - 1)
	            {
	                stringBuilder.Append('\n');
	            }
	        }
	        return stringBuilder.ToString();
	    }
	    return "";
	}

    private static string a(string A_0, bool A_1, bool A_2, bool A_3)
	{
		string result;
		try
		{
			if (A_0.Length == 0)
			{
				result = "";
			}
			else
			{
				A_0 = A_0.Replace("ی", "ي");
				string text = "";
				int i = 0;
				List<char> list = new List<char>(A_0.ToCharArray());
				list.Reverse();
				while (i < list.Count)
				{
					string a_ = RTL.a(list, A_1, ref i);
					text += RTL.b(a_);
					i++;
				}
				List<string> list2 = new List<string>(text.Split(new char[]
				{
					' '
				}));
				list2.Reverse();
				new List<string>();
				for (i = 0; i < list2.Count; i++)
				{
					if (list2[i] == "ﺔﻠﻟﺍ" || list2[i] == "ﺔﻠﻟﺃ" || list2[i] == "ﻪﻠﻟﺍ" || list2[i] == "ﻪﻠﻟﺃ")
					{
						list2[i] = char.ConvertFromUtf32(65010) + char.ConvertFromUtf32(65165);
					}
					if (list2[i] == "ﻪﻠﻟ" || list2[i] == "ﺔﻠﻟ")
					{
						list2[i] = char.ConvertFromUtf32(65010);
					}
				}
				text = "";
				bool flag = true;
				foreach (string current in list2)
				{
					if (flag)
					{
						for (int j = 0; j < current.Length; j++)
						{
							flag &= (RTL.punctuationMarks.IndexOf(current[j]) != -1 || RTL.latinChars.IndexOf(current.ToLower()[j]) != -1);
						}
					}
				}
				if (!A_2 && !flag)
				{
					list2.Reverse();
				}
				for (int k = 0; k < list2.Count; k++)
				{
					string a_2 = list2[k];
					text += RTL.a(RTL.a(a_2, A_2, A_3), "");
					if (k != list2.Count - 1)
					{
						text += " ";
					}
				}
				result = text;
			}
		}
		catch (Exception)
		{
			result = "";
		}
		return result;
	}

	private static string a(List<char> A_0, bool A_1, ref int A_2)
	{
		char arg_08_0 = A_0[A_2];
		if (A_0[A_2] == '\0')
		{
			A_0.RemoveAt(A_2);
			A_2--;
			return "";
		}
		string result = A_0[A_2].ToString();
		string key;
		switch (key = A_0[A_2].ToString())
		{
		case "ا":
			result = RTL.a(A_0, A_2, "0xFE8D", "0xFE8D", "0xFE8E", "0xFE8E");
			return result;
		case "أ":
			result = RTL.a(A_0, A_2, "0xFE83", "0xFE83", "0xFE84", "0xFE84");
			return result;
		case "إ":
			result = RTL.a(A_0, A_2, "0xFE87", "0xFE87", "0xFE88", "0xFE88");
			return result;
		case "آ":
			result = RTL.a(A_0, A_2, "0xFE81", "0xFE81", "0xFE82", "0xFE82");
			return result;
		case "ب":
			result = RTL.a(A_0, A_2, "0xFE8F", "0xFE91", "0xFE92", "0xFE90");
			return result;
		case "پ":
			result = RTL.a(A_0, A_2, "0xFB56", "0xFB58", "0xFB59", "0xFB57");
			return result;
		case "ت":
			result = RTL.a(A_0, A_2, "0xFE95", "0xFE97", "0xFE98", "0xFE96");
			return result;
		case "ث":
			result = RTL.a(A_0, A_2, "0xFE99", "0xFE9B", "0xFE9C", "0xFE9A");
			return result;
		case "ج":
			result = RTL.a(A_0, A_2, "0xFE9D", "0xFE9F", "0xFEA0", "0xFE9E");
			return result;
		case "چ":
			result = RTL.a(A_0, A_2, "0xFB7A", "0xFB7C", "0xFB7D", "0xFB7B");
			return result;
		case "ح":
			result = RTL.a(A_0, A_2, "0xFEA1", "0xFEA3", "0xFEA4", "0xFEA2");
			return result;
		case "خ":
			result = RTL.a(A_0, A_2, "0xFEA5", "0xFEA7", "0xFEA8", "0xFEA6");
			return result;
		case "د":
			result = RTL.a(A_0, A_2, "0xFEA9", "0xFEA9", "0xFEAA", "0xFEAA");
			return result;
		case "ذ":
			result = RTL.a(A_0, A_2, "0xFEAB", "0xFEAB", "0xFEAC", "0xFEAC");
			return result;
		case "ر":
			result = RTL.a(A_0, A_2, "0xFEAD", "0xFEAD", "0xFEAE", "0xFEAE");
			return result;
		case "ز":
			result = RTL.a(A_0, A_2, "0xFEAF", "0xFEAF", "0xFEB0", "0xFEB0");
			return result;
		case "ژ":
			result = RTL.a(A_0, A_2, "0x0698", "0x0698", "0xFB8B", "0xFB8B");
			return result;
		case "س":
			result = RTL.a(A_0, A_2, "0xFEB1", "0xFEB3", "0xFEB4", "0xFEB2");
			return result;
		case "ش":
			result = RTL.a(A_0, A_2, "0xFEB5", "0xFEB7", "0xFEB8", "0xFEB6");
			return result;
		case "ص":
			result = RTL.a(A_0, A_2, "0xFEB9", "0xFEBB", "0xFEBC", "0xFEBA");
			return result;
		case "ض":
			result = RTL.a(A_0, A_2, "0xFEBD", "0xFEBF", "0xFEC0", "0xFEBE");
			return result;
		case "ط":
			result = RTL.a(A_0, A_2, "0xFEC1", "0xFEC3", "0xFEC4", "0xFEC2");
			return result;
		case "ظ":
			result = RTL.a(A_0, A_2, "0xFEC5", "0xFEC7", "0xFEC8", "0xFEC6");
			return result;
		case "ع":
			result = RTL.a(A_0, A_2, "0xFEC9", "0xFECB", "0xFECC", "0xFECA");
			return result;
		case "غ":
			result = RTL.a(A_0, A_2, "0xFECD", "0xFECF", "0xFED0", "0xFECE");
			return result;
		case "ف":
			result = RTL.a(A_0, A_2, "0xFED1", "0xFED3", "0xFED4", "0xFED2");
			return result;
		case "ق":
			result = RTL.a(A_0, A_2, "0xFED5", "0xFED7", "0xFED8", "0xFED6");
			return result;
		case "ﮎ":
			result = RTL.a(A_0, A_2, "0xFB8E", "0xFB90", "0xFB91", "0xFB8F");
			return result;
		case "ک":
		case "ك":
			result = RTL.a(A_0, A_2, "0xFED9", "0xFEDB", "0xFEDC", "0xFEDA");
			return result;
		case "گ":
			result = RTL.a(A_0, A_2, "0xFB92", "0xFB94", "0xFB95", "0xFB93");
			return result;
		case "ل":
			result = RTL.a(A_0, A_2, "0xFEDD", "0xFEDF", "0xFEE0", "0xFEDE");
			return result;
		case "م":
			result = RTL.a(A_0, A_2, "0xFEE1", "0xFEE3", "0xFEE4", "0xFEE2");
			return result;
		case "ن":
			result = RTL.a(A_0, A_2, "0xFEE5", "0xFEE7", "0xFEE8", "0xFEE6");
			return result;
		case "ه":
			result = RTL.a(A_0, A_2, "0xFEE9", "0xFEEB", "0xFEEC", "0xFEEA");
			return result;
		case "ة":
			result = RTL.a(A_0, A_2, "0xFE93", "0xFEEB", "0xFEEC", "0xFE94");
			return result;
		case "و":
			result = RTL.a(A_0, A_2, "0xFEED", "0xFEED", "0xFEEE", "0xFEEE");
			return result;
		case "ؤ":
			result = RTL.a(A_0, A_2, "0xFE85", "0xFE85", "0xFE86", "0xFE86");
			return result;
		case "ى":
			result = RTL.a(A_0, A_2, "0xFEEF", "0xFEEF", "0xFEF0", "0xFEF0");
			return result;
		case "ي":
			result = RTL.a(A_0, A_2, "0xFEEF", "0xFEF3", "0xFEF4", "0xFEF0");
			return result;
		case "ئ":
			result = RTL.a(A_0, A_2, "0xFE89", "0xFE8B", "0xFE8C", "0xFE8A");
			return result;
		case "ء":
			result = "0xFE80";
			return result;
		case "ٹ":
			result = RTL.a(A_0, A_2, "0xFB66", "0xFB68", "0xFB69", "0xFB67");
			return result;
		case "ڈ":
			result = RTL.a(A_0, A_2, "0xFB88", "0xFB88", "0xFB89", "0xFB89");
			return result;
		case "ڑ":
			result = RTL.a(A_0, A_2, "0xFB8C", "0xFB8C", "0xFB8D", "0xFB8D");
			return result;
		case "ں":
			result = RTL.a(A_0, A_2, "0xFB9E", "0xFB9E", "0xFBE9", "0xFB9F");
			return result;
		case "ﮠ":
			result = RTL.a(A_0, A_2, "0xFBA0", "0xFBA2", "0xFBA3", "0xFBA1");
			return result;
		case "ے":
			result = RTL.a(A_0, A_2, "0xFBAE", "0xFBAE", "0xFBAF", "0xFBAF");
			return result;
		case "ہ":
			result = RTL.a(A_0, A_2, "0xFBA6", "0xFBA8", "0xFBA9", "0xFBA7");
			return result;
		case "0":
			if (A_1)
			{
				result = "0x0660";
				return result;
			}
			return result;
		case "1":
			if (A_1)
			{
				result = "0x0661";
				return result;
			}
			return result;
		case "2":
			if (A_1)
			{
				result = "0x0662";
				return result;
			}
			return result;
		case "3":
			if (A_1)
			{
				result = "0x0663";
				return result;
			}
			return result;
		case "4":
			if (A_1)
			{
				result = "0x0664";
				return result;
			}
			return result;
		case "5":
			if (A_1)
			{
				result = "0x0665";
				return result;
			}
			return result;
		case "6":
			if (A_1)
			{
				result = "0x0666";
				return result;
			}
			return result;
		case "7":
			if (A_1)
			{
				result = "0x0667";
				return result;
			}
			return result;
		case "8":
			if (A_1)
			{
				result = "0x0668";
				return result;
			}
			return result;
		case "9":
			if (A_1)
			{
				result = "0x0669";
				return result;
			}
			return result;
		}
		result = A_0[A_2].ToString();
		return result;
	}

	private static string a(List<char> A_0, int A_1, string A_2, string A_3, string A_4, string A_5)
	{
		string text = "ءئيىؤوةهﮪنھملکكکگقفغعظطضصشسزرژذدخحجچپثتبآإاأـدڈذرڑزژوءےیابپتٹثجچحخسشصضطظعغفقکگلمﮠںنہ,ﮩ,ﮨہھ";
		string text2 = "اأإآدذرزژوؤءددڈذرڑزژوء";
		string result;
		if (A_1 + 1 <= A_0.Count - 1 && A_0[A_1 + 1] == 'ل' && A_0[A_1] == 'ا')
		{
			if (A_1 + 2 <= A_0.Count - 1)
			{
				char arg_53_0 = A_0[A_1 + 2];
				if (text.IndexOf(A_0[A_1 + 2]) != -1 && text2.IndexOf(A_0[A_1 + 2]) == -1)
				{
					result = "0xFEFC";
					goto IL_86;
				}
			}
			result = "0xFEFB";
			IL_86:
			A_0[A_1 + 1] = '\0';
		}
		else if (A_1 + 1 <= A_0.Count - 1 && A_0[A_1 + 1] == 'ل' && A_0[A_1] == 'أ')
		{
			if (A_1 + 2 <= A_0.Count - 1)
			{
				char arg_D6_0 = A_0[A_1 + 2];
				if (text.IndexOf(A_0[A_1 + 2]) != -1 && text2.IndexOf(A_0[A_1 + 2]) == -1)
				{
					result = "0xFEF8";
					goto IL_109;
				}
			}
			result = "0xFEF7";
			IL_109:
			A_0[A_1 + 1] = '\0';
		}
		else if (A_1 + 1 <= A_0.Count - 1 && A_0[A_1 + 1] == 'ل' && A_0[A_1] == 'إ')
		{
			if (A_1 + 2 <= A_0.Count - 1)
			{
				char arg_159_0 = A_0[A_1 + 2];
				if (text.IndexOf(A_0[A_1 + 2]) != -1 && text2.IndexOf(A_0[A_1 + 2]) == -1)
				{
					result = "0xFEFA";
					goto IL_18C;
				}
			}
			result = "0xFEF9";
			IL_18C:
			A_0[A_1 + 1] = '\0';
		}
		else if (A_1 + 1 <= A_0.Count - 1 && A_0[A_1 + 1] == 'ل' && A_0[A_1] == 'آ')
		{
			if (A_1 + 2 <= A_0.Count - 1)
			{
				char arg_1DC_0 = A_0[A_1 + 2];
				if (text.IndexOf(A_0[A_1 + 2]) != -1 && text2.IndexOf(A_0[A_1 + 2]) == -1)
				{
					result = "0xFEF6";
					goto IL_20F;
				}
			}
			result = "0xFEF5";
			IL_20F:
			A_0[A_1 + 1] = '\0';
		}
		else if ((A_1 > 0 && A_0[A_1 - 1] == ' ') || (A_1 > 0 && text.IndexOf(A_0[A_1 - 1]) == -1))
		{
			if (A_1 == A_0.Count - 1 && (A_0[A_1 - 1] == ' ' || text.IndexOf(A_0[A_1 - 1]) == -1 || text2.IndexOf(A_0[A_1 - 1]) != -1))
			{
				result = A_2;
			}
			else if (A_1 + 1 <= A_0.Count - 1 && (A_0[A_1 + 1] == ' ' || text.IndexOf(A_0[A_1 + 1]) == -1 || text2.IndexOf(A_0[A_1 + 1]) != -1))
			{
				result = A_2;
			}
			else
			{
				result = A_5;
			}
		}
		else if ((A_1 == 0 && A_0.Count == 1) || (A_1 == 0 && (A_0[A_1 + 1] == ' ' || text.IndexOf(A_0[A_1 + 1]) == -1 || text2.IndexOf(A_0[A_1 + 1]) != -1)))
		{
			result = A_2;
		}
		else if (A_1 + 1 > A_0.Count - 1 || A_0[A_1 + 1] == ' ' || text.IndexOf(A_0[A_1 + 1]) == -1 || text2.IndexOf(A_0[A_1 + 1]) != -1)
		{
			result = A_3;
		}
		else if (A_1 > 0 && A_0[A_1 - 1] != 'ء')
		{
			result = A_4;
		}
		else
		{
			result = A_5;
		}
		return result;
	}

	private static string a(IEnumerable A_0, string A_1)
	{
		string text = "";
		if (A_0 != null)
		{
			foreach (object current in A_0)
			{
				text = text + current.ToString() + A_1;
			}
		}
		return text;
	}

	private static string b(string A_0)
	{
		if (A_0.Length == 0)
		{
			return "";
		}
		if (!A_0.ToLower().StartsWith("0x"))
		{
			return A_0[0].ToString();
		}
		int num = int.Parse(A_0.Substring(2), NumberStyles.AllowHexSpecifier);
		return ((char)num).ToString();
	}

	private static string a(string A_0, int A_1)
	{
		string[] array = A_0.Split(new char[]
		{
			' '
		});
		int num = 0;
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < array.Length; i++)
		{
			if (num + array[i].Length + 1 <= A_1)
			{
				stringBuilder.Append(array[i]);
				stringBuilder.Append(" ");
				num += array[i].Length + 1;
			}
			else
			{
				stringBuilder.Append("\n");
				stringBuilder.Append(array[i]);
				stringBuilder.Append(" ");
				num = array[i].Length + 1;
			}
		}
		return stringBuilder.ToString();
	}

	private static string a(string A_0, bool A_1, bool A_2)
	{
		List<char> list = new List<char>(A_0.ToLower().ToCharArray());
		List<char> list2 = new List<char>(A_0.ToCharArray());
		new List<char>();
		List<string> list3 = new List<string>();
		string text = "";
		RTL.PartMode partMode = RTL.PartMode.Arabic;
		RTL.PartMode partMode2 = RTL.PartMode.Arabic;
		for (int i = 0; i < list.Count; i++)
		{
			bool flag = false;
			partMode2 = RTL.a(list, i, partMode, partMode2, A_2);
			if (partMode2 != partMode)
			{
				flag = true;
				if (partMode == RTL.PartMode.Arabic && partMode2 == RTL.PartMode.Punctuation)
				{
					flag = false;
				}
			}
			if (flag)
			{
				RTL.a(partMode, text, ref list3);
				text = "";
				partMode = partMode2;
			}
			text += list2[i];
		}
		RTL.a(partMode, text, ref list3);
		StringBuilder stringBuilder = new StringBuilder();
		if (A_1)
		{
			for (int j = list3.Count - 1; j >= 0; j--)
			{
				stringBuilder.Append(list3[j]);
			}
		}
		else if (A_2)
		{
			for (int k = list3.Count - 1; k >= 0; k--)
			{
				stringBuilder.Append(list3[k]);
			}
		}
		else
		{
			foreach (string current in list3)
			{
				stringBuilder.Append(current);
			}
		}
		return stringBuilder.ToString();
	}

	private static void a(RTL.PartMode A_0, string A_1, ref List<string> A_2)
	{
		if (A_1 == "")
		{
			return;
		}
		switch (A_0)
		{
		case RTL.PartMode.Arabic:
			A_2.Add(A_1);
			return;
		case RTL.PartMode.English:
			A_1 = RTL.a(A_1);
			A_2.Add(A_1);
			return;
		case RTL.PartMode.LatinNumbers:
			A_1 = RTL.a(A_1);
			A_2.Add(A_1);
			return;
		case RTL.PartMode.ArabicNumbers:
			A_1 = RTL.a(A_1);
			A_2.Add(A_1);
			return;
		case RTL.PartMode.Punctuation:
			A_2.Add(A_1);
			return;
		default:
			return;
		}
	}

	private static RTL.PartMode a(List<char> A_0, int A_1, RTL.PartMode A_2, RTL.PartMode A_3, bool A_4)
	{
		if (RTL.latinChars.IndexOf(A_0[A_1]) > -1)
		{
			if (A_1 == 0)
			{
			}
			A_3 = RTL.PartMode.English;
		}
		else if (RTL.arabicIntegers.IndexOf(A_0[A_1]) > -1)
		{
			if (A_1 == 0)
			{
			}
			A_3 = RTL.PartMode.ArabicNumbers;
		}
		else if (RTL.punctuationMarks.IndexOf(A_0[A_1]) > -1)
		{
			if (A_1 == 0)
			{
			}
			A_3 = RTL.PartMode.Punctuation;
		}
		else
		{
			if (A_1 == 0)
			{
			}
			A_3 = RTL.PartMode.Arabic;
		}
		return A_3;
	}

	private static string a(string A_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = A_0.Length - 1; i >= 0; i--)
		{
			stringBuilder.Append(A_0[i]);
		}
		return stringBuilder.ToString();
	}
}
