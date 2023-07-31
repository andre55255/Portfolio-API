using Portfolio.Communication.CustomExceptions;
using Portfolio.Communication.ViewObjects.Utlis;

namespace Portfolio.Helpers
{
    public static class StaticMethods
    {
        public static string GetPlace(this object obj)
        {
            return obj.GetType().ToString();
        }

        public static void GetPaginationItems<T>(ref ListAllEntityVO<T> list, ref int? limit, ref int? page) where T : class
        {
            try
            {
                if (limit is null)
                    limit = -1;

                if (page is null)
                    page = -1;

                double countPages = list.TotalItems.Value / limit.Value;
                if (Math.Floor(countPages) < page)
                {
                    limit = list.TotalItems;
                    page = 0;
                    countPages = 0;
                }
                list.TotalPages = int.Parse(countPages.ToString()) <= 0 ? 0 : int.Parse(countPages.ToString());
                list.HasNextPage = list.TotalPages > (page + 1);
                list.HasPreviousPage = page > 0;

                if (limit <= 0)
                    limit = list.TotalItems;
                if (page <= 0)
                    page = 0;
            }
            catch (Exception ex)
            {
                throw new ValidException($"Falha ao realizar cálculo de paginação de itens", ex);
            }
        }
    }
}
