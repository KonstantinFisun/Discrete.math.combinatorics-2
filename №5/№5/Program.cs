using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5
{
    class Program
    {
		static void swap(int[] pere, int i, int j)//меняем местами
		{
			
			int bufer = pere[i];
			pere[i] = pere[j];
			pere[j] = bufer;

		}

		static bool nextCombobj(int[] pere, int N)
		{

			int j = N - 2;
			while (j != -1 && pere[j] >= pere[j + 1]) j--; //ищем пока следующий элемент больше предыдущего

			if (j == -1) return false; // перестановок не осталось
			int k = N - 1;

			while (pere[j] >= pere[k]) k--; //ищем пока найдется элемент больше j
			swap(pere, j, k); //меняем их местами

			// сортируем элемента за j
			int q = j + 1, p = N - 1;
			while (q < p) swap(pere, q++, p--);

			return true;
		}

		static void Main()
		{
			const int N = 9;
			char[] arr = new char[N] { 'Н', 'Н', 'Е', 'Е', 'К', 'О', 'Т', 'Й', 'Р' };

			FileInfo output = new FileInfo("out.txt");
			StreamWriter fs = output.CreateText();
			int[] pere = new int[N];

			for (int i = 0; i < N; i++)
				pere[i] = i;
			pere[1] = 0;
			pere[3] = 2;
			int kol = 0;
			for (int i = 0; i < N; i++)
			{
				fs.Write(arr[pere[i]] + " ");
			}
			fs.WriteLine();
			kol++;


			while (nextCombobj(pere, N))
			{		
					for (int i = 0; i < N; i++)
						fs.Write(arr[pere[i]] + " ");

					kol++;
					fs.WriteLine();
			}
			fs.WriteLine($"Количество перестановок слова Контейнер = {kol}");
			fs.Close();

			Console.WriteLine("Программа завершена");
			Console.ReadKey();
		}
	}
}
