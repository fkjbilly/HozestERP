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
    public partial interface IMisSettingService
    {
        /// <summary>
        /// Get an object by id
        /// </summary>
        /// <param name="id">identifier id</param>
        /// <returns>the new object</returns>
        Mis_Setting GetById(int id);

        /// <summary>
        /// Insert a new record
        /// </summary>
        /// <param name="name">setting's name</param>
        /// <param name="value">setting's value</param>
        /// <param name="memo">setting's memo</param>
        /// <returns>the new object</returns>
        Mis_Setting Insert(string name, string value, string memo);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="id">identifier id</param>
        /// <param name="name">setting's name</param>
        /// <param name="value">setting's value</param>
        /// <param name="memo">setting's memo</param>
        /// <returns>the new object instance</returns>
        Mis_Setting Update(int id, string name, string value, string memo);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="id">identifier id</param>
        void Delete(int id);

        /// <summary>
        ///  Gets all settings
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns>Setting collection</returns>
        PagedList<Mis_Setting> GetAllSettings(string Name, int pageIndex, int pageSize);

         /// <summary>
        /// Inserts/updates a param
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <param name="description">The description</param>
        /// <returns>Setting</returns>
        Mis_Setting SetParam(string name, string value, string memo);
    }
}
