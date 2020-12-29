using System;
using System.IO;

namespace _1
{
    class Program
	{

		/*
		Составить программный продукт для ПЭВМ, который составляет и выводит в файл
		все слова алфавита A = { a, b, c, d, e, f, g, h, j, k} длины n, в которых ровно три буквы
		встречаются по 2 раза и одна буква k раз, остальные буквы не повторяются.
		*/

		static bool Podschet(int[] razP, int N, int n, int k, int m)
		{
			int[] Kol = new int[N];
			int[] seen = new int[N];
			for (int i = 0; i < N; i++)
			{
				Kol[i] = 0;
				seen[i] = 0;
			}

			for (int i = 0; i < N; i++)
			{
				if (seen[i] == 0)
				{
					int count = 0;
					for (int j = i; j < N; j++)
					{
						if (razP[j] == razP[i])
						{
							count++;
							seen[j] = 1;
						}
					}
					Kol[i] = count;
				}
			}


			int l = 0;
			int p = 0;
			int q = 0;

			for (int i = 0; i < N; i++)
			{
				if (Kol[i] > m)
				{
					Kol[i] = 0;
					l = 0;
					p = 0;
					q = 0;
					for (int g = 0; g < N; g++)
                    {
						if(Kol[g]<k && Kol[g] > 1)
                        {
							Kol[g] = 0;
							p++;
                        }
						if (Kol[g] > m )
						{
							Kol[g] = 0;
							q++;
						}
						if (Kol[g] == k)
                        {
							Kol[g] = 0;
							l++;
                        }
					}
					if (l == 2 && p < 2 && q == 0) //Если 2 буквы встречаются k раз, буква A либо встречается 1 раз либо вообще не встречается, и при этом буква встречающаяся больше m раз всего одна
                    {
						return true;
                    }

                   
				}
				
			}
		
			return false;
		}

		static bool nextCombobj(int[] razP, int k, int n)
		{

			int j = k - 1;
			while (j >= 0 && razP[j] == n - 1) j--;

			if (j == -1) return false;

			razP[j]++;


			for (int i = j + 1; i < k; i++)
			{
				razP[i] = 0;
			}

			return true;
		}


		static void Main()
		{
			int n = 10;//размер алфавита
			char[] arr = new char[10] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'j', 'k' };

			int N,k,m;
			do
			{
				Console.Write("Введите длину слова: ");
				N = Convert.ToInt32(Console.ReadLine());

				Console.Write("Буква A встречается менее раз и сколько раз будет встречаться буква B и C: ");
				k = Convert.ToInt32(Console.ReadLine()); ;
				
				Console.Write("Буква D повторяется более раз: ");
				m = Convert.ToInt32(Console.ReadLine()); ;
				Console.WriteLine();

				if ((n-2*k)>m && k<=m) break;
				else Console.WriteLine("Ошибка!!! Введите повторно.\n");

			} while (true);

			int[] razP = new int[N];
			for (int i = 0; i < N; i++)
			{
				razP[i] = 0;
			}
			FileInfo output = new FileInfo("out3.txt");
			StreamWriter fs = output.CreateText();

			int kol = 0;
			while (nextCombobj(razP, N, n))
			{
				if (Podschet(razP, N, n, k,m))
				{
					for (int i = 0; i < N; i++)
					{
						fs.Write(arr[razP[i]]);
					}
					fs.WriteLine();
					kol++;
				}

			}
			fs.WriteLine("Количество - " + kol);
			Console.WriteLine("Количество - " + kol);
			fs.Close();
			Console.ReadKey();
		}
	}
}
