using DynamicData;
using LearnWords.Model.DBEntity;
using LearnWords.Model.DBEntity.Clases;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LearnWords.Model.CRUD
{
    internal static class DataPresent
    {
        public static void CreateData(PresentSentence data)
        {
            if (data is null)
                throw new ArgumentNullException(nameof(data));

            using ContextApp context = new();

            context.PresentSentences.Add(data);

            context.SaveChanges();
        }

        public static List<PresentSentence> ReadData()
        {
            using ContextApp context = new();

            List<PresentSentence> data = context.PresentSentences.ToList();

            return data;
        }

        public static List<PresentSentence> ReadTenData(bool enua)
        {
            using ContextApp context = new();

            PresentSentence[] data = ReadData().ToArray();
            Random rnd = new();

            for (int i = data.Length - 1; i >= 1; i--)
            {
                int j = rnd.Next(i + 1);

                (data[i], data[j]) = (data[j], data[i]);
            }

            Queue<PresentSentence> queue = new(data);

            if (enua)
            {
                double average = queue.Select(t => t.SuccesENUA()).Average();

                List<PresentSentence> tenData = new();

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

                List<PresentSentence> tenData = new();

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

        public static void UpdateData(PresentSentence data)
        {
            if (data is null)
                throw new ArgumentNullException(nameof(data));

            using ContextApp context = new();

            context.PresentSentences.Update(data);

            context.SaveChanges();
        }

        public static void DeleteData(PresentSentence data)
        {
            if (data is null)
                throw new ArgumentNullException(nameof(data));

            using ContextApp context = new();

            context.PresentSentences.Remove(data);

            context.SaveChanges();
        }
    }
}
