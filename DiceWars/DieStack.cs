using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiceWars
{
	class DieStack
	{
		private int _numDie;
		private int[] _values;
		public DieStack(int numDie)
		{
			_numDie = numDie;
			_values = new int[_numDie];
			this.reset();
		}
		public bool hasNext()
		{
			for (int i = 0; i < _numDie; i++)
			{
				if (_values[i] != 6)
				{
					return true;
				}
			}
			return false;
		}
		public bool next()
		{
			for (int i = 0; i < _numDie; i++)
			{
				if (_values[i] < 6)
				{
					_values[i]++;
					return true;
				}
				else
				{
					_values[i] = 1;
				}
			}
			return false;
		}
		public int sum
		{
			get
			{
				int total = 0;
				for (int i = 0; i < _numDie; i++)
				{
					total += _values[i];
				}
				return total;
			}
		}
		public bool isBetter(DieStack d)
		{
			//Console.WriteLine(this.sum + " versus " + d.sum);
			return (this.sum > d.sum);
		}
		public void reset()
		{
			for (int i = 0; i < _numDie; i++)
			{
				_values[i] = 1;
			}
		}
		public static double matchup(int d1, int d2)
		{
			DieStack ds1 = new DieStack(d1);
			DieStack ds2 = new DieStack(d2);
			long numTrials = 0;
			long ds1Wins = 0;
			do
			{
				do
				{
					numTrials++;
					if (ds1.isBetter(ds2))
					{
						ds1Wins++;
					}
				}
				while (ds2.next());
			}
			while (ds1.next());
			return (double)ds1Wins / (double)numTrials;
		}
	}
}
