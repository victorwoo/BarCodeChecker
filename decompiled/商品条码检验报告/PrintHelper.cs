namespace 商品条码检验报告
{
    using GoldPrinter;
    using System;
    using System.Configuration;
    using System.IO;

    internal class PrintHelper
    {
        public static void Print(PrintType printType, BarcodeSample sample, TestResult technic, TestResult reality)
        {
            ExcelAccess access = new ExcelAccess();
            string path = ConfigurationManager.AppSettings["template"];
            string fullPath = Path.GetFullPath(path);
            access.Open(fullPath);
            access.IsVisibledExcel = true;
            access.FormCaption = "商品条码符号检测数据";
            switch (printType)
            {
                case PrintType.Print:
                    access.Print();
                    break;

                case PrintType.PrintView:
                    access.PrintPreview();
                    break;

                default:
                    access.Close();
                    break;
            }
            access.Close();
        }

        public static bool Save(BarcodeSample sample, TestResult technic, TestResult reality, string saveFilename, string templateFile)
        {
            ExcelAccess access = new ExcelAccess();
            access.Open(templateFile);
            access.IsVisibledExcel = true;
            access.FormCaption = "商品条码符号检测数据";
            bool flag = false;
            access.SetCellText(2, "F", sample.SerialNumber);
            access.SetCellText(3, "F", sample.CustomerName);
            access.SetCellText(3, "Z", reality.BarcodeType);
            access.SetCellText(4, "F", sample.SampleName);
            access.SetCellText(4, "Z", sample.PrintFormat);
            access.SetCellText(6, "F", sample.CustomerContactPersoner);
            access.SetCellText(6, "N", sample.CustomerContactNumber);
            access.SetCellText(0x11, "J", "代办点" + sample.RegisterPoint);
            access.SetCellText(10, "J", technic.SymbolLevel);
            access.SetCellText(11, "J", technic.DecodingData);
            access.SetCellText(12, "J", "≥" + technic.LeftBlank);
            access.SetCellText(13, "J", "≥" + technic.RightBlank);
            access.SetCellText(14, "J", "≥" + technic.BarHeight.ToString());
            access.SetCellText(15, "J", technic.SizeOfZ);
            access.SetCellText(0x10, "J", technic.IsValidBarcode);
            access.SetCellText(10, "V", reality.SymbolLevel);
            access.SetCellText(11, "V", reality.DecodingData);
            access.SetCellText(12, "V", reality.LeftBlank);
            access.SetCellText(13, "V", reality.RightBlank);
            access.SetCellText(14, "V", reality.BarHeight.ToString());
            access.SetCellText(15, "V", reality.SizeOfZ.ToString());
            access.SetCellText(0x10, "V", reality.IsValidBarcode);
            access.SetCellText(6, "Z", reality.TestDate.ToString("yyyyMMdd"));
            if (access.SaveAs(saveFilename, false))
            {
                flag = true;
            }
            access.Close();
            return flag;
        }
    }
}

