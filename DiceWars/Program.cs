using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiceWars
{
	class Program
	{
		static void Main(string[] args)
		{
			for (int left = 1; left <= 8; left++)
			{
				for (int right = 1; right <= 8; right++)
				{
					double num = DieStack.matchup(left, right);
					string percentage = string.Format("{0:0.000%}", num);
					Console.WriteLine(left + " vs " + right + ": " + percentage);
				}
			}
			Console.ReadLine();
		}
	}
}
