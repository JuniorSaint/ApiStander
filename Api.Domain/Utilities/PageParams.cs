using System;
namespace Api.Domain.Utilities
{
    public class PageParams
    {
        public const int MaxPageSize = 25;
        public int PageNumber { get; set; } = 1;
        public int PageSize = 10;
        public int pageSize
        {
            get{return PageSize;}
            set { PageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }
        public string term { get; set; } = string.Empty;
    }
}

