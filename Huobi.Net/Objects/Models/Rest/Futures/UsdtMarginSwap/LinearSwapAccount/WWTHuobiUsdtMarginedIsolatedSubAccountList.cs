﻿using Huobi.Net.Objects.Models.Rest.Futures.UsdtMarginSwap.LinearSwapAccount.CommonBaseModels;

namespace Huobi.Net.Objects.Models.Rest.Futures.UsdtMarginSwap.LinearSwapAccount
{
    /// <summary>
    /// 【逐仓】查询母账户下所有子账户资产信息(PrivateData)
    /// </summary>
    public class WWTHuobiUsdtMarginedIsolatedSubAccountList
    {
        /// <summary>
        /// 子账户UID
        /// </summary>
        [JsonProperty("sub_uid", NullValueHandling = NullValueHandling.Ignore)]
        public string SubUid { get; set; } = string.Empty;

        /// <summary>
        /// 账户权益
        /// </summary>
        [JsonProperty("account_info_list", NullValueHandling = NullValueHandling.Ignore)]

        public IEnumerable<WWTHuobiSubAccountIsolatedInfo> List { get; set; } = Array.Empty<WWTHuobiSubAccountIsolatedInfo>();
    }
}