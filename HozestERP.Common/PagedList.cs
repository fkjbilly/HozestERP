using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using　System.Reflection;
using　System;

namespace HozestERP.Common
{
    /// <summary>
    /// Paged list
    /// </summary>
    /// <typeparam name="T">T</typeparam>
    public class PagedList<T> : List<T>, IPagedList
    {  
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        public PagedList(IQueryable<T> source, int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            if (sortExpression.Trim().Length > 0)
            {
                string sortingDir = string.Empty;
                if (sortDirection.ToUpper().Trim() == "ASC")
                    sortingDir = "OrderBy";
                else if (sortDirection.ToUpper().Trim() == "DESC")
                    sortingDir = "OrderByDescending";
                ParameterExpression param = Expression.Parameter(typeof(T), sortExpression);
                PropertyInfo pi = typeof(T).GetProperty(sortExpression);
                Type[] types = new Type[2];
                types[0] = typeof(T);
                types[1] = pi.PropertyType;
                Expression expr = Expression.Call(typeof(Queryable), sortingDir, types, source.Expression, Expression.Lambda(Expression.Property(param, sortExpression), param));
                source = source.AsQueryable().Provider.CreateQuery<T>(expr);
            }

            int total = source.Count();
            this.TotalCount = total;
            this.TotalPages = total / pageSize;

            if (total % pageSize > 0)
                TotalPages++;

            this.PageSize = pageSize;
            this.PageIndex = pageIndex;
            this.AddRange(source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList());
        }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        public PagedList(IQueryable<T> source, int pageIndex, int pageSize)
        {
            
            int total = source.Count();
            this.TotalCount = total;
            this.TotalPages = total / pageSize;

            if (total % pageSize > 0)
                TotalPages++;

            this.PageSize = pageSize;
            this.PageIndex = pageIndex;
            this.AddRange(source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList());
        }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        public PagedList(List<T> source, int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = source.AsQueryable();
            if (sortExpression.Trim().Length > 0)
            {
                string sortingDir = string.Empty;
                if (sortDirection.ToUpper().Trim() == "ASC")
                    sortingDir = "OrderBy";
                else if (sortDirection.ToUpper().Trim() == "DESC")
                    sortingDir = "OrderByDescending";
                ParameterExpression param = Expression.Parameter(typeof(T), sortExpression);
                PropertyInfo pi = typeof(T).GetProperty(sortExpression);
                Type[] types = new Type[2];
                types[0] = typeof(T);
                types[1] = pi.PropertyType;
                Expression expr = Expression.Call(typeof(Queryable), sortingDir, types, query.Expression, Expression.Lambda(Expression.Property(param, sortExpression), param));
                query = query.AsQueryable().Provider.CreateQuery<T>(expr);
            }

            TotalCount = query.Count();
            TotalPages = TotalCount / pageSize;

            if (TotalCount % pageSize > 0)
                TotalPages++;

            this.PageSize = pageSize;
            this.PageIndex = pageIndex;
            this.AddRange(query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList());
        }
        /// <summary>
        /// 将所有数据排序
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        public PagedList(List<T> source, string sortExpression, string sortDirection)
        {
            var query = source.AsQueryable();
            if (sortExpression.Trim().Length > 0)
            {
                string sortingDir = string.Empty;
                if (sortDirection.ToUpper().Trim() == "ASC")
                    sortingDir = "OrderBy";
                else if (sortDirection.ToUpper().Trim() == "DESC")
                    sortingDir = "OrderByDescending";
                ParameterExpression param = Expression.Parameter(typeof(T), sortExpression);
                PropertyInfo pi = typeof(T).GetProperty(sortExpression);
                Type[] types = new Type[2];
                types[0] = typeof(T);
                types[1] = pi.PropertyType;
                Expression expr = Expression.Call(typeof(Queryable), sortingDir, types, query.Expression, Expression.Lambda(Expression.Property(param, sortExpression), param));
                query = query.AsQueryable().Provider.CreateQuery<T>(expr);
            }
            this.AddRange(query.ToList());

        }
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        public PagedList(List<T> source, int pageIndex, int pageSize)
        {
            TotalCount = source.Count();
            TotalPages = TotalCount / pageSize;

            if (TotalCount % pageSize > 0)
                TotalPages++;

            this.PageSize = pageSize;
            this.PageIndex = pageIndex;
          
            this.AddRange(source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList());
        }
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        public PagedList(List<T> source, int pageIndex, int pageSize, int totalCount, bool canPage = true)
        {
            TotalCount = totalCount;
            TotalPages = TotalCount / pageSize;

            if (TotalCount % pageSize > 0)
                TotalPages++;

            this.PageSize = pageSize;
            this.PageIndex = pageIndex;
         
            this.AddRange(source.ToList());
        }
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public int TotalPages { get; private set; }

        public bool HasPreviousPage
        {
            get { return (PageIndex > 0); }
        }
        public bool HasNextPage
        {
            get { return (PageIndex + 1 < TotalPages); }
        }
    }
}
