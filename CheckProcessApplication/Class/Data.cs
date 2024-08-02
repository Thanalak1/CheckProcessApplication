using CheckProcessApplication;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObject
{
    public class JobType : Base
    {
        public JobType(string TableName = "")
        {
            if (TableName == "") TableName = this.GetType().Name;
            drSearch = base.GetSchema(TableName);
        }

        internal int JobTypes
        {
            get { return Convert.ToInt16(_dr["JobType"]); }
            set { _dr["JobType"]  = value; }
        }
        internal string JobName
        {
            get { return _dr["JobName"].ToString(); }
            set { _dr["JobName"] = value; }
        }

    }
}
