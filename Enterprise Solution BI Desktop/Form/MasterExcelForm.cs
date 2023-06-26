using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace EnterpriseSolutionBIDesktop
{   
    public partial class MasterExcelForm : FormBase
    {
        private string _dbname;
        private string _tableNameMaster;
        private string _tableNameMasterFilter;
        
        #region File

        private List<string> files = new List<string>
        {
            "Account 帐户 SAMFAM.xls",
            "Analysis Codes 分析编码 SAISAC.xls",
            "Bank 银行 SAMFFM.xls",
            "BOM 物料清单 PRPEMS.xls",
            "Charge Type 特别费用 PUPREI.xls",
            "Color 颜色 SAMFCO.xls",
            "Commodity 海关商品 CUSTCO .xls",
            "Container 货柜 SAMFCT.xls",
            "Currency 货币 SAMFCU.xls",
            "Customer Group 客户组别 SAGCCG .xls",
            "Customer 客户 SAMFCM.xls",
            "Cycle Count Detail 周期盘点 ICCYCEIM.xls",
            "Department 部门 SAISDP.xls",
            "Entries BOM 物料清单 PRPEMS.xls",
            "Entries Purchase Requisition 采购申请 PUPOREI.xls",
            "File Type 文件类型 SAMFFT.xls",
            "Fixed Assets Card 固定资产 GBFACD .xls",
            "Fixed Assets Group 固定资产组别 GBFAIG.xls",
            "Inventory Receipt 进仓单 ICIMSRIM.xls",
            "Item Group 物料组别 SAGCIG.xls",
            "Item 物料主档 SAMFIM.xls",
            "Location 仓库 SAMFLM.xls",
            "Master Data Account 帐户 SAMFAM.xls",
            "Master Data Analysis Codes 分析编码 SAISAC.xls",
            "Master Data Bank 银行 SAMFFM.xls",
            "Master Data Charge Type 特别费用 PUPREI.xls",
            "Master Data Color 颜色 SAMFCO.xls",
            "Master Data Commodity 海关商品 CUSTCO .xls",
            "Master Data Container 货柜 SAMFCT.xls",
            "Master Data Currency 货币 SAMFCU.xls",
            "Master Data Customer Group 客户组别 SAGCCG .xls",
            "Master Data Customer 客户 SAMFCM.xls",
            "Master Data Cycle Count Detail 周期盘点 ICCYCEIM.xls",
            "Master Data Department 部门 SAISDP.xls",
            "Master Data File Type 文件类型 SAMFFT.xls",
            "Master Data Fixed Assets Card 固定资产 GBFACD .xls",
            "Master Data Fixed Assets Group 固定资产组别 GBFAIG.xls",
            "Master Data Item Group 物料组别 SAGCIG.xls",
            "Master Data Item 物料主档 SAMFIM.xls",
            "Master Data Location 仓库 SAMFLM.xls",
            "Master Data Mold 模具 PRPEMO.xls",
            "Master Data Move Type 进出类别 SAINIT SAINRT SAINAT.xls",
            "Master Data Operation 工序 PRPNOP.xls",
            "Master Data Package Type 包装类别 SLPRPT.xls",
            "Master Data Panel 配件 SAMFPN.xls",
            "Master Data Pay Term 付款条款 SAMFPM.xls",
            "Master Data Port Code 港口 SAMFPT.xls",
            "Master Data Position 职位 SAUTPS.xls",
            "Master Data Reason Code 损坏原因 SAMFRC.xls",
            "Master Data Series Code 序号编码 SASCSCIM.xls",
            "Master Data Ship Via Code 运输方式 SAMFSV.xls",
            "Master Data Shipment Terms 送货条款 SAMFST.xls",
            "Master Data Style 款式 SAMFSY.xls",
            "Master Data Unit of Measure 单位 SAMFUM.xls",
            "Master Data Vendor Group 供应商组别 SAGCVG.xls",
            "Master Data Vendor Price 供应商价目表 PUPRVCIM.xls",
            "Master Data Vendor 供应商 SAMFVM.xls",
            "Master Data Voucher Type 凭证类别 SAINVT.xls",
            "Master Data Work Centre 车间 PRPNWC.xls",
            "Mold 模具 PRPEMO.xls",
            "Move Type 进出类别 SAINIT SAINRT SAINAT.xls",
            "Operation 工序 PRPNOP.xls",
            "Package Type 包装类别 SLPRPT.xls",
            "Panel 配件 SAMFPN.xls",
            "Pay Term 付款条款 SAMFPM.xls",
            "Port Code 港口 SAMFPT.xls",
            "Position 职位 SAUTPS.xls",
            "Purchase Requisition 采购申请 PUPOREI.xls",
            "Reason Code 损坏原因 SAMFRC.xls",
            "Series Code 序号编码 SASCSCIM.xls",
            "Ship Via Code 运输方式 SAMFSV.xls",
            "Shipment Terms 送货条款 SAMFST.xls",
            "Style 款式 SAMFSY.xls",
            "Unit of Measure 单位 SAMFUM.xls",
            "Vendor Group 供应商组别 SAGCVG.xls",
            "Vendor Pric 供应商价目表 PUPRVCIM.xls",
            "Vendor 供应商 SAMFVM.xls",
            "Voucher Type 凭证类别 SAINVT.xls",
            "Work Centre 车间 PRPNWC.xls"
        };

        #endregion

        private DataTable _table;

        public MasterExcelForm()
        {
            InitializeComponent();
            gridMaster.ColumnAdded += dataGrid_ColumnAdded;
        }

        void dataGrid_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            if (e.Column.CellType == typeof(DataGridViewImageCell))
                grid.Columns.Remove(e.Column);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            gridMaster.DataSource = bindingSourceMaster;
            gridMaster.AutoGenerateColumns = true;

            gridMaster.CellContentDoubleClick += GridMaster_CellContentDoubleClick;
            gridMaster.CellDoubleClick += GridMaster_CellContentDoubleClick;

            GetData();
          
            gridMaster.AutoResizeColumns();
            this.Description = string.Format("Master [{0}]","Excel");
        }

        private void GridMaster_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bindingSourceMaster.Current == null)
                return;

            var table = bindingSourceMaster.DataSource as DataTable;

            int cnt = table.AsEnumerable().Count(row => Convert.ToBoolean(row["Check"]) == true);
            if (cnt == 0)
            {
                MessageBox.Show("Please select data first");
                return;
            }

            string path = string.Empty;
            FolderBrowserDialog df = new FolderBrowserDialog();
            df.Description = "Excel File";
            df.ShowNewFolderButton = true;
            if (df.ShowDialog() == DialogResult.OK)
                path = df.SelectedPath;
            if (string.IsNullOrWhiteSpace(path))
                return;

            List<string> exportList = table.AsEnumerable().Where(row => Convert.ToBoolean(row["Check"]) == true).Select(row => Convert.ToString(row["File"])).ToList();
            foreach (string file in exportList)
            {
                string fullName = "ConfigurationManager.Excel." + file;
                Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(fullName);
                FileStream fileStream = new FileStream(Path.Combine(path, file), FileMode.CreateNew);
                for (int i = 0; i < stream.Length; i++)
                    fileStream.WriteByte((byte)stream.ReadByte());
                fileStream.Close();
            }
        }

        private void GetData()
        {
            _table = new DataTable("Query");
            _table.Columns.Add("Check", typeof(bool));
            _table.Columns.Add("FunctionCode", typeof(string));
            _table.Columns.Add("Description", typeof(string));
            _table.Columns.Add("File", typeof(string));
            foreach (string file in files)
            {
                string xls = file.Substring(0, file.Length - 4);
                string functionCode = ProcessFunctionCode(xls);
                DataRow row = _table.NewRow();
                row["Check"] = false;
                row["FunctionCode"] = functionCode;
                row["Description"] = xls.Replace(functionCode, string.Empty).Trim();
                row["File"] = file;
                _table.Rows.Add(row);
            }

            bindingSourceMaster.DataSource = _table;
        }

        private string ProcessFunctionCode(string file)
        {
            string word = Reverse(file.Trim());
            StringBuilder builder = new StringBuilder();
            foreach (char ch in word)
            {
                if (!Char.IsWhiteSpace(ch))
                {
                    builder.Append(ch.ToString());
                }
                else
                    break;
            }

            return Reverse(builder.ToString());
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
