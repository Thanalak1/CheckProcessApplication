using System.Data;
using CheckProcessApplication;

namespace DataObject
{
    public abstract class Base
    {
        private DataTable _dt;
        protected DataRow _dr;
        private DataTable _dtSchema;
        public DataRow drSearch;

        public DataTable CurrentDataTable
        {
            get { return _dt; }
            set { _dt = value; }
        }
        public DataRow CurrentDataRow
        {
            get { return _dr; }
            set { _dr = value; }
        }

        protected Base()
        {
            _dt = new DataTable();
        }

        protected DataRow GetSchema(string TableName)
        {
            DataTable dt = null;
            _dtSchema = new DataTable();
            _dtSchema.TableName = TableName;
            Center.cmd.CommandText = $"SELECT * FROM {TableName} WHERE 1 = 2";
            try
            {
                dt = _dtSchema.Copy();
                _dt = _dtSchema;
                _dr = _dt.NewRow();
            }
            catch (System.Exception ex)
            {
                return null;
            }

            return dt.NewRow();
        }

        public DataTable Load()
        {
            drSearch = null;
            return Load(drSearch);
        }

        public DataTable Load(DataRow drSearch = null, IDbTransaction Trans = null)
        {
            Center.cmd.CommandText = $"SELECT * FROM {_dtSchema.TableName}";
            _dt.Clear();
            _dt = Center.Load();
            if (_dt.Rows.Count == 0)
                _dr[0] = 0;
            else
                _dr = _dt.Rows[0];

            return _dt;
        }
    }
}
