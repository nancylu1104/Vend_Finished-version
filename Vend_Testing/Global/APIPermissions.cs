using System;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;

namespace Vend_Testing.Global
{
    class APIPermissions
    {
        //获取role 然后得到manager的permisson
        public static void GetAPIPermissonsStatus()
        {
            
            var client = new RestClient(Base.RestClientGet);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Authorization", Base.Authorization);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            //get response data: string
            string content = response.Content;

            JsonBodyAndProperties.ResponseFromGets.Add(
                //  将content 反序列化为ResponseBodyFromGet对象
                JsonConvert.DeserializeObject<JsonBodyAndProperties.ResponseFromGet>(content));
            //遍历进行查找
            foreach (JsonBodyAndProperties.ResponseFromGet responseFromGet  in JsonBodyAndProperties.ResponseFromGets)
            {
                foreach (JsonBodyAndProperties.Datum datum in responseFromGet.data)
                {
                    if (datum.name.Equals("Manager"))
                    {
                        //保存id
                        JsonBodyAndProperties.managerId=datum.id;
                        //检查promotion
                        foreach (JsonBodyAndProperties.GetRolesPermission getRolesPermission  in datum.permissions)
                        {
                            //如果有promotion， 将tag设置为1，默认为0
                            if (getRolesPermission.name.Equals(Base.Promotion))
                            {
                                //修改标志位为1，否则为0
                                JsonBodyAndProperties.APIPromotionTag = 1;
                            }
                        }
                    }
                }
            }
        }

        //patch 操作并且检车响应的状态
        public static void PatchAndGetAPIStatus()
        {
            //如果基准状态为0 patch改为1 patch code 默认是0
            if (JsonBodyAndProperties.APIPromotionTag==0)
            {
                JsonBodyAndProperties.PatchCode = 1;
            }
            //构建和patch
            var client = new RestClient(Base.RestClientPatch);
            var request = new RestRequest(Method.PATCH);
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Authorization", Base.Authorization);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined",
                "{\r\n    \"permissions\": [\r\n        {\r\n            \"name\": \"promotion.add_edit\",\r\n            \"value\": "+JsonBodyAndProperties.PatchCode+"\r\n        }\r\n    ]\r\n}",
                ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            string content = response.Content;

                //deserilization-json
            //ResponseBodyFromGets 是一个list,这里操作往list里面添加返回的对象；
            JsonBodyAndProperties.PatchResponses.Add(
                //                将content 反序列化为ResponseBodyFromGet对象
                JsonConvert.DeserializeObject<JsonBodyAndProperties.PatchResponse>(content));
            //遍历查找promotion的permission
            foreach (JsonBodyAndProperties.PatchResponse patchResponse in JsonBodyAndProperties.PatchResponses)
            {
                foreach (JsonBodyAndProperties.Permission permission in patchResponse.data.permissions)
                {
                    //如果有，则PatchResponseTag值为1
                    if (permission.name.Equals(Base.Promotion))
                    {
                        JsonBodyAndProperties.PatchResponseTag = 1;
                    }                 
                }
            }
            //验证patch和接受的是否一致。
            Assert.AreEqual(JsonBodyAndProperties.PatchCode,JsonBodyAndProperties.PatchResponseTag, "PatchCode is: "+JsonBodyAndProperties.PatchCode+ " and PatchResponseTag is: "+JsonBodyAndProperties.PatchResponseTag);
        }
    }
}