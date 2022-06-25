using LearnWords.Model.DBEntity;
using LearnWords.Model.DBEntity.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnWords.Model
{
    internal static class Data<T>
    {
        public static void CreateData(T data)
        {
            if (data is null)
                throw new ArgumentNullException(nameof(data));

            using ContextApp context = new();

            switch (data.GetType().Name)
            {
                case nameof(FutureSentence):
                    context.FutureSentences.Add(data as FutureSentence);
                    break;
                case nameof(PastSentence):
                    context.PastSentences.Add(data as PastSentence);
                    break;
                case nameof(PresentSentence):
                    context.PresentSentences.Add(data as PresentSentence);
                    break;
                case nameof(Sentence):
                    context.Sentences.Add(data as Sentence);
                    break;
                case nameof(Word):
                    context.Words.Add(data as Word);
                    break;
            }

            context.SaveChanges();
        }

        public static List<T> ReadFutureSentence()
        {
            using ContextApp context = new();

            List<T> data = new();

            switch (data.AsQueryable().ElementType.Name)
            {
                case nameof(FutureSentence):
                    data = context.FutureSentences.ToList() as List<T>;
                    break;
                case nameof(PastSentence):
                    data = context.PastSentences.ToList() as List<T>;
                    break;
                case nameof(PresentSentence):
                    data = context.PresentSentences.ToList() as List<T>;
                    break;
                case nameof(Sentence):
                    data = context.Sentences.ToList() as List<T>;
                    break;
                case nameof(Word):
                    data = context.Words.ToList() as List<T>;
                    break;
            }

            return data;
        }

        public static void UpdateFutureSentence(List<T> data)
        {
            if (data is null)
                throw new ArgumentNullException(nameof(data));

            using ContextApp context = new();

            switch (data.AsQueryable().ElementType.Name)
            {
                case nameof(FutureSentence):
                    foreach (T d in data)
                        context.FutureSentences.Update(d as FutureSentence);
                    break;
                case nameof(PastSentence):
                    foreach (T d in data)
                        context.PastSentences.Update(d as PastSentence);
                    break;
                case nameof(PresentSentence):
                    foreach (T d in data)
                        context.PresentSentences.Update(d as PresentSentence);
                    break;
                case nameof(Sentence):
                    foreach (T d in data)
                        context.Sentences.Update(d as Sentence);
                    break;
                case nameof(Word):
                    foreach (T d in data)
                        context.Words.Update(d as Word);
                    break;
            }

            context.SaveChanges();
        }

        public static void DeleteFutureSentence(List<T> data)
        {
            if (data is null)
                throw new ArgumentNullException(nameof(data));

            using ContextApp context = new();

            switch (data.AsQueryable().ElementType.Name)
            {
                case nameof(FutureSentence):
                    foreach (T d in data)
                        context.FutureSentences.Remove(d as FutureSentence);
                    break;
                case nameof(PastSentence):
                    foreach (T d in data)
                        context.PastSentences.Remove(d as PastSentence);
                    break;
                case nameof(PresentSentence):
                    foreach (T d in data)
                        context.PresentSentences.Remove(d as PresentSentence);
                    break;
                case nameof(Sentence):
                    foreach (T d in data)
                        context.Sentences.Remove(d as Sentence);
                    break;
                case nameof(Word):
                    foreach (T d in data)
                        context.Words.Remove(d as Word);
                    break;
            }

            context.SaveChanges();
        }
    }
}
