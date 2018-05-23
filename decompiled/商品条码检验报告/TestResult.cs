namespace 商品条码检验报告
{
    using System;

    internal class TestResult
    {
        private string _symbolLevel = "";
        private string _decodingData = "";
        private string _leftBlank = "";
        private string _rightBlank = "";
        private int _barHeight = 0;
        private string _sizeOfZ = "";
        private string _isValidBarcode = "";
        private DateTime _testDate;
        private string _barcodeType = "";

        public string SymbolLevel
        {
            get => 
                this._symbolLevel;
            set => 
                (this._symbolLevel = value);
        }

        public string DecodingData
        {
            get => 
                this._decodingData.Replace(" ", "");
            set => 
                (this._decodingData = value);
        }

        public string LeftBlank
        {
            get => 
                this._leftBlank;
            set => 
                (this._leftBlank = value);
        }

        public string RightBlank
        {
            get => 
                this._rightBlank;
            set => 
                (this._rightBlank = value);
        }

        public int BarHeight
        {
            get => 
                this._barHeight;
            set => 
                (this._barHeight = value);
        }

        public string SizeOfZ
        {
            get => 
                this._sizeOfZ;
            set => 
                (this._sizeOfZ = value);
        }

        public string IsValidBarcode
        {
            get => 
                this._isValidBarcode;
            set => 
                (this._isValidBarcode = value);
        }

        public DateTime TestDate
        {
            get => 
                this._testDate;
            set => 
                (this._testDate = value);
        }

        public string BarcodeType
        {
            get => 
                this._barcodeType;
            set => 
                (this._barcodeType = value);
        }
    }
}

