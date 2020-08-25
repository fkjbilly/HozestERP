using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;

namespace HozestERP.BusinessLogic.ExportImport
{
    public class ExcelBase
    {
        private Application app = null;
        private Workbook workbook = null;
        private Worksheet worksheet = null;
        private Range workSheet_range = null;

        public ExcelBase()
        {
            createDoc();
        }


        public void SaveDoc(string paramPath)
        {
            workbook.Saved = true;
            workbook.SaveAs(paramPath);
        }

        public void createDoc()
        {
            try
            { 

                app = new Application();

                if (app == null)
                {
                    Console.Write("无法创建Excel对象，可能您的电脑未安装Excel"); 
                    return;
                }   

                app.Visible = false;
                workbook = app.Workbooks.Add(1);
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1]; 
            }
            catch (Exception e)
            {
                Console.Write("Error");
            }
            finally
            {
            }
        }

        public void CloseDoc()
        {
            try
            {
                this.workbook.Close(true, Type.Missing, Type.Missing);
                this.workbook = null;

                this.app.Quit();
                this.app = null;

            }
            catch (Exception e)
            {
                Console.Write("Error");
            }
            finally
            {
            }
        }

        public void InsertData(ExcelBE be)
        {
            worksheet.Cells[be.Row, be.Col] = be.Text;
            workSheet_range = worksheet.get_Range(be.StartCell, be.EndCell);
            workSheet_range.MergeCells = be.IsMerge;
            workSheet_range.Interior.Color = GetColorValue(be.InteriorColor);
            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
            workSheet_range.ColumnWidth = be.Size;
            workSheet_range.Font.Color = string.IsNullOrEmpty(be.FontColor) ? System.Drawing.Color.White.ToArgb() : System.Drawing.Color.Black.ToArgb();
            workSheet_range.NumberFormat = be.Formart;
            workSheet_range.Font.Bold = be.Bold; //字体加粗
            workSheet_range.Font.Size = be.Size;
            if (be.HorizontalAlignment)//是否水平居中
                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            workSheet_range.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
        }

        private int GetColorValue(string interiorColor)
        {
            switch (interiorColor)
            {
                case "YELLOW":
                    return System.Drawing.Color.Yellow.ToArgb();
                case "GRAY":
                    return System.Drawing.Color.Gray.ToArgb();
                case "GAINSBORO":
                    return System.Drawing.Color.Gainsboro.ToArgb();
                case "Turquoise":
                    return System.Drawing.Color.Turquoise.ToArgb();
                case "PeachPuff":
                    return System.Drawing.Color.PeachPuff.ToArgb();

                default:
                    return System.Drawing.Color.White.ToArgb();
            }
        }
    }
}
