﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TheNameFlewAway.Models
{
    using System;
    using System.Collections.Generic;
    
    /// <summary>
    /// 进阶知识与资源关联
    /// </summary>
    public partial class AdvanceKonwledgeAndResource
    {
        /// <summary>
        /// 进阶知识id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 资源id
        /// </summary>
        public int resourceid { get; set; }

        /// <summary>
        /// 进阶知识与资源关联全参构造函数
        /// </summary>
        /// <param name="id">进阶知识id</param>
        /// <param name="resourceid">资源id</param>
        public AdvanceKonwledgeAndResource(int id, int resourceid)
        {
            this.id = id;
            this.resourceid = resourceid;
        }
        /// <summary>
        /// 进阶知识与资源关联无参构造函数
        /// </summary>
        public AdvanceKonwledgeAndResource()
        {

        }
    }
}
