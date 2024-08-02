using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckProcessApplication.Class
{
    public class UI
    {
        public DataTable NewListDataTable
        {
            get
            {
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("ID", typeof(int));
                dataTable.Columns.Add("Name", typeof(string));
                return dataTable;
            }
        }

    }
}
