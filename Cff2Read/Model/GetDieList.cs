using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Cff2Read.Model
{
    public  class GetDieList
    {
        bool um = false;
        bool ui = false;
        double unit;
        private string[] fileLines = null;

        private List<string> fileLines1 = new List<string>();
        public List<Cff2> FileList { get; set; }
        public GetDieList()
        {
            this.FileList = new List<Cff2>();
        }
        public List<Cff2> GetFile(string path)
        {
            List<Cff2> cff2 = new List<Cff2>();
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] fil = dir.GetFiles();
            DirectoryInfo[] dii = dir.GetDirectories();
            foreach (FileInfo f in fil)
            {
                if (f.Extension == ".cf2")
                {
                    Cff2 cf = new Cff2();
                    //分析数据
                    string[] fileLines = System.IO.File.ReadAllLines(f.FullName);
                    int k = 0;
                    for (int i = 0; i < fileLines.Length; i++)
                    {
                        //初始化筛选有用的信息
                        if (fileLines[i] == "END")
                        {
                            k = k + 1;
                            if (k == 2)
                            {
                                for (int j = 0; j < i; j++)
                                {
                                    fileLines1.Add(fileLines[j]);
                                }
                            }
                        }
                    }      
                }
                for (int p = 0; p < fileLines1.Count; p++)
                {
                    cff2.Add(AnalysisCff2(fileLines1));
                }
            }
            //获取子文件夹内的文件列表，递归遍历
            foreach (DirectoryInfo d in dii)
            {
                GetFile(d.FullName);
            }
            return cff2;
        }
        private Cff2 AnalysisCff2(List<string> strs)
        {
            #region 解析数据
            List<string> s1 = new List<string>();
            string s2 = string.Empty;
            string s3 = string.Empty;
            string s4 = string.Empty;
            string s5 = string.Empty;
            List<string> s6 = new List<string>();
            int i = 0;
            //匹配小版数量
            Regex r1 = new Regex("C,");
            //匹配名字
            Regex r2 = new Regex("MAIN,");
            //匹配创建时间,创建者
            Regex r3 = new Regex(",Created by");
            //匹配上机长,上机宽,版芯长度,版芯宽度,模数
            Regex r4 = new Regex("LL,");
            Regex r5 = new Regex("UR,");
            //匹配小版印刷的高度、宽度
            Regex r6 = new Regex("L,");
            //匹配类型
            Regex r7 = new Regex("UM");
            Regex r8 = new Regex("UI");
            foreach (string s in strs)
            {
                Match m1 = r1.Match(s);
                Match m2 = r2.Match(s);
                Match m3 = r3.Match(s);
                Match m4 = r4.Match(s);
                Match m5 = r5.Match(s);
                Match m6 = r6.Match(s, 0, 2);
                if (m1.Success)
                {
                    s1.Add(s);
                }
                if (m2.Success)
                {
                    s2 = s;
                }
                if (m3.Success)
                {
                    s3 = s;
                }
                if (m4.Success)
                {
                    s4 = s;
                }
                if (m5.Success)
                {
                    s5 = s;
                }
                if (m6.Success)
                {
                    s6.Add(s);
                }
                um = r7.IsMatch(s);
            }
            #endregion

            Cff2 cf = new Cff2();

            #region 拼版方案赋值
            cf.Id = Guid.NewGuid().ToString();
            cf.Name = s2;
            string[] strArray1 = s3.Split(new string[] { " on" }, StringSplitOptions.RemoveEmptyEntries);
            cf.Createtime = strArray1[1];
            string[] strArray2 = s3.Split(new string[] { " by", " on" }, StringSplitOptions.RemoveEmptyEntries);
            cf.Createperson = strArray2[1];
            #endregion

            #region 印张赋值
            cf.Yid = Guid.NewGuid().ToString();
            cf.Pid = cf.Id;
            cf.Sjlength = Readlongth(s6);
            cf.Sjwidth = ReadWidth(s6);
            cf.Modulus = s1.Count.ToString();
            #endregion

            #region 小版刀线赋值
            cf.Xid = Guid.NewGuid().ToString();
            cf.Fid = cf.Pid;
            cf.Gid = cf.Id;
            string[] strArray3 = s1[0].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            cf.Xname = strArray3[1];
            #endregion

            return cf;
        }
        private void ReadCff2()
        {
            try
            {
               
            }
            catch (IOException e)
            {
               
            }
        }

        private string ReadWidth(List<string> ss)
        {
            string Width=string.Empty;
            if (um==true)
            {
                unit = 1;
            }
            else
            {
                unit = 25.4;
            }
            for (int i = 0; i < ss.Count; i++)
            {
              string[] s = ss[i].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
              if (s[0] == "L" && s[2] == "97")
              {
                  double sx = double.Parse(s[4]);
                  double ex = double.Parse(s[6]);
                  if ((ex - sx) > 0)
                  {
                      Width =Convert.ToString( (ex - sx) * unit);
                        break;
                  }
              }
            }
            return Width;
        }
        private string Readlongth(List<string> ss)
        {
            string Height=string.Empty;
            if (um == true)
            {
                unit = 1;
            }
            else
            {
                unit = 25.4;
            }
            for (int i = 0; i < ss.Count; i++)
            {
              string[] s = ss[i].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
              if (s[0] == "L" && s[2] == "97")
              {
                  double sy = double.Parse(s[5]);
                  double ey = double.Parse(s[7]);
                  if ((ey - sy) > 0)
                  {
                      Height =Convert.ToString((ey - sy) * unit);
                        break;
                    }
              }
            }
            return Height;
        }
    }
}
