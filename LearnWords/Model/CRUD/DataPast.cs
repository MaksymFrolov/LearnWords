using LearnWords.Model.DBEntity;
using LearnWords.Model.DBEntity.Clases;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LearnWords.Model.CRUD
{
    internal static class DataPast
    {
        public static void CreateData(PastSentence data)
        {
            if (data is null)
                throw new ArgumentNullException(nameof(data));

            using ContextApp context = new();

            context.PastSentences.Add(data);

            context.SaveChanges();
        }

        public static List<PastSentence> ReadData()
        {
            using ContextApp context = new();

            List<PastSentence> data = context.PastSentences.ToList();

            return data;
        }

        public static List<PastSentence> ReadTenData(bool enua)
        {
            using ContextApp context = new();

            PastSentence[] data = ReadData().ToArray();
            Random rnd = new();

            for (int i = data.Length - 1; i >= 1; i--)
            {
                int j = rnd.Next(i + 1);

                (data[i], data[j]) = (data[j], data[i]);
            }

            Queue<PastSentence> queue = new(data);

            if (enua)
            {
                double average = queue.Select(t => t.SuccesENUA()).Average();

                List<PastSentence> tenData = new();

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

                List<PastSentence> tenData = new();

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

        public static void UpdateData(PastSentence data)
        {
            if (data is null)
                throw new ArgumentNullException(nameof(data));

            using ContextApp context = new();

            context.PastSentences.Update(data);

            context.SaveChanges();
        }

        public static void DeleteData(PastSentence data)
        {
            if (data is null)
                throw new ArgumentNullException(nameof(data));

            using ContextApp context = new();

            context.PastSentences.Remove(data);

            context.SaveChanges();
        }
    }
}
