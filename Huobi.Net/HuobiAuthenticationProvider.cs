﻿using Huobi.Net.Objects.Internal;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Huobi.Net
{
    internal class HuobiAuthenticationProvider : AuthenticationProvider
    {
        private readonly bool signPublicRequests;

        public HuobiAuthenticationProvider(ApiCredentials credentials, bool signPublicRequests) : base(credentials)
        {
            this.signPublicRequests = signPublicRequests;
        }

        /// <summary>
        /// 这是一个不做字典排序的签名方法，这里不需要实现，火币是要求排序的
        /// </summary>
        public override void AuthenticateRequest(RestApiClient apiClient, Uri uri, HttpMethod method, Dictionary<string, object> providedParameters, bool auth, ArrayParametersSerialization arraySerialization, HttpMethodParameterPosition parameterPosition, out Dictionary<string, object> uriParameters, out Dictionary<string, object> bodyParameters, out Dictionary<string, string> headers)
        {
            throw new NotImplementedException();
        }

        public override void AuthenticateRequest(RestApiClient apiClient,
            Uri uri,
            HttpMethod method,
            Dictionary<string, object> providedParameters,
            bool auth,
            ArrayParametersSerialization arraySerialization,
            HttpMethodParameterPosition parameterPosition,
            out SortedDictionary<string, object> uriParameters,
            out SortedDictionary<string, object> bodyParameters,
            out Dictionary<string, string> headers)
        {
            uriParameters = parameterPosition == HttpMethodParameterPosition.InUri ? new SortedDictionary<string, object>(providedParameters) : new SortedDictionary<string, object>();
            bodyParameters = parameterPosition == HttpMethodParameterPosition.InBody ? new SortedDictionary<string, object>(providedParameters) : new SortedDictionary<string, object>();
            headers = new Dictionary<string, string>();

            if (!auth && !signPublicRequests)
                return;

            // These are always in the uri
            uriParameters.Add("AccessKeyId", Credentials.Key!.GetString());
            uriParameters.Add("SignatureMethod", "HmacSHA256");
            uriParameters.Add("SignatureVersion", 2);
            uriParameters.Add("Timestamp", GetTimestamp(apiClient).ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture));

            var absolutePath = uri.AbsolutePath;
            if (absolutePath.StartsWith("/api"))
                // Russian api has /api prefix which shouldn't be part of the signature
                absolutePath = absolutePath.Substring(4);

            var sortedParameters = uriParameters.OrderBy(kv => Encoding.UTF8.GetBytes(WebUtility.UrlEncode(kv.Key)!), new ByteOrderComparer());
            var paramString = uri.SetParameters(sortedParameters, arraySerialization).Query.Replace("?", "");
            paramString = new Regex(@"%[a-f0-9]{2}").Replace(paramString, m => m.Value.ToUpperInvariant());
            var signData = $"{method}\n{uri.Host}\n{absolutePath}\n{paramString}";
            uriParameters.Add("Signature", SignHMACSHA256(signData, SignOutputType.Base64));
        }

        public HuobiAuthenticationRequest GetWebsocketAuthentication(Uri uri)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("accessKey", Credentials.Key!.GetString());
            parameters.Add("signatureMethod", "HmacSHA256");
            parameters.Add("signatureVersion", 2.1);
            parameters.Add("timestamp", DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture));

            var sortedParameters = parameters.OrderBy(kv => Encoding.UTF8.GetBytes(WebUtility.UrlEncode(kv.Key)!), new ByteOrderComparer());
            var paramString = uri.SetParameters(sortedParameters, ArrayParametersSerialization.Array).Query.Replace("?", "");
            paramString = new Regex(@"%[a-f0-9]{2}").Replace(paramString, m => m.Value.ToUpperInvariant()).Replace("%2C", ".");
            var signData = $"GET\n{uri.Host}\n{uri.AbsolutePath}\n{paramString}";
            var signature = SignHMACSHA256(signData, SignOutputType.Base64);

            return new HuobiAuthenticationRequest(Credentials.Key!.GetString(), (string)parameters["timestamp"], signature);
        }

        public HuobiAuthenticationRequest2 GetWebsocketAuthentication2(Uri uri)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("AccessKeyId", Credentials.Key!.GetString());
            parameters.Add("SignatureMethod", "HmacSHA256");
            parameters.Add("SignatureVersion", 2);
            parameters.Add("Timestamp", DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture));

            var sortedParameters = parameters.OrderBy(kv => Encoding.UTF8.GetBytes(WebUtility.UrlEncode(kv.Key)!), new ByteOrderComparer());
            var paramString = uri.SetParameters(sortedParameters, ArrayParametersSerialization.Array).Query.Replace("?", "");
            paramString = new Regex(@"%[a-f0-9]{2}").Replace(paramString, m => m.Value.ToUpperInvariant()).Replace("%2C", ".");
            var signData = $"GET\n{uri.Host}\n{uri.AbsolutePath}\n{paramString}";
            var signature = SignHMACSHA256(signData, SignOutputType.Base64);

            return new HuobiAuthenticationRequest2(Credentials.Key!.GetString(), (string)parameters["Timestamp"], signature);
        }
    }
}
