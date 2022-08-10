// Напишите программу, которая принимает на вход цифру, обозначающую день недели, и проверяет, является ли этот день выходным.
// 6 -> да
// 7 -> да
// 1 -> нет

do
{
	Console.Clear();
	PrintTitle("Проверка соответсвия номера дня недели выходному дню", ConsoleColor.Cyan);

	// Ошибка ввода значения вне диапазона 1..7 обрабатывается в GetUserInput()
	int dayOfWeek = GetUserInput("Введите цифру, обозначающую день недели: ");
	string answer = IsWeekend(dayOfWeek) ? "Да" : "Нет";
	Console.WriteLine($"Вывод: {dayOfWeek} -> {answer}");

} while (AskForRepeat());

// Methods

int GetUserInput(string inputMessage)
{
	int input;
	bool notANumber = false;
	bool outOfRange = false;
	do
	{
		if (notANumber)
		{
			PrintError("Некорректный ввод! Пожалуйста повторите", ConsoleColor.Magenta);
		}
		if (outOfRange)
		{
			PrintError("Цифра должна быть в диапазоне от 1 до 7. Пожалуйста повторите", ConsoleColor.Magenta);
		}

		Console.Write(inputMessage);

		notANumber = !int.TryParse(Console.ReadLine(), out input);
		outOfRange = !notANumber && CheckIfValid(input);

	} while (notANumber || outOfRange);

	return input;
}

bool CheckIfValid(int input)
{
	return input < 1 || input > 7;
}

bool IsWeekend(int dayOfWeek)
{
	return dayOfWeek == 6 || dayOfWeek == 7;
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
