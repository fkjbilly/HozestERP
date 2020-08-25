using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CRM.Common;

namespace CRM.BusinessLogic.Media
{
    /// <summary>
    /// Service interface
    /// </summary>
    public partial interface IMisPlayService
    {
        /// <summary>
        /// Get an object by id
        /// </summary>
        /// <param name="id">identifier id</param>
        /// <returns>the new object</returns>
        Mis_Play GetById(int id);

        /// <summary>
        /// Insert a new record
        /// </summary>
        /// <param name="musicName">music name</param>
        /// <param name="musicUrl">music url</param>
        /// <returns>the new object</returns>
        Mis_Play Insert(string musicName, string musicUrl);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="id">identifier id</param>
        /// <param name="musicName">music name</param>
        /// <param name="musicUrl">music url</param>
        /// <returns>the new object instance</returns>
        Mis_Play Update(int id, string musicName, string musicUrl);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="id">identifier id</param>
        void Delete(int id);

        /// <summary>
        ///  Gets all records
        /// </summary>
        /// <param name="pageIndex">start index</param>
        /// <param name="pageSize">size of per page</param>
        /// <returns>Setting collection</returns>
        PagedList<Mis_Play> GetAll(int pageIndex, int pageSize);
    }
}
