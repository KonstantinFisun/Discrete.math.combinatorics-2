using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class Program
    {
      
		/*
		Составить программный продукт для ПЭВМ, который составляет и выводит в файл
		все слова алфавита A = { a, b, c, d, e, f, g, h, j, k} длины n, в которых ровно три буквы
		встречаются по 2 раза и одна буква k раз, остальные буквы не повторяются.
		*/
		
			static bool Podschet(int[] razP, int N, int n, int k)
			{
				int[] Kol = new int[10];
				int[] seen = new int[12];
				for (int i = 0; i < n; i++)
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
		
				for (int i = 0; i < n; i++)
				{
					if (Kol[i] == k)
					{
						l++;
						Kol[i] = 0;
						break;
					}
				}
				if (l == 0) return false;
		
				l = 0;
		
				for (int i = 0; i < n; i++)
				{
					if (Kol[i] == 2)
					{
						l++;
						Kol[i] = 0;
					}
				}
		
				if (l != 3) return false;
				for (int i = 0; i < n; i++)
				{
					if (Kol[i] > 1) return false;
				}
		
		
				return true;
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

			bool f = false;
			int N, k;
			do
			{
				f = false;
				Console.WriteLine("Введите длину слова: "); 
				N = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine("Введите сколько раз будет встречаться одна из букв: ");
				k = Convert.ToInt32(Console.ReadLine()); ; 
				Console.WriteLine();

				if (k == 2) f = true; //если k = 2 , то запрашиваем заново

				//if (N == 7 && k == 1) break; //Если длина слова 7, а k = 1 то выходим

				if (N < (6 + k)) f = true; //Длина должна вмещать в себя три буквы встречающихся по 2 раза + букву встречающаяся k раз

				if (k == 1 && N > 7) f = true;//Если k = 1, а длина больше 7 => у нас будет больше одной буквы встречающейся 1 раз

				if(f==true) Console.WriteLine( "Ошибка!!! Введите повторно.\n");

			} while (f);
		
			int[] razP = new int[N];
			for (int i = 0; i < N; i++)
			{
				razP[i] = 0;
			}
			FileInfo output = new FileInfo("out.txt");
			StreamWriter fs = output.CreateText();

			int kol = 0;
			while (nextCombobj(razP, N, n))
				{
					if (Podschet(razP, N, n, k))
					{
						for (int i = 0; i < N; i++)
						{
							fs.Write(arr[razP[i]]);
						}
						fs.WriteLine();
						kol++;
				}
		
			}
			Console.WriteLine("Количество - "+ kol);
			fs.Close();
			Console.WriteLine("Программа завершена.");
			Console.ReadKey();
			}
	}
}
