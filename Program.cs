using System;

namespace HomeWorkKadry
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fullNames = new string[0];
            string[] listOfProfessions = new string[0];
            string userInput = "";

            while (userInput != "5")
            {
                Console.WriteLine("Пункты меню:\n" +
                    "1) добавить досье.\n" +
                    "2) вывести всё досье.\n" +
                    "3) удалить досье.\n" +
                    "4) поиск по фамилиию.\n" +
                    "5) выход из приложения.");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddDossier(ref fullNames, ref listOfProfessions);
                        break;
                    case "2":
                        ShowDossier(fullNames, listOfProfessions);
                        break;
                    case "3":
                        DeleteDossier(ref fullNames, ref listOfProfessions);
                        break;
                    case "4":
                        SearchSurname(fullNames, listOfProfessions);
                        break;
                }
            }
        }

        static void AddDossier(ref string[] fullNames, ref string[] listOfProfessions)
        {
            Console.WriteLine("Добавитье ФИО в досье.");
            string element = Console.ReadLine();
            AddElement(ref fullNames, element);
            Console.WriteLine("Добавитье профессию в досье.");
            element = Console.ReadLine();
            AddElement(ref listOfProfessions, element);
        }

        static void AddElement(ref string[] array, string element)
        {
            string[] tempArray = new string[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }
            tempArray[tempArray.Length - 1] = element;
            array = tempArray;
        }

        static void DeleteDossier(ref string[] fullNames, ref string[] listOfProfessions)
        {
            if (fullNames.Length == 0)
            {
                Console.WriteLine("Досье не заполнено.");
            }
            else
            {
                Console.WriteLine("Введите порядкой номер  досье для удаления");
                int deleteIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                DeleteElement(ref fullNames, deleteIndex);
                DeleteElement(ref listOfProfessions, deleteIndex);
            }
        }

        static void DeleteElement(ref string[] array, int deleteIndex)
        {
            string[] tempArray = new string[array.Length - 1];

            for (int i = 0; i < deleteIndex; i++)
            {
                tempArray[i] = array[i];
            }

            for (int i = deleteIndex + 1; i < array.Length; i++)
            {
                tempArray[i - 1] = array[i];
            }
            array = tempArray;
        }

        static void ShowDossier(string[] fullNames, string[] listOfProfessions)
        {
            if (fullNames.Length == 0)
            {
                Console.WriteLine("Досье не заполнено.");
            }
            else
            {
                for (int i = 0; i < fullNames.Length; i++)
                {
                    Console.WriteLine($"{i + 1}: {fullNames[i]} - {listOfProfessions[i]}");
                }
                Console.WriteLine();
            }
        }

        static void SearchSurname(string[] fullNames, string[] listOfProfessions)
        {
            if (fullNames.Length == 0)
            {
                Console.WriteLine("Досье не заполнено.");
            }
            else
            {
                Console.WriteLine("Введите фамилию для поиска:");
                string surname = Console.ReadLine();
                bool surnameIsFind = false;
                for (int i = 0; i < fullNames.Length; i++)
                {
                    if (surname.ToLower() == fullNames[i].ToLower())
                    {
                        Console.WriteLine($"{ i + 1}: { fullNames[i]} - { listOfProfessions[i]}");
                        surnameIsFind = true;
                    }
                }
                if (surnameIsFind == false)
                {
                    Console.WriteLine($"Особа с фамилией {surname} досье не найдена.");
                }
            }
        }
    }
}
