namespace 商品条码检验报告
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    internal class Quatity
    {
        public DataTable getHistoryTesting()
        {
            DataTable table;
            string sqlstring = string.Format("select serialnumber 编号,barcodenumber 条码号,samplename 样品名称,specification 规格型号,brand 品牌商标,printformat 印刷载体,customername 企业名称,left(real_symbollevel,3) 符号等级,convert(varchar(10),testingdate,112) 检验日期 from jy_quatity_service order by testingdate", new object[0]);
            try
            {
                table = SqlHelper.ExecSql(DatabaseConn.DbZwb, sqlstring);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return table;
        }

        public DataTable getHistoryTesting(string qymc)
        {
            DataTable table;
            SqlParameter param = new SqlParameter("@qymc", qymc);
            string sqlstring = string.Format("select serialnumber 编号,barcodenumber 条码号,samplename 样品名称,specification 规格型号,brand 品牌商标,printformat 印刷载体,customername 企业名称,left(real_symbollevel,3) 符号等级,convert(varchar(10),testingdate,112) 检验日期 from jy_quatity_service where customername like '%" + qymc + "%' order by testingdate", new object[0]);
            try
            {
                table = SqlHelper.ExecSql(DatabaseConn.DbZwb, sqlstring, param);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return table;
        }

        public DataTable getHistoryTesting(DateTime qsrq, DateTime jsrq)
        {
            DataTable table;
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@qsrq", qsrq), new SqlParameter("@jsrq", jsrq) };
            string sqlstring = string.Format("select serialnumber 编号,barcodenumber 条码号,samplename 样品名称,specification 规格型号,brand 品牌商标,printformat 印刷载体,customername 企业名称,left(real_symbollevel,3) 符号等级,convert(varchar(10),testingdate,112) 检验日期 from jy_quatity_service where testingdate between @qsrq and @jsrq order by testingdate", new object[0]);
            try
            {
                table = SqlHelper.ExecSql(DatabaseConn.DbZwb, sqlstring, param);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return table;
        }

        public void insertTestingData(BarcodeSample sample, TestResult technic, TestResult reality)
        {
            SqlParameter[] param = new SqlParameter[] { 
                new SqlParameter("@serialnumber", sample.SerialNumber), new SqlParameter("@barcodenumber", sample.BarCodeNumber), new SqlParameter("@samplename", sample.SampleName), new SqlParameter("@barcodetype", reality.BarcodeType), new SqlParameter("@customername", sample.CustomerName), new SqlParameter("@contactman", sample.CustomerContactPersoner), new SqlParameter("@contactphone", sample.CustomerContactNumber), new SqlParameter("@contactaddress", sample.CustomerContactAddress), new SqlParameter("@bussinesstype", sample.BussinessType), new SqlParameter("@agencycode", sample.RegisterPoint), new SqlParameter("@printformat", sample.PrintFormat), new SqlParameter("@specification", sample.Specification), new SqlParameter("@brand", sample.Brand), new SqlParameter("@tsymbollevel", technic.SymbolLevel), new SqlParameter("@tdecodingdata", technic.DecodingData), new SqlParameter("@tleftblank", technic.LeftBlank),
                new SqlParameter("@trightblank", technic.RightBlank), new SqlParameter("@tbarheight", technic.BarHeight), new SqlParameter("@tsizeofz", technic.SizeOfZ), new SqlParameter("@testingdate", reality.TestDate), new SqlParameter("@rsymbollevel", reality.SymbolLevel), new SqlParameter("@rdecodingdata", reality.DecodingData), new SqlParameter("@rleftblank", reality.LeftBlank), new SqlParameter("@rrightblank", reality.RightBlank), new SqlParameter("@rbarheight", reality.BarHeight), new SqlParameter("@rsizeofz", reality.SizeOfZ), new SqlParameter("@tisvalidcode", technic.IsValidBarcode), new SqlParameter("@risvalidcode", reality.IsValidBarcode)
            };
            string sqlstring = string.Format("insert into jy_quatity_service(SerialNumber,BarCodeNumber,SampleName,BarCodeType,CustomerName,ContactMan,ContactPhone,ContactAddress,BussinessType,AgencyCode,PrintFormat,Specification,Brand,Tech_SymbolLevel,Tech_DecodingData,Tech_LeftBlank,Tech_RightBlank,Tech_BarHeight,Tech_SizeOfZ,Tech_IsValidCode,Real_SymbolLevel,Real_DecodingData,Real_LeftBlank,Real_RightBlank,Real_BarHeight,Real_SizeOfZ,Real_IsValidCode,TestingDate,ReportDate) values(@SerialNumber,@BarCodeNumber,@SampleName,@BarCodeType,@CustomerName,@ContactMan,@ContactPhone,@ContactAddress,@BussinessType,@AgencyCode,@PrintFormat,@Specification,@Brand,@TSymbolLevel,@TDecodingData,@TLeftBlank,@TRightBlank,@TBarHeight,@TSizeOfZ,@tisvalidcode,@RSymbolLevel,@RDecodingData,@RLeftBlank,@RRightBlank,@RBarHeight,@RSizeOfZ,@risvalidcode,@TestingDate,GetDate())", new object[0]);
            try
            {
                SqlHelper.ExecNonQuery(DatabaseConn.DbZwb, sqlstring, param);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}

