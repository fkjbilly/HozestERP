

using System;
using System.Data;
using System.Data.Objects;
using System.Diagnostics;
using System.Data.Metadata.Edm;
using System.Linq;
using System.Linq.Expressions;
using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using System.Runtime.CompilerServices;

using HozestERP.BusinessLogic.Data;

namespace HozestERP.BusinessLogic.Data
{
    /// <summary>
    /// Extensions
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Determines whether record is attached
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="entity">Entity</param>
        /// <returns>Result</returns>
        public static bool IsAttached(this ObjectContext context, object entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            try
            {
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.ToString());
            }
            return false;
        }

        /// <summary>
        /// 返回当前管理人员下有多少用户人员
        /// </summary>
        /// <param name="context">HozestERPObjectContext</param>
        /// <param name="customerID">当前管理人员</param>
        /// <returns>IEnumerable<int></returns>
        public static IQueryable<int> Security(this HozestERPObjectContext context, int customerID)
        {

            var query = from cr in context.CustomerRoles
                        from c in cr.SCustomers
                        from crs in cr.SCustomerRoleStaffPrivileges
                        where c.CustomerID == customerID
                        select crs.CustomerID;

            var query1 = from cr in context.CustomerRoles
                         from d in cr.SDepartments
                         from crs in cr.SCustomers
                         join customer in context.CustomerInfoes
                         on d.DepartmentID equals customer.DepartmentID
                         where crs.CustomerID == customerID
                         select customer.CustomerID;

            var query2 = from p in context.Customers
                         where p.CustomerID == customerID
                         select p.CustomerID;


            return query.Union(query1).Union(query2);
        }

        public static string LinqToSql<T>(this IQueryable<T> query) where T : class
        {

            return (query as ObjectQuery<T>).ToTraceString();
        }
    }
}
