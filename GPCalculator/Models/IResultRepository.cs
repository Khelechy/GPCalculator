using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GPCalculator.Models
{
    public interface IResultRepository { 
        Result GetResult(int Id);
        IEnumerable<Result> GetAllResult();
        Result Add(Result result);
        Result Update(Result resultChanges);
        Result Delete(int Id);
    }
}
