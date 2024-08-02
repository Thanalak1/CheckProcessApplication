using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckProcessApplication.Class
{
    public static class AppSetting
    {
        public enum ePassStatus
        {
            All = 1, Pass = 2, NotPass = 3
        }

        public enum eComboList
        {
            Data, All
        }

        public static string GetPassStatusName(ePassStatus status)
        {
            string result = string.Empty;
            switch (status)
            {
                case ePassStatus.All:
                    result = "ทั้งหมด";
                    break;
                case ePassStatus.Pass:
                    result = "ตรวจแล้ว";
                    break;
                case ePassStatus.NotPass:
                    result = "ยังไม่ได้ตรวจ";
                    break;
            }
            return result;
        }
    }
}
