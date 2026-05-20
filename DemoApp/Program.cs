using MyCollectionLib;
using MyNewCollectionLib;
using System.Diagnostics;
using WorkersLib.Models;
using QueryLib;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nВыберите лабораторную:");
            Console.WriteLine("1 — Лабороторная 11. Коллекции");
            Console.WriteLine("2 — Лабороторная 12. Классы-коллекции, создаваемые пользователем");
            Console.WriteLine("3 — Лабороторная 13. Разработка программы, управляемой событиями");
            Console.WriteLine("4 — Лабороторная 14. LINQ");
            Console.WriteLine("0 — Выход");
            Console.Write("Ваш выбор: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Task1();
                    break;
                case 2:
                    Task2();
                    break;
                case 3:
                    Task3();
                    break;
                case 4:
                    Task4();
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }

        
    }

    static void Task1()
    {
        TestCollections test = new TestCollections();
        test.SearchTests();
    }

    static void Task2()
    {
        var list = new MyLinkedList<Person>();
        var dlist = new MyDoublyLinkedList<Person>();
        InitList(list);
        InitDList(dlist);

        while (true)
        {
            MenuForTask2();

            Console.Write("Выберите: ");
            if (!int.TryParse(Console.ReadLine(), out int operationNumber))
            {
                Console.WriteLine("ошибка\n");
                continue;
            }
            Console.WriteLine();

            switch (operationNumber)
            {
                case 1:
                    PrintList(list);
                    PrintList(dlist);
                    break;

                case 2:
                    AddRandomPerson(list);
                    AddRandomPerson(dlist);
                    break;

                case 3:
                    RemovePersonByName(dlist);
                    break;

                case 4:
                    FindByName(dlist);
                    break;

                case 5:
                    ShallowCopyTest(dlist);
                    break;

                case 6:
                    DeepCopyTest(dlist);
                    break;

                case 7:
                    ClearList(dlist);
                    break;

                case 0:
                    return;

                default:
                    Console.WriteLine("ошибка\n");
                    continue;
            }
            Console.WriteLine("\n");
        }
    }

    static void InitList(MyLinkedList<Person> list)
    {        
        Random rnd = new();

        var per1 = new Worker();
        var per2 = new Engineer();
        var per3 = new Administration();

        per1.RandomInit(rnd);
        per2.RandomInit(rnd);
        per3.RandomInit(rnd);

        list.AddRange(per1, per2, per3);

        foreach (Person per in list)
        {
            per.Show();
        }

        Console.WriteLine("\n");
    }

    static void InitDList(MyDoublyLinkedList<Person> list)
    {
        Random rnd = new();

        var per1 = new Worker();
        var per2 = new Engineer();
        var per3 = new Administration();

        per1.RandomInit(rnd);
        per2.RandomInit(rnd);
        per3.RandomInit(rnd);

        list.AddRange(per1, per2, per3);

        foreach (Person per in list)
        {
            per.Show();
        }

        Console.WriteLine("\n");
    }


    static void MenuForTask2()
    {
        Console.WriteLine("Выберите:");
        Console.WriteLine("1 - Вывести списки");
        Console.WriteLine("2 - Добавть объект");
        Console.WriteLine("3 - Удалить объект");
        Console.WriteLine("4 - Найти объект");
        Console.WriteLine("5 - Поверхностная копия");
        Console.WriteLine("6 - Глубокая копия");
        Console.WriteLine("7 - Очистить списки");
        Console.WriteLine("0 - Выход");
    }

    static void PrintList(ICollection<Person> list)
    {
        if (list.Count < 1)
        {
            Console.WriteLine("пусто");
        }

        foreach (Person per in list)
        {
            per.Show();
        }
    }

    static void AddRandomPerson(ICollection<Person> list)
    {
        Worker per = new Worker();

        int perType = new Random().Next(1, 4 + 1);
        switch (perType)
        {
            case 1:
                per = new Worker();
                break;

            case 2:
                per = new Engineer();
                break;

            case 3:
                per = new Administration();
                break;
        }

        Random rnd = new();
        per.RandomInit(rnd);
        list.Add(per);

        Console.WriteLine($"Добавлен: {per.Name}");
        Console.WriteLine("Список:");
        PrintList(list);
    }

    static void RemovePersonByName(MyDoublyLinkedList<Person> list)
    {
        Console.Write("Введите имя: ");
        string perName = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(perName))
        {
            Console.WriteLine("ошибка");
            return;
        }

        var per = list.Find(perName);
        list.Remove(per);

        Console.WriteLine("после удаления");
        PrintList(list);
    }


    static void FindByName(MyDoublyLinkedList<Person> list)
    {
        Console.Write("Введите имя: ");
        string perName = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(perName))
        {
            Console.WriteLine("ошибка");
            return;
        }

        var per = list.Find(perName);

        if (per == null)
        {
            Console.WriteLine("ошибка");
            return;
        }

        per.Show();
    }


    static void ShallowCopyTest(MyDoublyLinkedList<Person> list)
    {
        var shallowCopy = list.ShallowCopy();
        Console.WriteLine("поверхностная копия, меянем всем возраст");

        if (list.Count > 0)
        {
            foreach (Person per in shallowCopy)
            {
                per.Age = 100;
            }
        }

        Console.WriteLine("оригинал:");
        PrintList(list);
        Console.WriteLine("копия:");
        PrintList(shallowCopy);
    }


    static void DeepCopyTest(MyDoublyLinkedList<Person> list)
    {
        var deepCopy = list.DeepCopy();
        Console.WriteLine("глубокая копия, меняем всем возраст");
        if (list.Count > 0)
        {
            foreach (Person per in deepCopy)
            {
                per.Age = 67;
            }
        }
        Console.WriteLine("оригинал:");
        PrintList(list);
        Console.WriteLine("копия:");
        PrintList(deepCopy);
    }


    static void ClearList(ICollection<Person> list)
    {
        list.Clear();
        PrintList(list);
    }

    static void Task3()
    {
        MyNewCollection<Person> c1 = new();
        MyNewCollection<Person> c2 = new();

        Journal j1 = new();
        Journal j2 = new();

        // подписки
        c1.CollectionCountChanged += j1.Handler;
        c1.CollectionReferenceChanged += j1.Handler;

        c1.CollectionReferenceChanged += j2.Handler;
        c2.CollectionReferenceChanged += j2.Handler;

        // генерация
        Random rnd = new();

        c1.AddDefaults(5, () =>
        {
            var p = new Worker();
            p.RandomInit(rnd);
            return p;
        });

        // изменения
        c1[0] = new Engineer();
        c1.Remove(2);

        c2.AddDefaults(3, () =>
        {
            var p = new Administration();
            p.RandomInit(rnd);
            return p;
        });

        // вывод журналов
        Console.WriteLine("Journal 1:");
        j1.Print();

        Console.WriteLine("Journal 2:");
        j2.Print();
    }

    static void Task4()
    {
        Company company = CompanyFactory.Create();
        QueryService service = new QueryService(company);

        Console.WriteLine("======================================");
        Console.WriteLine("LINQ TO OBJECTS DEMONSTRATION PROGRAM");
        Console.WriteLine("======================================\n");

        // =====================================================
        // WHERE
        // =====================================================

        Console.WriteLine("1. WHERE (Query Syntax)\n");

        var engineersQuery = service.Where_Query_Administation();

        foreach (var person in engineersQuery)
        {
            Console.WriteLine(person);
        }

        Console.WriteLine("\n1. WHERE (Method Syntax)\n");

        var engineersMethod = service.Where_Method_Administation();

        foreach (var person in engineersMethod)
        {
            Console.WriteLine(person);
        }

        // =====================================================
        // UNION
        // =====================================================

        Console.WriteLine("\n======================================");
        Console.WriteLine("2. UNION");
        Console.WriteLine("======================================\n");

        var union = service.Union_Example();

        foreach (var person in union)
        {
            Console.WriteLine(person);
        }

        // =====================================================
        // EXCEPT
        // =====================================================

        Console.WriteLine("\n======================================");
        Console.WriteLine("3. EXCEPT");
        Console.WriteLine("======================================\n");

        var except = service.Except_Example();

        foreach (var person in except)
        {
            Console.WriteLine(person);
        }

        // =====================================================
        // INTERSECT
        // =====================================================

        Console.WriteLine("\n======================================");
        Console.WriteLine("4. INTERSECT");
        Console.WriteLine("======================================\n");

        var intersect = service.Intersect_Example();

        foreach (var person in intersect)
        {
            Console.WriteLine(person);
        }

        // =====================================================
        // AGGREGATION
        // =====================================================

        Console.WriteLine("\n======================================");
        Console.WriteLine("5. AGGREGATION");
        Console.WriteLine("======================================\n");

        Console.WriteLine($"Sum Age: {service.SumAges()}");
        Console.WriteLine($"Max Age: {service.MaxAge()}");
        Console.WriteLine($"Min Age: {service.MinAge()}");
        Console.WriteLine($"Average Age: {service.AverageAge():F2}");

        // =====================================================
        // GROUP BY
        // =====================================================

        Console.WriteLine("\n======================================");
        Console.WriteLine("6. GROUP BY");
        Console.WriteLine("======================================\n");

        var groups = service.GroupBy_Method();

        foreach (var group in groups)
        {
            Console.WriteLine($"GROUP: {group.Key}");

            foreach (var person in group)
            {
                Console.WriteLine($"   {person}");
            }

            Console.WriteLine();
        }

        // =====================================================
        // LET
        // =====================================================

        Console.WriteLine("\n======================================");
        Console.WriteLine("7. LET");
        Console.WriteLine("======================================\n");

        var letResult = service.Let_Query();

        foreach (var item in letResult)
        {
            Console.WriteLine(
                $"Name: {item.Name}, " +
                $"Age: {item.Age}, " +
                $"Level: {item.Level}"
            );
        }

        // =====================================================
        // JOIN
        // =====================================================

        Console.WriteLine("\n======================================");
        Console.WriteLine("8. JOIN");
        Console.WriteLine("======================================\n");

        var join = service.Join_Example();

        foreach (var item in join)
        {
            Console.WriteLine(
                $"Department: {item.Department}, " +
                $"Person: {item.Name}, " +
                $"Salary: {item.Salary}"
            );
        }

        // =====================================================
        // PERFORMANCE TEST
        // =====================================================

        Console.WriteLine("\n======================================");
        Console.WriteLine("9. PERFORMANCE TEST");
        Console.WriteLine("======================================\n");

        Stopwatch sw = new Stopwatch();

        // LINQ
        sw.Start();

        var linqResult = service.Where_Method_Administation().ToList();

        sw.Stop();

        long linqTicks = sw.ElapsedTicks;

        // FOREACH
        sw.Restart();

        int count = 0;

        foreach (var dept in company.Departments)
        {
            foreach (var person in dept.Value)
            {
                if (person is Engineer)
                {
                    count++;
                }
            }
        }

        sw.Stop();

        long loopTicks = sw.ElapsedTicks;

        Console.WriteLine($"LINQ Time: {linqTicks} ticks");
        Console.WriteLine($"FOREACH Time: {loopTicks} ticks");

        Console.WriteLine("\n======================================");
        Console.WriteLine("PROGRAM FINISHED");
        Console.WriteLine("======================================");
    }
}