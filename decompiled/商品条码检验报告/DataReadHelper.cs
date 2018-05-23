namespace 商品条码检验报告
{
    using Microsoft.Office.Interop.Excel;
    using System;
    using System.Collections;
    using System.Data;
    using System.IO;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Text;

    internal class DataReadHelper
    {
        public static System.Data.DataTable ExcelRead(string excelPath)
        {
            System.Data.DataTable table2;
            Application o = new ApplicationClass();
            object updateLinks = Missing.Value;
            Workbook workbook = null;
            System.Data.DataTable table = new System.Data.DataTable();
            bool flag = true;
            try
            {
                if (o == null)
                {
                    return null;
                }
                workbook = o.Workbooks.Open(excelPath, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks);
                Worksheet worksheet = (Worksheet) workbook.Worksheets.get_Item(1);
                if (worksheet == null)
                {
                    return null;
                }
                int count = worksheet.UsedRange.Rows.Count;
                int num2 = worksheet.UsedRange.Columns.Count;
                for (int i = 0; i < num2; i++)
                {
                    string name = "column" + i;
                    if (flag)
                    {
                        string str2 = ((Microsoft.Office.Interop.Excel.Range) worksheet.Cells[1, i + 1]).Text.ToString();
                        if (!string.IsNullOrEmpty(str2))
                        {
                            name = str2;
                        }
                    }
                    while (table.Columns.Contains(name))
                    {
                        name = name + "_1";
                    }
                    table.Columns.Add(new DataColumn(name, typeof(string)));
                }
                int num4 = flag ? 2 : 1;
                for (int j = num4; j <= count; j++)
                {
                    DataRow row = table.NewRow();
                    for (int k = 1; k <= num2; k++)
                    {
                        Microsoft.Office.Interop.Excel.Range range = (Microsoft.Office.Interop.Excel.Range) worksheet.Cells[j, k];
                        row[k - 1] = (range.Value2 == null) ? "" : range.Text.ToString();
                    }
                    table.Rows.Add(row);
                }
                table2 = table;
            }
            catch (Exception exception)
            {
                throw new Exception("读取Excel文件错误！" + exception.Message);
            }
            finally
            {
                workbook.Close(false, updateLinks, updateLinks);
                Marshal.ReleaseComObject(workbook);
                workbook = null;
                o.Workbooks.Close();
                o.Quit();
                Marshal.ReleaseComObject(o);
                o = null;
            }
            return table2;
        }

        public static Hashtable TextRead(string txtPath)
        {
            Hashtable hashtable2;
            Hashtable hashtable = new Hashtable();
            try
            {
                string str;
                StreamReader reader = new StreamReader(txtPath, Encoding.Default);
                while ((str = reader.ReadLine()) != null)
                {
                    if (str.Contains(":"))
                    {
                        string[] strArray = str.Split(new char[] { ':' });
                        hashtable.Add(strArray[0].Trim(), strArray[1].Trim());
                    }
                }
                reader.Dispose();
                hashtable2 = hashtable;
            }
            catch (Exception exception)
            {
                throw new Exception("读取文本文件错误!" + exception.Message);
            }
            return hashtable2;
        }
    }
}

