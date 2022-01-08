using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkKadry
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] listName = new string[0];
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
                        AddListName(ref listName, ref listOfProfessions);
                        break;
                    case "2":
                        ShowDossier(listName, listOfProfessions);
                        break;
                    case "3":
                        DeleteName(ref listName, ref listOfProfessions);
                        break;
                    case "4":
                        SearchSurname(listName, listOfProfessions);
                        break;
                }
            }
        }

        static void AddListName(ref string[] listName, ref string[] listOfProfessions)
        {
            string[] tempListName = new string[listName.Length + 1];
            string[] tempListOfProfessions = new string[listOfProfessions.Length + 1];

            for (int i = 0; i < listName.Length; i++)
            {
                tempListName[i] = listName[i];
                tempListOfProfessions[i] = listOfProfessions[i];
            }
            Console.WriteLine("Добавитье ФИО в досье.");
            tempListName[tempListName.Length - 1] = Console.ReadLine();
            listName = tempListName;
            Console.WriteLine("Добавитье профессию в досье.");
            tempListOfProfessions[tempListOfProfessions.Length - 1] = Console.ReadLine();
            listOfProfessions = tempListOfProfessions;
        }

        static void ShowDossier(string[] listName, string[] listOfProfessions)
        {
            if (listName.Length == 0)
            {
                Console.WriteLine("Досье не заполнено.");
            }
            else
            {
                for (int i = 0; i < listName.Length; i++)
                {
                    Console.WriteLine($"{i + 1}: {listName[i]} - {listOfProfessions[i]}");
                }
                Console.WriteLine();
            }
        }

        static void DeleteName(ref string[] listName, ref string[] listOfProfessions)
        {
            if (listName.Length == 0)
            {
                Console.WriteLine("Досье не заполнено.");
            }
            else
            {
                Console.WriteLine("Введите порядкой номер  досье для удаления");
                int deleteIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                string[] tempListName = new string[listName.Length - 1];
                string[] tempListOfProfessions = new string[listOfProfessions.Length - 1];

                for (int i = 0; i < deleteIndex; i++)
                {
                    tempListName[i] = listName[i];
                    tempListOfProfessions[i] = listOfProfessions[i];
                }

                for (int i = deleteIndex + 1; i < listName.Length; i++)
                {
                    tempListName[i - 1] = listName[i];
                    tempListOfProfessions[i - 1] = listOfProfessions[i];
                }
                listName = tempListName;
                listOfProfessions = tempListOfProfessions;
            }
        }

        static void SearchSurname(string[] listName, string[] listOfProfessions)
        {
            if (listName.Length == 0)
            {
                Console.WriteLine("Досье не заполнено.");
            }
            else
            {
                Console.WriteLine("Введите фамилию для поиска:");
                string surname = Console.ReadLine();
                bool surnameIsFind = false;
                for (int i = 0; i < listName.Length; i++)
                {
                    if (surname.ToLower() == listName[i].ToLower())
                    {
                        Console.WriteLine($"{ i + 1}: { listName[i]} - { listOfProfessions[i]}");
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
