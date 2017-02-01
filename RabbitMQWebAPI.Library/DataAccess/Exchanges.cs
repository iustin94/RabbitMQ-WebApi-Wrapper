﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RabbitMQWebAPI.Library.Models;

namespace RabbitMQWebAPI.Library.DataAccess
{
    public class Exchanges
    {
        public static async Task<ExchangeInfo> GetExchangeInfo(string exchangeName, string vhost = "/")
        {
            return await GetExchangeInfoInternal(exchangeName, vhost);
        }

        public static async Task<IEnumerable<ExchangeInfo>> GetExchangeInfos()
        {
            return await GetExchangeInfosInternal();
        }


        /// <summary>
        /// Retrieves the exchange in the node with the specified parameter 
        /// </summary>
        /// <param name="exchangeName"></param>
        /// <returns></returns>
        private static async Task<ExchangeInfo> GetExchangeInfoInternal(string exchangeName, string vhost)
        {
            dynamic exchangeData;


            var builder = new DbConnectionStringBuilder();
            builder.ConnectionString = ConfigurationManager.ConnectionStrings["HTTPapi"].ConnectionString;

            string baseAddress = builder["BaseAddress"].ToString();
            string userName = builder["username"].ToString();
            string password = builder["password"].ToString();

            using (var handler = new HttpClientHandler()
            {
                Credentials = new NetworkCredential(userName: userName, password: password)
            })
            {
                using (var client = new HttpClient(handler) { BaseAddress = new Uri(baseAddress) })
                {
                    string vhostArgument = WebUtility.UrlEncode(vhost);
                    string exchangeNameArgument = WebUtility.UrlEncode(exchangeName);
                    using (
                        var response =
                            await
                                client.GetAsync(String.Format("exchanges/{0}/{1}", vhostArgument, exchangeNameArgument), //Encode "/" character
                                        HttpCompletionOption.ResponseContentRead)
                                    .ConfigureAwait(false))
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        exchangeData = JsonConvert.DeserializeObject(result);

                        var name = exchangeData["name"].ToString();
                        var e_vhost = exchangeData["vhost"].ToString();
                        var type = exchangeData["type"].ToString();
                        bool durable = exchangeData["durable"].ToString() == "true";
                        bool auto_delete = exchangeData["auto_delete"].ToString() == "true";
                        bool internal_exchange = exchangeData["internal"].ToString() == "true";

                        Dictionary<string, string> arguments =
                            JsonConvert.DeserializeObject<Dictionary<string, string>>(
                                exchangeData["arguments"].ToString());

                        return new ExchangeInfo(name: name, vhost: e_vhost, type: type, durable: durable,
                            auto_delete: auto_delete, internal_exchange: internal_exchange, arguments: arguments);
                    }
                }
            }
        }

        private static async Task<IEnumerable<ExchangeInfo>> GetExchangeInfosInternal()
        {
            dynamic info;
            List<ExchangeInfo> exchanges = new List<ExchangeInfo>();


            var builder = new DbConnectionStringBuilder();
            builder.ConnectionString = ConfigurationManager.ConnectionStrings["RabbitMQDevelopmentClusterAddress"].ConnectionString;

            string baseAddress = builder["BaseAddress"].ToString();
            string userName = builder["username"].ToString();
            string password = builder["password"].ToString();

            using (var handler = new HttpClientHandler()
            {
                Credentials = new NetworkCredential(userName: userName, password: password)
            })
            {
                using (var client = new HttpClient(handler) { BaseAddress = new Uri(baseAddress) })
                {
                    using (
                        var response =
                            await
                                client.GetAsync("exchanges", HttpCompletionOption.ResponseContentRead)
                                    .ConfigureAwait(false))
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        info = JsonConvert.DeserializeObject(result);

                        JArray exchangeDataSet = info.Result;

                        foreach (JObject exchangeData in exchangeDataSet)
                        {
                            var name = exchangeData["name"].ToString();
                            var vhost = exchangeData["vhost"].ToString();
                            var type = exchangeData["type"].ToString();
                            bool durable = exchangeData["durable"].ToString() == "true";
                            bool auto_delete = exchangeData["auto_delete"].ToString() == "true";
                            bool internal_exchange = exchangeData["internal"].ToString() == "true";

                            Dictionary<string, string> arguments =
                                JsonConvert.DeserializeObject<Dictionary<string, string>>(
                                    exchangeData["arguments"].ToString());

                            exchanges.Add(new ExchangeInfo(name: name, vhost: vhost, type: type, auto_delete: auto_delete, durable: durable, internal_exchange: internal_exchange, arguments: arguments));
                        }

                    }
                }
            }

            return exchanges;
        }

    }
}
