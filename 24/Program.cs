using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace _24
{
    class Program
    {
        static void z1()
        {
            // 1) Считываем строковую дату в формате ДДММГГГГ
            Console.Write("Введите дату (ДДММГГГГ): ");
            string dateInput = Console.ReadLine();

            // Разбиваем строку на части: день, месяц, год
            string dayStr = dateInput.Substring(0, 2);   // первые 2 символа - день
            string monthStr = dateInput.Substring(2, 2); // следующие 2 символа - месяц
            string yearStr = dateInput.Substring(4, 4);  // последние 4 символа - год

            // Выводим день, месяц, год по отдельности
            Console.WriteLine($"День: {dayStr}");
            Console.WriteLine($"Месяц: {monthStr}");
            Console.WriteLine($"Год: {yearStr}");

            // 2) Считываем дату и время производства продукта
            Console.Write("Введите дату производства (ДДММГГГГ): ");
            string prodDate = Console.ReadLine();
            Console.Write("Введите время производства (ЧЧ:ММ:СС): ");
            string prodTime = Console.ReadLine();

            // Считываем срок годности в часах (целое число)
            Console.Write("Введите срок годности (в часах): ");
            int shelfLifeHours;
            if (!int.TryParse(Console.ReadLine(), out shelfLifeHours))
            {
                // Если введено не целое число, сообщаем об ошибке и завершаем программу
                Console.WriteLine("Неверный формат срока годности!");
                return;
            }

            // Преобразуем строку даты и времени производства в объект DateTime
            DateTime productionDateTime = DateTime.ParseExact(
                prodDate + " " + prodTime,
                "ddMMyyyy HH:mm:ss",
                CultureInfo.InvariantCulture
            );

            // 3) Вычисляем момент окончания срока годности
            DateTime expirationDateTime = productionDateTime.AddHours(shelfLifeHours);

            // Сравниваем вычисленную дату окончания срока с текущим временем
            DateTime now = DateTime.Now;
            if (expirationDateTime > now)
            {
                // Срок еще не истек: вычисляем, сколько часов осталось до его окончания
                TimeSpan remaining = expirationDateTime - now;
                double hoursLeft = remaining.TotalHours; // разница в часах (с дробной частью)

                // Выводим оставшиеся часы (форматируем до 2 знаков после запятой)
                Console.WriteLine($"До окончания срока годности осталось {hoursLeft:F2} часов.");
            }
            else
            {
                // Срок годности истек: выводим предупреждение
                Console.WriteLine("Продукт просрочен.");
            }
        }
        public static void TrainScheduleTask()
        {
            // Чтение данных первого поезда
            Console.WriteLine("Введите номер поезда 1:");
            int number1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите станцию отправления поезда 1:");
            string departureStation1 = Console.ReadLine();
            Console.WriteLine("Введите дату отправления (ДДММГГГГ):");
            string depDate1 = Console.ReadLine();
            Console.WriteLine("Введите время отправления (ЧЧ:ММ:СС):");
            string depTime1 = Console.ReadLine();
            Console.WriteLine("Введите станцию прибытия поезда 1:");
            string arrivalStation1 = Console.ReadLine();
            Console.WriteLine("Введите дату прибытия (ДДММГГГГ):");
            string arrDate1 = Console.ReadLine();
            Console.WriteLine("Введите время прибытия (ЧЧ:ММ:СС):");
            string arrTime1 = Console.ReadLine();

            // Парсинг даты и времени первого поезда
            DateTime departDateTime1 = DateTime.ParseExact(depDate1 + " " + depTime1, "ddMMyyyy HH:mm:ss", CultureInfo.InvariantCulture);
            DateTime arrivalDateTime1 = DateTime.ParseExact(arrDate1 + " " + arrTime1, "ddMMyyyy HH:mm:ss", CultureInfo.InvariantCulture);
            TimeSpan duration1 = arrivalDateTime1 - departDateTime1; // длительность пути

            // Чтение данных второго поезда
            Console.WriteLine("Введите номер поезда 2:");
            int number2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите станцию отправления поезда 2:");
            string departureStation2 = Console.ReadLine();
            Console.WriteLine("Введите дату отправления (ДДММГГГГ):");
            string depDate2 = Console.ReadLine();
            Console.WriteLine("Введите время отправления (ЧЧ:ММ:СС):");
            string depTime2 = Console.ReadLine();
            Console.WriteLine("Введите станцию прибытия поезда 2:");
            string arrivalStation2 = Console.ReadLine();
            Console.WriteLine("Введите дату прибытия (ДДММГГГГ):");
            string arrDate2 = Console.ReadLine();
            Console.WriteLine("Введите время прибытия (ЧЧ:ММ:СС):");
            string arrTime2 = Console.ReadLine();

            DateTime departDateTime2 = DateTime.ParseExact(depDate2 + " " + depTime2, "ddMMyyyy HH:mm:ss", CultureInfo.InvariantCulture);
            DateTime arrivalDateTime2 = DateTime.ParseExact(arrDate2 + " " + arrTime2, "ddMMyyyy HH:mm:ss", CultureInfo.InvariantCulture);
            TimeSpan duration2 = arrivalDateTime2 - departDateTime2;

            // Вывод информации о поездах
            Console.WriteLine($"Поезд №{number1}, {departureStation1} -> {arrivalStation1}");
            Console.WriteLine($"Время отправления: {departDateTime1:dd.MM.yyyy HH:mm:ss}");
            Console.WriteLine($"Время прибытия: {arrivalDateTime1:dd.MM.yyyy HH:mm:ss}");
            Console.WriteLine($"Длительность в пути: {duration1:hh\\:mm\\:ss}");
            Console.WriteLine($"Поезд №{number2}, {departureStation2} -> {arrivalStation2}");
            Console.WriteLine($"Время отправления: {departDateTime2:dd.MM.yyyy HH:mm:ss}");
            Console.WriteLine($"Время прибытия: {arrivalDateTime2:dd.MM.yyyy HH:mm:ss}");
            Console.WriteLine($"Длительность в пути: {duration2:hh\\:mm\\:ss}");

            // Поиск поездов из Киева по указанному интервалу
            Console.WriteLine("Введите начальную дату интервала (ДДММГГГГ):");
            string startDate = Console.ReadLine();
            Console.WriteLine("Введите начальное время интервала (ЧЧ:ММ:СС):");
            string startTime = Console.ReadLine();
            DateTime start = DateTime.ParseExact(startDate + " " + startTime, "ddMMyyyy HH:mm:ss", CultureInfo.InvariantCulture);

            Console.WriteLine("Введите конечную дату интервала (ДДММГГГГ):");
            string endDate = Console.ReadLine();
            Console.WriteLine("Введите конечное время интервала (ЧЧ:ММ:СС):");
            string endTime = Console.ReadLine();
            DateTime end = DateTime.ParseExact(endDate + " " + endTime, "ddMMyyyy HH:mm:ss", CultureInfo.InvariantCulture);

            // Проверка первого поезда
            if (departureStation1.Equals("Киев", StringComparison.OrdinalIgnoreCase)
                && departDateTime1 >= start && departDateTime1 <= end)
            {
                Console.WriteLine($"Поезд №{number1}, {departureStation1} -> {arrivalStation1}");
                Console.WriteLine($"Время отправления: {departDateTime1:dd.MM.yyyy HH:mm:ss}");
                Console.WriteLine($"Время прибытия: {arrivalDateTime1:dd.MM.yyyy HH:mm:ss}");
                Console.WriteLine($"Длительность в пути: {duration1:hh\\:mm\\:ss}");
            }
            // Проверка второго поезда
            if (departureStation2.Equals("Киев", StringComparison.OrdinalIgnoreCase)
                && departDateTime2 >= start && departDateTime2 <= end)
            {
                Console.WriteLine($"Поезд №{number2}, {departureStation2} -> {arrivalStation2}");
                Console.WriteLine($"Время отправления: {departDateTime2:dd.MM.yyyy HH:mm:ss}");
                Console.WriteLine($"Время прибытия: {arrivalDateTime2:dd.MM.yyyy HH:mm:ss}");
                Console.WriteLine($"Длительность в пути: {duration2:hh\\:mm\\:ss}");
            }
        }
        class Train
        {
            public int Number { get; set; }
            public string DepartureStation { get; set; }
            public DateTime Departure { get; set; }
            public string ArrivalStation { get; set; }
            public DateTime Arrival { get; set; }

            public TimeSpan Duration => Arrival - Departure;

            public override string ToString()
            {
                return $"Поезд {Number}: {DepartureStation} {Departure:dd.MM.yyyy HH:mm:ss} -> {ArrivalStation} {Arrival:dd.MM.yyyy HH:mm:ss}, В пути: {Duration:hh\\:mm\\:ss}";
            }

            public string ToFileString()
            {
                return $"{Number};{DepartureStation};{Departure:ddMMyyyy};{Departure:HH:mm:ss};{ArrivalStation};{Arrival:ddMMyyyy};{Arrival:HH:mm:ss}";
            }

            public static Train FromFileString(string line)
            {
                var parts = line.Split(';');
                int number = int.Parse(parts[0]);
                string depSt = parts[1];
                DateTime dep = DateTime.ParseExact(parts[2], "ddMMyyyy", CultureInfo.InvariantCulture)
                                  .Add(TimeSpan.Parse(parts[3]));
                string arrSt = parts[4];
                DateTime arr = DateTime.ParseExact(parts[5], "ddMMyyyy", CultureInfo.InvariantCulture)
                                  .Add(TimeSpan.Parse(parts[6]));
                return new Train { Number = number, DepartureStation = depSt, Departure = dep, ArrivalStation = arrSt, Arrival = arr };
            }
        }

        void HighLevelTrainTasks()
        {
            string filePath = "trains.txt";
            var trains = new List<Train>();

            Console.Write("Введите количество поездов: ");
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"\nПоезд #{i + 1}:");
                Console.Write("Номер: ");
                int number = int.Parse(Console.ReadLine());
                Console.Write("Станция отправления: ");
                string depSt = Console.ReadLine();
                Console.Write("Дата отправления (ДДММГГГГ): ");
                DateTime depDate = DateTime.ParseExact(Console.ReadLine(), "ddMMyyyy", CultureInfo.InvariantCulture);
                Console.Write("Время отправления (ЧЧ:ММ:СС): ");
                TimeSpan depTime = TimeSpan.Parse(Console.ReadLine());
                Console.Write("Станция прибытия: ");
                string arrSt = Console.ReadLine();
                Console.Write("Дата прибытия (ДДММГГГГ): ");
                DateTime arrDate = DateTime.ParseExact(Console.ReadLine(), "ddMMyyyy", CultureInfo.InvariantCulture);
                Console.Write("Время прибытия (ЧЧ:ММ:СС): ");
                TimeSpan arrTime = TimeSpan.Parse(Console.ReadLine());

                trains.Add(new Train
                {
                    Number = number,
                    DepartureStation = depSt,
                    Departure = depDate + depTime,
                    ArrivalStation = arrSt,
                    Arrival = arrDate + arrTime
                });
            }

            File.WriteAllLines(filePath, trains.Select(t => t.ToFileString()));
            Console.WriteLine("\nДанные записаны в файл.");

            var loadedTrains = File.ReadAllLines(filePath).Select(Train.FromFileString).ToList();

            // Задание 1
            Console.Write("\nВведите станцию прибытия: ");
            string targetStation = Console.ReadLine();
            var afterNoon = loadedTrains.Where(t =>
                t.ArrivalStation.Equals(targetStation, StringComparison.OrdinalIgnoreCase)
                && t.Arrival.TimeOfDay > new TimeSpan(12, 0, 0)).ToList();

            Console.WriteLine($"\nПоезда, прибывающие в {targetStation} после 12:00:");
            foreach (var train in afterNoon)
                Console.WriteLine(train);
            Console.WriteLine($"Всего: {afterNoon.Count}");

            // Задание 2
            var odessaToKyiv = loadedTrains
                .Where(t => t.DepartureStation.Equals("Одесса", StringComparison.OrdinalIgnoreCase)
                         && t.ArrivalStation.Equals("Киев", StringComparison.OrdinalIgnoreCase))
                .OrderBy(t => t.Departure)
                .FirstOrDefault();

            if (odessaToKyiv != null)
            {
                Console.WriteLine("\nПервый поезд Одесса → Киев:");
                Console.WriteLine(odessaToKyiv);
            }
            else Console.WriteLine("\nНет поездов из Одессы в Киев.");

            // Задание 3
            var kharkivTrains = loadedTrains.Where(t =>
                t.Number >= 1 && t.Number <= 100
                && t.ArrivalStation.Equals("Харьков", StringComparison.OrdinalIgnoreCase)
                && t.Arrival.TimeOfDay < new TimeSpan(9, 0, 0)).ToList();

            string refFile = "KharkivFastTrains.txt";
            var refLines = kharkivTrains.Select(t =>
                $"Поезд {t.Number}: {t.Departure:dd.MM.yyyy HH:mm:ss} -> {t.Arrival:dd.MM.yyyy HH:mm:ss}, В пути: {t.Duration:hh\\:mm\\:ss}");
            File.WriteAllLines(refFile, refLines);
            Console.WriteLine("\nСправка записана в файл KharkivFastTrains.txt.");
        }
        static void z3()
        {
            // 1. Ввод данных двух поездов и запись в файл
            List<string> lines = new List<string>();
            for (int i = 1; i <= 2; i++)
            {
                Console.WriteLine($"Введите данные для поезда #{i}:");
                Console.Write("Номер поезда : ");
                int number = int.Parse(Console.ReadLine());
                Console.Write("Станция отправления: ");
                string depStation = Console.ReadLine();
                Console.Write("Дата отправления (ДДММГГГГ): ");
                string depDate = Console.ReadLine();
                Console.Write("Время отправления (ЧЧ:ММ:СС): ");
                string depTime = Console.ReadLine();
                Console.Write("Станция прибытия: ");
                string arrStation = Console.ReadLine();
                Console.Write("Дата прибытия (ДДММГГГГ): ");
                string arrDate = Console.ReadLine();
                Console.Write("Время прибытия (ЧЧ:ММ:СС): ");
                string arrTime = Console.ReadLine();

                // Формируем строку с разделителем ';'
                string line = $"{number};{depStation};{depDate};{depTime};{arrStation};{arrDate};{arrTime}";
                lines.Add(line);
                Console.WriteLine(); // пустая строка для читабельности
            }
            // Записываем все введённые поезда в файл trains.txt
            File.WriteAllLines("trains.txt", lines);

            // 2. Чтение поездов из файла
            if (!File.Exists("trains.txt"))
            {
                Console.WriteLine("Файл trains.txt не найден.");
                return;
            }
            string[] allLines = File.ReadAllLines("trains.txt");
            // Структура для хранения данных поезда
            var trains = new List<(int Number, string DepStation, DateTime DepTime, string ArrStation, DateTime ArrTime)>();
            foreach (string ln in allLines)
            {
                if (string.IsNullOrWhiteSpace(ln)) continue;
                var parts = ln.Split(';');
                if (parts.Length != 7) continue; // некорректная строка
                int num = int.Parse(parts[0]);
                string depSt = parts[1];
                // Парсим дату и время отправления
                DateTime depDateTime = DateTime.ParseExact(parts[2] + parts[3], "ddMMyyyyHH:mm:ss", CultureInfo.InvariantCulture);
                string arrSt = parts[4];
                DateTime arrDateTime = DateTime.ParseExact(parts[5] + parts[6], "ddMMyyyyHH:mm:ss", CultureInfo.InvariantCulture);
                trains.Add((num, depSt, depDateTime, arrSt, arrDateTime));
            }

            // 3. Вывод поездов по введённой станции прибытия после 12:00
            Console.Write("Введите название станции прибытия для фильтра: ");
            string targetStation = Console.ReadLine();
            var filtered = trains
                .Where(t => t.ArrStation.Equals(targetStation, StringComparison.OrdinalIgnoreCase)
                         && t.ArrTime.TimeOfDay > new TimeSpan(12, 0, 0))
                .ToList();
            Console.WriteLine($"\nПоездов, прибывающих в \"{targetStation}\" после 12:00: {filtered.Count}");
            foreach (var t in filtered)
            {
                Console.WriteLine($"Поезд №{t.Number}: {t.DepStation} ({t.DepTime:dd.MM.yyyy HH:mm:ss}) -> {t.ArrStation} ({t.ArrTime:dd.MM.yyyy HH:mm:ss}), " +
                                  $"время в пути {t.ArrTime - t.DepTime}");
            }

            // 4. Поиск самого раннего поезда из Одессы в Киев
            var odessaKiev = trains
                .Where(t => t.DepStation.Equals("Одесса", StringComparison.OrdinalIgnoreCase)
                         && t.ArrStation.Equals("Киев", StringComparison.OrdinalIgnoreCase))
                .OrderBy(t => t.DepTime)
                .FirstOrDefault();
            if (odessaKiev.Number != 0) // проверяем, что найден хотя бы один
            {
                TimeSpan duration = odessaKiev.ArrTime - odessaKiev.DepTime;
                Console.WriteLine($"\nПервый поезд из Одессы в Киев: №{odessaKiev.Number}, время отправления {odessaKiev.DepTime:dd.MM.yyyy HH:mm:ss}.");
                Console.WriteLine($"Продолжительность пути: {duration}");
            }
            else
            {
                Console.WriteLine("\nПоездов из Одессы в Киев не найдено.");
            }

            // 5. Создание файла KharkivFastTrains.txt для поездов №1–100, прибывающих в Харьков до 09:00
            var kharkivFast = trains
                .Where(t => t.Number >= 1 && t.Number <= 100
                         && t.ArrStation.Equals("Харьков", StringComparison.OrdinalIgnoreCase)
                         && t.ArrTime.TimeOfDay < new TimeSpan(9, 0, 0))
                .ToList();
            List<string> kharkivLines = new List<string>();
            foreach (var t in kharkivFast)
            {
                TimeSpan dur = t.ArrTime - t.DepTime;
                kharkivLines.Add($"№{t.Number}; {t.DepStation} ({t.DepTime:dd.MM.yyyy HH:mm:ss}) -> {t.ArrStation} ({t.ArrTime:dd.MM.yyyy HH:mm:ss}); время_в_пути={dur}");
            }
            File.WriteAllLines("KharkivFastTrains.txt", kharkivLines);

            Console.WriteLine("\nДополнительный файл KharkivFastTrains.txt создан.");
        }

        static void Main(string[] args)
        {
            Console.Write("Введите номер задачи (уровень(Легкий, средний, высокий)) ");
            int zadanie = int.Parse(Console.ReadLine());
            switch (zadanie)
            {
                case 1: z1(); break;
                case 2:TrainScheduleTask() ; break;
                case 3:z3() ;break;
            }
        }
    }
}
