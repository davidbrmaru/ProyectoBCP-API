namespace ProyectoBCP_API.Models.Request
{
    public class PaginadoRequest
    {
        const int maxPageSize = 20;
        
        private int _pageSize = 10;
        public int PageSize { get { return _pageSize; } set { _pageSize = (value > maxPageSize) ? maxPageSize : value; } }
        public int PageNumber { get; set; } = 1;
    }
    //public class PaginadoRequest2
    public class PaginadoTotalRequest
    {
        public int TotalRows { get; set; }

    }
}
