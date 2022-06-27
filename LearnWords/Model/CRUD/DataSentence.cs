using LearnWords.Model.DBEntity;
using LearnWords.Model.DBEntity.Clases;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LearnWords.Model.CRUD
{
    internal static class DataSentence
    {
        public static void CreateData(Sentence data)
        {
            if (data is null)
                throw new ArgumentNullException(nameof(data));

            using ContextApp context = new();

            context.Sentences.Add(data);

            context.SaveChanges();
        }

        public static List<Sentence> ReadData()
        {
            using ContextApp context = new();

            List<Sentence> data = context.Sentences.ToList();

            return data;
        }

        public static List<Sentence> ReadTenData(bool enua)
        {
            using ContextApp context = new();

            Sentence[] data = ReadData().ToArray();

            Random rnd = new();

            for (int i = data.Length - 1; i >= 1; i--)
            {
                int j = rnd.Next(i + 1);

                (data[i], data[j]) = (data[j], data[i]);
            }

            Queue<Sentence> queue = new(data);

            if (enua)
            {
                double average = queue.Select(t => t.SuccesENUA()).Average();

                List<Sentence> tenData = new();

                while (tenData.Count < 10)
                {
                    int num = queue.First().SuccesENUA(),
                        randomNum = rnd.Next(0, 10);

                    if (num < average / 2)
                        tenData.Add(queue.Dequeue());
                    else if (num < average && randomNum < 5)
                        tenData.Add(queue.Dequeue());
                    else if (randomNum < 3)
                        tenData.Add(queue.Dequeue());
                }

                return tenData;
            }
            else
            {
                double average = queue.Select(t => t.SuccesUAEN()).Average();

                List<Sentence> tenData = new();

                while (tenData.Count < 10)
                {
                    int num = queue.First().SuccesUAEN(),
                        randomNum = rnd.Next(0, 10);

                    if (num < average / 2)
                        tenData.Add(queue.Dequeue());
                    else if (num < average && randomNum < 5)
                        tenData.Add(queue.Dequeue());
                    else if (randomNum < 3)
                        tenData.Add(queue.Dequeue());
                }

                return tenData;
            }
        }

        public static void UpdateData(Sentence data)
        {
            if (data is null)
                throw new ArgumentNullException(nameof(data));

            using ContextApp context = new();

            context.Sentences.Update(data);

            context.SaveChanges();
        }

        public static void DeleteData(Sentence data)
        {
            if (data is null)
                throw new ArgumentNullException(nameof(data));

            using ContextApp context = new();

            context.Sentences.Remove(data);

            context.SaveChanges();
        }
    }
}
