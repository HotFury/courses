using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.WebUI.Models
{
    public class PageInfo
    {
        public int StartPage
        {
            get
            {
                if (CurPage - PageRange/2 > 1)
                {
                    return CurPage - PageRange / 2;
                }
                else
                {
                    return 1;
                }
            }
        }
        public int CurPage { get; set; }
        public int PageRange { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }
        public int PageLimit
        {
            get
            {
                if (StartPage + PageRange < TotalPages)
                    return StartPage + PageRange;
                else
                    return TotalPages;
            }
        }
        public int TotalPages
        {
            get
            {
                return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
            }
        }
    }
}