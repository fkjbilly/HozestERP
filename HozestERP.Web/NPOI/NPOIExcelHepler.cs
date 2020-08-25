using NPOI.HPSF;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace HozestERP.Web.NPOIHelper
{
    /// <summary>
    /// 利用NPOI导出Excel
    /// </summary>
    public class NPOIExcelHepler
    {
        /// <summary>
        /// DataTable导出到Excel文件  
        /// </summary>
        /// <param name="strFileName">保存位置</param>
        /// <param name="db">源DataTable</param>

        public static void ExportExcel(string filePath, string fileName, DataTable db)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            string sheetName = "sheet1";
            ISheet sheet = workbook.CreateSheet(sheetName);
            HSSFRow rowHeader = (HSSFRow)sheet.CreateRow(0);//创建标题列
            var ColumnsCount = 0;
            foreach (DataColumn column in db.Columns)//填充列头信息
            {
                rowHeader.CreateCell(ColumnsCount).SetCellValue(column.ColumnName);
                ColumnsCount++;
            }
            //填充内容
            for (int i = 0; i < db.Rows.Count; i++)
            {
                HSSFRow dataRows = (HSSFRow)sheet.CreateRow(i + 1);
                for (int j = 0; j < db.Columns.Count; j++)
                {
                    dataRows.CreateCell(j).SetCellValue(db.Rows[i][j].ToString());
                }
            }
            for (int i = 0; i <= db.Columns.Count; i++)//自动调整列宽
            {
                sheet.AutoSizeColumn(i, true);
            }
            MemoryStream ms = new MemoryStream();
            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;
            workbook = null;
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fileName, Encoding.UTF8) + ".xls");
            HttpContext.Current.Response.BinaryWrite(ms.ToArray());
            HttpContext.Current.Response.End();
            GC.Collect();
        }
    }
}