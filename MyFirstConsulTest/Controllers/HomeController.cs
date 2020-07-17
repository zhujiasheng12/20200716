using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyFirstConsulTest.Models;
using IBLL;
using System.Net.Http;
using Model;
using Consul;

namespace MyFirstConsulTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _iUserService=null;

        public HomeController(ILogger<HomeController> logger,IUserService userService )
        {
            _logger = logger;
            _iUserService = userService;

        }

        public IActionResult Index()
        {
            //base.ViewBag.Users = this._iUserService.UserAll();

            //string url = "http://UsersData/api/User/all";
            #region Consul
            //{
            //    ConsulClient client = new ConsulClient(c=>
            //    {
            //        c.Address = new Uri("http://localhost:8500/");
            //        c.Datacenter = "dc1";
            //    });
            //    var response = client.Agent.Services().Result.Response;
            //    //foreach (var item in response)
            //    //{
            //    //    Console.WriteLine("******************************************");
            //    //    Console.WriteLine(item.Key);
            //    //    var server = item.Value;
            //    //    Console.WriteLine($"{ server .Address }---{server.Port}---{server .Service}");
            //    //    Console.WriteLine("******************************************");
            //    //}
            //    Uri uri = new Uri(url);
            //    string groupName = uri.Host;
            //    var serviceDictionary = response.Where(s => s.Value.Service.Equals(groupName, StringComparison.OrdinalIgnoreCase)).ToArray ();
            //    //url = $"{uri.Scheme }://{serviceDictionary.First().Value.Address}:{serviceDictionary.First().Value.Port}{uri.PathAndQuery}";
            //    //做负载均衡
            //    AgentService agentService = null;
            //    {
            //        //平均策略，随机分配
            //        agentService = serviceDictionary[new Random(isSeed++).Next(0, serviceDictionary.Length)].Value;

            //    }
            //    {
            //        //轮询策略，轮流调用服务
            //        agentService = serviceDictionary[isSeed ++%serviceDictionary.Length].Value;

            //    }
            //    {
            //        //权重策略，根据每个服务注册时的权重占比分配，实际实现是按照每个服务权重给列表中添加对应数量的服务实例，然后在列表中使用平均策略
            //        List<KeyValuePair<string, AgentService>> pairsLast = new List<KeyValuePair<string, AgentService>>();
            //        foreach (var item in serviceDictionary)
            //        {
            //            int count = int.Parse(item.Value.Tags?[0]);
            //            for (int i = 0; i < count; i++)
            //            {
            //                pairsLast.Add(item);
            //            }
            //        }
            //        agentService = pairsLast[new Random(isSeed++).Next(0, pairsLast.Count)].Value;

            //    }
            //    url = $"{uri.Scheme }://{agentService.Address}:{agentService.Port}{uri.PathAndQuery}";

            // }
            var url = "http://localhost:6299/T/USER/ALL";
            #endregion
            var content = InvokeApi(url);
            base.ViewBag.Users = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<User>>(content);

            Console.WriteLine($"This is {url} invoke");
            return View();
        }
        private static int isSeed=0;
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public static string InvokeApi(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage message = new HttpRequestMessage();
                message.Method = HttpMethod.Get;
                message.RequestUri = new Uri(url);
                var result = client.SendAsync(message).Result;
                string resultStr = result.Content.ReadAsStringAsync().Result;
                return resultStr;
            }
        }
    }
}
