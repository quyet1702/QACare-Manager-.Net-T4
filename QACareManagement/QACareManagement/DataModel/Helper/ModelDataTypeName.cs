using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QACareManagement.DataModel.Helper
{
    public static class ModelDataTypeName
    {
        public static String GetPromotionOrGiftTypeName(int type)
        {
            if (type == 1) return "Tích Điểm";
            else return "Quà Tặng ";
        }

        public static String GetCustomerRoleName(int type)
        {
            if (type == 1) return "Khách Hàng";
            else return "Đối Tác";
        }

        public static String GetRegisterOrOrderTypeName(int type)
        {
            if (type == 1) return "Đăng Ký";
            else return "Đổi Quà";
        }
    }
}
