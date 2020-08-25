using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Reflection;

namespace HozestERP.Common.Utils
{
    public static class Enumerate
    {
        /// <summary>
        /// 获得枚举类型数据项（不包括空项）
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static IList<object> GetItems(this Type enumType)
        {
            if (!enumType.IsEnum)
                throw new InvalidOperationException();

            IList<object> list = new List<object>();

            // 获取Description特性 
            Type typeDescription = typeof(DescriptionAttribute);
            // 获取枚举字段
            FieldInfo[] fields = enumType.GetFields();
            foreach (FieldInfo field in fields)
            {
                if (!field.FieldType.IsEnum)
                    continue;

                // 获取枚举值
                int value = (int)enumType.InvokeMember(field.Name, BindingFlags.GetField, null, null, null);

                // 不包括空项
                if (value > 0)
                {
                    string text = string.Empty;
                    object[] array = field.GetCustomAttributes(typeDescription, false);

                    if (array.Length > 0) text = ((DescriptionAttribute)array[0]).Description;
                    else text = field.Name; //没有描述，直接取值

                    //添加到列表
                    list.Add(new { Value = value, Text = text });
                }
            }
            return list;
        }

        /// <summary>
        /// 获得枚举描述的值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription(Enum value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            string description = value.ToString();
            FieldInfo fieldInfo = value.GetType().GetField(description);
            //EnumDescriptionAttribute[] attributes = (EnumDescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(EnumDescriptionAttribute), false);
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes != null && attributes.Length > 0)
            {
                description = attributes[0].Description;
            }
            else
            {
                description = value.ToString();
            }
            return description;
        }
    }

    /// <summary>
    /// 用品登记类型
    /// </summary>
    public enum SuppliesInputEnum
    {
        /// <summary>
        /// 所有
        /// </summary>
        [Description(" ")]
        All = 1,

        /// <summary>
        /// 采购入库
        /// </summary>
        [Description("采购入库")]
        Purchasing = 2,

        /// <summary>
        /// 领用
        /// </summary>
        [Description("领用")]
        Recipients = 3,

        /// <summary>
        /// 借用
        /// </summary>
        [Description("借用")]
        Borrow = 4,

        /// <summary>
        /// 归还
        /// </summary>
        [Description("归还")]
        Return = 5,

        /// <summary>
        /// 报废
        /// </summary>
        [Description("报废")]
        Scrapped = 6

    }

    
    
}
