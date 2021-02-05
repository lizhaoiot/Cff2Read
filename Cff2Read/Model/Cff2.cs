using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Cff2Read.Model
{
    public  class Cff2
    {
        #region 拼版方案
        //拼版方案ID
        private string _id = string.Empty;
        //名称
        private string _name = string.Empty;
        //创建时间
        private string _createtime = string.Empty;
        //创建者
        private string _createperson = string.Empty;

        public string Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public string Createtime
        {
            get
            {
                return _createtime;
            }

            set
            {
                _createtime = value;
            }
        }

        public string Createperson
        {
            get
            {
                return _createperson;
            }

            set
            {
                _createperson = value;
            }
        }


        #endregion

        #region 印张
        //印张ID
        private string _yid = string.Empty;
        //PID 拼版方案检索号
        private string _pid = string.Empty;
        //刀版编号
        private string _dbid = string.Empty;
        //版芯长度
        private string _bxlength = string.Empty;
        //版芯宽度
        private string _bxwidth = string.Empty;
        //上机长
        private string _sjlength = string.Empty;
        //上机宽
        private string _sjwidth = string.Empty;
        //模数
        private string _modulus = string.Empty;
        public string Yid
        {
            get
            {
                return _yid;
            }

            set
            {
                _yid = value;
            }
        }

        public string Pid
        {
            get
            {
                return _pid;
            }

            set
            {
                _pid = value;
            }
        }

        public string Dbid
        {
            get
            {
                return _dbid;
            }

            set
            {
                _dbid = value;
            }
        }

        public string Bxlength
        {
            get
            {
                return _bxlength;
            }

            set
            {
                _bxlength = value;
            }
        }

        public string Bxwidth
        {
            get
            {
                return _bxwidth;
            }

            set
            {
                _bxwidth = value;
            }
        }

        public string Sjlength
        {
            get
            {
                return _sjlength;
            }

            set
            {
                _sjlength = value;
            }
        }

        public string Sjwidth
        {
            get
            {
                return _sjwidth;
            }

            set
            {
                _sjwidth = value;
            }
        }

        public string Modulus
        {
            get
            {
                return _modulus;
            }

            set
            {
                _modulus = value;
            }
        }

        #endregion

        #region 小版刀线
        //小版编号
        private string _xid = string.Empty;
        //印张编号
        private string _fid = string.Empty;
        //拼版方案编号
        private string _gid = string.Empty;
        //宽度
        private string _width = string.Empty;
        //长度
        private string _length = string.Empty;
        //小版名称
        private string _xname = string.Empty;
        public string Xid
        {
            get
            {
                return _xid;
            }

            set
            {
                _xid = value;
            }
        }

        public string Fid
        {
            get
            {
                return _fid;
            }

            set
            {
                _fid = value;
            }
        }

        public string Gid
        {
            get
            {
                return _gid;
            }

            set
            {
                _gid = value;
            }
        }

        public string Width
        {
            get
            {
                return _width;
            }

            set
            {
                _width = value;
            }
        }

        public string Length
        {
            get
            {
                return _length;
            }

            set
            {
                _length = value;
            }
        }

        public string Xname
        {
            get
            {
                return _xname;
            }

            set
            {
                _xname = value;
            }
        }
        #endregion
    }
}
