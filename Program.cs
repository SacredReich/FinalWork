#pragma warning disable
// Задача: Написать программу, которая из имеющегося массива строк формирует новый массив из строк, длина которых меньше, либо равна 3 символам. Первоначальный массив можно ввести с клавиатуры, либо задать на старте выполнения алгоритма. При решении не рекомендуется пользоваться коллекциями, лучше обойтись исключительно массивами.

int size = TryCorrectAnswer("Задайте размер исходного массива: ", 1, 1);
string[] array = new string[size];
EditMenu(array, size, 0, 0);
NewArray3Chars(array);

void EditMenu(string[] array, int length, int answer, int index)
{
    switch (answer)
    {
        case 0:
            answer = TryCorrectAnswer($"Размер массива: {size}. \nВыберите нужный вариант:\n1 - Перейти к ручному редактированию элементов массива.\n2 - Заполнить сразу все элементы массива случайными числами.\n3 - Завершить редактирование массива, перейти к выполнению программы.\n", 1, 4);
            EditMenu(array, size, answer, index);
            break;
        case 1:
            answer = TryCorrectAnswer($"Выберите действие: \n1 - Ввести значение для текущего ({index + 1}/{size}) элемента массива. \n2 - Перейти к следующему элементу массива. \n3 - Ввести номер элемента и перейти к нему.\n4 - Вернуться к вариантам редактирования.\n", 1, 5) * 10;
            EditMenu(array, size, answer, index);
            break;
        case 2:
            for (int i = 0; i < size; i++)
            {
                int random = new Random().Next(1, 10000);
                array[i] = random.ToString();
            }
            answer = TryCorrectAnswer($"Всем {size} элементам массива присвоено случайное число.\nВыберите действие:\n1 - Завершить редактирование массива, перейти к выполнению программы.\n2 - Вернуться к вариантам редактирования.\n", 1, 3) * 100;
            EditMenu(array, size, answer, index);
            break;
        case 3:
            goto case 100;
        case 10:
            Console.Clear();
            Console.Write($"Введите значение для ({index + 1}/{size}) элемента массива:\n");
            array[index] = Console.ReadLine();
            goto case 1;
        case 20:
            if (index + 1 == size)
            {
                index = 0;
                goto case 1;
            }
            else
            {
                index++;
                goto case 1;
            }
        case 30:
            index = TryCorrectAnswer($"Введите номер элемента массива:\n", 1, size);
            goto case 1;
        case 40:
            goto case 0;
        case 100:
            Console.Clear();
            string emptys = "Необходимо задать значение для ячеек под номерами:\n";
            index = 0;
            for (int i = 0; i < size; i++)
            {
                if (string.IsNullOrEmpty(array[i]))
                {
                    emptys += $"{i + 1}, ";

                    index++;
                }

            }
            emptys = emptys.TrimEnd(' ');
            emptys = emptys.TrimEnd(',');
            emptys += "\nНажмите любую клавишу для возврата к редактированию.";
            if (index > 0)
            {
                index = TryCorrectAnswer(emptys, 0, 1);
                goto case 0;
            }
            else
                break;
        case 200:
            goto case 0;
    }

}

void NewArray3Chars(string[] array)
{
    Console.Clear();
    Console.Write("[");
    string[] array2 = new string[array.Length];
    int index = 0;
    for (int i = 0; i < array.Length; i++)
    {
        if (i == array.Length - 1)
            Console.Write($"\"{array[i]}\"] -> [");
        else
            Console.Write($"\"{array[i]}\",");
        string symbols = array[i];
        int lenght = symbols.Length;
        if (lenght <= 3)
        {
            array2[index] = array[i];
            index++;
        }
    }
    if (index == 0)
        index++;
    string[] array3 = new string[index];
    for (int i = 0; i < index; i++)
    {
        array3[i] = array2[i];
        if (i == array3.Length - 1)
            Console.Write($"\"{array3[i]}\"]");
        else
            Console.Write($"\"{array3[i]}\",");
    }
}

int TryCorrectAnswer(string question, int min, int max) // Принимает значения: вопрос пользователю в консоле (question), диапозон чисел для верного ответа (int min, int max). Проверяет ответ пользователя, возвращает, если он верный и просит пользователя повторить ответ, если нет.
{
    int console;
    Console.Clear();
    Console.Write($"{question}");
    int.TryParse(Console.ReadLine(), out console);
    if (max <= min)
    {
        while (console < min)
        {
            Console.Clear();
            Console.Write($"Некорректное значение, попробуйте еще раз.\n{question} ");
            int.TryParse(Console.ReadLine(), out console);
        }
    }
    else
    {
        while (console < min || console > max)
        {
            Console.Clear();
            Console.Write($"Некорректное значение, попробуйте еще раз: ");
            int.TryParse(Console.ReadLine(), out console);
        }
    }
    return console;
}
