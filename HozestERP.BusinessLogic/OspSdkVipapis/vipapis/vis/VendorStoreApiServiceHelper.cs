using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.vis{
	
	
	public class VendorStoreApiServiceHelper {
		
		
		
		public class addWarehouseInfo_args {
			
			///<summary>
			///</summary>
			
			private com.vip.vms.common.CommonParam commonParam_;
			
			///<summary>
			///</summary>
			
			private List<com.vip.vms.store.service.StoreAddParam> storeAddParamList_;
			
			public com.vip.vms.common.CommonParam GetCommonParam(){
				return this.commonParam_;
			}
			
			public void SetCommonParam(com.vip.vms.common.CommonParam value){
				this.commonParam_ = value;
			}
			public List<com.vip.vms.store.service.StoreAddParam> GetStoreAddParamList(){
				return this.storeAddParamList_;
			}
			
			public void SetStoreAddParamList(List<com.vip.vms.store.service.StoreAddParam> value){
				this.storeAddParamList_ = value;
			}
			
		}
		
		
		
		
		public class delWarehouseInfo_args {
			
			///<summary>
			///</summary>
			
			private com.vip.vms.common.CommonParam commonParam_;
			
			///<summary>
			///</summary>
			
			private List<com.vip.vms.store.service.StoreDeleteParam> storeDeleteParamList_;
			
			public com.vip.vms.common.CommonParam GetCommonParam(){
				return this.commonParam_;
			}
			
			public void SetCommonParam(com.vip.vms.common.CommonParam value){
				this.commonParam_ = value;
			}
			public List<com.vip.vms.store.service.StoreDeleteParam> GetStoreDeleteParamList(){
				return this.storeDeleteParamList_;
			}
			
			public void SetStoreDeleteParamList(List<com.vip.vms.store.service.StoreDeleteParam> value){
				this.storeDeleteParamList_ = value;
			}
			
		}
		
		
		
		
		public class getStoreByStoreCode_args {
			
			///<summary>
			///</summary>
			
			private com.vip.vms.common.CommonParam commonParam_;
			
			///<summary>
			///</summary>
			
			private string storeCode_;
			
			public com.vip.vms.common.CommonParam GetCommonParam(){
				return this.commonParam_;
			}
			
			public void SetCommonParam(com.vip.vms.common.CommonParam value){
				this.commonParam_ = value;
			}
			public string GetStoreCode(){
				return this.storeCode_;
			}
			
			public void SetStoreCode(string value){
				this.storeCode_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class getWarehouseInfo_args {
			
			///<summary>
			///</summary>
			
			private com.vip.vms.common.CommonParam commonParam_;
			
			///<summary>
			///</summary>
			
			private List<com.vip.vms.store.service.StoreQueryParam> storeQueryParamList_;
			
			public com.vip.vms.common.CommonParam GetCommonParam(){
				return this.commonParam_;
			}
			
			public void SetCommonParam(com.vip.vms.common.CommonParam value){
				this.commonParam_ = value;
			}
			public List<com.vip.vms.store.service.StoreQueryParam> GetStoreQueryParamList(){
				return this.storeQueryParamList_;
			}
			
			public void SetStoreQueryParamList(List<com.vip.vms.store.service.StoreQueryParam> value){
				this.storeQueryParamList_ = value;
			}
			
		}
		
		
		
		
		public class queryStoresByVendorCode_args {
			
			///<summary>
			///</summary>
			
			private com.vip.vms.common.CommonParam commonParam_;
			
			///<summary>
			///</summary>
			
			private int? vendorCode_;
			
			public com.vip.vms.common.CommonParam GetCommonParam(){
				return this.commonParam_;
			}
			
			public void SetCommonParam(com.vip.vms.common.CommonParam value){
				this.commonParam_ = value;
			}
			public int? GetVendorCode(){
				return this.vendorCode_;
			}
			
			public void SetVendorCode(int? value){
				this.vendorCode_ = value;
			}
			
		}
		
		
		
		
		public class updateVendorWarehouseAndVIPWarehouseMap_args {
			
			///<summary>
			///</summary>
			
			private com.vip.vms.common.CommonParam commonParam_;
			
			///<summary>
			///</summary>
			
			private List<com.vip.vms.store.service.StoreWarehouseRelUpdateParam> storeWarehouseRelUpdateParamList_;
			
			public com.vip.vms.common.CommonParam GetCommonParam(){
				return this.commonParam_;
			}
			
			public void SetCommonParam(com.vip.vms.common.CommonParam value){
				this.commonParam_ = value;
			}
			public List<com.vip.vms.store.service.StoreWarehouseRelUpdateParam> GetStoreWarehouseRelUpdateParamList(){
				return this.storeWarehouseRelUpdateParamList_;
			}
			
			public void SetStoreWarehouseRelUpdateParamList(List<com.vip.vms.store.service.StoreWarehouseRelUpdateParam> value){
				this.storeWarehouseRelUpdateParamList_ = value;
			}
			
		}
		
		
		
		
		public class updateWarehouseInfo_args {
			
			///<summary>
			///</summary>
			
			private com.vip.vms.common.CommonParam commonParam_;
			
			///<summary>
			///</summary>
			
			private List<com.vip.vms.store.service.StoreUpdateParam> storeUpdateParamList_;
			
			public com.vip.vms.common.CommonParam GetCommonParam(){
				return this.commonParam_;
			}
			
			public void SetCommonParam(com.vip.vms.common.CommonParam value){
				this.commonParam_ = value;
			}
			public List<com.vip.vms.store.service.StoreUpdateParam> GetStoreUpdateParamList(){
				return this.storeUpdateParamList_;
			}
			
			public void SetStoreUpdateParamList(List<com.vip.vms.store.service.StoreUpdateParam> value){
				this.storeUpdateParamList_ = value;
			}
			
		}
		
		
		
		
		public class addWarehouseInfo_result {
			
			///<summary>
			/// json格式新增供应商门店信息结果
			///</summary>
			
			private string success_;
			
			public string GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(string value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class delWarehouseInfo_result {
			
			///<summary>
			/// json格式删除供应商门店信息结果
			///</summary>
			
			private string success_;
			
			public string GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(string value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getStoreByStoreCode_result {
			
			///<summary>
			/// json格式供应商门店信息
			///</summary>
			
			private string success_;
			
			public string GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(string value){
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
		
		
		
		
		public class getWarehouseInfo_result {
			
			///<summary>
			/// json格式供应商门店信息
			///</summary>
			
			private string success_;
			
			public string GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(string value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class queryStoresByVendorCode_result {
			
			///<summary>
			/// json格式供应商门店信息
			///</summary>
			
			private string success_;
			
			public string GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(string value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class updateVendorWarehouseAndVIPWarehouseMap_result {
			
			///<summary>
			/// json格式更新供应商门店与唯品会仓库对应关系结果
			///</summary>
			
			private string success_;
			
			public string GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(string value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class updateWarehouseInfo_result {
			
			///<summary>
			/// json格式更新供应商门店信息结果
			///</summary>
			
			private string success_;
			
			public string GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(string value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		
		public class addWarehouseInfo_argsHelper : TBeanSerializer<addWarehouseInfo_args>
		{
			
			public static addWarehouseInfo_argsHelper OBJ = new addWarehouseInfo_argsHelper();
			
			public static addWarehouseInfo_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(addWarehouseInfo_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.vms.common.CommonParam value;
					
					value = new com.vip.vms.common.CommonParam();
					com.vip.vms.common.CommonParamHelper.getInstance().Read(value, iprot);
					
					structs.SetCommonParam(value);
				}
				
				
				
				
				
				if(true){
					
					List<com.vip.vms.store.service.StoreAddParam> value;
					
					value = new List<com.vip.vms.store.service.StoreAddParam>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.vms.store.service.StoreAddParam elem1;
							
							elem1 = new com.vip.vms.store.service.StoreAddParam();
							com.vip.vms.store.service.StoreAddParamHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetStoreAddParamList(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(addWarehouseInfo_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetCommonParam() != null) {
					
					oprot.WriteFieldBegin("commonParam");
					
					com.vip.vms.common.CommonParamHelper.getInstance().Write(structs.GetCommonParam(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("commonParam can not be null!");
				}
				
				
				if(structs.GetStoreAddParamList() != null) {
					
					oprot.WriteFieldBegin("storeAddParamList");
					
					oprot.WriteListBegin();
					foreach(com.vip.vms.store.service.StoreAddParam _item0 in structs.GetStoreAddParamList()){
						
						
						com.vip.vms.store.service.StoreAddParamHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("storeAddParamList can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(addWarehouseInfo_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class delWarehouseInfo_argsHelper : TBeanSerializer<delWarehouseInfo_args>
		{
			
			public static delWarehouseInfo_argsHelper OBJ = new delWarehouseInfo_argsHelper();
			
			public static delWarehouseInfo_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(delWarehouseInfo_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.vms.common.CommonParam value;
					
					value = new com.vip.vms.common.CommonParam();
					com.vip.vms.common.CommonParamHelper.getInstance().Read(value, iprot);
					
					structs.SetCommonParam(value);
				}
				
				
				
				
				
				if(true){
					
					List<com.vip.vms.store.service.StoreDeleteParam> value;
					
					value = new List<com.vip.vms.store.service.StoreDeleteParam>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.vms.store.service.StoreDeleteParam elem2;
							
							elem2 = new com.vip.vms.store.service.StoreDeleteParam();
							com.vip.vms.store.service.StoreDeleteParamHelper.getInstance().Read(elem2, iprot);
							
							value.Add(elem2);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetStoreDeleteParamList(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(delWarehouseInfo_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetCommonParam() != null) {
					
					oprot.WriteFieldBegin("commonParam");
					
					com.vip.vms.common.CommonParamHelper.getInstance().Write(structs.GetCommonParam(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("commonParam can not be null!");
				}
				
				
				if(structs.GetStoreDeleteParamList() != null) {
					
					oprot.WriteFieldBegin("storeDeleteParamList");
					
					oprot.WriteListBegin();
					foreach(com.vip.vms.store.service.StoreDeleteParam _item0 in structs.GetStoreDeleteParamList()){
						
						
						com.vip.vms.store.service.StoreDeleteParamHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("storeDeleteParamList can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(delWarehouseInfo_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getStoreByStoreCode_argsHelper : TBeanSerializer<getStoreByStoreCode_args>
		{
			
			public static getStoreByStoreCode_argsHelper OBJ = new getStoreByStoreCode_argsHelper();
			
			public static getStoreByStoreCode_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getStoreByStoreCode_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.vms.common.CommonParam value;
					
					value = new com.vip.vms.common.CommonParam();
					com.vip.vms.common.CommonParamHelper.getInstance().Read(value, iprot);
					
					structs.SetCommonParam(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetStoreCode(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getStoreByStoreCode_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetCommonParam() != null) {
					
					oprot.WriteFieldBegin("commonParam");
					
					com.vip.vms.common.CommonParamHelper.getInstance().Write(structs.GetCommonParam(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("commonParam can not be null!");
				}
				
				
				if(structs.GetStoreCode() != null) {
					
					oprot.WriteFieldBegin("storeCode");
					oprot.WriteString(structs.GetStoreCode());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("storeCode can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getStoreByStoreCode_args bean){
				
				
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
		
		
		
		
		public class getWarehouseInfo_argsHelper : TBeanSerializer<getWarehouseInfo_args>
		{
			
			public static getWarehouseInfo_argsHelper OBJ = new getWarehouseInfo_argsHelper();
			
			public static getWarehouseInfo_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getWarehouseInfo_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.vms.common.CommonParam value;
					
					value = new com.vip.vms.common.CommonParam();
					com.vip.vms.common.CommonParamHelper.getInstance().Read(value, iprot);
					
					structs.SetCommonParam(value);
				}
				
				
				
				
				
				if(true){
					
					List<com.vip.vms.store.service.StoreQueryParam> value;
					
					value = new List<com.vip.vms.store.service.StoreQueryParam>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.vms.store.service.StoreQueryParam elem1;
							
							elem1 = new com.vip.vms.store.service.StoreQueryParam();
							com.vip.vms.store.service.StoreQueryParamHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetStoreQueryParamList(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getWarehouseInfo_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetCommonParam() != null) {
					
					oprot.WriteFieldBegin("commonParam");
					
					com.vip.vms.common.CommonParamHelper.getInstance().Write(structs.GetCommonParam(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("commonParam can not be null!");
				}
				
				
				if(structs.GetStoreQueryParamList() != null) {
					
					oprot.WriteFieldBegin("storeQueryParamList");
					
					oprot.WriteListBegin();
					foreach(com.vip.vms.store.service.StoreQueryParam _item0 in structs.GetStoreQueryParamList()){
						
						
						com.vip.vms.store.service.StoreQueryParamHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("storeQueryParamList can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getWarehouseInfo_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class queryStoresByVendorCode_argsHelper : TBeanSerializer<queryStoresByVendorCode_args>
		{
			
			public static queryStoresByVendorCode_argsHelper OBJ = new queryStoresByVendorCode_argsHelper();
			
			public static queryStoresByVendorCode_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(queryStoresByVendorCode_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.vms.common.CommonParam value;
					
					value = new com.vip.vms.common.CommonParam();
					com.vip.vms.common.CommonParamHelper.getInstance().Read(value, iprot);
					
					structs.SetCommonParam(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendorCode(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(queryStoresByVendorCode_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetCommonParam() != null) {
					
					oprot.WriteFieldBegin("commonParam");
					
					com.vip.vms.common.CommonParamHelper.getInstance().Write(structs.GetCommonParam(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("commonParam can not be null!");
				}
				
				
				if(structs.GetVendorCode() != null) {
					
					oprot.WriteFieldBegin("vendorCode");
					oprot.WriteI32((int)structs.GetVendorCode()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendorCode can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(queryStoresByVendorCode_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateVendorWarehouseAndVIPWarehouseMap_argsHelper : TBeanSerializer<updateVendorWarehouseAndVIPWarehouseMap_args>
		{
			
			public static updateVendorWarehouseAndVIPWarehouseMap_argsHelper OBJ = new updateVendorWarehouseAndVIPWarehouseMap_argsHelper();
			
			public static updateVendorWarehouseAndVIPWarehouseMap_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateVendorWarehouseAndVIPWarehouseMap_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.vms.common.CommonParam value;
					
					value = new com.vip.vms.common.CommonParam();
					com.vip.vms.common.CommonParamHelper.getInstance().Read(value, iprot);
					
					structs.SetCommonParam(value);
				}
				
				
				
				
				
				if(true){
					
					List<com.vip.vms.store.service.StoreWarehouseRelUpdateParam> value;
					
					value = new List<com.vip.vms.store.service.StoreWarehouseRelUpdateParam>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.vms.store.service.StoreWarehouseRelUpdateParam elem1;
							
							elem1 = new com.vip.vms.store.service.StoreWarehouseRelUpdateParam();
							com.vip.vms.store.service.StoreWarehouseRelUpdateParamHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetStoreWarehouseRelUpdateParamList(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateVendorWarehouseAndVIPWarehouseMap_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetCommonParam() != null) {
					
					oprot.WriteFieldBegin("commonParam");
					
					com.vip.vms.common.CommonParamHelper.getInstance().Write(structs.GetCommonParam(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("commonParam can not be null!");
				}
				
				
				if(structs.GetStoreWarehouseRelUpdateParamList() != null) {
					
					oprot.WriteFieldBegin("storeWarehouseRelUpdateParamList");
					
					oprot.WriteListBegin();
					foreach(com.vip.vms.store.service.StoreWarehouseRelUpdateParam _item0 in structs.GetStoreWarehouseRelUpdateParamList()){
						
						
						com.vip.vms.store.service.StoreWarehouseRelUpdateParamHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateVendorWarehouseAndVIPWarehouseMap_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateWarehouseInfo_argsHelper : TBeanSerializer<updateWarehouseInfo_args>
		{
			
			public static updateWarehouseInfo_argsHelper OBJ = new updateWarehouseInfo_argsHelper();
			
			public static updateWarehouseInfo_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateWarehouseInfo_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.vms.common.CommonParam value;
					
					value = new com.vip.vms.common.CommonParam();
					com.vip.vms.common.CommonParamHelper.getInstance().Read(value, iprot);
					
					structs.SetCommonParam(value);
				}
				
				
				
				
				
				if(true){
					
					List<com.vip.vms.store.service.StoreUpdateParam> value;
					
					value = new List<com.vip.vms.store.service.StoreUpdateParam>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.vms.store.service.StoreUpdateParam elem2;
							
							elem2 = new com.vip.vms.store.service.StoreUpdateParam();
							com.vip.vms.store.service.StoreUpdateParamHelper.getInstance().Read(elem2, iprot);
							
							value.Add(elem2);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetStoreUpdateParamList(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateWarehouseInfo_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetCommonParam() != null) {
					
					oprot.WriteFieldBegin("commonParam");
					
					com.vip.vms.common.CommonParamHelper.getInstance().Write(structs.GetCommonParam(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("commonParam can not be null!");
				}
				
				
				if(structs.GetStoreUpdateParamList() != null) {
					
					oprot.WriteFieldBegin("storeUpdateParamList");
					
					oprot.WriteListBegin();
					foreach(com.vip.vms.store.service.StoreUpdateParam _item0 in structs.GetStoreUpdateParamList()){
						
						
						com.vip.vms.store.service.StoreUpdateParamHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("storeUpdateParamList can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateWarehouseInfo_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class addWarehouseInfo_resultHelper : TBeanSerializer<addWarehouseInfo_result>
		{
			
			public static addWarehouseInfo_resultHelper OBJ = new addWarehouseInfo_resultHelper();
			
			public static addWarehouseInfo_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(addWarehouseInfo_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(addWarehouseInfo_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					oprot.WriteString(structs.GetSuccess());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(addWarehouseInfo_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class delWarehouseInfo_resultHelper : TBeanSerializer<delWarehouseInfo_result>
		{
			
			public static delWarehouseInfo_resultHelper OBJ = new delWarehouseInfo_resultHelper();
			
			public static delWarehouseInfo_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(delWarehouseInfo_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(delWarehouseInfo_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					oprot.WriteString(structs.GetSuccess());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(delWarehouseInfo_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getStoreByStoreCode_resultHelper : TBeanSerializer<getStoreByStoreCode_result>
		{
			
			public static getStoreByStoreCode_resultHelper OBJ = new getStoreByStoreCode_resultHelper();
			
			public static getStoreByStoreCode_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getStoreByStoreCode_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getStoreByStoreCode_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					oprot.WriteString(structs.GetSuccess());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getStoreByStoreCode_result bean){
				
				
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
		
		
		
		
		public class getWarehouseInfo_resultHelper : TBeanSerializer<getWarehouseInfo_result>
		{
			
			public static getWarehouseInfo_resultHelper OBJ = new getWarehouseInfo_resultHelper();
			
			public static getWarehouseInfo_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getWarehouseInfo_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getWarehouseInfo_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					oprot.WriteString(structs.GetSuccess());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getWarehouseInfo_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class queryStoresByVendorCode_resultHelper : TBeanSerializer<queryStoresByVendorCode_result>
		{
			
			public static queryStoresByVendorCode_resultHelper OBJ = new queryStoresByVendorCode_resultHelper();
			
			public static queryStoresByVendorCode_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(queryStoresByVendorCode_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(queryStoresByVendorCode_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					oprot.WriteString(structs.GetSuccess());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(queryStoresByVendorCode_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateVendorWarehouseAndVIPWarehouseMap_resultHelper : TBeanSerializer<updateVendorWarehouseAndVIPWarehouseMap_result>
		{
			
			public static updateVendorWarehouseAndVIPWarehouseMap_resultHelper OBJ = new updateVendorWarehouseAndVIPWarehouseMap_resultHelper();
			
			public static updateVendorWarehouseAndVIPWarehouseMap_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateVendorWarehouseAndVIPWarehouseMap_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateVendorWarehouseAndVIPWarehouseMap_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					oprot.WriteString(structs.GetSuccess());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateVendorWarehouseAndVIPWarehouseMap_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateWarehouseInfo_resultHelper : TBeanSerializer<updateWarehouseInfo_result>
		{
			
			public static updateWarehouseInfo_resultHelper OBJ = new updateWarehouseInfo_resultHelper();
			
			public static updateWarehouseInfo_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateWarehouseInfo_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateWarehouseInfo_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					oprot.WriteString(structs.GetSuccess());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateWarehouseInfo_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class VendorStoreApiServiceClient : OspRestStub , VendorStoreApiService  {
			
			
			public VendorStoreApiServiceClient():base("vipapis.vis.VendorStoreApiService","1.3.2") {
				
				
			}
			
			
			
			public string addWarehouseInfo(com.vip.vms.common.CommonParam commonParam_,List<com.vip.vms.store.service.StoreAddParam> storeAddParamList_) {
				
				send_addWarehouseInfo(commonParam_,storeAddParamList_);
				return recv_addWarehouseInfo(); 
				
			}
			
			
			private void send_addWarehouseInfo(com.vip.vms.common.CommonParam commonParam_,List<com.vip.vms.store.service.StoreAddParam> storeAddParamList_){
				
				InitInvocation("addWarehouseInfo");
				
				addWarehouseInfo_args args = new addWarehouseInfo_args();
				args.SetCommonParam(commonParam_);
				args.SetStoreAddParamList(storeAddParamList_);
				
				SendBase(args, addWarehouseInfo_argsHelper.getInstance());
			}
			
			
			private string recv_addWarehouseInfo(){
				
				addWarehouseInfo_result result = new addWarehouseInfo_result();
				ReceiveBase(result, addWarehouseInfo_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public string delWarehouseInfo(com.vip.vms.common.CommonParam commonParam_,List<com.vip.vms.store.service.StoreDeleteParam> storeDeleteParamList_) {
				
				send_delWarehouseInfo(commonParam_,storeDeleteParamList_);
				return recv_delWarehouseInfo(); 
				
			}
			
			
			private void send_delWarehouseInfo(com.vip.vms.common.CommonParam commonParam_,List<com.vip.vms.store.service.StoreDeleteParam> storeDeleteParamList_){
				
				InitInvocation("delWarehouseInfo");
				
				delWarehouseInfo_args args = new delWarehouseInfo_args();
				args.SetCommonParam(commonParam_);
				args.SetStoreDeleteParamList(storeDeleteParamList_);
				
				SendBase(args, delWarehouseInfo_argsHelper.getInstance());
			}
			
			
			private string recv_delWarehouseInfo(){
				
				delWarehouseInfo_result result = new delWarehouseInfo_result();
				ReceiveBase(result, delWarehouseInfo_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public string getStoreByStoreCode(com.vip.vms.common.CommonParam commonParam_,string storeCode_) {
				
				send_getStoreByStoreCode(commonParam_,storeCode_);
				return recv_getStoreByStoreCode(); 
				
			}
			
			
			private void send_getStoreByStoreCode(com.vip.vms.common.CommonParam commonParam_,string storeCode_){
				
				InitInvocation("getStoreByStoreCode");
				
				getStoreByStoreCode_args args = new getStoreByStoreCode_args();
				args.SetCommonParam(commonParam_);
				args.SetStoreCode(storeCode_);
				
				SendBase(args, getStoreByStoreCode_argsHelper.getInstance());
			}
			
			
			private string recv_getStoreByStoreCode(){
				
				getStoreByStoreCode_result result = new getStoreByStoreCode_result();
				ReceiveBase(result, getStoreByStoreCode_resultHelper.getInstance());
				
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
			
			
			public string getWarehouseInfo(com.vip.vms.common.CommonParam commonParam_,List<com.vip.vms.store.service.StoreQueryParam> storeQueryParamList_) {
				
				send_getWarehouseInfo(commonParam_,storeQueryParamList_);
				return recv_getWarehouseInfo(); 
				
			}
			
			
			private void send_getWarehouseInfo(com.vip.vms.common.CommonParam commonParam_,List<com.vip.vms.store.service.StoreQueryParam> storeQueryParamList_){
				
				InitInvocation("getWarehouseInfo");
				
				getWarehouseInfo_args args = new getWarehouseInfo_args();
				args.SetCommonParam(commonParam_);
				args.SetStoreQueryParamList(storeQueryParamList_);
				
				SendBase(args, getWarehouseInfo_argsHelper.getInstance());
			}
			
			
			private string recv_getWarehouseInfo(){
				
				getWarehouseInfo_result result = new getWarehouseInfo_result();
				ReceiveBase(result, getWarehouseInfo_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public string queryStoresByVendorCode(com.vip.vms.common.CommonParam commonParam_,int vendorCode_) {
				
				send_queryStoresByVendorCode(commonParam_,vendorCode_);
				return recv_queryStoresByVendorCode(); 
				
			}
			
			
			private void send_queryStoresByVendorCode(com.vip.vms.common.CommonParam commonParam_,int vendorCode_){
				
				InitInvocation("queryStoresByVendorCode");
				
				queryStoresByVendorCode_args args = new queryStoresByVendorCode_args();
				args.SetCommonParam(commonParam_);
				args.SetVendorCode(vendorCode_);
				
				SendBase(args, queryStoresByVendorCode_argsHelper.getInstance());
			}
			
			
			private string recv_queryStoresByVendorCode(){
				
				queryStoresByVendorCode_result result = new queryStoresByVendorCode_result();
				ReceiveBase(result, queryStoresByVendorCode_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public string updateVendorWarehouseAndVIPWarehouseMap(com.vip.vms.common.CommonParam commonParam_,List<com.vip.vms.store.service.StoreWarehouseRelUpdateParam> storeWarehouseRelUpdateParamList_) {
				
				send_updateVendorWarehouseAndVIPWarehouseMap(commonParam_,storeWarehouseRelUpdateParamList_);
				return recv_updateVendorWarehouseAndVIPWarehouseMap(); 
				
			}
			
			
			private void send_updateVendorWarehouseAndVIPWarehouseMap(com.vip.vms.common.CommonParam commonParam_,List<com.vip.vms.store.service.StoreWarehouseRelUpdateParam> storeWarehouseRelUpdateParamList_){
				
				InitInvocation("updateVendorWarehouseAndVIPWarehouseMap");
				
				updateVendorWarehouseAndVIPWarehouseMap_args args = new updateVendorWarehouseAndVIPWarehouseMap_args();
				args.SetCommonParam(commonParam_);
				args.SetStoreWarehouseRelUpdateParamList(storeWarehouseRelUpdateParamList_);
				
				SendBase(args, updateVendorWarehouseAndVIPWarehouseMap_argsHelper.getInstance());
			}
			
			
			private string recv_updateVendorWarehouseAndVIPWarehouseMap(){
				
				updateVendorWarehouseAndVIPWarehouseMap_result result = new updateVendorWarehouseAndVIPWarehouseMap_result();
				ReceiveBase(result, updateVendorWarehouseAndVIPWarehouseMap_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public string updateWarehouseInfo(com.vip.vms.common.CommonParam commonParam_,List<com.vip.vms.store.service.StoreUpdateParam> storeUpdateParamList_) {
				
				send_updateWarehouseInfo(commonParam_,storeUpdateParamList_);
				return recv_updateWarehouseInfo(); 
				
			}
			
			
			private void send_updateWarehouseInfo(com.vip.vms.common.CommonParam commonParam_,List<com.vip.vms.store.service.StoreUpdateParam> storeUpdateParamList_){
				
				InitInvocation("updateWarehouseInfo");
				
				updateWarehouseInfo_args args = new updateWarehouseInfo_args();
				args.SetCommonParam(commonParam_);
				args.SetStoreUpdateParamList(storeUpdateParamList_);
				
				SendBase(args, updateWarehouseInfo_argsHelper.getInstance());
			}
			
			
			private string recv_updateWarehouseInfo(){
				
				updateWarehouseInfo_result result = new updateWarehouseInfo_result();
				ReceiveBase(result, updateWarehouseInfo_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}