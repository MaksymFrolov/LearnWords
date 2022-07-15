using LearnWords.Model.DBEntity;
using LearnWords.Model.DBEntity.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnWords.Model.Service
{
    public class GenericDataService<T> : IDataService<T> where T : Promotion
    {
        readonly ContextAppFactory contextFactory;

        public GenericDataService(ContextAppFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public async Task<bool> Create(T entity)
        {
            using ContextApp context = contextFactory.CreateDbContext();

            context.Set<T>().Add(entity);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(T entity)
        {
            using ContextApp context = contextFactory.CreateDbContext();

            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using ContextApp context = contextFactory.CreateDbContext();

            return await Task.Run(() => context.Set<T>().ToList());
        }

        public async Task<IEnumerable<T>> GetTen(bool enua)
        {
            List<T> data = (await GetAll()).ToList();
            Random rnd = new();

            for (int i = data.Count - 1; i >= 1; i--)
            {
                int j = rnd.Next(i + 1);

                (data[i], data[j]) = (data[j], data[i]);
            }

            List<T> tenData = new();

            if (enua)
            {
                double average = data.Select(t => t.SuccesENUA).Average();

                while (tenData.Count < 10)
                {
                    data.RemoveAll(t => tenData.Any(x => x.Id == t.Id));

                    foreach (var d in data)
                    {
                        int num = d.SuccesENUA,
                            randomNum = rnd.Next(0, 10);

                        if (num < average / 2)
                            tenData.Add(d);
                        else if (num < average && randomNum < 5)
                            tenData.Add(d);
                        else if (randomNum < 3)
                            tenData.Add(d);
                        if (tenData.Count == 10)
                            return tenData;
                    }
                }

                return tenData;
            }
            else
            {
                double average = data.Select(t => t.SuccesUAEN).Average();

                while (tenData.Count < 10)
                {
                    data.RemoveAll(t => tenData.Any(x => x.Id == t.Id));

                    foreach (var d in data)
                    {
                        int num = d.SuccesUAEN,
                            randomNum = rnd.Next(0, 10);

                        if (num < average / 2)
                            tenData.Add(d);
                        else if (num < average && randomNum < 5)
                            tenData.Add(d);
                        else if (randomNum < 3)
                            tenData.Add(d);
                        if (tenData.Count == 10)
                            return tenData;
                    }
                }

                return tenData;
            }
        }

        public async Task<bool> Update(T entity)
        {
            using ContextApp context = contextFactory.CreateDbContext();

            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();

            return true;
        }
    }
}
