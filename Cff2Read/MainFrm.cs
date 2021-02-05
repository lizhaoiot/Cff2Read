using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cff2Read
{
    #region Form
    public partial class MainFrm : Form
    {
        #region 定量
        //排版方案
        DataTable dt1 = new DataTable();
        //大版方案
        DataTable dt2 = new DataTable();
        //小版方案
        DataTable dt3 = new DataTable();
        #endregion

        #region 变量

        #endregion

        #region 初始化
        public MainFrm()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //在初始化的datatable中创建列
            CreateTable();
        }

        #endregion

        #region 窗体事件
        //打开刀版文件
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            List<Model.Cff2> cff2 = new List<Model.Cff2>();
            //打开文件夹路径
            folderBrowserDialog1.ShowDialog();
            Model.GetDieList dielist = new Model.GetDieList();
            cff2= dielist.GetFile(folderBrowserDialog1.SelectedPath);
            foreach (Model.Cff2 s in cff2)
            {
                #region 拼版方案信息
                DataRow dr1 = dt1.NewRow();
                dr1["拼版方案编号"] = s.Id;
                dr1["名称"] = s.Name;
                dr1["创建者"] = s.Createperson;
                dr1["创建时间"] = s.Createtime;
                dataGridView3.DataSource = dt1;
                dt1.Rows.Add(dr1);
                #endregion

                #region 印张信息
                DataRow dr2 = dt2.NewRow();
                dr2["印张编号"] = s.Yid;
                dr2["拼版方案编号"] = s.Pid;
                dr2["上机长"] = s.Sjlength;
                dr2["上机宽"] = s.Sjwidth;
                dr2["模数"] = s.Modulus;
                dataGridView1.DataSource = dt2;
                dt2.Rows.Add(dr2);
                #endregion

                #region 小版信息
                DataRow dr3 = dt3.NewRow();
                dr3["小版编号"] = s.Xid;
                dr3["印张编号"] = s.Fid;
                dr3["拼版方案编号"] = s.Gid;
                dr3["小版名称"] = s.Xname;
                dataGridView2.DataSource = dt3;
                dt3.Rows.Add(dr3);
                #endregion
            }
        }
        #endregion

        #region 方法

        #endregion

        #region 建立表格
        private void CreateTable()
        {
            DataColumn dc1 = null;
            dc1 = dt1.Columns.Add("拼版方案编号", Type.GetType("System.String"));
            dc1 = dt1.Columns.Add("名称", Type.GetType("System.String"));
            dc1 = dt1.Columns.Add("创建时间", Type.GetType("System.String"));
            dc1 = dt1.Columns.Add("创建者", Type.GetType("System.String"));

            DataColumn dc2 = null;
            dc2 = dt2.Columns.Add("印张编号", Type.GetType("System.String"));
            dc2 = dt2.Columns.Add("拼版方案编号", Type.GetType("System.String"));
            dc2 = dt2.Columns.Add("上机长", Type.GetType("System.String"));
            dc2 = dt2.Columns.Add("上机宽", Type.GetType("System.String"));
            dc2 = dt2.Columns.Add("模数", Type.GetType("System.String"));

            DataColumn dc3 = null;
            dc3 = dt3.Columns.Add("小版编号", Type.GetType("System.String"));
            dc3 = dt3.Columns.Add("印张编号", Type.GetType("System.String"));
            dc3 = dt3.Columns.Add("拼版方案编号", Type.GetType("System.String"));
            dc3 = dt3.Columns.Add("小版名称", Type.GetType("System.String"));
        }
        #endregion
    }
    #endregion

}
