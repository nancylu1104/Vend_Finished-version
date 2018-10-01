using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vend_Testing.Global
{
    class JsonBodyAndProperties
    {
        public static List<ResponseFromGet> ResponseFromGets = new List<ResponseFromGet>();
        public static List<PatchResponse> PatchResponses = new List<PatchResponse>();
        
        
        public static string managerId = null;
        //最开始获取的api状态
        public static int APIPromotionTag = 0;
        //最开始获取的web 状态
        public static int WebPromotionTag = 0;
        //获取的patch 相应
        public static int PatchResponseTag = 0;
        //patch 操作时候的状态
        public static int PatchCode = 0;

        //patch rp
        //*****************************************
        public class Permission
        {
            public string name { get; set; }
        }

        public class Data
        {
            public string id { get; set; }
            public string name { get; set; }
            public int position { get; set; }
            public string updated_at { get; set; }
            public List<Permission> permissions { get; set; }
        }

        public class PatchResponse
        {
            public Data data { get; set; }
        }

        //Get Rp 
        //*****************************************
        public class GetRolesPermission
        {
            public string name { get; set; }
        }

        public class Datum
        {
            public string id { get; set; }
            public string name { get; set; }
            public int position { get; set; }
            public string updated_at { get; set; }
            public List<object> users { get; set; }
            public List<GetRolesPermission> permissions { get; set; }
        }

        public class ResponseFromGet
        {
            public List<Datum> data { get; set; }
        }

    }


   
}
