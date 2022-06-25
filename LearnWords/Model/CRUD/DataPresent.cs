using LearnWords.Model.DBEntity;
using LearnWords.Model.DBEntity.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            List<PresentSentence> tenData = new();
            Random rnd = new();
            double average;

            for (int i = data.Length - 1; i >= 1; i--)
            {
                int j = rnd.Next(i + 1);

                (data[i], data[j]) = (data[j], data[i]);
            }

            Queue<PresentSentence> queue = new(data);

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

        public static void UpdateData(List<PresentSentence> data)
        {
            if (data is null)
                throw new ArgumentNullException(nameof(data));

            using ContextApp context = new();

            foreach (PresentSentence d in data)
                context.PresentSentences.Update(d);

            context.SaveChanges();
        }

        public static void DeleteData(List<PresentSentence> data)
        {
            if (data is null)
                throw new ArgumentNullException(nameof(data));

            using ContextApp context = new();

            foreach (PresentSentence d in data)
                context.PresentSentences.Remove(d);

            context.SaveChanges();
        }
    }
}
