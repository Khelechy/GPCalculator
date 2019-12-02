using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GPCalculator.Models
{
    public class MockResultRepository : IResultRepository
    {
        private List<Result> _resultList;
        public MockResultRepository()
        {
            _resultList = new List<Result>()
            {
                new Result(){Lastname="Ulelu", Firstname="Israel", Id = 1, Regno="2017/386373", Department="Computer Science", Level="300", Session="2019/2020", Semester="First" },
                new Result(){Lastname="Bala", Firstname="Thomas",Id = 2,  Regno="2017/656373", Department="Soil Science", Level="100", Session="2019/2020", Semester="First" },
                new Result(){Lastname="Lastname", Firstname="Firstname", Id = 3, Regno="Registration number", Department="Department", Level="Level", Session="2019/2020", Semester="Semester" },
            };
        }

        public Result Add(Result result)
        {
            result.Id = _resultList.Max(r => r.Id) + 1;
            _resultList.Add(result);
            return result;
        }

        public Result Delete(int Id)
        {
            Result result = _resultList.FirstOrDefault(r => r.Id == Id);

            if(result != null)
            {
                _resultList.Remove(result);
            }
            return result;
        }

        public Result GetResult(int Id)
        {
            return _resultList.FirstOrDefault(r => r.Id == Id);
        }

        public void Save(Result result)
        {
            throw new NotImplementedException();
        }

        public Result Update(Result resultChanges)
        {
            Result result = _resultList.FirstOrDefault(r => r.Id == resultChanges.Id);

            if(result != null)
            {
                result.Firstname = resultChanges.Firstname;
                result.Lastname = resultChanges.Lastname;
                result.Level = resultChanges.Level;
                result.Regno = resultChanges.Regno;
                result.Semester = resultChanges.Semester;
                result.Session = resultChanges.Session;
            }
            return result;
        }

        IEnumerable<Result> IResultRepository.GetAllResult()
        {
            return _resultList;
        }
    }
}
