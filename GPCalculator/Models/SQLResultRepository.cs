using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GPCalculator.Models
{
    public class SQLResultRepository : IResultRepository
    {
        private readonly AppDBContext context;

        public SQLResultRepository(AppDBContext context)
        {
            this.context = context;
        }
        public Result Add(Result result)
        {
            context.Results.Add(result);
            context.SaveChanges();
            return result;
        }

        public Result Delete(int Id)
        {
            Result result = context.Results.Find(Id);
            if (result != null)
            {
                context.Results.Remove(result);
                context.SaveChanges();
            }
            return result;
        }

        public IEnumerable<Result> GetAllResult()
        {
            return context.Results;
        }

        public Result GetResult(int Id)
        {
            return context.Results.Find(Id);
        }

        public Result Update(Result resultChanges)
        {
            var result = context.Results.Attach(resultChanges);
            result.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return resultChanges;
        }
    }
}
