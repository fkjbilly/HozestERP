using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Web;
using System.Threading;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.ModuleManagement;

namespace HozestERP.BusinessLogic
{
    public partial class EventContext
    {
        #region Nested
        /// <summary>
        /// Customer event handler
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Arguments</param>
        public delegate void CustomerEventHandler(object sender, CustomerEventArgs e);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void ModuleEventHandler(object sender, ModuleEventArgs e);

        #endregion

        #region Ctor

        /// <summary>
        /// Creates a new instance of the EventContext class
        /// </summary>
        private EventContext()
        {

        }

        #endregion

        #region Methods

        /// <summary>
        /// Raise customer created event
        /// </summary>
        /// <param name="source">Source</param>
        /// <param name="e">Arguments</param>
        public virtual void OnCustomerCreated(object source, CustomerEventArgs e)
        {
            if (this.CustomerCreated != null)
                this.CustomerCreated(source, e);
        }
        /// <summary>
        /// Raise customer updated event
        /// </summary>
        /// <param name="source">Source</param>
        /// <param name="e">Arguments</param>
        public virtual void OnCustomerUpdated(object source, CustomerEventArgs e)
        {
            if (this.CustomerUpdated != null)
                this.CustomerUpdated(source, e);
        }

        public virtual void OnModuleUpdated(object source, ModuleEventArgs e)
        {
            if (this.ModuleUpdated != null)
            {
                this.ModuleUpdated(source, e);
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets an instance of the EventContext, which can be used to retrieve information about current context.
        /// </summary>
        public static EventContext Current
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    object data = Thread.GetData(Thread.GetNamedDataSlot("CRMEventContext"));
                    if (data != null)
                    {
                        return (EventContext)data;
                    }
                    EventContext context = new EventContext();
                    Thread.SetData(Thread.GetNamedDataSlot("CRMEventContext"), context);
                    return context;
                }
                if (HttpContext.Current.Items["CRMEventContext"] == null)
                {
                    EventContext context = new EventContext();
                    HttpContext.Current.Items.Add("CRMEventContext", context);
                    return context;
                }
                return (EventContext)HttpContext.Current.Items["CRMEventContext"];
            }
        }

        /// <summary>
        /// Customer created event
        /// </summary>
        public event CustomerEventHandler CustomerCreated;
        /// <summary>
        /// Customer updated event
        /// </summary>
        public event CustomerEventHandler CustomerUpdated;

        /// <summary>
        /// 
        /// </summary>
        public event ModuleEventHandler ModuleUpdated;
        #endregion
    }
}
