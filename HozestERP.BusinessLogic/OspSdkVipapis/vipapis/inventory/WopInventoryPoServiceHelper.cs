using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.inventory{
	
	
	public class WopInventoryPoServiceHelper {
		
		
		
		public class cancelPo_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private string vendor_id_;
			
			///<summary>
			/// 系统入库凭证号
			///</summary>
			
			private string systemPoNo_;
			
			public string GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(string value){
				this.vendor_id_ = value;
			}
			public string GetSystemPoNo(){
				return this.systemPoNo_;
			}
			
			public void SetSystemPoNo(string value){
				this.systemPoNo_ = value;
			}
			
		}
		
		
		
		
		public class cleanPoDetail_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private string vendor_id_;
			
			///<summary>
			/// 系统入库凭证号
			///</summary>
			
			private string systemPoNo_;
			
			public string GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(string value){
				this.vendor_id_ = value;
			}
			public string GetSystemPoNo(){
				return this.systemPoNo_;
			}
			
			public void SetSystemPoNo(string value){
				this.systemPoNo_ = value;
			}
			
		}
		
		
		
		
		public class createPo_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private string vendor_id_;
			
			///<summary>
			/// 创建PO请求
			///</summary>
			
			private com.vip.domain.inventory.CreatePoRequest poReq_;
			
			public string GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(string value){
				this.vendor_id_ = value;
			}
			public com.vip.domain.inventory.CreatePoRequest GetPoReq(){
				return this.poReq_;
			}
			
			public void SetPoReq(com.vip.domain.inventory.CreatePoRequest value){
				this.poReq_ = value;
			}
			
		}
		
		
		
		
		public class editPO_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private string vendor_id_;
			
			///<summary>
			/// 修改PO请求
			///</summary>
			
			private com.vip.domain.inventory.EditPoRequest poReq_;
			
			public string GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(string value){
				this.vendor_id_ = value;
			}
			public com.vip.domain.inventory.EditPoRequest GetPoReq(){
				return this.poReq_;
			}
			
			public void SetPoReq(com.vip.domain.inventory.EditPoRequest value){
				this.poReq_ = value;
			}
			
		}
		
		
		
		
		public class getPoDetailList_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private string vendor_id_;
			
			///<summary>
			/// 系统入库凭证
			///</summary>
			
			private string systemPoNo_;
			
			///<summary>
			/// 页码
			///</summary>
			
			private int? pageNum_;
			
			///<summary>
			/// 每页的记录数 (最大支持100 条数据)
			///</summary>
			
			private int? pageSize_;
			
			public string GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(string value){
				this.vendor_id_ = value;
			}
			public string GetSystemPoNo(){
				return this.systemPoNo_;
			}
			
			public void SetSystemPoNo(string value){
				this.systemPoNo_ = value;
			}
			public int? GetPageNum(){
				return this.pageNum_;
			}
			
			public void SetPageNum(int? value){
				this.pageNum_ = value;
			}
			public int? GetPageSize(){
				return this.pageSize_;
			}
			
			public void SetPageSize(int? value){
				this.pageSize_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class importPoDetail_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private string vendor_id_;
			
			///<summary>
			/// 系统入库凭证号
			///</summary>
			
			private string systemPoNo_;
			
			///<summary>
			/// 入库商品明细
			///</summary>
			
			private List<com.vip.domain.inventory.PoSku> impSkuList_;
			
			public string GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(string value){
				this.vendor_id_ = value;
			}
			public string GetSystemPoNo(){
				return this.systemPoNo_;
			}
			
			public void SetSystemPoNo(string value){
				this.systemPoNo_ = value;
			}
			public List<com.vip.domain.inventory.PoSku> GetImpSkuList(){
				return this.impSkuList_;
			}
			
			public void SetImpSkuList(List<com.vip.domain.inventory.PoSku> value){
				this.impSkuList_ = value;
			}
			
		}
		
		
		
		
		public class searchPoList_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private string vendor_id_;
			
			///<summary>
			/// 页码
			///</summary>
			
			private int? pageNum_;
			
			///<summary>
			/// 每页的记录数 (最大支持100 条数据)
			///</summary>
			
			private int? pageSize_;
			
			///<summary>
			/// 入库单查询条件
			///</summary>
			
			private com.vip.domain.inventory.SearchPoRequest searchRequest_;
			
			public string GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(string value){
				this.vendor_id_ = value;
			}
			public int? GetPageNum(){
				return this.pageNum_;
			}
			
			public void SetPageNum(int? value){
				this.pageNum_ = value;
			}
			public int? GetPageSize(){
				return this.pageSize_;
			}
			
			public void SetPageSize(int? value){
				this.pageSize_ = value;
			}
			public com.vip.domain.inventory.SearchPoRequest GetSearchRequest(){
				return this.searchRequest_;
			}
			
			public void SetSearchRequest(com.vip.domain.inventory.SearchPoRequest value){
				this.searchRequest_ = value;
			}
			
		}
		
		
		
		
		public class submitPo_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private string vendor_id_;
			
			///<summary>
			/// 系统入库凭证号
			///</summary>
			
			private string systemPoNo_;
			
			public string GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(string value){
				this.vendor_id_ = value;
			}
			public string GetSystemPoNo(){
				return this.systemPoNo_;
			}
			
			public void SetSystemPoNo(string value){
				this.systemPoNo_ = value;
			}
			
		}
		
		
		
		
		public class cancelPo_result {
			
			///<summary>
			///</summary>
			
			private com.vip.domain.inventory.OpPoResponse success_;
			
			public com.vip.domain.inventory.OpPoResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.domain.inventory.OpPoResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class cleanPoDetail_result {
			
			///<summary>
			///</summary>
			
			private com.vip.domain.inventory.OpPoResponse success_;
			
			public com.vip.domain.inventory.OpPoResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.domain.inventory.OpPoResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class createPo_result {
			
			///<summary>
			///</summary>
			
			private com.vip.domain.inventory.CreatePoResponse success_;
			
			public com.vip.domain.inventory.CreatePoResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.domain.inventory.CreatePoResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class editPO_result {
			
			///<summary>
			///</summary>
			
			private com.vip.domain.inventory.OpPoResponse success_;
			
			public com.vip.domain.inventory.OpPoResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.domain.inventory.OpPoResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getPoDetailList_result {
			
			///<summary>
			///</summary>
			
			private com.vip.domain.inventory.GetPoItemResponse success_;
			
			public com.vip.domain.inventory.GetPoItemResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.domain.inventory.GetPoItemResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_result {
			
			///<summary>
			///</summary>
			
			private com.vip.hermes.core.health.CheckResult success_;
			
			public com.vip.hermes.core.health.CheckResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.hermes.core.health.CheckResult value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class importPoDetail_result {
			
			///<summary>
			///</summary>
			
			private com.vip.domain.inventory.OpPoResponse success_;
			
			public com.vip.domain.inventory.OpPoResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.domain.inventory.OpPoResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class searchPoList_result {
			
			///<summary>
			///</summary>
			
			private com.vip.domain.inventory.SearchPoResponse success_;
			
			public com.vip.domain.inventory.SearchPoResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.domain.inventory.SearchPoResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class submitPo_result {
			
			///<summary>
			///</summary>
			
			private com.vip.domain.inventory.OpPoResponse success_;
			
			public com.vip.domain.inventory.OpPoResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.domain.inventory.OpPoResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		
		public class cancelPo_argsHelper : TBeanSerializer<cancelPo_args>
		{
			
			public static cancelPo_argsHelper OBJ = new cancelPo_argsHelper();
			
			public static cancelPo_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(cancelPo_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSystemPoNo(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(cancelPo_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteString(structs.GetVendor_id());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetSystemPoNo() != null) {
					
					oprot.WriteFieldBegin("systemPoNo");
					oprot.WriteString(structs.GetSystemPoNo());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("systemPoNo can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(cancelPo_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class cleanPoDetail_argsHelper : TBeanSerializer<cleanPoDetail_args>
		{
			
			public static cleanPoDetail_argsHelper OBJ = new cleanPoDetail_argsHelper();
			
			public static cleanPoDetail_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(cleanPoDetail_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSystemPoNo(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(cleanPoDetail_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteString(structs.GetVendor_id());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetSystemPoNo() != null) {
					
					oprot.WriteFieldBegin("systemPoNo");
					oprot.WriteString(structs.GetSystemPoNo());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("systemPoNo can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(cleanPoDetail_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class createPo_argsHelper : TBeanSerializer<createPo_args>
		{
			
			public static createPo_argsHelper OBJ = new createPo_argsHelper();
			
			public static createPo_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createPo_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.domain.inventory.CreatePoRequest value;
					
					value = new com.vip.domain.inventory.CreatePoRequest();
					com.vip.domain.inventory.CreatePoRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetPoReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(createPo_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteString(structs.GetVendor_id());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetPoReq() != null) {
					
					oprot.WriteFieldBegin("poReq");
					
					com.vip.domain.inventory.CreatePoRequestHelper.getInstance().Write(structs.GetPoReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("poReq can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(createPo_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class editPO_argsHelper : TBeanSerializer<editPO_args>
		{
			
			public static editPO_argsHelper OBJ = new editPO_argsHelper();
			
			public static editPO_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(editPO_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.domain.inventory.EditPoRequest value;
					
					value = new com.vip.domain.inventory.EditPoRequest();
					com.vip.domain.inventory.EditPoRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetPoReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(editPO_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteString(structs.GetVendor_id());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetPoReq() != null) {
					
					oprot.WriteFieldBegin("poReq");
					
					com.vip.domain.inventory.EditPoRequestHelper.getInstance().Write(structs.GetPoReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("poReq can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(editPO_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getPoDetailList_argsHelper : TBeanSerializer<getPoDetailList_args>
		{
			
			public static getPoDetailList_argsHelper OBJ = new getPoDetailList_argsHelper();
			
			public static getPoDetailList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getPoDetailList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSystemPoNo(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetPageNum(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetPageSize(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getPoDetailList_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteString(structs.GetVendor_id());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetSystemPoNo() != null) {
					
					oprot.WriteFieldBegin("systemPoNo");
					oprot.WriteString(structs.GetSystemPoNo());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("systemPoNo can not be null!");
				}
				
				
				if(structs.GetPageNum() != null) {
					
					oprot.WriteFieldBegin("pageNum");
					oprot.WriteI32((int)structs.GetPageNum()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("pageNum can not be null!");
				}
				
				
				if(structs.GetPageSize() != null) {
					
					oprot.WriteFieldBegin("pageSize");
					oprot.WriteI32((int)structs.GetPageSize()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("pageSize can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getPoDetailList_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class healthCheck_argsHelper : TBeanSerializer<healthCheck_args>
		{
			
			public static healthCheck_argsHelper OBJ = new healthCheck_argsHelper();
			
			public static healthCheck_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(healthCheck_args structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(healthCheck_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(healthCheck_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class importPoDetail_argsHelper : TBeanSerializer<importPoDetail_args>
		{
			
			public static importPoDetail_argsHelper OBJ = new importPoDetail_argsHelper();
			
			public static importPoDetail_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(importPoDetail_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSystemPoNo(value);
				}
				
				
				
				
				
				if(true){
					
					List<com.vip.domain.inventory.PoSku> value;
					
					value = new List<com.vip.domain.inventory.PoSku>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.domain.inventory.PoSku elem0;
							
							elem0 = new com.vip.domain.inventory.PoSku();
							com.vip.domain.inventory.PoSkuHelper.getInstance().Read(elem0, iprot);
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetImpSkuList(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(importPoDetail_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteString(structs.GetVendor_id());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetSystemPoNo() != null) {
					
					oprot.WriteFieldBegin("systemPoNo");
					oprot.WriteString(structs.GetSystemPoNo());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("systemPoNo can not be null!");
				}
				
				
				if(structs.GetImpSkuList() != null) {
					
					oprot.WriteFieldBegin("impSkuList");
					
					oprot.WriteListBegin();
					foreach(com.vip.domain.inventory.PoSku _item0 in structs.GetImpSkuList()){
						
						
						com.vip.domain.inventory.PoSkuHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("impSkuList can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(importPoDetail_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class searchPoList_argsHelper : TBeanSerializer<searchPoList_args>
		{
			
			public static searchPoList_argsHelper OBJ = new searchPoList_argsHelper();
			
			public static searchPoList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(searchPoList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetPageNum(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetPageSize(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.domain.inventory.SearchPoRequest value;
					
					value = new com.vip.domain.inventory.SearchPoRequest();
					com.vip.domain.inventory.SearchPoRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetSearchRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(searchPoList_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteString(structs.GetVendor_id());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetPageNum() != null) {
					
					oprot.WriteFieldBegin("pageNum");
					oprot.WriteI32((int)structs.GetPageNum()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("pageNum can not be null!");
				}
				
				
				if(structs.GetPageSize() != null) {
					
					oprot.WriteFieldBegin("pageSize");
					oprot.WriteI32((int)structs.GetPageSize()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("pageSize can not be null!");
				}
				
				
				if(structs.GetSearchRequest() != null) {
					
					oprot.WriteFieldBegin("searchRequest");
					
					com.vip.domain.inventory.SearchPoRequestHelper.getInstance().Write(structs.GetSearchRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(searchPoList_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class submitPo_argsHelper : TBeanSerializer<submitPo_args>
		{
			
			public static submitPo_argsHelper OBJ = new submitPo_argsHelper();
			
			public static submitPo_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(submitPo_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSystemPoNo(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(submitPo_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteString(structs.GetVendor_id());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetSystemPoNo() != null) {
					
					oprot.WriteFieldBegin("systemPoNo");
					oprot.WriteString(structs.GetSystemPoNo());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("systemPoNo can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(submitPo_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class cancelPo_resultHelper : TBeanSerializer<cancelPo_result>
		{
			
			public static cancelPo_resultHelper OBJ = new cancelPo_resultHelper();
			
			public static cancelPo_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(cancelPo_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.domain.inventory.OpPoResponse value;
					
					value = new com.vip.domain.inventory.OpPoResponse();
					com.vip.domain.inventory.OpPoResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(cancelPo_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.domain.inventory.OpPoResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(cancelPo_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class cleanPoDetail_resultHelper : TBeanSerializer<cleanPoDetail_result>
		{
			
			public static cleanPoDetail_resultHelper OBJ = new cleanPoDetail_resultHelper();
			
			public static cleanPoDetail_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(cleanPoDetail_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.domain.inventory.OpPoResponse value;
					
					value = new com.vip.domain.inventory.OpPoResponse();
					com.vip.domain.inventory.OpPoResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(cleanPoDetail_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.domain.inventory.OpPoResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(cleanPoDetail_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class createPo_resultHelper : TBeanSerializer<createPo_result>
		{
			
			public static createPo_resultHelper OBJ = new createPo_resultHelper();
			
			public static createPo_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createPo_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.domain.inventory.CreatePoResponse value;
					
					value = new com.vip.domain.inventory.CreatePoResponse();
					com.vip.domain.inventory.CreatePoResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(createPo_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.domain.inventory.CreatePoResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(createPo_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class editPO_resultHelper : TBeanSerializer<editPO_result>
		{
			
			public static editPO_resultHelper OBJ = new editPO_resultHelper();
			
			public static editPO_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(editPO_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.domain.inventory.OpPoResponse value;
					
					value = new com.vip.domain.inventory.OpPoResponse();
					com.vip.domain.inventory.OpPoResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(editPO_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.domain.inventory.OpPoResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(editPO_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getPoDetailList_resultHelper : TBeanSerializer<getPoDetailList_result>
		{
			
			public static getPoDetailList_resultHelper OBJ = new getPoDetailList_resultHelper();
			
			public static getPoDetailList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getPoDetailList_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.domain.inventory.GetPoItemResponse value;
					
					value = new com.vip.domain.inventory.GetPoItemResponse();
					com.vip.domain.inventory.GetPoItemResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getPoDetailList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.domain.inventory.GetPoItemResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getPoDetailList_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class healthCheck_resultHelper : TBeanSerializer<healthCheck_result>
		{
			
			public static healthCheck_resultHelper OBJ = new healthCheck_resultHelper();
			
			public static healthCheck_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(healthCheck_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.hermes.core.health.CheckResult value;
					
					value = new com.vip.hermes.core.health.CheckResult();
					com.vip.hermes.core.health.CheckResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(healthCheck_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.hermes.core.health.CheckResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(healthCheck_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class importPoDetail_resultHelper : TBeanSerializer<importPoDetail_result>
		{
			
			public static importPoDetail_resultHelper OBJ = new importPoDetail_resultHelper();
			
			public static importPoDetail_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(importPoDetail_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.domain.inventory.OpPoResponse value;
					
					value = new com.vip.domain.inventory.OpPoResponse();
					com.vip.domain.inventory.OpPoResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(importPoDetail_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.domain.inventory.OpPoResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(importPoDetail_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class searchPoList_resultHelper : TBeanSerializer<searchPoList_result>
		{
			
			public static searchPoList_resultHelper OBJ = new searchPoList_resultHelper();
			
			public static searchPoList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(searchPoList_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.domain.inventory.SearchPoResponse value;
					
					value = new com.vip.domain.inventory.SearchPoResponse();
					com.vip.domain.inventory.SearchPoResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(searchPoList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.domain.inventory.SearchPoResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(searchPoList_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class submitPo_resultHelper : TBeanSerializer<submitPo_result>
		{
			
			public static submitPo_resultHelper OBJ = new submitPo_resultHelper();
			
			public static submitPo_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(submitPo_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.domain.inventory.OpPoResponse value;
					
					value = new com.vip.domain.inventory.OpPoResponse();
					com.vip.domain.inventory.OpPoResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(submitPo_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.domain.inventory.OpPoResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(submitPo_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class WopInventoryPoServiceClient : OspRestStub , WopInventoryPoService  {
			
			
			public WopInventoryPoServiceClient():base("vipapis.inventory.WopInventoryPoService","1.0.0") {
				
				
			}
			
			
			
			public com.vip.domain.inventory.OpPoResponse cancelPo(string vendor_id_,string systemPoNo_) {
				
				send_cancelPo(vendor_id_,systemPoNo_);
				return recv_cancelPo(); 
				
			}
			
			
			private void send_cancelPo(string vendor_id_,string systemPoNo_){
				
				InitInvocation("cancelPo");
				
				cancelPo_args args = new cancelPo_args();
				args.SetVendor_id(vendor_id_);
				args.SetSystemPoNo(systemPoNo_);
				
				SendBase(args, cancelPo_argsHelper.getInstance());
			}
			
			
			private com.vip.domain.inventory.OpPoResponse recv_cancelPo(){
				
				cancelPo_result result = new cancelPo_result();
				ReceiveBase(result, cancelPo_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.domain.inventory.OpPoResponse cleanPoDetail(string vendor_id_,string systemPoNo_) {
				
				send_cleanPoDetail(vendor_id_,systemPoNo_);
				return recv_cleanPoDetail(); 
				
			}
			
			
			private void send_cleanPoDetail(string vendor_id_,string systemPoNo_){
				
				InitInvocation("cleanPoDetail");
				
				cleanPoDetail_args args = new cleanPoDetail_args();
				args.SetVendor_id(vendor_id_);
				args.SetSystemPoNo(systemPoNo_);
				
				SendBase(args, cleanPoDetail_argsHelper.getInstance());
			}
			
			
			private com.vip.domain.inventory.OpPoResponse recv_cleanPoDetail(){
				
				cleanPoDetail_result result = new cleanPoDetail_result();
				ReceiveBase(result, cleanPoDetail_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.domain.inventory.CreatePoResponse createPo(string vendor_id_,com.vip.domain.inventory.CreatePoRequest poReq_) {
				
				send_createPo(vendor_id_,poReq_);
				return recv_createPo(); 
				
			}
			
			
			private void send_createPo(string vendor_id_,com.vip.domain.inventory.CreatePoRequest poReq_){
				
				InitInvocation("createPo");
				
				createPo_args args = new createPo_args();
				args.SetVendor_id(vendor_id_);
				args.SetPoReq(poReq_);
				
				SendBase(args, createPo_argsHelper.getInstance());
			}
			
			
			private com.vip.domain.inventory.CreatePoResponse recv_createPo(){
				
				createPo_result result = new createPo_result();
				ReceiveBase(result, createPo_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.domain.inventory.OpPoResponse editPO(string vendor_id_,com.vip.domain.inventory.EditPoRequest poReq_) {
				
				send_editPO(vendor_id_,poReq_);
				return recv_editPO(); 
				
			}
			
			
			private void send_editPO(string vendor_id_,com.vip.domain.inventory.EditPoRequest poReq_){
				
				InitInvocation("editPO");
				
				editPO_args args = new editPO_args();
				args.SetVendor_id(vendor_id_);
				args.SetPoReq(poReq_);
				
				SendBase(args, editPO_argsHelper.getInstance());
			}
			
			
			private com.vip.domain.inventory.OpPoResponse recv_editPO(){
				
				editPO_result result = new editPO_result();
				ReceiveBase(result, editPO_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.domain.inventory.GetPoItemResponse getPoDetailList(string vendor_id_,string systemPoNo_,int pageNum_,int pageSize_) {
				
				send_getPoDetailList(vendor_id_,systemPoNo_,pageNum_,pageSize_);
				return recv_getPoDetailList(); 
				
			}
			
			
			private void send_getPoDetailList(string vendor_id_,string systemPoNo_,int pageNum_,int pageSize_){
				
				InitInvocation("getPoDetailList");
				
				getPoDetailList_args args = new getPoDetailList_args();
				args.SetVendor_id(vendor_id_);
				args.SetSystemPoNo(systemPoNo_);
				args.SetPageNum(pageNum_);
				args.SetPageSize(pageSize_);
				
				SendBase(args, getPoDetailList_argsHelper.getInstance());
			}
			
			
			private com.vip.domain.inventory.GetPoItemResponse recv_getPoDetailList(){
				
				getPoDetailList_result result = new getPoDetailList_result();
				ReceiveBase(result, getPoDetailList_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.hermes.core.health.CheckResult healthCheck() {
				
				send_healthCheck();
				return recv_healthCheck(); 
				
			}
			
			
			private void send_healthCheck(){
				
				InitInvocation("healthCheck");
				
				healthCheck_args args = new healthCheck_args();
				
				SendBase(args, healthCheck_argsHelper.getInstance());
			}
			
			
			private com.vip.hermes.core.health.CheckResult recv_healthCheck(){
				
				healthCheck_result result = new healthCheck_result();
				ReceiveBase(result, healthCheck_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.domain.inventory.OpPoResponse importPoDetail(string vendor_id_,string systemPoNo_,List<com.vip.domain.inventory.PoSku> impSkuList_) {
				
				send_importPoDetail(vendor_id_,systemPoNo_,impSkuList_);
				return recv_importPoDetail(); 
				
			}
			
			
			private void send_importPoDetail(string vendor_id_,string systemPoNo_,List<com.vip.domain.inventory.PoSku> impSkuList_){
				
				InitInvocation("importPoDetail");
				
				importPoDetail_args args = new importPoDetail_args();
				args.SetVendor_id(vendor_id_);
				args.SetSystemPoNo(systemPoNo_);
				args.SetImpSkuList(impSkuList_);
				
				SendBase(args, importPoDetail_argsHelper.getInstance());
			}
			
			
			private com.vip.domain.inventory.OpPoResponse recv_importPoDetail(){
				
				importPoDetail_result result = new importPoDetail_result();
				ReceiveBase(result, importPoDetail_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.domain.inventory.SearchPoResponse searchPoList(string vendor_id_,int pageNum_,int pageSize_,com.vip.domain.inventory.SearchPoRequest searchRequest_) {
				
				send_searchPoList(vendor_id_,pageNum_,pageSize_,searchRequest_);
				return recv_searchPoList(); 
				
			}
			
			
			private void send_searchPoList(string vendor_id_,int pageNum_,int pageSize_,com.vip.domain.inventory.SearchPoRequest searchRequest_){
				
				InitInvocation("searchPoList");
				
				searchPoList_args args = new searchPoList_args();
				args.SetVendor_id(vendor_id_);
				args.SetPageNum(pageNum_);
				args.SetPageSize(pageSize_);
				args.SetSearchRequest(searchRequest_);
				
				SendBase(args, searchPoList_argsHelper.getInstance());
			}
			
			
			private com.vip.domain.inventory.SearchPoResponse recv_searchPoList(){
				
				searchPoList_result result = new searchPoList_result();
				ReceiveBase(result, searchPoList_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.domain.inventory.OpPoResponse submitPo(string vendor_id_,string systemPoNo_) {
				
				send_submitPo(vendor_id_,systemPoNo_);
				return recv_submitPo(); 
				
			}
			
			
			private void send_submitPo(string vendor_id_,string systemPoNo_){
				
				InitInvocation("submitPo");
				
				submitPo_args args = new submitPo_args();
				args.SetVendor_id(vendor_id_);
				args.SetSystemPoNo(systemPoNo_);
				
				SendBase(args, submitPo_argsHelper.getInstance());
			}
			
			
			private com.vip.domain.inventory.OpPoResponse recv_submitPo(){
				
				submitPo_result result = new submitPo_result();
				ReceiveBase(result, submitPo_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}