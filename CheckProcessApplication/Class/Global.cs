using System;
using System.Data;
using System.Windows.Forms;

namespace CheckProcessApplication.Class
{
    public static class Global
    {
        private static UI _UI;

        public static UI UI
        {
            get
            {
                if (_UI == null)
                    _UI = new UI();
                return _UI;
            }
        }

        public static void SetComboList(ComboBox comboBox, DataTable dataTable, string cID = "ID", string cName = "Name")
        {
            comboBox.DataSource = dataTable;
            comboBox.ValueMember = cID;
            comboBox.DisplayMember = cName;
        }

        private static void AddNewRowToComboDatasource(DataTable dt, DataRow dataRow, ref string cID)
        {
            if (cID == "")
            {
                cID = "ID";
                dt.Columns.Add(cID, typeof(int));
                for (int i = 1; i <= dt.Rows.Count; i++)
                {
                    dt.Rows[i - 1][cID] = i;
                }
            }

            if (dataRow != null)
            {
                dataRow[cID] = 0;
                DataRow[] array = dt.Select($"{cID} = 0");
                if (array.Length == 0)
                {
                    dt.Rows.Add(dataRow);
                }
            }

            dt = dt.DefaultView.ToTable();
        }

        public static void SetComboSource(ComboBox comboBox, DataTable dataTable, string cID, string cName, AppSetting.eComboList eComboList)
        {
            DataRow dataRow = null;
            DataTable dataTable1 = null;
            try
            {
                if (dataTable == null)
                    throw new Exception("can't load)");
                dataTable1 = dataTable.Copy();
            }
            catch (Exception ex)
            {

                throw;
            }

            for (int i = dataTable1.Columns.Count - 1; i > 0; i--)
            {
                if (dataTable1.Columns[i].ColumnName != cID && dataTable1.Columns[i].ColumnName != cName)
                    dataTable1.Columns.RemoveAt(i);
            }

            dataTable = dataTable1;
            dataRow = dataTable.NewRow();
            switch (eComboList)
            {
                case AppSetting.eComboList.Data:
                    AddNewRowToComboDatasource(dataTable, dataRow, ref cID);
                    break;
                case AppSetting.eComboList.All:
                    dataRow[cName] = "ทั้งหมด";
                    AddNewRowToComboDatasource(dataTable, dataRow, ref cID);
                    dataTable.DefaultView.Sort = cID;
                    dataTable = dataTable.DefaultView.ToTable();
                    break;
            }
            SetComboList(comboBox, dataTable, cID, cName);
            comboBox.SelectedValue = dataTable.Rows[0][cID];
        }

        public static class Combo
        {
            public static void Load(ComboBox combo, Type type, bool All = false)
            {
                DataTable dt = UI.NewListDataTable;
                short start = 0;
                if (!All)
                    start = 1;

                for (int i = start; i <= System.Enum.GetValues(type).Length; i++)
                {
                    var dr = dt.NewRow();
                    dr["ID"] = i;

                    if (i == 0)
                        dr["Name"] = "ทั้งหมด";
                    else
                    {
                        switch (type.Name)
                        {
                            case string s when s == typeof(AppSetting.ePassStatus).Name:
                                dr["Name"] = AppSetting.GetPassStatusName((AppSetting.ePassStatus)i);
                                break;
                        }
                    }
                    dt.Rows.Add(dr);
                }
                SetComboList(combo, dt);
            }

            public static void Load(ComboBox combo, DataObject.Base o, AppSetting.eComboList eComboList = AppSetting.eComboList.Data)
            {
                var cID = "";
                var cName = "";
                switch (o.GetType().Name)
                {
                    case string s when s == typeof(DataObject.JobType).Name:
                        var oJobGroup = (DataObject.JobType)o;
                        cID = "JobType";
                        cName = nameof(oJobGroup.JobName);
                        break;
                }

                SetComboSource(combo, o.Load().Copy(), cID, cName, eComboList);
            }
        }
    }

    public static class DBManager
    {

    }
}
