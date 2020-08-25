using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace HozestERP.BusinessLogic.ExportImport
{
    public partial class CSVHelper : IDisposable
    {
        private string _path = "";
        public CSVHelper(string path)
        {
            this._path = path;
        }

        public DataTable dt1(string tablename)
        {
            string pCsvPath = _path;
            String line;
            String[] split = null;
            DataTable table = new DataTable();
            DataRow row = null;
            StreamReader sr = new StreamReader(pCsvPath, System.Text.Encoding.Default);
            //创建与数据源对应的数据列
            line = sr.ReadLine();
            if (string.IsNullOrEmpty(line))
            {
                return null;
            }
            split = line.Split(',');
            for (int i = 0; i < split.Length; i++)
            {
                table.Columns.Add(split[i], System.Type.GetType("System.String"));
            }
            //将数据填入数据表
            while (!string.IsNullOrEmpty(line = sr.ReadLine()))
            {
                row = table.NewRow();
                //split = line.Split(',');

                string[][] asplit = read_csv(line);

                if (table.Columns.Count >= asplit[0].Length)
                {
                    for (int p = 0; p < asplit[0].Length; p++)
                    {
                        row[p] = asplit[0][p];
                    }
                    table.Rows.Add(row);
                    continue;
                }
                if (table.Columns.Count < asplit.Length)
                {
                    for (int p = 0; p < table.Columns.Count; p++)
                    {
                        row[p] = asplit[p];
                    }
                    table.Rows.Add(row);
                    continue;
                }
            }
            sr.Close();
            //显示数据
            //this.dataGridView1.DataSource = table.DefaultView;
            return table;
        }
        public string[][] read_csv(string text)
        {
            if (text == null)
            {
                return null;
            }
            var text_array = new List<string[]>();
            var line = new List<string>();
            var field = new StringBuilder();
            //是否在双引号内
            bool in_quata = false;
            //字段是否开始
            bool field_start = true;
            for (int i = 0; i < text.Length; i++)
            {
                char ch = text[i];
                if (in_quata)
                {
                    //如果已经处于双引号范围内
                    if (ch == '\"')
                    {
                        //如果是两个引号，则当成一个普通的引号处理
                        if (i < text.Length - 1 && text[i + 1] == '\"')
                        {
                            field.Append('\"');
                            i++;
                        }
                        else
                        {
                            //否则退出引号范围
                            in_quata = false;
                        }
                    }
                    else //双引号范围内的任何字符（除了双引号）都当成普通字符
                    {
                        field.Append(ch);
                    }
                }
                else
                {
                    switch (ch)
                    {
                        #region

                        case ',': //新的字段开始
                            line.Add(field.ToString());
                            field.Remove(0, field.Length);
                            field_start = true;
                            break;
                        case '\"': //引号的处理
                            if (field_start)
                            {
                                in_quata = true;
                            }
                            else
                            {
                                field.Append(ch);
                            }
                            break;
                        case '\r': //新的记录行开始
                            if (field.Length > 0 || field_start)
                            {
                                line.Add(field.ToString());
                                field.Remove(0, field.Length);
                            }
                            text_array.Add(line.ToArray());
                            line.Clear();
                            field_start = true;
                            //在 window 环境下，\r\n通常是成对出现，所以要跳过
                            if (i < text.Length - 1 && text[i + 1] == '\n')
                            {
                                i++;
                            }
                            break;
                        default:
                            field_start = false;
                            field.Append(ch);
                            break;

                        #endregion
                    }
                }
            }
            //文件结束
            if (field.Length > 0 || field_start)
            {
                line.Add(field.ToString());
            }
            if (line.Count > 0)
            {
                text_array.Add(line.ToArray());
            }
            return text_array.ToArray();
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            this._path = string.Empty;
        }
    }
}
