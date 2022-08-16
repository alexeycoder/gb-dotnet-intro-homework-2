// Напишите программу, которая выводит третью цифру заданного числа или сообщает, что третьей цифры нет.
// 645 -> 5
// 78 -> третьей цифры нет
// 32679 -> 6

do
{
	Console.Clear();
	PrintTitle("Вывод третьей СЛЕВА цифры заданного целого числа", ConsoleColor.Cyan);

	int number = GetUserInput("Введите целое число: ", "Некорректный ввод! Пожалуйста повторите");
	int thirdDigitFromLeft = GetNthDigitFromLeft(number, 3);

	Console.WriteLine($"Вывод: {number} -> {(thirdDigitFromLeft < 0 ? "третьей цифры нет" : thirdDigitFromLeft.ToString())}");

} while (AskForRepeat());

// Methods

int GetNthDigitFromLeft(int num, int n)
{
	if (num < 0)
		num = -num;

	int nPowersOfTen = 10;
	for (int i = 1; i < n; ++i, nPowersOfTen *= 10) ;

	if (num < nPowersOfTen / 10)
		return -1;

	while (num >= nPowersOfTen)
		num /= 10;

	return num % 10;
}

// int GetNthDigitFromLeft(int num, int n)
// {
// 	if (num < 0)
// 		num = -num;

// 	int m = GetMagnitude(num);
// 	for (int i = 1; i < n && m != 0; ++i, m /= 10)
// 	{
// 		num %= m;
// 	}

// 	return m != 0 ? num / m : -1;
// }

// // returns:	1 for 0..9,
// // 			10 for 10..99,
// //			100 for 100..999, etc
// int GetMagnitude(int num)
// {
// 	if (num < 0)
// 		num = -num;

// 	num /= 10;
// 	int magnitude = 1;

// 	while (num >= magnitude)
// 		magnitude *= 10;

// 	return magnitude;
// }

int GetUserInput(string inputMessage, string errorMessage)
{
	int input;
	bool handleError = false;
	do
	{
		if (handleError)
		{
			PrintError(errorMessage, ConsoleColor.Magenta);
		}
		Console.Write(inputMessage);
		handleError = !(int.TryParse(Console.ReadLine(), out input));

	} while (handleError);

	return input;
}

void PrintTitle(string title, ConsoleColor foreColor)
{
	var bkpColor = Console.ForegroundColor;
	Console.ForegroundColor = foreColor;
	string titleDelimiter = new string('\u2550', title.Length);
	Console.WriteLine(titleDelimiter);
	Console.WriteLine(title);
	Console.WriteLine(titleDelimiter);
	Console.ForegroundColor = bkpColor;
}

void PrintError(string errorMessage, ConsoleColor foreColor)
{
	var bkpColor = Console.ForegroundColor;
	Console.ForegroundColor = foreColor;
	Console.Write("\u2757 Ошибка: ");
	Console.WriteLine(errorMessage);
	Console.ForegroundColor = bkpColor;
}

bool AskForRepeat()
{
	Console.WriteLine();
	Console.WriteLine("Нажмите Enter, чтобы повторить или Esc, чтобы завершить...");
	ConsoleKeyInfo key = Console.ReadKey(true);
	return key.Key != ConsoleKey.Escape;
}

//// Can be useful

// int GetNthDigitFromRight(int num, int n)
// {
// 	for (int i = 1; i < n; ++i)
// 		num = num / 10;

// 	return num % 10;
// }

// int GetNumberOfDigits(int num)
// {
//	if (num < 10)
//		return 1;
//
// 	int count = 0;
// 	while (num != 0)
// 	{
// 		++count;
// 		num /= 10;
// 	}
// 	return count;
// }
