using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Hangman
{
	class Program
	{
		static void Main(string[] args)
		{
			List<string> dym = new List<string>(){
				"Eagle","Mole","Sponge","Shark","Deer"
			};
			char[,] hangman =
			{
			{' ','_','_','_',' ',' '},
			{'|',' ',' ',' ','|',' '},
			{'|',' ',' ',' ','o',' '},
			{'|',' ',' ','/','0','\\'},
			{'|',' ',' ','/',' ','\\'},
			{'|',' ',' ',' ','=',' '}
			};
			int mistakes = 0;
			int n = dym.Count();///getting the size of the dictionary
								///Generating a random number
			Random rnd = new Random();
			int rand = rnd.Next(0, n);
			///Getting the size of the selected random word
			int nd = dym[rand].Length;
			string real = dym[rand];
			string view = "";
			string wrong = "";
			List<char> submitted = new List<char>();
			for (int i = 0; i < nd; i++)
			{
				if (real[i] == ' ') { view = view + ' '; }
				else view = view + '?';
			}
			while (view != real)
			{
				for (int i = 0; i < 6; i++)
				{
					for (int j = 0; j < 6; j++)
					{
						if (mistakes >= 1 && ((i == 1 && j == 0) || (i == 2 && j == 0) || (i == 3 && j == 0) || (i == 4 && j == 0) || (i == 5 && j == 0)))
						{
							Console.Write(hangman[i, j]);
						}
						else if (mistakes >= 2 && ((i == 0 && j == 1) || (i == 0 && j == 2) || (i == 0 && j == 3)))
						{
							Console.Write(hangman[i, j]);
						}
						else if (mistakes >= 3 && i == 1 && j == 4)
						{
							Console.Write(hangman[i, j]);
						}
						else if (mistakes >= 4 && i == 2 && j == 4)
						{
							Console.Write(hangman[i, j]);
						}
						else if (mistakes >= 5 && i == 3 && j == 4)
						{
							Console.Write(hangman[i, j]);
						}
						else if (mistakes >= 6 && i == 3 && j == 3)
						{
							Console.Write(hangman[i, j]);
						}
						else if (mistakes >= 7 && i == 3 && j == 5)
						{
							Console.Write(hangman[i, j]);
						}
						else if (mistakes >= 8 && i == 4 && j == 3)
						{
							Console.Write(hangman[i, j]);
						}
						else if (mistakes >= 9 && i == 4 && j == 5)
						{
							Console.Write(hangman[i, j]);
						}
						else if (mistakes >= 10 && i == 5 && j == 4)
						{
							Console.Write(hangman[i, j]);
						}
						else if (mistakes == 11)
						{
							Console.Clear();
							Console.WriteLine("You lost");
							Console.Write("The word was:");
							Console.WriteLine(real);
							Thread.Sleep(4000);
							return;
						}
						else Console.Write(" ");

					}
					///Printing the word
					Console.Write("  ");
					if (i == 0) Console.Write(view);
					if (i == 5) Console.Write(wrong);
					Console.WriteLine();
				}

				char byk = Convert.ToChar(Console.ReadLine().Trim().Replace(Environment.NewLine, "").Substring(0, 1));
				if (submitted.Contains(byk))
				{
					Console.Clear();
					continue;
				}
				submitted.Add(byk);
				bool flag = false;
				for (int i = 0; i < nd; i++)
				{
					if (real[i] == Char.ToLower(byk) || real[i] == Char.ToUpper(byk))
					{
						var aStringBuilder = new StringBuilder(view);
						aStringBuilder[i] = byk;
						view = aStringBuilder.ToString();
						flag = true;
					}
				}
				if (!flag)
				{
					wrong = wrong + byk;
					Console.Write("word ");
					Console.WriteLine(wrong);
					mistakes++;
				}
				Console.WriteLine(wrong);
				Console.Clear();

			}
		}

	}
}
