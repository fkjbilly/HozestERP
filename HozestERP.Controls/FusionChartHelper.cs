﻿
#region 引用命名空间
using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using LindonSoft.QRIIIS.Controls;

#endregion

namespace HozestERP.Controls
{

    /// <summary>
    /// FusionChart图表控件辅助工具类
    /// </summary>
    public class FusionChartHelper
    {
        #region 字段定义
        /// <summary>
        /// FusionChart图表控件的类型
        /// </summary>
        private FusionChartType _chartType;
        /// <summary>
        /// 控件的宽度
        /// </summary>
        private double _chartWidth = 500;
        /// <summary>
        /// 控件的高度
        /// </summary>
        private double _chartHeight = 300;
        /// <summary>
        /// FusionChart图表控件的颜色风格
        /// </summary>
        private FusionChartPalette _chartPalette = FusionChartPalette.Style4;
        /// <summary>
        /// 是否以圆形边缘显示( 对应chart标记的useRoundEdges属性 )
        /// </summary>
        private bool _isUseRoundEdges = true;
        /// <summary>
        /// 创建XML数据字符串
        /// </summary>
        private StringBuilder _dataXML = new StringBuilder();
        /// <summary>
        /// 标题,对应chart标记的caption属性
        /// </summary>
        private string _caption = string.Empty;
        /// <summary>
        /// 小数点位数
        /// </summary>
        private int _decimals = 0;
        /// <summary>
        /// 是否显示标签的指示线
        /// </summary>
        private bool _isShowLine = true;
        /// <summary>
        /// 是否允许旋转,默认不允许
        /// </summary>
        private bool _isRotation = false;
        /// <summary>
        /// 背景色
        /// </summary>
        private string _bgColor = string.Empty;
        /// <summary>
        /// 是否显示边框,默认显示
        /// </summary>
        private bool _isShowBorder = true;
        /// <summary>
        /// 起始角度
        /// </summary>
        private double _startingAngle = -1;
        /// <summary>
        /// 字体大小,取值范围:0-72,默认20,对应chart标记的baseFontSize属性
        /// </summary>
        private int _fontSize = 12;
        /// <summary>
        /// X轴显示的名称,对应chart标记的xAxisName属性
        /// </summary>
        private string _xName;
        /// <summary>
        /// Y轴显示的名称,对应chart标记的yAxisName属性
        /// </summary>
        private string _yName;
        /// <summary>
        /// 数字的前缀,对应chart标记的numberPrefix属性
        /// </summary>
        private string _numberPrefix;
        /// <summary>
        /// 是否在图形上显示相应的数值,对应chart标记的showValues属性
        /// </summary>
        private bool _isShowValues = false;
        /// <summary>
        /// 是否格式化数字刻度,默认格式化。对应chart标记的formatNumberScale属性
        /// </summary>
        private bool _isFormatNumberScale = true;
        /// <summary>
        /// 是否强制显示指定位数的小数。
        /// </summary>
        private bool _isForceDecimals = false;
        /// <summary>
        /// 是否格式化数字
        /// </summary>
        private bool _isFormatNumber = true;
        /// <summary>
        /// 小数点分隔符字符
        /// </summary>
        private string _decimalSeparator = ".";
        /// <summary>
        /// 千位分隔符字符
        /// </summary>
        private string _thousandSeparator = ",";
        /// <summary>
        /// 是否在数字后添加后缀"%"
        /// </summary>
        private bool _isNumberSuffix = false;
        /// <summary>
        /// Y轴显示的最小值，对应chart标记的yAxisMinValue属性
        /// </summary>
        private double _yMinValue;
        /// <summary>
        /// Y轴显示的最大值，对应chart标记的yAxisMaxValue属性
        /// </summary>
        private double _yMaxValue;
        /// <summary>
        /// 默认数字刻度
        /// </summary>
        private string _defaultNumberScale;
        /// <summary>
        /// 数字刻度值列表
        /// </summary>
        private string _numberScaleValue;
        /// <summary>
        /// 数字刻度单位列表
        /// </summary>
        private string _numberScaleUnit;
        /// <summary>
        /// 是否显示合计,默认显示
        /// </summary>
        private bool _isShowSum = true;
        /// <summary>
        /// 是否显示数据项名称,默认显示
        /// </summary>
        private bool _isShowNames = true;
        /// <summary>
        /// 设置组与数据列的映射关系
        /// </summary>
        private Dictionary<string, string> _seriesColumnMapping = new Dictionary<string, string>();
        /// <summary>
        /// 数据源
        /// </summary>
        private DataTable dt_DataSource = new DataTable();
        /// <summary>
        /// 分组
        /// </summary>
        private List<string> _group = new List<string>();
        /// <summary>
        /// 子标题
        /// </summary>
        private string _subCaption;
        /// <summary>
        /// 字体颜色
        /// </summary>
        private string _fontColor = "666666";
        /// <summary>
        /// 画布边框色
        /// </summary>
        private string _canvasBorderColor = "666666";
        #endregion

        #region 构造函数
        /// <summary>
        /// 初始化对象
        /// </summary>
        /// <param name="chartType">图表控件类型</param>
        public FusionChartHelper(FusionChartType chartType)
        {
            //初始化图表控件的类型
            _chartType = chartType;

            //初始化dt_DataSource
            CreateDataSource_DT();
        }

        #region 初始化dt_DataSource
        /// <summary>
        /// 初始化dt_DataSource
        /// </summary>
        private void CreateDataSource_DT()
        {
            DataColumn column = new DataColumn();

            //标签,对应set或category标记的 lable 属性
            column.ColumnName = "Lable";
            column.Caption = "标签名";
            column.DataType = typeof(String);
            column.Unique = true;
            dt_DataSource.Columns.Add(column);

            //第1组的值,对应set的 value 属性
            column = new DataColumn();
            column.ColumnName = "Series1";
            column.Caption = "第1组";
            column.DataType = typeof(double);
            dt_DataSource.Columns.Add(column);

            //第2组的值,对应set的 value 属性
            column = new DataColumn();
            column.ColumnName = "Series2";
            column.Caption = "第2组";
            column.DataType = typeof(double);
            dt_DataSource.Columns.Add(column);

            //第3组的值,对应set的 value 属性
            column = new DataColumn();
            column.ColumnName = "Series3";
            column.Caption = "第3组";
            column.DataType = typeof(double);
            dt_DataSource.Columns.Add(column);

            //第4组的值,对应set的 value 属性
            column = new DataColumn();
            column.ColumnName = "Series4";
            column.Caption = "第4组";
            column.DataType = typeof(double);
            dt_DataSource.Columns.Add(column);

            //第5组的值,对应set的 value 属性
            column = new DataColumn();
            column.ColumnName = "Series5";
            column.Caption = "第5组";
            column.DataType = typeof(double);
            dt_DataSource.Columns.Add(column);

            //第6组的值,对应set的 value 属性
            column = new DataColumn();
            column.ColumnName = "Series6";
            column.Caption = "第6组";
            column.DataType = typeof(double);
            dt_DataSource.Columns.Add(column);
        }
        #endregion

        #endregion

        #region 属性

        #region 标题
        /// <summary>
        /// 标题 ( 对应chart标记的caption属性 )
        /// </summary>
        public string Caption
        {
            get
            {
                return _caption;
            }
            set
            {
                _caption = value;
            }
        }
        #endregion

        #region 子标题
        /// <summary>
        /// 子标题 ( 对应chart标记的subcaption属性 )
        /// </summary>
        public string SubCaption
        {
            get
            {
                return _subCaption;
            }
            set
            {
                _subCaption = value;
            }
        }
        #endregion

        #region 字体颜色
        /// <summary>
        /// 字体颜色 ( 对应chart标记的baseFontColor属性 )
        /// </summary>
        public string FontColor
        {
            get
            {
                return _fontColor;
            }
            set
            {
                _fontColor = value;
            }
        }
        #endregion

        #region FusionChart图表控件的颜色
        /// <summary>
        /// FusionChart图表控件的颜色 ( 对应chart标记的palette属性 )
        /// </summary>
        public FusionChartPalette Palette
        {
            get
            {
                return _chartPalette;
            }
            set
            {
                _chartPalette = value;
            }
        }
        #endregion

        #region 小数点位数
        /// <summary>
        /// 小数点位数,默认不显示小数位。 ( 对应chart标记的decimals属性 )
        /// </summary>
        public int Decimals
        {
            get
            {
                return _decimals;
            }
            set
            {
                _decimals = value;
            }
        }
        #endregion

        #region 默认数字刻度单位
        /// <summary>
        /// 默认数字刻度单位,一般配合NumberScaleValue和NumberScaleUnit属性使用。
        /// ( 对应chart标记的defaultNumberScale属性 )
        /// 范例："bits"
        /// </summary>
        public string DefaultNumberScale
        {
            get
            {
                return _defaultNumberScale;
            }
            set
            {
                _defaultNumberScale = value;
            }
        }
        #endregion

        #region 数字刻度值列表
        /// <summary>
        /// 数字刻度值列表,一般配合DefaultNumberScale和NumberScaleUnit属性使用。
        /// ( 对应chart标记的numberScaleValue属性 )
        /// 范例："8,1024,1024,1024,1024"
        /// </summary>
        public string NumberScaleValue
        {
            get
            {
                return _numberScaleValue;
            }
            set
            {
                _numberScaleValue = value;
            }
        }
        #endregion

        #region 数字刻度单位列表
        /// <summary>
        /// 数字刻度单位列表,一般配合DefaultNumberScale和NumberScaleValue属性使用。
        /// ( 对应chart标记的numberScaleUnit属性 )
        /// 范例："bytes,KB,MB,GB,TB"
        /// </summary>
        public string NumberScaleUnit
        {
            get
            {
                return _numberScaleUnit;
            }
            set
            {
                _numberScaleUnit = value;
            }
        }
        #endregion

        #region 是否在数字后添加后缀"%"
        /// <summary>
        /// 是否在数字后添加后缀"%" ,默认不加后缀。
        /// </summary>
        public bool IsNumberSuffix
        {
            get
            {
                return _isNumberSuffix;
            }
            set
            {
                _isNumberSuffix = value;
            }
        }
        #endregion

        #region Y轴显示的最小值
        /// <summary>
        /// Y轴显示的最小值 ( 对应chart标记的yAxisMinValue属性 )
        /// </summary>
        public double YMinValue
        {
            get
            {
                return _yMinValue;
            }
            set
            {
                _yMinValue = value;
            }
        }
        #endregion

        #region Y轴显示的最大值
        /// <summary>
        /// Y轴显示的最大值 ( 对应chart标记的yAxisMaxValue属性 )
        /// </summary>
        public double YMaxValue
        {
            get
            {
                return _yMaxValue;
            }
            set
            {
                _yMaxValue = value;
            }
        }
        #endregion

        #region 是否强制显示小数位数
        /// <summary>
        /// 是否强制显示指定位数的小数,如果位数不足则补0。
        /// 该属性必须配合Decimals属性使用,默认不显示。
        /// ( 对应chart标记的forceDecimals属性 )。
        /// 范例：指定Decimals属性为5,则10.12显示为10.12000
        /// </summary>
        public bool IsForceDecimals
        {
            get
            {
                return _isForceDecimals;
            }
            set
            {
                _isForceDecimals = value;
            }
        }
        #endregion

        #region 是否格式化数字刻度
        /// <summary>
        /// 是否格式化数字刻度,默认格式化。 
        /// ( 对应chart标记的formatNumberScale属性 )。
        /// 1,000格式化为1K, 1,000,000格式化为1M,范例：10000格式化为10K。
        /// </summary>
        public bool IsFormatNumberScale
        {
            get
            {
                return _isFormatNumberScale;
            }
            set
            {
                _isFormatNumberScale = value;
            }
        }
        #endregion

        #region 是否格式化数字
        /// <summary>
        /// 是否格式化数字,默认格式化。 
        /// ( 对应chart标记的formatNumber属性 )。
        /// 1000格式化为1,000 , 1000000格式化为1,000,000
        /// </summary>
        public bool IsFormatNumber
        {
            get
            {
                return _isFormatNumber;
            }
            set
            {
                _isFormatNumber = value;
            }
        }
        #endregion

        #region 小数点分隔符字符
        /// <summary>
        /// 小数点分隔符字符,默认为句点 。
        /// ( 对应chart标记的decimalSeparator属性 )。
        /// </summary>
        public string DecimalSeparator
        {
            get
            {
                return _decimalSeparator;
            }
            set
            {
                _decimalSeparator = value;
            }
        }
        #endregion

        #region 千位分隔符字符
        /// <summary>
        /// 千位分隔符字符,默认为逗号 。
        /// ( 对应chart标记的thousandSeparator属性 )。
        /// </summary>
        public string ThousandSeparator
        {
            get
            {
                return _thousandSeparator;
            }
            set
            {
                _thousandSeparator = value;
            }
        }
        #endregion

        #region 控件的宽度
        /// <summary>
        /// 控件的宽度
        /// </summary>
        public double ChartWidth
        {
            get
            {
                return _chartWidth;
            }
            set
            {
                _chartWidth = value;
            }
        }
        #endregion

        #region 控件的高度
        /// <summary>
        /// 控件的高度
        /// </summary>
        public double ChartHeight
        {
            get
            {
                return _chartHeight;
            }
            set
            {
                _chartHeight = value;
            }
        }
        #endregion

        #region 是否显示标签的指示线
        /// <summary>
        /// 是否显示标签的指示线,默认显示指示线. ( 对应chart标记的enableSmartLabels属性 )
        /// </summary>
        public bool IsShowLableLine
        {
            get
            {
                return _isShowLine;
            }
            set
            {
                _isShowLine = value;
            }
        }
        #endregion

        #region 是否允许旋转
        /// <summary>
        /// 是否允许旋转,默认不允许,如果允许旋转,则设置为true. ( 对应chart标记的enableRotation属性 )
        /// </summary>
        public bool IsRotation
        {
            get
            {
                return _isRotation;
            }
            set
            {
                _isRotation = value;
            }
        }
        #endregion

        #region 背景色
        /// <summary>
        /// 背景色,设置范例: "99CCFF,FFFFFF". ( 对应chart标记的bgColor属性 )
        /// </summary>
        public string BgColor
        {
            get
            {
                return _bgColor;
            }
            set
            {
                _bgColor = value;
            }
        }
        #endregion

        #region 画布边框色
        /// <summary>
        /// 画布边框色. ( 对应chart标记的canvasBorderColor属性 )
        /// </summary>
        public string CanvasBorderColor
        {
            get
            {
                return _canvasBorderColor;
            }
            set
            {
                _canvasBorderColor = value;
            }
        }
        #endregion

        #region 是否显示边框
        /// <summary>
        /// 是否显示边框,默认显示. ( 对应chart标记的showBorder属性 )
        /// </summary>
        public bool IsShowBorder
        {
            get
            {
                return _isShowBorder;
            }
            set
            {
                _isShowBorder = value;
            }
        }
        #endregion

        #region 起始角度
        /// <summary>
        /// 起始角度. ( 对应chart标记的startingAngle属性 )
        /// </summary>
        public double StartingAngle
        {
            get
            {
                return _startingAngle;
            }
            set
            {
                _startingAngle = value;
            }
        }
        #endregion

        #region 字体大小
        /// <summary>
        /// 字体大小,取值范围:1-72,默认12 ( 对应chart标记的baseFontSize属性 )
        /// </summary>
        public int FontSize
        {
            get
            {
                return _fontSize;
            }
            set
            {
                _fontSize = value;
            }
        }
        #endregion

        #region X轴显示的名称
        /// <summary>
        /// X轴显示的名称 ( 对应chart标记的xAxisName属性 )
        /// </summary>
        public string XName
        {
            get
            {
                return _xName;
            }
            set
            {
                _xName = value;
            }
        }
        #endregion

        #region Y轴显示的名称
        /// <summary>
        /// Y轴显示的名称。注意：仅支持英文. ( 对应chart标记的yAxisName属性 )
        /// </summary>
        public string YName
        {
            get
            {
                return _yName;
            }
            set
            {
                _yName = value;
            }
        }
        #endregion

        #region 数字的前缀
        /// <summary>
        /// 数字的前缀字符 ( 对应chart标记的numberPrefix属性 )
        /// </summary>
        public string NumberPrefix
        {
            get
            {
                return _numberPrefix;
            }
            set
            {
                _numberPrefix = value;
            }
        }
        #endregion

        #region 是否在图形上显示相应的数值
        /// <summary>
        /// 是否在图形上显示相应的数值,默认不显示。 ( 对应chart标记的showValues属性 )
        /// </summary>
        public bool IsShowValues
        {
            get
            {
                return _isShowValues;
            }
            set
            {
                _isShowValues = value;
            }
        }
        #endregion

        #region 是否以圆形边缘显示
        /// <summary>
        /// 是否以圆形边缘显示 ( 对应chart标记的useRoundEdges属性 )
        /// </summary>
        public bool IsUseRoundEdges
        {
            get
            {
                return _isUseRoundEdges;
            }
            set
            {
                _isUseRoundEdges = value;
            }
        }
        #endregion

        #region 是否显示合计
        /// <summary>
        /// 是否显示合计,默认显示 ( 对应chart标记的showSum属性 )
        /// </summary>
        public bool IsShowSum
        {
            get
            {
                return _isShowSum;
            }
            set
            {
                _isShowSum = value;
            }
        }
        #endregion

        #region 是否显示数据项名称
        /// <summary>
        /// 是否显示数据项名称,默认显示 ( 对应chart标记的shownames属性 )
        /// </summary>
        public bool IsShowNames
        {
            get
            {
                return _isShowNames;
            }
            set
            {
                _isShowNames = value;
            }
        }
        #endregion

        #endregion

        #region 添加数据项

        #region 添加数据项重载方法1
        /// <summary>
        /// 添加数据项,对于多组图表，必须调用SetSeriesName设置每列的组名。
        /// </summary>
        /// <param name="name">数据项名称,即label属性</param>
        /// <param name="value">数据项的值,即value属性</param>
        public void AddItem(string name, double value)
        {
            //创建新行
            DataRow row = dt_DataSource.NewRow();

            //插入数据
            row["Lable"] = name;
            row["Series1"] = value;
            dt_DataSource.Rows.Add(row);
        }
        #endregion

        #region 添加数据项重载方法2
        /// <summary>
        /// 添加数据项,对于多组图表，必须调用SetSeriesName设置每列的组名。
        /// </summary>
        /// <param name="name">数据项名称,即label属性</param>
        /// <param name="series1Value">第1组数据项的值</param>
        /// <param name="series2Value">第2组数据项的值</param>
        public void AddItem(string name, double series1Value, double series2Value)
        {
            //创建新行
            DataRow row = dt_DataSource.NewRow();

            //插入数据
            row["Lable"] = name;
            row["Series1"] = series1Value;
            row["Series2"] = series2Value;
            dt_DataSource.Rows.Add(row);
        }
        #endregion

        #region 添加数据项重载方法3
        /// <summary>
        /// 添加数据项,对于多组图表，必须调用SetSeriesName设置每列的组名。
        /// </summary>
        /// <param name="name">数据项名称,即label属性</param>
        /// <param name="series1Value">第1组数据项的值</param>
        /// <param name="series2Value">第2组数据项的值</param>
        /// <param name="series3Value">第3组数据项的值</param>
        public void AddItem(string name, double series1Value, double series2Value, double series3Value)
        {
            //创建新行
            DataRow row = dt_DataSource.NewRow();

            //插入数据
            row["Lable"] = name;
            row["Series1"] = series1Value;
            row["Series2"] = series2Value;
            row["Series3"] = series3Value;
            dt_DataSource.Rows.Add(row);
        }
        #endregion

        #region 添加数据项重载方法4
        /// <summary>
        /// 添加数据项,对于多组图表，必须调用SetSeriesName设置每列的组名。
        /// </summary>
        /// <param name="name">数据项名称,即label属性</param>
        /// <param name="series1Value">第1组数据项的值</param>
        /// <param name="series2Value">第2组数据项的值</param>
        /// <param name="series3Value">第3组数据项的值</param>
        /// <param name="series4Value">第4组数据项的值</param>
        public void AddItem(string name, double series1Value, double series2Value, double series3Value,
            double series4Value)
        {
            //创建新行
            DataRow row = dt_DataSource.NewRow();

            //插入数据
            row["Lable"] = name;
            row["Series1"] = series1Value;
            row["Series2"] = series2Value;
            row["Series3"] = series3Value;
            row["Series4"] = series4Value;
            dt_DataSource.Rows.Add(row);
        }
        #endregion

        #region 添加数据项重载方法5
        /// <summary>
        /// 添加数据项,对于多组图表，必须调用SetSeriesName设置每列的组名。
        /// </summary>
        /// <param name="name">数据项名称,即label属性</param>
        /// <param name="series1Value">第1组数据项的值</param>
        /// <param name="series2Value">第2组数据项的值</param>
        /// <param name="series3Value">第3组数据项的值</param>
        /// <param name="series4Value">第4组数据项的值</param>
        /// <param name="series5Value">第5组数据项的值</param>
        public void AddItem(string name, double series1Value, double series2Value, double series3Value,
            double series4Value, double series5Value)
        {
            //创建新行
            DataRow row = dt_DataSource.NewRow();

            //插入数据
            row["Lable"] = name;
            row["Series1"] = series1Value;
            row["Series2"] = series2Value;
            row["Series3"] = series3Value;
            row["Series4"] = series4Value;
            row["Series5"] = series5Value;
            dt_DataSource.Rows.Add(row);
        }
        #endregion

        #region 添加数据项重载方法6
        /// <summary>
        /// 添加数据项,对于多组图表，必须调用SetSeriesName设置每列的组名。
        /// </summary>
        /// <param name="name">数据项名称,即label属性</param>
        /// <param name="series1Value">第1组数据项的值</param>
        /// <param name="series2Value">第2组数据项的值</param>
        /// <param name="series3Value">第3组数据项的值</param>
        /// <param name="series4Value">第4组数据项的值</param>
        /// <param name="series5Value">第5组数据项的值</param>
        /// <param name="series6Value">第6组数据项的值</param>
        public void AddItem(string name, double series1Value, double series2Value, double series3Value,
            double series4Value, double series5Value, double series6Value)
        {
            //创建新行
            DataRow row = dt_DataSource.NewRow();

            //插入数据
            row["Lable"] = name;
            row["Series1"] = series1Value;
            row["Series2"] = series2Value;
            row["Series3"] = series3Value;
            row["Series4"] = series4Value;
            row["Series5"] = series5Value;
            row["Series6"] = series6Value;
            dt_DataSource.Rows.Add(row);
        }
        #endregion

        #endregion

        #region 设置数据源
        /// <summary>
        /// 设置数据源,第一列为类别的标签(lable)，后面每一列对应一个组。
        /// 对于多组图表，必须调用SetSeriesName设置每列的组名。
        /// </summary>
        /// <param name="dataSource">数据源</param>
        public void SetDataSource(DataTable dataSource)
        {
            dt_DataSource = dataSource;
        }

        /// <summary>
        /// 设置数据源,默认第一列为标签(lable)，后面每一列对应一个组。
        /// 对于多组图表，必须调用SetSeriesName设置每列的组名。
        /// </summary>
        /// <param name="dataSource">数据源</param>
        public void SetDataSource(DataSet dataSource)
        {
            dt_DataSource = dataSource.Tables[0];
        }

        /// <summary>
        /// 设置数据源,默认第一列为标签(lable)，后面每一列对应一个组。
        /// 对于多组图表，必须调用SetSeriesName设置每列的组名。
        /// </summary>
        /// <param name="dataSource">数据源</param>
        public void SetDataSource(DataView dataSource)
        {
            dt_DataSource = dataSource.Table;
        }
        #endregion

        #region 设置数据源中列对应的组名
        /// <summary>
        /// 设置数据源中列对应的组名
        /// </summary>
        /// <param name="columnName">数据源中的列名</param>
        /// <param name="seriesName">显示的名称,即组名</param>
        public void SetSeriesName(string columnName, string seriesName)
        {
            //将列名与组名的映射关系添加到_seriesColumnMapping
            _seriesColumnMapping.Add(columnName, seriesName);
        }

        /// <summary>
        /// 设置数据源中列对应的组名
        /// </summary>
        /// <param name="columnIndex">数据源中的列索引</param>
        /// <param name="seriesName">显示的名称,即组名</param>
        public void SetSeriesName(int columnIndex, string seriesName)
        {
            //将列索引转换为列名
            string columnName = dt_DataSource.Columns[columnIndex].ColumnName;

            //将列名与组名的映射关系添加到_seriesColumnMapping
            _seriesColumnMapping.Add(columnName, seriesName);
        }
        #endregion

        #region 对数据源中的列进行分组
        /// <summary>
        /// 对数据源中的列进行分组
        /// </summary>
        /// <param name="columnNames">数据源中分为一组的字段名列表</param>
        public void SetGroup(params string[] columnNames)
        {
            //如果columnNames为空，则返回
            if (ValidationHelper.IsNullOrEmpty(columnNames))
            {
                return;
            }

            //将字段名列表用逗号连接,并添加到分组中
            _group.Add(StringHelper.GetCommaString(columnNames));
        }

        /// <summary>
        /// 对数据源中列进行分组
        /// </summary>
        /// <param name="columnIndexs">数据源中分为一组的字段索引列表</param>
        public void SetGroup(params int[] columnIndexs)
        {
            //如果columnIndexs为空，则返回
            if (ValidationHelper.IsNullOrEmpty(columnIndexs))
            {
                return;
            }

            //临时字符串
            StringBuilder sb = new StringBuilder();

            //将字段名列表用逗号连接
            foreach (int index in columnIndexs)
            {
                //将列索引转换为列名
                sb.AppendFormat("{0},", dt_DataSource.Columns[index].ColumnName);
            }

            //添加到分组中
            _group.Add(StringHelper.RemoveLastComma(sb));
        }
        #endregion

        #region RenderChartByDataUrl方法( 获取呈现控件的字符串,通过设置XML数据文件路径 )
        /// <summary>
        /// 获取呈现FusionChart控件的字符串( 通过设置XML数据文件路径 )
        /// </summary>
        /// <param name="chartType">图表控件类型</param>
        /// <param name="dataUrl">XML数据文件的URL地址,形式应为 @"~/路径"</param>
        /// <param name="chartWidth">图表控件的宽度</param>
        /// <param name="chartHeight">图表控件的高度</param>
        /// <param name="debugMode">是否调试模式,设为true则为调试模式</param>
        public static string RenderChartByDataUrl(FusionChartType chartType, string dataUrl, double chartWidth, double chartHeight, bool debugMode)
        {
            return RenderChart(chartType, dataUrl, "", chartWidth, chartHeight, debugMode);
        }

        /// <summary>
        /// 获取呈现FusionChart控件的字符串( 通过设置XML数据文件路径 )
        /// </summary>
        /// <param name="chartType">图表控件类型</param>
        /// <param name="dataUrl">XML数据文件的URL地址,形式应为 @"~/路径"</param>
        /// <param name="chartWidth">图表控件的宽度</param>
        /// <param name="chartHeight">图表控件的高度</param>
        public static string RenderChartByDataUrl(FusionChartType chartType, string dataUrl, double chartWidth, double chartHeight)
        {
            return RenderChart(chartType, dataUrl, "", chartWidth, chartHeight, false);
        }
        #endregion

        #region RenderChartByDataXML方法( 获取呈现控件的字符串, 通过设置XML数据字符串 )
        /// <summary>
        /// 获取呈现FusionChart控件的字符串( 通过设置XML数据字符串 )
        /// </summary>
        /// <param name="chartType">图表控件类型</param>
        /// <param name="dataXML">XML格式的数据字符串</param>
        /// <param name="chartWidth">图表控件的宽度</param>
        /// <param name="chartHeight">图表控件的高度</param>
        public static string RenderChartByDataXML(FusionChartType chartType, string dataXML, double chartWidth, double chartHeight)
        {
            return RenderChart(chartType, "", dataXML, chartWidth, chartHeight, false);
        }

        /// <summary>
        /// 获取呈现FusionChart控件的字符串( 通过设置XML数据字符串 )
        /// </summary>
        /// <param name="chartType">图表控件类型</param>
        /// <param name="dataXML">XML格式的数据字符串</param>
        /// <param name="chartWidth">图表控件的宽度</param>
        /// <param name="chartHeight">图表控件的高度</param>
        /// <param name="debugMode">是否调试模式,设为true则为调试模式</param>
        public static string RenderChartByDataXML(FusionChartType chartType, string dataXML, double chartWidth, double chartHeight, bool debugMode)
        {
            return RenderChart(chartType, "", dataXML, chartWidth, chartHeight, debugMode);
        }
        #endregion

        #region RenderChart方法( 获取呈现Chart控件的字符串 )
        /// <summary>
        /// 获取呈现Chart控件的字符串
        /// </summary>
        /// <param name="chartType">图表控件类型</param>
        /// <param name="dataUrl">XML数据文件的URL地址,形式应为 @"~/路径"</param>
        /// <param name="dataXML">XML格式的数据字符串</param>
        /// <param name="chartWidth">图表控件的宽度</param>
        /// <param name="chartHeight">图表控件的高度</param>
        /// <param name="debugMode">是否调试模式,设为true则为调试模式</param>
        private static string RenderChart(FusionChartType chartType, string dataUrl, string dataXML, double chartWidth, double chartHeight, bool debugMode)
        {
            //创建一个ID
            string id = Guid.NewGuid().ToString().Replace("-", "");
            //string id = null; 
            //   id=new Random().Next().ToString();
            //Random ra = new Random(8);
            //string id = ra.Next().ToString();

            //获取图表控件的文件路径
            string chartPath = GetChartFilePath(chartType);

            //将dataURL映射为客户端相对路径
            dataUrl = WebHelper.ResolveURL(dataUrl);

            //创建呈现Chart控件的字符串
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("<div id='Div{0}' align='center'></div>" + Environment.NewLine, id);
            builder.Append("<script type=\"text/javascript\">" + Environment.NewLine);
            builder.AppendFormat("var chart_{0} = new FusionCharts(\"{1}\", \"{0}\", \"{2}\",", id, chartPath, chartWidth);
            builder.AppendFormat("\"{0}\",\"{1}\", \"{2}\");" + Environment.NewLine, chartHeight, ConvertHelper.ToInt32(debugMode), 0);
            if (dataXML.Length == 0)
            {
                builder.AppendFormat("chart_{0}.setDataURL(\"{1}\");" + Environment.NewLine, id, dataUrl);
            }
            else
            {
                builder.AppendFormat("chart_{0}.setDataXML(\"{1}\");" + Environment.NewLine, id, dataXML);
            }
            builder.AppendFormat("chart_{0}.render(\"Div{0}\");" + Environment.NewLine, id);
            builder.Append("</script>" + Environment.NewLine);

            //返回呈现Chart控件的字符串
            return builder.ToString();
        }
        #endregion

        #region RenderSomeChartXML方法( 获取呈现Chart控件的字符串 )
        /// <summary>
        /// 获取呈现Chart控件的字符串
        /// </summary>
        /// <param name="chartType">图表控件类型</param>
        /// <param name="dataXML">XML格式的数据字符串</param>
        /// <param name="chartWidth">图表控件的宽度</param>
        /// <param name="chartHeight">图表控件的高度</param>
        /// <param name="debugMode">是否调试模式,设为true则为调试ssss模式</param>
        public static string RenderSomeChartXML(string someid, FusionChartType chartType, string dataXML, double chartWidth, double chartHeight, bool debugMode)
        {
            //创建一个ID
            //string id = StringHelper.GenerateID();
            //Random ra = new Random(8);
            //string id = ra.Next().ToString();

            //获取图表控件的文件路径
            string chartPath = GetChartFilePath(chartType);

            //创建呈现Chart控件的字符串
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("<div id='Div{0}' align='center'></div>" + Environment.NewLine, someid);
            builder.Append("<script type=\"text/javascript\">" + Environment.NewLine);
            builder.AppendFormat("var chart_{0} = new FusionCharts(\"{1}\", \"{0}\", \"{2}\",", someid, chartPath, chartWidth);
            builder.AppendFormat("\"{0}\",\"{1}\", \"{2}\");" + Environment.NewLine, chartHeight, ConvertHelper.ToInt32(debugMode), 0);
            if (dataXML.Length != 0)
            {
                builder.AppendFormat("chart_{0}.setDataXML(\"{1}\");" + Environment.NewLine, someid, dataXML);
            }
            builder.AppendFormat("chart_{0}.render(\"Div{0}\");" + Environment.NewLine, someid);
            builder.Append("</script>" + Environment.NewLine);

            //返回呈现Chart控件的字符串
            return builder.ToString();
        }
        #endregion

        #region 获取Chart控件的文件路径
        /// <summary>
        /// 获取Chart控件的文件路径
        /// </summary>
        private static string GetChartFilePath(FusionChartType chartType)
        {
            //获取FusionChart存放目录的相对路径
            string folderPath = FusionChartPath;
            if (!folderPath.EndsWith(@"/"))
            {
                folderPath = folderPath + @"/";
            }

            string path = @"~/" + folderPath + EnumHelper.GetMemberName<FusionChartType>(chartType) + ".swf";
            return WebHelper.ResolveURL(path);
        }
        #endregion

        #region 获取FusionChart图表控件存放的相对路径
        /// <summary>
        /// 获取FusionChart图表控件存放的相对路径
        /// </summary>
        public static string FusionChartPath
        {
            get
            {
                XMLReadeWrite myXmlRead = new XMLReadeWrite();
                string url = XMLReadeWrite.GetXml("FusionChartPath");
                if (ValidationHelper.IsNullOrEmpty(url))
                {
                    return @"FusionCharts";
                }
                else
                {

                    return url;
                }
            }
        }
        #endregion

        #region 创建XML数据字符串

        #region GetDataXML方法
        /// <summary>
        /// 创建XML数据字符串
        /// </summary>
        private string GetDataXML()
        {
            //创建chart标记的属性字符串
            string propertys = GetPropertys();

            //创建数据字符串的开始标记
            _dataXML.AppendFormat("<chart {0} >", propertys);

            //创建数据项
            _dataXML.Append(CreateItems());

            //创建数据字符串的结束标记
            _dataXML.Append("</chart>");

            //返回数据字符串
            return _dataXML.ToString();
        }
        #endregion

        #region 创建chart标记的属性字符串
        /// <summary>
        /// 创建chart标记的属性字符串
        /// </summary>
        private string GetPropertys()
        {
            //创建公共属性字符串
            StringBuilder sb = new StringBuilder();

            //================================== 添加属性 =====================================

            #region 基础设置

            //添加标题
            sb.AppendFormat("caption='{0}' ", _caption);

            //添加子标题
            sb.AppendFormat("subcaption='{0}' ", _subCaption);

            //设置X轴显示的名称
            sb.AppendFormat("xAxisName='{0}' ", _xName);

            //设置Y轴显示的名称
            sb.AppendFormat("yAxisName='{0}' ", _yName);

            //设置Y轴显示的最小值
            sb.AppendFormat("yAxisMinValue='{0}' ", _yMinValue);

            //设置Y轴显示的最大值
            sb.AppendFormat("yAxisMaxValue='{0}' ", _yMaxValue);

            //是否显示合计
            sb.AppendFormat("showSum='{0}' ", ConvertHelper.ToInt32(_isShowSum));

            //是否显示数据项名称
            sb.AppendFormat("shownames='{0}' ", ConvertHelper.ToInt32(_isShowNames));

            //是否在图形上显示相应的数值
            sb.AppendFormat("showValues='{0}' ", ConvertHelper.ToInt32(_isShowValues));

            //是否显示标签的指示线
            sb.AppendFormat("enableSmartLabels='{0}' ", ConvertHelper.ToInt32(_isShowLine));

            //是否允许旋转
            sb.AppendFormat("enableRotation='{0}' ", _isRotation);

            //设置起始角度
            if (_startingAngle != -1)
            {
                sb.AppendFormat("startingAngle='{0}' ", _startingAngle);
            }

            #endregion

            #region 样式设置

            //设置字体大小
            sb.AppendFormat("baseFontSize = '{0}' ", _fontSize);

            //设置字体颜色
            sb.AppendFormat("baseFontColor='{0}' ", _fontColor);

            //设置调色板
            sb.AppendFormat("palette='{0}' ", (int)_chartPalette);

            //是否以圆形边缘显示
            sb.AppendFormat("useRoundEdges='{0}' ", ConvertHelper.ToInt32(_isUseRoundEdges));

            //设置背景色
            if (!ValidationHelper.IsNullOrEmpty(_bgColor))
            {
                sb.AppendFormat("bgColor='{0}' ", _bgColor);

                //设置背景透明度
                sb.Append("bgAlpha='40,100' ");
                //设置背景比率
                sb.Append("bgRatio='0,100' ");
                //设置背景角度
                sb.Append("bgAngle='360' ");
            }

            //设置边框
            sb.AppendFormat("showBorder='{0}' ", ConvertHelper.ToInt32(_isShowBorder));

            //曲线图专用样式
            switch (_chartType)
            {
                case FusionChartType.Line:
                    SetLineStyle(sb);
                    break;
                case FusionChartType.ScrollLine2D:
                    SetLineStyle(sb);
                    break;
            }

            #endregion

            #region 格式化设置

            //是否在数字后添加后缀"%"
            if (_isNumberSuffix)
            {
                sb.Append("numberSuffix='%25' ");
            }

            //设置默认数字刻度
            sb.AppendFormat("defaultNumberScale='{0}' ", _defaultNumberScale);

            //设置数字刻度值列表
            sb.AppendFormat("numberScaleValue='{0}' ", _numberScaleValue);

            //设置数字刻度单位列表
            sb.AppendFormat("numberScaleUnit='{0}' ", _numberScaleUnit);

            //设置数字的前缀字符
            sb.AppendFormat("numberPrefix='{0}' ", _numberPrefix);

            //是否强制显示指定位数的小数
            sb.AppendFormat("forceDecimals='{0}' ", ConvertHelper.ToInt32(_isForceDecimals));

            //设置数字格式化分隔符
            sb.AppendFormat("decimalSeparator='{0}' ", _decimalSeparator);

            //设置千位分隔符字符
            sb.AppendFormat("thousandSeparator='{0}' ", _thousandSeparator);

            //是否格式化数字刻度
            sb.AppendFormat("formatNumberScale='{0}' ", ConvertHelper.ToInt32(_isFormatNumberScale));

            //是否格式化数字
            sb.AppendFormat("formatNumber='{0}' ", ConvertHelper.ToInt32(_isFormatNumber));

            //设置小数位数
            sb.AppendFormat("decimals='{0}' ", _decimals);

            #endregion

            //返回公共属性
            return sb.ToString();
        }

        #region 曲线图专用样式
        /// <summary>
        /// 曲线图专用样式
        /// </summary>
        /// <param name="sb">格式字符串</param>
        private void SetLineStyle(StringBuilder sb)
        {
            //设置交替色
            sb.AppendFormat("alternateHGridColor='#FCB541' ");
            //设置交替色的透明度
            sb.AppendFormat("alternateHGridAlpha='20' ");
            //设置DIV边框色
            sb.AppendFormat("divLineColor='FCB541' ");
            //设置DIV边框色的透明度
            sb.AppendFormat("divLineAlpha='50' ");
            //设置画布边框色
            sb.AppendFormat("canvasBorderColor='{0}' ", _canvasBorderColor);
            //设置曲线的颜色
            sb.AppendFormat(" lineColor='FCB541' ");
        }
        #endregion

        #endregion

        #region 创建数据项

        #region CreateItems方法
        /// <summary>
        /// 创建数据项
        /// </summary>
        private string CreateItems()
        {
            //如果dt_DataSource没有数据，则返回
            if (dt_DataSource.Rows.Count == 0)
            {
                return string.Empty;
            }

            //根据不同控件,创建相应的数据项字符串
            switch (_chartType)
            {
                //单组控件
                case FusionChartType.Column2D:
                    return CreateItems_SingleSeries();
                case FusionChartType.Column3D:
                    return CreateItems_SingleSeries();
                case FusionChartType.Bar2D:
                    return CreateItems_SingleSeries();
                case FusionChartType.Pie2D:
                    return CreateItems_SingleSeries();
                case FusionChartType.Pie3D:
                    return CreateItems_SingleSeries();
                case FusionChartType.Line:
                    return CreateItems_SingleSeries();
                case FusionChartType.Area2D:
                    return CreateItems_SingleSeries();
                case FusionChartType.Doughnut2D:
                    return CreateItems_SingleSeries();
                case FusionChartType.Doughnut3D:
                    return CreateItems_SingleSeries();
                //分组控件
                case FusionChartType.MSStackedColumn2D:
                    return CreateItems_Group();
                case FusionChartType.MSStackedColumn2DLineDY:
                    return CreateItems_Group();
                //多组控件
                default:
                    return CreateItems_MultiSeries();
            }
        }
        #endregion

        #region 创建单组图表的数据项
        /// <summary>
        /// 创建单组图表的数据项
        /// </summary>
        private string CreateItems_SingleSeries()
        {
            //数据项字符串
            StringBuilder dataItems = new StringBuilder();

            //遍历dt_DataSource,拼接set标记
            foreach (DataRow row in dt_DataSource.Rows)
            {
                dataItems.AppendFormat("<set label='{0}' value='{1}' />", row[0].ToString(), row[1].ToString());
            }

            //返回数据项字符串
            return dataItems.ToString();
        }
        #endregion

        #region 创建多组图表的数据项
        /// <summary>
        /// 创建多组图表的数据项
        /// </summary>
        private string CreateItems_MultiSeries()
        {
            //数据项字符串
            StringBuilder dataItems = new StringBuilder();

            //添加类别标记
            dataItems.Append(CreateCategoryTag());

            //====================================== 创建组标记 =======================================
            //遍历_seriesColumnMapping,拼接每组的dataset标记
            foreach (KeyValuePair<string, string> keyValue in _seriesColumnMapping)
            {
                //创建组开始标记
                dataItems.AppendFormat("<dataset seriesName='{0}' >", keyValue.Value);
                //创建组的项
                foreach (DataRow row in dt_DataSource.Rows)
                {
                    dataItems.AppendFormat("<set value='{0}' />", row[keyValue.Key].ToString());
                }
                //创建组结束标记
                dataItems.Append("</dataset>");
            }

            //返回数据项字符串
            return dataItems.ToString();
        }
        #endregion

        #region 创建分组图表的数据项
        /// <summary>
        /// 创建分组图表的数据项
        /// </summary>
        private string CreateItems_Group()
        {
            //对分组剩下的列进行处理
            ProcessGroup();

            //数据项字符串
            StringBuilder dataItems = new StringBuilder();

            //添加类别标记
            dataItems.Append(CreateCategoryTag());

            //====================================== 创建分组标记 =======================================
            //遍历分组
            foreach (string item in _group)
            {
                //添加分组开始标记
                dataItems.Append("<dataset>");

                //遍历本分组的所有列
                string[] columns = item.Split(',');
                foreach (string columnName in columns)
                {
                    //创建组开始标记
                    dataItems.AppendFormat("<dataset seriesName='{0}' >", _seriesColumnMapping[columnName]);
                    //创建组的项
                    foreach (DataRow row in dt_DataSource.Rows)
                    {
                        dataItems.AppendFormat("<set value='{0}' />", row[columnName].ToString());
                    }
                    //创建组结束标记
                    dataItems.Append("</dataset>");
                }

                //添加分组结束标记
                dataItems.Append("</dataset>");
            }

            //返回数据项字符串
            return dataItems.ToString();
        }
        #endregion

        #region 创建类别标记
        /// <summary>
        /// 创建类别标记
        /// </summary>
        private string CreateCategoryTag()
        {
            //===================================== 创建类别标记 ======================================
            StringBuilder categoryTag = new StringBuilder();

            //创建类别开始标记
            categoryTag.Append("<categories>");
            //创建类别的项
            foreach (DataRow row in dt_DataSource.Rows)
            {
                categoryTag.AppendFormat("<category label='{0}' />", row[0].ToString());
            }
            //创建类别结束标记
            categoryTag.Append("</categories>");

            //返回类别标记
            return categoryTag.ToString();
        }
        #endregion

        #region 对分组剩下的列进行处理
        /// <summary>
        /// 对分组剩下的列进行处理
        /// </summary>
        private void ProcessGroup()
        {
            //=============== 将设置分组剩下的列添加到_group ===========================
            //获取已分组的列名数组
            List<string> groupColumns = new List<string>();
            foreach (string groupStr in _group)
            {
                string[] columns = groupStr.Split(',');
                foreach (string column in columns)
                {
                    groupColumns.Add(column);
                }
            }

            //保存剩下的列名
            List<string> remainColumns = new List<string>();

            //获取用逗号分隔的所有有效列的字符串
            foreach (DataColumn column in dt_DataSource.Columns)
            {
                //对标签列跳过
                if (column.ColumnName == dt_DataSource.Columns[0].ColumnName)
                {
                    continue;
                }

                //如果第一行无值,则说明后面的列都无效
                if (ValidationHelper.IsNullOrEmpty(dt_DataSource.Rows[0][column]))
                {
                    break;
                }

                //如果还未分组，则添加到remainColumns
                if (!groupColumns.Contains(column.ColumnName))
                {
                    remainColumns.Add(column.ColumnName);
                }
            }

            //添加到_group
            if (remainColumns.Count != 0)
            {
                _group.Add(StringHelper.GetCommaString(remainColumns.ToArray()));
            }
        }
        #endregion

        #endregion

        #endregion

        #region 重写ToString
        /// <summary>
        /// 获取呈现FusionChart控件的字符串
        /// </summary>
        public override string ToString()
        {
            return ToString(false);
        }

        /// <summary>
        /// 获取呈现FusionChart控件的字符串
        /// </summary>
        /// <param name="debugMode">是否调试模式,设为true则为调试模式</param>
        public string ToString(bool debugMode)
        {
            //获取XML数据
            string dataXML = GetDataXML();

            return ToString(dataXML, debugMode);
        }

        /// <summary>
        /// 获取呈现FusionChart控件的字符串
        /// </summary>
        /// <param name="dataXML">XML格式的数据字符串</param>
        public string ToString(string dataXML)
        {
            return ToString(dataXML, false);
        }

        /// <summary>
        /// 获取呈现FusionChart控件的字符串
        /// </summary>
        /// <param name="dataXML">XML格式的数据字符串</param>
        /// <param name="debugMode">是否调试模式,设为true则为调试模式</param>
        public string ToString(string dataXML, bool debugMode)
        {
            return RenderChartByDataXML(_chartType, dataXML, _chartWidth, _chartHeight, debugMode);
        }
        #endregion

        #region FusionChart图表控件的类型
        /// <summary>
        /// FusionChart图表控件的类型
        /// </summary>
        public enum FusionChartType
        {
            /// <summary>
            /// 2D区域图
            /// </summary>
            Area2D,
            /// <summary>
            /// 2D横向柱状图
            /// </summary>
            Bar2D,
            /// <summary>
            /// 泡状图
            /// </summary>
            Bubble,
            /// <summary>
            /// 2D柱状图
            /// </summary>
            Column2D,
            /// <summary>
            /// 3D柱状图
            /// </summary>
            Column3D,
            /// <summary>
            /// 2D环状图
            /// </summary>
            Doughnut2D,
            /// <summary>
            /// 3D环状图
            /// </summary>
            Doughnut3D,
            /// <summary>
            /// 2D曲线图
            /// </summary>
            Line,
            /// <summary>
            /// 2D区域图
            /// </summary>
            MSArea,
            /// <summary>
            /// 2D横向柱状图
            /// </summary>
            MSBar2D,
            /// <summary>
            /// 3D横向柱状图
            /// </summary>
            MSBar3D,
            /// <summary>
            /// 2D柱状图
            /// </summary>
            MSColumn2D,
            /// <summary>
            /// 3D柱状图
            /// </summary>
            MSColumn3D,
            /// <summary>
            /// 3D ( 柱状 + 曲线 ) 图
            /// </summary>
            MSColumn3DLineDY,
            /// <summary>
            /// 3D ( 柱状 + 曲线 ) 图
            /// </summary>
            MSColumnLine3D,
            /// <summary>
            /// 由各种形状组合而成的2D图
            /// </summary>
            MSCombi2D,
            /// <summary>
            /// 由各种形状组合而成的2D图
            /// </summary>
            MSCombiDY2D,
            /// <summary>
            /// 2D曲线图
            /// </summary>
            MSLine,
            /// <summary>
            /// 2D柱状图
            /// </summary>
            MSStackedColumn2D,
            /// <summary>
            /// 2D ( 柱状 + 曲线 ) 图
            /// </summary>
            MSStackedColumn2DLineDY,
            /// <summary>
            /// 2D饼图
            /// </summary>
            Pie2D,
            /// <summary>
            /// 3D饼图
            /// </summary>
            Pie3D,
            /// <summary>
            /// 点状图
            /// </summary>
            Scatter,
            /// <summary>
            /// 2D区域图( 带滚动条 )
            /// </summary>
            ScrollArea2D,
            /// <summary>
            /// 2D柱状图( 带滚动条 )
            /// </summary>
            ScrollColumn2D,
            /// <summary>
            /// 由各种形状组合而成的图形( 带滚动条 )
            /// </summary>
            ScrollCombi2D,
            /// <summary>
            /// 由各种形状组合而成的图形( 带滚动条 )
            /// </summary>
            ScrollCombiDY2D,
            /// <summary>
            /// 2D曲线图( 带滚动条 )
            /// </summary>
            ScrollLine2D,
            /// <summary>
            /// 2D柱状图( 带滚动条 )
            /// </summary>
            ScrollStackedColumn2D,
            /// <summary>
            /// SSGrid
            /// </summary>
            SSGrid,
            /// <summary>
            /// 2D区域图
            /// </summary>
            StackedArea2D,
            /// <summary>
            /// 2D横向柱状图
            /// </summary>
            StackedBar2D,
            /// <summary>
            /// 3D横向柱状图
            /// </summary>
            StackedBar3D,
            /// <summary>
            /// 2D柱状图
            /// </summary>
            StackedColumn2D,
            /// <summary>
            /// 3D柱状图
            /// </summary>
            StackedColumn3D,
            /// <summary>
            /// 3D ( 柱状 + 曲线 ) 图
            /// </summary>
            StackedColumn3DLineDY
        }
        #endregion

        #region FusionChart图表控件的颜色风格
        /// <summary>
        /// FusionChart图表控件的颜色风格
        /// </summary>
        public enum FusionChartPalette
        {
            /// <summary>
            /// 浅灰色风格
            /// </summary>
            Style1 = 1,
            /// <summary>
            /// 深灰色风格
            /// </summary>
            Style2 = 2,
            /// <summary>
            /// 浅蓝色风格
            /// </summary>
            Style3 = 3,
            /// <summary>
            /// 浅棕色风格
            /// </summary>
            Style4 = 4,
            /// <summary>
            /// 浅红色风格
            /// </summary>
            Style5 = 5
        }
        #endregion
    }
}
