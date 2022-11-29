﻿using System;
using System.Collections.Generic;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Interfaces;
using Huobi.Net.Enums;
using Newtonsoft.Json;

namespace Huobi.Net.Objects.Models.Rest.Futures.UsdtMarginSwap.LinearSwapAccount.CommonBaseModels
{
    /// <summary>
    /// 子账户交易权限设置异常错误
    /// </summary>
    public class HuobiSubAuthError
    {
        /// <summary>
        /// 子用户用户编号
        /// </summary>
        [JsonProperty("sub_uid", NullValueHandling = NullValueHandling.Ignore)]

        public string SubUid { get; set; } = string.Empty;

        /// <summary>
        /// 持仓列表
        /// </summary>
        [JsonProperty("err_code", NullValueHandling = NullValueHandling.Ignore)]

        public int ErrCode { get; set; } = default;

        /// <summary>
        /// 错误信息
        /// </summary>
        [JsonProperty("err_msg", NullValueHandling = NullValueHandling.Ignore)]

        public string ErrMsg { get; set; } = string.Empty;
    }
}