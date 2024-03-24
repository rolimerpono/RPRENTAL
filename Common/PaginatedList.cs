using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class PaginatedList<T>
    {
        public IEnumerable<T> ITEMS { get; set; }

        public int TOTAL_ITEMS { get; set; }

        public int PAGE_INDEX { get; set; }

        public int PAGE_SIZE { get; set;}

        public int TOTAL_PAGES { get; set; }
      
   
        public PaginatedList(List<T> items, int count , int pageIndex, int pageSize)
        {
            PAGE_INDEX = pageIndex;
            TOTAL_PAGES = (int)Math.Ceiling(count / (double)pageSize);
            ITEMS = items;
      
        }

        public Boolean HAS_PREVIOUS_PAGE => (PAGE_INDEX > 1);
        public Boolean HAS_NEXT_PAGE => (PAGE_INDEX < TOTAL_PAGES);

        public int FIRST_INDEX => (PAGE_INDEX - 1) * PAGE_SIZE + 1;

        public int LAST_INDEX => Math.Min(PAGE_INDEX * PAGE_SIZE, TOTAL_ITEMS);


        public static PaginatedList<T> Create(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count(); //Total Number of Items

            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            return new PaginatedList<T>(items,count, pageIndex, pageSize);
        
        }
    }
}
