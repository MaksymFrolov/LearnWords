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
            using ContextApp context = new();

            FutureSentence[] data = ReadData().ToArray();
            List<FutureSentence> tenData = new();
            Random rnd = new();
            double average;

            for (int i = data.Length - 1; i >= 1; i--)
            {
                int j = rnd.Next(i + 1);

                (data[i], data[j]) = (data[j], data[i]);
            }

            Queue<FutureSentence> queue = new(data);

            if (enua)
            {
                average = queue.Select(t => t.SuccesENUA()).Average();

                while (tenData.Count < 10)
                {
                    if (queue.First().SuccesENUA() < average / 2)
                        tenData.Add(queue.Dequeue());
                    else if (queue.First().SuccesENUA() < average && rnd.Next(0, 4) < 2)
                        tenData.Add(queue.Dequeue());
                    else if (rnd.Next(0, 10) < 3)
                        tenData.Add(queue.Dequeue());
                }
                return tenData;
            }
            else
            {
                average = queue.Select(t => t.SuccesUAEN()).Average();

                while (tenData.Count < 10)
                {
                    if (queue.First().SuccesUAEN() < average / 2)
                        tenData.Add(queue.Dequeue());
                    else if (queue.First().SuccesUAEN() < average && rnd.Next(0, 4) < 2)
                        tenData.Add(queue.Dequeue());
                    else if (rnd.Next(0, 10) < 3)
                        tenData.Add(queue.Dequeue());
                }
                return tenData;
            }
        }

        public static void UpdateData(List<FutureSentence> data)
        {
            if (data is null)
                throw new ArgumentNullException(nameof(data));

            using ContextApp context = new();

            foreach (FutureSentence d in data)
                context.FutureSentences.Update(d);

            context.SaveChanges();
        }

        public static void DeleteData(List<FutureSentence> data)
        {
            if (data is null)
                throw new ArgumentNullException(nameof(data));

            using ContextApp context = new();

            foreach (FutureSentence d in data)
                context.FutureSentences.Remove(d);

            context.SaveChanges();
        }
    }
}

