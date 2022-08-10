// Напишите программу, которая принимает на вход трёхзначное число и на выходе показывает вторую цифру этого числа.
// 456 -> 5
// 782 -> 8
// 918 -> 1

do
{
	Console.Clear();
	PrintTitle("Вывод второй цифры трёхзначного числа", ConsoleColor.Cyan);

	int number = GetUserInput("Введите целое трёхзначное число: ", "Некорректный ввод! Пожалуйста повторите");
	int secondDigit = GetSecondDigitOfThree(number);

	Console.WriteLine($"Вывод: {number} -> {secondDigit}");

} while (AskForRepeat());

// Methods

int GetSecondDigitOfThree(int num)
{
	if (num < 0)
		num = -num;

	num /= 10;
	return num % 10;
}

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
		handleError = !(int.TryParse(Console.ReadLine(), out input) && CheckIfValid(input));

	} while (handleError);

	return input;
}

bool CheckIfValid(int input)
{
	if (input < 0)
		input = -input;

	return input >= 100 && input <= 999;
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
