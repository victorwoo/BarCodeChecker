namespace 商品条码检验报告
{
    using System;

    public class BarcodeSample
    {
        private string _serialNumber;
        private string _barCodeNumber;
        private string _sampleName;
        private string _printFormat = "";
        private string _barcodeType = "";
        private string _customerName;
        private string _customerContactPersoner;
        private string _customerContactNumber;
        private string _customerContactAddress;
        private string _bussinessType = "";
        private string _registerPoint = "";
        private string _specification = "/";
        private string _brand = "/";

        public string SerialNumber
        {
            get
            {
                return this._serialNumber;
            }
            set
            {
                this._serialNumber = value;
            }
        }

        public string BarCodeNumber
        {
            get
            {
                return this._barCodeNumber;
            }
            set
            {
                this._barCodeNumber = value;
            }
        }

        public string SampleName
        {
            get
            {
                return this._sampleName;
            }
            set
            {
                this._sampleName = value;
            }
        }

        public string PrintFormat
        {
            get
            {
                return this._printFormat;
            }
            set
            {
                this._printFormat = value;
            }
        }

        public string BarcodeType
        {
            get
            {
                return this._barcodeType;
            }
            set
            {
                this._barcodeType = value;
            }
        }

        public string CustomerName
        {
            get
            {
                return this._customerName;
            }
            set
            {
                this._customerName = value;
            }
        }

        public string CustomerContactPersoner
        {
            get
            {
                return this._customerContactPersoner;
            }
            set
            {
                this._customerContactPersoner = value;
            }
        }

        public string CustomerContactNumber
        {
            get
            {
                return this._customerContactNumber;
            }
            set
            {
                this._customerContactNumber = value;
            }
        }

        public string CustomerContactAddress
        {
            get
            {
                return this._customerContactAddress;
            }
            set
            {
                this._customerContactAddress = value;
            }
        }

        public string BussinessType
        {
            get
            {
                return this._bussinessType;
            }
            set
            {
                this._bussinessType = value;
            }
        }

        public string RegisterPoint
        {
            get
            {
                return this._registerPoint;
            }
            set
            {
                this._registerPoint = value;
            }
        }

        public string Specification
        {
            get
            {
                return this._specification;
            }
            set
            {
                this._specification = value;
            }
        }

        public string Brand
        {
            get
            {
                return this._brand;
            }
            set
            {
                this._brand = value;
            }
        }
    }
}

