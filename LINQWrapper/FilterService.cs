using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQWrapper
{
    public class FilterService <T>
    {
        private readonly IEnumerable<T> _data;

        public FilterService(IEnumerable<T> data)
        {
            _data = data;
        }

        public IEnumerable<T> Where(Func<T, bool> f)
        {
            return
                from s in this._data 
                where f(s)
                select s;
        }
    }
}