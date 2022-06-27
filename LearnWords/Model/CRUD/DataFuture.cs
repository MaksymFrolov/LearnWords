using LearnWords.Model.DBEntity;
using LearnWords.Model.DBEntity.Clases;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LearnWords.Model.CRUD
{
    internal static class DataFuture
    {
        public static void CreateData(FutureSentence data)
        {
            if (data is null)
                throw new ArgumentNullException(nameof(data));

            using ContextApp context = new();

            context.FutureSentences.Add(data);

            context.SaveChanges();
        }

        public static List<FutureSentence> ReadData()
        {
            using ContextApp context = new();

            List<FutureSentence> data = context.FutureSentences.ToList();

            return data;
        }

        public static List<FutureSentence> ReadTenData(bool enua)
        {
            FutureSentence[] data = ReadData().ToArray();
            Random rnd = new();

            for (int i = data.Length - 1; i >= 1; i--)
            {
                int j = rnd.Next(i + 1);

                (data[i], data[j]) = (data[j], data[i]);
            }

            Queue<FutureSentence> queue = new(data);

            if (enua)
            {
                double average = queue.Select(t => t.SuccesENUA()).Average();

                List<FutureSentence> tenData = new();

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

                List<FutureSentence> tenData = new();

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

        public static void UpdateData(FutureSentence data)
        {
            if (data is null)
                throw new ArgumentNullException(nameof(data));

            using ContextApp context = new();

            context.FutureSentences.Update(data);

            context.SaveChanges();
        }

        public static void DeleteData(FutureSentence data)
        {
            if (data is null)
                throw new ArgumentNullException(nameof(data));

            using ContextApp context = new();

            context.FutureSentences.Remove(data);

            context.SaveChanges();
        }
    }
}

