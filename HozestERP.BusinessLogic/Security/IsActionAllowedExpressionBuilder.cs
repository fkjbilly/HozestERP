
using System;
using System.CodeDom;
using System.Web.Compilation;
using System.Web.UI;

using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.CustomerManagement;

namespace HozestERP.BusinessLogic.Security
{
    [ExpressionPrefix("CRMIsActionAllowed")]
    public partial class IsActionAllowedExpressionBuilder : ExpressionBuilder
    {
        #region Methods
        /// <summary>
        /// Gets value
        /// </summary>
        /// <param name="systemKeyword">system Keyword</param>
        /// <returns>is action allowed(true 允许 false 不允许)</returns>
        public static bool GetVal(string systemKeyword)
        {
            bool isAllowed = false;
            try
            {
                isAllowed = IoC.Resolve<IACLService>().IsActionAllowed(systemKeyword);
            }
            catch
            {
            }
            return isAllowed;
        }
        /// <summary>
        /// Returns a code expression to evaluate during page execution.
        /// </summary>
        /// <param name="entry">The property name of the object.</param>
        /// <param name="parsedData">The parsed value of the expression.</param>
        /// <param name="context">Properties for the control or page.</param>
        /// <returns>A CodeExpression that invokes a method.</returns>
        public override CodeExpression GetCodeExpression(BoundPropertyEntry entry, object parsedData, ExpressionBuilderContext context)
        {
            var lsr = (CustomerAction)parsedData;
            var ex = new CodeMethodInvokeExpression(
                new CodeTypeReferenceExpression(base.GetType()),
                "GetVal",
                new CodePrimitiveExpression(lsr.SystemKeyword)
            );
            return ex;
        }

        /// <summary>
        /// Returns an object that represents the parsed expression. 
        /// </summary>
        /// <param name="expression">The value of the declarative expression.</param>
        /// <param name="propertyType">The type of the property bound to by the expression.</param>
        /// <param name="context">Contextual information for the evaluation of the expression.</param>
        /// <returns>An Object that represents the parsed expression</returns>
        public override object ParseExpression(string expression, Type propertyType, ExpressionBuilderContext context)
        {
            var lsr = new CustomerAction();
            lsr.SystemKeyword = expression;
            return lsr;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Returns a value indicating whether the current ExpressionBuilder object supports no-compile pages. 
        /// </summary>
        public override bool SupportsEvaluate
        {
            get
            {
                return true;
            }
        }
        #endregion
    }


    [ExpressionPrefix("CRMIsActionAllowedContrary")]
    public partial class IsActionAllowedContraryExpressionBuilder : ExpressionBuilder
    {
        #region Methods
        /// <summary>
        /// Gets value
        /// </summary>
        /// <param name="systemKeyword">system Keyword</param>
        /// <returns>is action allowed(true 允许 false 不允许)</returns>
        public static bool GetVal(string systemKeyword)
        {
            bool isAllowed = false;
            try
            {
                isAllowed = IoC.Resolve<IACLService>().IsActionAllowed(systemKeyword);
            }
            catch
            {
            }
            return !isAllowed;
        }
        /// <summary>
        /// Returns a code expression to evaluate during page execution.
        /// </summary>
        /// <param name="entry">The property name of the object.</param>
        /// <param name="parsedData">The parsed value of the expression.</param>
        /// <param name="context">Properties for the control or page.</param>
        /// <returns>A CodeExpression that invokes a method.</returns>
        public override CodeExpression GetCodeExpression(BoundPropertyEntry entry, object parsedData, ExpressionBuilderContext context)
        {
            var lsr = (CustomerAction)parsedData;
            var ex = new CodeMethodInvokeExpression(
                new CodeTypeReferenceExpression(base.GetType()),
                "GetVal",
                new CodePrimitiveExpression(lsr.SystemKeyword)
            );
            return ex;
        }

        /// <summary>
        /// Returns an object that represents the parsed expression. 
        /// </summary>
        /// <param name="expression">The value of the declarative expression.</param>
        /// <param name="propertyType">The type of the property bound to by the expression.</param>
        /// <param name="context">Contextual information for the evaluation of the expression.</param>
        /// <returns>An Object that represents the parsed expression</returns>
        public override object ParseExpression(string expression, Type propertyType, ExpressionBuilderContext context)
        {
            var lsr = new CustomerAction();
            lsr.SystemKeyword = expression;
            return lsr;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Returns a value indicating whether the current ExpressionBuilder object supports no-compile pages. 
        /// </summary>
        public override bool SupportsEvaluate
        {
            get
            {
                return true;
            }
        }
        #endregion
    }
}
