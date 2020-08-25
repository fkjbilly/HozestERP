using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace com.vip.vms.store.service{
	
	
	public class VendorStoreApiServiceHelper {
		
		
		
		public class addStores_args {
			
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
		
		
		
		
		public class deleteStores_args {
			
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
		
		
		
		
		public class queryStores_args {
			
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
		
		
		
		
		public class updateStoreWarehouseRel_args {
			
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
		
		
		
		
		public class updateStores_args {
			
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
		
		
		
		
		public class addStores_result {
			
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
		
		
		
		
		public class deleteStores_result {
			
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
		
		
		
		
		public class queryStores_result {
			
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
		
		
		
		
		public class updateStoreWarehouseRel_result {
			
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
		
		
		
		
		public class updateStores_result {
			
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
		
		
		
		
		
		public class addStores_argsHelper : BeanSerializer<addStores_args>
		{
			
			public static addStores_argsHelper OBJ = new addStores_argsHelper();
			
			public static addStores_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(addStores_args structs, Protocol iprot){
				
				
				
				
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
			
			
			public void Write(addStores_args structs, Protocol oprot){
				
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
			
			
			public void Validate(addStores_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class deleteStores_argsHelper : BeanSerializer<deleteStores_args>
		{
			
			public static deleteStores_argsHelper OBJ = new deleteStores_argsHelper();
			
			public static deleteStores_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(deleteStores_args structs, Protocol iprot){
				
				
				
				
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
			
			
			public void Write(deleteStores_args structs, Protocol oprot){
				
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
			
			
			public void Validate(deleteStores_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getStoreByStoreCode_argsHelper : BeanSerializer<getStoreByStoreCode_args>
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
		
		
		
		
		public class queryStores_argsHelper : BeanSerializer<queryStores_args>
		{
			
			public static queryStores_argsHelper OBJ = new queryStores_argsHelper();
			
			public static queryStores_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(queryStores_args structs, Protocol iprot){
				
				
				
				
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
			
			
			public void Write(queryStores_args structs, Protocol oprot){
				
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
			
			
			public void Validate(queryStores_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class queryStoresByVendorCode_argsHelper : BeanSerializer<queryStoresByVendorCode_args>
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
		
		
		
		
		public class updateStoreWarehouseRel_argsHelper : BeanSerializer<updateStoreWarehouseRel_args>
		{
			
			public static updateStoreWarehouseRel_argsHelper OBJ = new updateStoreWarehouseRel_argsHelper();
			
			public static updateStoreWarehouseRel_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateStoreWarehouseRel_args structs, Protocol iprot){
				
				
				
				
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
			
			
			public void Write(updateStoreWarehouseRel_args structs, Protocol oprot){
				
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
			
			
			public void Validate(updateStoreWarehouseRel_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateStores_argsHelper : BeanSerializer<updateStores_args>
		{
			
			public static updateStores_argsHelper OBJ = new updateStores_argsHelper();
			
			public static updateStores_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateStores_args structs, Protocol iprot){
				
				
				
				
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
			
			
			public void Write(updateStores_args structs, Protocol oprot){
				
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
			
			
			public void Validate(updateStores_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class addStores_resultHelper : BeanSerializer<addStores_result>
		{
			
			public static addStores_resultHelper OBJ = new addStores_resultHelper();
			
			public static addStores_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(addStores_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(addStores_result structs, Protocol oprot){
				
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
			
			
			public void Validate(addStores_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class deleteStores_resultHelper : BeanSerializer<deleteStores_result>
		{
			
			public static deleteStores_resultHelper OBJ = new deleteStores_resultHelper();
			
			public static deleteStores_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(deleteStores_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(deleteStores_result structs, Protocol oprot){
				
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
			
			
			public void Validate(deleteStores_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getStoreByStoreCode_resultHelper : BeanSerializer<getStoreByStoreCode_result>
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
		
		
		
		
		public class queryStores_resultHelper : BeanSerializer<queryStores_result>
		{
			
			public static queryStores_resultHelper OBJ = new queryStores_resultHelper();
			
			public static queryStores_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(queryStores_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(queryStores_result structs, Protocol oprot){
				
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
			
			
			public void Validate(queryStores_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class queryStoresByVendorCode_resultHelper : BeanSerializer<queryStoresByVendorCode_result>
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
		
		
		
		
		public class updateStoreWarehouseRel_resultHelper : BeanSerializer<updateStoreWarehouseRel_result>
		{
			
			public static updateStoreWarehouseRel_resultHelper OBJ = new updateStoreWarehouseRel_resultHelper();
			
			public static updateStoreWarehouseRel_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateStoreWarehouseRel_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateStoreWarehouseRel_result structs, Protocol oprot){
				
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
			
			
			public void Validate(updateStoreWarehouseRel_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateStores_resultHelper : BeanSerializer<updateStores_result>
		{
			
			public static updateStores_resultHelper OBJ = new updateStores_resultHelper();
			
			public static updateStores_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateStores_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateStores_result structs, Protocol oprot){
				
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
			
			
			public void Validate(updateStores_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class VendorStoreApiServiceClient : OspRestStub , VendorStoreApiService  {
			
			
			public VendorStoreApiServiceClient():base("com.vip.vms.store.service.VendorStoreApiService","1.2.0") {
				
				
			}
			
			
			
			public string addStores(com.vip.vms.common.CommonParam commonParam_,List<com.vip.vms.store.service.StoreAddParam> storeAddParamList_) {
				
				send_addStores(commonParam_,storeAddParamList_);
				return recv_addStores(); 
				
			}
			
			
			private void send_addStores(com.vip.vms.common.CommonParam commonParam_,List<com.vip.vms.store.service.StoreAddParam> storeAddParamList_){
				
				InitInvocation("addStores");
				
				addStores_args args = new addStores_args();
				args.SetCommonParam(commonParam_);
				args.SetStoreAddParamList(storeAddParamList_);
				
				SendBase(args, addStores_argsHelper.getInstance());
			}
			
			
			private string recv_addStores(){
				
				addStores_result result = new addStores_result();
				ReceiveBase(result, addStores_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public string deleteStores(com.vip.vms.common.CommonParam commonParam_,List<com.vip.vms.store.service.StoreDeleteParam> storeDeleteParamList_) {
				
				send_deleteStores(commonParam_,storeDeleteParamList_);
				return recv_deleteStores(); 
				
			}
			
			
			private void send_deleteStores(com.vip.vms.common.CommonParam commonParam_,List<com.vip.vms.store.service.StoreDeleteParam> storeDeleteParamList_){
				
				InitInvocation("deleteStores");
				
				deleteStores_args args = new deleteStores_args();
				args.SetCommonParam(commonParam_);
				args.SetStoreDeleteParamList(storeDeleteParamList_);
				
				SendBase(args, deleteStores_argsHelper.getInstance());
			}
			
			
			private string recv_deleteStores(){
				
				deleteStores_result result = new deleteStores_result();
				ReceiveBase(result, deleteStores_resultHelper.getInstance());
				
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
			
			
			public string queryStores(com.vip.vms.common.CommonParam commonParam_,List<com.vip.vms.store.service.StoreQueryParam> storeQueryParamList_) {
				
				send_queryStores(commonParam_,storeQueryParamList_);
				return recv_queryStores(); 
				
			}
			
			
			private void send_queryStores(com.vip.vms.common.CommonParam commonParam_,List<com.vip.vms.store.service.StoreQueryParam> storeQueryParamList_){
				
				InitInvocation("queryStores");
				
				queryStores_args args = new queryStores_args();
				args.SetCommonParam(commonParam_);
				args.SetStoreQueryParamList(storeQueryParamList_);
				
				SendBase(args, queryStores_argsHelper.getInstance());
			}
			
			
			private string recv_queryStores(){
				
				queryStores_result result = new queryStores_result();
				ReceiveBase(result, queryStores_resultHelper.getInstance());
				
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
			
			
			public string updateStoreWarehouseRel(com.vip.vms.common.CommonParam commonParam_,List<com.vip.vms.store.service.StoreWarehouseRelUpdateParam> storeWarehouseRelUpdateParamList_) {
				
				send_updateStoreWarehouseRel(commonParam_,storeWarehouseRelUpdateParamList_);
				return recv_updateStoreWarehouseRel(); 
				
			}
			
			
			private void send_updateStoreWarehouseRel(com.vip.vms.common.CommonParam commonParam_,List<com.vip.vms.store.service.StoreWarehouseRelUpdateParam> storeWarehouseRelUpdateParamList_){
				
				InitInvocation("updateStoreWarehouseRel");
				
				updateStoreWarehouseRel_args args = new updateStoreWarehouseRel_args();
				args.SetCommonParam(commonParam_);
				args.SetStoreWarehouseRelUpdateParamList(storeWarehouseRelUpdateParamList_);
				
				SendBase(args, updateStoreWarehouseRel_argsHelper.getInstance());
			}
			
			
			private string recv_updateStoreWarehouseRel(){
				
				updateStoreWarehouseRel_result result = new updateStoreWarehouseRel_result();
				ReceiveBase(result, updateStoreWarehouseRel_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public string updateStores(com.vip.vms.common.CommonParam commonParam_,List<com.vip.vms.store.service.StoreUpdateParam> storeUpdateParamList_) {
				
				send_updateStores(commonParam_,storeUpdateParamList_);
				return recv_updateStores(); 
				
			}
			
			
			private void send_updateStores(com.vip.vms.common.CommonParam commonParam_,List<com.vip.vms.store.service.StoreUpdateParam> storeUpdateParamList_){
				
				InitInvocation("updateStores");
				
				updateStores_args args = new updateStores_args();
				args.SetCommonParam(commonParam_);
				args.SetStoreUpdateParamList(storeUpdateParamList_);
				
				SendBase(args, updateStores_argsHelper.getInstance());
			}
			
			
			private string recv_updateStores(){
				
				updateStores_result result = new updateStores_result();
				ReceiveBase(result, updateStores_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}