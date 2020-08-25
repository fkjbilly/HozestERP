using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace HozestERP.Web.Controls
{
    public class GridViewStyle
    {

        public static bool CanRowClickColor = true;

        public static ArrayList FixCol = new ArrayList();

        public static void SetGridViewStyle(GridView myGrid)
        {
            // 设置表格线
            myGrid.Attributes.Add("bordercolor", "#ababab");

            SetRowStyle(myGrid);
            SetGridHeadStyle(myGrid);
        }

        #region public static void SetRowStyle(GridView myGrid)
        /// <summary>
        /// 设置行样式
        /// </summary>
        /// <param name="myGrid"></param>
        public static void SetRowStyle(GridView myGrid)
        {
            CheckBox myChk = null;
            if (CanRowClickColor)
            {
                for (int i = 0; i < myGrid.Rows.Count; i++)
                {

                    myChk = (CheckBox)myGrid.Rows[i].Cells[0].FindControl("chkSelected");
                    myGrid.Rows[i].Style.Add("height", "5px");

                    if (myGrid.EditIndex != i)
                    {
                        if (myChk != null)
                        {
                            if (myChk.Visible)
                            {
                                myGrid.Rows[i].Attributes.Add("onclick", "RowColorIn('" + myChk.ClientID + "',this);");
                                myChk.Attributes.Add("onclick", "SelectChange(this);");
                            }
                        }
                        //else
                        //{
                        //    myGrid.Rows[i].Attributes.Add("onclick", "RowColorIn('',this);");
                        //}
                        if (myGrid.Rows[i].RowState == DataControlRowState.Alternate)
                        {
                            if (myGrid.Rows[i].Attributes["OldColor"] == null)
                            {
                                myGrid.Rows[i].Attributes.Add("OldColor", "#F7F7F7");
                            }
                        }
                        else
                        {
                            if (myGrid.Rows[i].Attributes["OldColor"] == null)
                            {
                                myGrid.Rows[i].Attributes.Add("OldColor", "#FFFFFF");
                            }
                        }
                    }
                    // 设定固定列
                    if (FixCol.Count > 0)
                    {
                        for (int j = 0; j < FixCol.Count; j++)
                        {
                            //myGrid.Rows[i].Cells[Convert.ToInt32(FixCol[j])].Style.Add("left", "expression(this.offsetParent.scrollLeft)");
                            //myGrid.Rows[i].Cells[Convert.ToInt32(FixCol[j])].Style.Add("z-index", "1000");
                            myGrid.Rows[i].Cells[Convert.ToInt32(FixCol[j])].CssClass = "fixCol";
                        }
                    }

                }
            }
        }
        #endregion

        #region public static void SetGridHeadStyle(GridView myGrid)
        /// <summary>
        /// 设置表头样式
        /// </summary>
        /// <param name="myGrid"></param>
        public static void SetGridHeadStyle(GridView myGrid)
        {
            if (myGrid.HeaderRow == null)
            {
                return;
            }
            myGrid.Style.Add("word-break", "keep-all");
            myGrid.Style.Add("word-wrap", "normal");

            myGrid.HeaderRow.Style.Add("height", "22px");
            // 表头处理
            int CellsCount = myGrid.HeaderRow.Cells.Count;
            for (int j = 0; j < CellsCount; j++)
            {

                myGrid.HeaderRow.Cells[j].Attributes.Add("class", "GridHeard");
                myGrid.HeaderRow.Cells[j].Attributes.Add("onmouseover", "SetHeadCellsCss('Over',this);");
                myGrid.HeaderRow.Cells[j].Attributes.Add("onmouseout", "SetHeadCellsCss('out',this);");
                myGrid.HeaderRow.Cells[j].Attributes.Add("noWrap", "noWrap");
                // 设定固定列
                if (FixCol.Contains(j))
                {
                    myGrid.HeaderRow.Cells[j].Style.Add("left", "expression(this.offsetParent.scrollLeft)");
                    myGrid.HeaderRow.Cells[j].Style.Add("z-index", "1000");
                }
                if (myGrid.Columns.Count <= j)
                {
                    continue;
                }
            }
        }
        #endregion
    }
}