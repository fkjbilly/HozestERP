using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.marketplace.sizetable{
	
	
	public class StoreSizeTableServiceHelper {
		
		
		
		public class addSizeDetail_args {
			
			///<summary>
			/// 新增尺码表详情请求
			///</summary>
			
			private vipapis.marketplace.sizetable.AddSizeDetailRequest request_;
			
			public vipapis.marketplace.sizetable.AddSizeDetailRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(vipapis.marketplace.sizetable.AddSizeDetailRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class addSizeTable_args {
			
			///<summary>
			/// 新增店铺尺码表请求
			///</summary>
			
			private vipapis.marketplace.sizetable.AddSizeTableRequest request_;
			
			public vipapis.marketplace.sizetable.AddSizeTableRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(vipapis.marketplace.sizetable.AddSizeTableRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class addSizeTableTemplate_args {
			
			///<summary>
			/// 新增尺码表模板请求
			///</summary>
			
			private vipapis.marketplace.sizetable.AddSizeTableTemplateRequest request_;
			
			public vipapis.marketplace.sizetable.AddSizeTableTemplateRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(vipapis.marketplace.sizetable.AddSizeTableTemplateRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class batchGetSizeDetails_args {
			
			///<summary>
			/// 尺码表详情Id列表
			///</summary>
			
			private List<long?> size_detail_ids_;
			
			public List<long?> GetSize_detail_ids(){
				return this.size_detail_ids_;
			}
			
			public void SetSize_detail_ids(List<long?> value){
				this.size_detail_ids_ = value;
			}
			
		}
		
		
		
		
		public class deleteSizeTableTemplate_args {
			
			///<summary>
			/// 尺码表模板ID
			///</summary>
			
			private int? size_table_template_id_;
			
			public int? GetSize_table_template_id(){
				return this.size_table_template_id_;
			}
			
			public void SetSize_table_template_id(int? value){
				this.size_table_template_id_ = value;
			}
			
		}
		
		
		
		
		public class getSizeTable_args {
			
			///<summary>
			/// 尺码表ID
			///</summary>
			
			private long? size_table_id_;
			
			public long? GetSize_table_id(){
				return this.size_table_id_;
			}
			
			public void SetSize_table_id(long? value){
				this.size_table_id_ = value;
			}
			
		}
		
		
		
		
		public class getSizeTableTemplate_args {
			
			///<summary>
			/// 获取店铺尺码表模板信息请求
			///</summary>
			
			private vipapis.marketplace.sizetable.GetSizeTableTemplateRequest request_;
			
			public vipapis.marketplace.sizetable.GetSizeTableTemplateRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(vipapis.marketplace.sizetable.GetSizeTableTemplateRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class getTemplateTypes_args {
			
			///<summary>
			/// 尺码表模板类型列表
			///</summary>
			
			private List<int?> template_types_;
			
			public List<int?> GetTemplate_types(){
				return this.template_types_;
			}
			
			public void SetTemplate_types(List<int?> value){
				this.template_types_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class updateSizeDetail_args {
			
			///<summary>
			/// 更新尺码表详情请求
			///</summary>
			
			private vipapis.marketplace.sizetable.UpdateSizeDetailRequest request_;
			
			public vipapis.marketplace.sizetable.UpdateSizeDetailRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(vipapis.marketplace.sizetable.UpdateSizeDetailRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class updateSizeTable_args {
			
			///<summary>
			/// 更新店铺尺码表信息请求
			///</summary>
			
			private vipapis.marketplace.sizetable.UpdateSizeTableRequest request_;
			
			public vipapis.marketplace.sizetable.UpdateSizeTableRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(vipapis.marketplace.sizetable.UpdateSizeTableRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class addSizeDetail_result {
			
			///<summary>
			///</summary>
			
			private vipapis.marketplace.sizetable.AddSizeDetailResponse success_;
			
			public vipapis.marketplace.sizetable.AddSizeDetailResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.marketplace.sizetable.AddSizeDetailResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class addSizeTable_result {
			
			///<summary>
			///</summary>
			
			private vipapis.marketplace.sizetable.AddSizeTableResponse success_;
			
			public vipapis.marketplace.sizetable.AddSizeTableResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.marketplace.sizetable.AddSizeTableResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class addSizeTableTemplate_result {
			
			///<summary>
			///</summary>
			
			private vipapis.marketplace.sizetable.AddSizeTableTemplateResponse success_;
			
			public vipapis.marketplace.sizetable.AddSizeTableTemplateResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.marketplace.sizetable.AddSizeTableTemplateResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class batchGetSizeDetails_result {
			
			///<summary>
			///</summary>
			
			private List<vipapis.marketplace.sizetable.SizeDetail> success_;
			
			public List<vipapis.marketplace.sizetable.SizeDetail> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<vipapis.marketplace.sizetable.SizeDetail> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class deleteSizeTableTemplate_result {
			
			
		}
		
		
		
		
		public class getSizeTable_result {
			
			///<summary>
			///</summary>
			
			private vipapis.marketplace.sizetable.SizeTable success_;
			
			public vipapis.marketplace.sizetable.SizeTable GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.marketplace.sizetable.SizeTable value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getSizeTableTemplate_result {
			
			///<summary>
			///</summary>
			
			private vipapis.marketplace.sizetable.GetSizeTableTemplateResponse success_;
			
			public vipapis.marketplace.sizetable.GetSizeTableTemplateResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.marketplace.sizetable.GetSizeTableTemplateResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getTemplateTypes_result {
			
			///<summary>
			///</summary>
			
			private vipapis.marketplace.sizetable.GetTemplateTypeResponse success_;
			
			public vipapis.marketplace.sizetable.GetTemplateTypeResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.marketplace.sizetable.GetTemplateTypeResponse value){
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
		
		
		
		
		public class updateSizeDetail_result {
			
			
		}
		
		
		
		
		public class updateSizeTable_result {
			
			
		}
		
		
		
		
		
		public class addSizeDetail_argsHelper : TBeanSerializer<addSizeDetail_args>
		{
			
			public static addSizeDetail_argsHelper OBJ = new addSizeDetail_argsHelper();
			
			public static addSizeDetail_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(addSizeDetail_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.sizetable.AddSizeDetailRequest value;
					
					value = new vipapis.marketplace.sizetable.AddSizeDetailRequest();
					vipapis.marketplace.sizetable.AddSizeDetailRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(addSizeDetail_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					vipapis.marketplace.sizetable.AddSizeDetailRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(addSizeDetail_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class addSizeTable_argsHelper : TBeanSerializer<addSizeTable_args>
		{
			
			public static addSizeTable_argsHelper OBJ = new addSizeTable_argsHelper();
			
			public static addSizeTable_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(addSizeTable_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.sizetable.AddSizeTableRequest value;
					
					value = new vipapis.marketplace.sizetable.AddSizeTableRequest();
					vipapis.marketplace.sizetable.AddSizeTableRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(addSizeTable_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					vipapis.marketplace.sizetable.AddSizeTableRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(addSizeTable_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class addSizeTableTemplate_argsHelper : TBeanSerializer<addSizeTableTemplate_args>
		{
			
			public static addSizeTableTemplate_argsHelper OBJ = new addSizeTableTemplate_argsHelper();
			
			public static addSizeTableTemplate_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(addSizeTableTemplate_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.sizetable.AddSizeTableTemplateRequest value;
					
					value = new vipapis.marketplace.sizetable.AddSizeTableTemplateRequest();
					vipapis.marketplace.sizetable.AddSizeTableTemplateRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(addSizeTableTemplate_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					vipapis.marketplace.sizetable.AddSizeTableTemplateRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(addSizeTableTemplate_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class batchGetSizeDetails_argsHelper : TBeanSerializer<batchGetSizeDetails_args>
		{
			
			public static batchGetSizeDetails_argsHelper OBJ = new batchGetSizeDetails_argsHelper();
			
			public static batchGetSizeDetails_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(batchGetSizeDetails_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<long?> value;
					
					value = new List<long?>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							long elem0;
							elem0 = iprot.ReadI64(); 
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetSize_detail_ids(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(batchGetSizeDetails_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSize_detail_ids() != null) {
					
					oprot.WriteFieldBegin("size_detail_ids");
					
					oprot.WriteListBegin();
					foreach(long _item0 in structs.GetSize_detail_ids()){
						
						oprot.WriteI64((long)_item0); 
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("size_detail_ids can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(batchGetSizeDetails_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class deleteSizeTableTemplate_argsHelper : TBeanSerializer<deleteSizeTableTemplate_args>
		{
			
			public static deleteSizeTableTemplate_argsHelper OBJ = new deleteSizeTableTemplate_argsHelper();
			
			public static deleteSizeTableTemplate_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(deleteSizeTableTemplate_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetSize_table_template_id(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(deleteSizeTableTemplate_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSize_table_template_id() != null) {
					
					oprot.WriteFieldBegin("size_table_template_id");
					oprot.WriteI32((int)structs.GetSize_table_template_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("size_table_template_id can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(deleteSizeTableTemplate_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSizeTable_argsHelper : TBeanSerializer<getSizeTable_args>
		{
			
			public static getSizeTable_argsHelper OBJ = new getSizeTable_argsHelper();
			
			public static getSizeTable_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSizeTable_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetSize_table_id(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSizeTable_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSize_table_id() != null) {
					
					oprot.WriteFieldBegin("size_table_id");
					oprot.WriteI64((long)structs.GetSize_table_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("size_table_id can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSizeTable_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSizeTableTemplate_argsHelper : TBeanSerializer<getSizeTableTemplate_args>
		{
			
			public static getSizeTableTemplate_argsHelper OBJ = new getSizeTableTemplate_argsHelper();
			
			public static getSizeTableTemplate_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSizeTableTemplate_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.sizetable.GetSizeTableTemplateRequest value;
					
					value = new vipapis.marketplace.sizetable.GetSizeTableTemplateRequest();
					vipapis.marketplace.sizetable.GetSizeTableTemplateRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSizeTableTemplate_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					vipapis.marketplace.sizetable.GetSizeTableTemplateRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSizeTableTemplate_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getTemplateTypes_argsHelper : TBeanSerializer<getTemplateTypes_args>
		{
			
			public static getTemplateTypes_argsHelper OBJ = new getTemplateTypes_argsHelper();
			
			public static getTemplateTypes_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getTemplateTypes_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<int?> value;
					
					value = new List<int?>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							int elem0;
							elem0 = iprot.ReadI32(); 
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetTemplate_types(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getTemplateTypes_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetTemplate_types() != null) {
					
					oprot.WriteFieldBegin("template_types");
					
					oprot.WriteListBegin();
					foreach(int _item0 in structs.GetTemplate_types()){
						
						oprot.WriteI32((int)_item0); 
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getTemplateTypes_args bean){
				
				
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
		
		
		
		
		public class updateSizeDetail_argsHelper : TBeanSerializer<updateSizeDetail_args>
		{
			
			public static updateSizeDetail_argsHelper OBJ = new updateSizeDetail_argsHelper();
			
			public static updateSizeDetail_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateSizeDetail_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.sizetable.UpdateSizeDetailRequest value;
					
					value = new vipapis.marketplace.sizetable.UpdateSizeDetailRequest();
					vipapis.marketplace.sizetable.UpdateSizeDetailRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateSizeDetail_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					vipapis.marketplace.sizetable.UpdateSizeDetailRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateSizeDetail_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateSizeTable_argsHelper : TBeanSerializer<updateSizeTable_args>
		{
			
			public static updateSizeTable_argsHelper OBJ = new updateSizeTable_argsHelper();
			
			public static updateSizeTable_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateSizeTable_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.sizetable.UpdateSizeTableRequest value;
					
					value = new vipapis.marketplace.sizetable.UpdateSizeTableRequest();
					vipapis.marketplace.sizetable.UpdateSizeTableRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateSizeTable_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					vipapis.marketplace.sizetable.UpdateSizeTableRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateSizeTable_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class addSizeDetail_resultHelper : TBeanSerializer<addSizeDetail_result>
		{
			
			public static addSizeDetail_resultHelper OBJ = new addSizeDetail_resultHelper();
			
			public static addSizeDetail_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(addSizeDetail_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.sizetable.AddSizeDetailResponse value;
					
					value = new vipapis.marketplace.sizetable.AddSizeDetailResponse();
					vipapis.marketplace.sizetable.AddSizeDetailResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(addSizeDetail_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.marketplace.sizetable.AddSizeDetailResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(addSizeDetail_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class addSizeTable_resultHelper : TBeanSerializer<addSizeTable_result>
		{
			
			public static addSizeTable_resultHelper OBJ = new addSizeTable_resultHelper();
			
			public static addSizeTable_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(addSizeTable_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.sizetable.AddSizeTableResponse value;
					
					value = new vipapis.marketplace.sizetable.AddSizeTableResponse();
					vipapis.marketplace.sizetable.AddSizeTableResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(addSizeTable_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.marketplace.sizetable.AddSizeTableResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(addSizeTable_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class addSizeTableTemplate_resultHelper : TBeanSerializer<addSizeTableTemplate_result>
		{
			
			public static addSizeTableTemplate_resultHelper OBJ = new addSizeTableTemplate_resultHelper();
			
			public static addSizeTableTemplate_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(addSizeTableTemplate_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.sizetable.AddSizeTableTemplateResponse value;
					
					value = new vipapis.marketplace.sizetable.AddSizeTableTemplateResponse();
					vipapis.marketplace.sizetable.AddSizeTableTemplateResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(addSizeTableTemplate_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.marketplace.sizetable.AddSizeTableTemplateResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(addSizeTableTemplate_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class batchGetSizeDetails_resultHelper : TBeanSerializer<batchGetSizeDetails_result>
		{
			
			public static batchGetSizeDetails_resultHelper OBJ = new batchGetSizeDetails_resultHelper();
			
			public static batchGetSizeDetails_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(batchGetSizeDetails_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.marketplace.sizetable.SizeDetail> value;
					
					value = new List<vipapis.marketplace.sizetable.SizeDetail>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.marketplace.sizetable.SizeDetail elem0;
							
							elem0 = new vipapis.marketplace.sizetable.SizeDetail();
							vipapis.marketplace.sizetable.SizeDetailHelper.getInstance().Read(elem0, iprot);
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(batchGetSizeDetails_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(vipapis.marketplace.sizetable.SizeDetail _item0 in structs.GetSuccess()){
						
						
						vipapis.marketplace.sizetable.SizeDetailHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(batchGetSizeDetails_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class deleteSizeTableTemplate_resultHelper : TBeanSerializer<deleteSizeTableTemplate_result>
		{
			
			public static deleteSizeTableTemplate_resultHelper OBJ = new deleteSizeTableTemplate_resultHelper();
			
			public static deleteSizeTableTemplate_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(deleteSizeTableTemplate_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(deleteSizeTableTemplate_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(deleteSizeTableTemplate_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSizeTable_resultHelper : TBeanSerializer<getSizeTable_result>
		{
			
			public static getSizeTable_resultHelper OBJ = new getSizeTable_resultHelper();
			
			public static getSizeTable_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSizeTable_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.sizetable.SizeTable value;
					
					value = new vipapis.marketplace.sizetable.SizeTable();
					vipapis.marketplace.sizetable.SizeTableHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSizeTable_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.marketplace.sizetable.SizeTableHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSizeTable_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSizeTableTemplate_resultHelper : TBeanSerializer<getSizeTableTemplate_result>
		{
			
			public static getSizeTableTemplate_resultHelper OBJ = new getSizeTableTemplate_resultHelper();
			
			public static getSizeTableTemplate_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSizeTableTemplate_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.sizetable.GetSizeTableTemplateResponse value;
					
					value = new vipapis.marketplace.sizetable.GetSizeTableTemplateResponse();
					vipapis.marketplace.sizetable.GetSizeTableTemplateResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSizeTableTemplate_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.marketplace.sizetable.GetSizeTableTemplateResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSizeTableTemplate_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getTemplateTypes_resultHelper : TBeanSerializer<getTemplateTypes_result>
		{
			
			public static getTemplateTypes_resultHelper OBJ = new getTemplateTypes_resultHelper();
			
			public static getTemplateTypes_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getTemplateTypes_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.sizetable.GetTemplateTypeResponse value;
					
					value = new vipapis.marketplace.sizetable.GetTemplateTypeResponse();
					vipapis.marketplace.sizetable.GetTemplateTypeResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getTemplateTypes_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.marketplace.sizetable.GetTemplateTypeResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getTemplateTypes_result bean){
				
				
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
		
		
		
		
		public class updateSizeDetail_resultHelper : TBeanSerializer<updateSizeDetail_result>
		{
			
			public static updateSizeDetail_resultHelper OBJ = new updateSizeDetail_resultHelper();
			
			public static updateSizeDetail_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateSizeDetail_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateSizeDetail_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateSizeDetail_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateSizeTable_resultHelper : TBeanSerializer<updateSizeTable_result>
		{
			
			public static updateSizeTable_resultHelper OBJ = new updateSizeTable_resultHelper();
			
			public static updateSizeTable_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateSizeTable_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateSizeTable_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateSizeTable_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class StoreSizeTableServiceClient : OspRestStub , StoreSizeTableService  {
			
			
			public StoreSizeTableServiceClient():base("vipapis.marketplace.sizetable.StoreSizeTableService","1.0.0") {
				
				
			}
			
			
			
			public vipapis.marketplace.sizetable.AddSizeDetailResponse addSizeDetail(vipapis.marketplace.sizetable.AddSizeDetailRequest request_) {
				
				send_addSizeDetail(request_);
				return recv_addSizeDetail(); 
				
			}
			
			
			private void send_addSizeDetail(vipapis.marketplace.sizetable.AddSizeDetailRequest request_){
				
				InitInvocation("addSizeDetail");
				
				addSizeDetail_args args = new addSizeDetail_args();
				args.SetRequest(request_);
				
				SendBase(args, addSizeDetail_argsHelper.getInstance());
			}
			
			
			private vipapis.marketplace.sizetable.AddSizeDetailResponse recv_addSizeDetail(){
				
				addSizeDetail_result result = new addSizeDetail_result();
				ReceiveBase(result, addSizeDetail_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.marketplace.sizetable.AddSizeTableResponse addSizeTable(vipapis.marketplace.sizetable.AddSizeTableRequest request_) {
				
				send_addSizeTable(request_);
				return recv_addSizeTable(); 
				
			}
			
			
			private void send_addSizeTable(vipapis.marketplace.sizetable.AddSizeTableRequest request_){
				
				InitInvocation("addSizeTable");
				
				addSizeTable_args args = new addSizeTable_args();
				args.SetRequest(request_);
				
				SendBase(args, addSizeTable_argsHelper.getInstance());
			}
			
			
			private vipapis.marketplace.sizetable.AddSizeTableResponse recv_addSizeTable(){
				
				addSizeTable_result result = new addSizeTable_result();
				ReceiveBase(result, addSizeTable_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.marketplace.sizetable.AddSizeTableTemplateResponse addSizeTableTemplate(vipapis.marketplace.sizetable.AddSizeTableTemplateRequest request_) {
				
				send_addSizeTableTemplate(request_);
				return recv_addSizeTableTemplate(); 
				
			}
			
			
			private void send_addSizeTableTemplate(vipapis.marketplace.sizetable.AddSizeTableTemplateRequest request_){
				
				InitInvocation("addSizeTableTemplate");
				
				addSizeTableTemplate_args args = new addSizeTableTemplate_args();
				args.SetRequest(request_);
				
				SendBase(args, addSizeTableTemplate_argsHelper.getInstance());
			}
			
			
			private vipapis.marketplace.sizetable.AddSizeTableTemplateResponse recv_addSizeTableTemplate(){
				
				addSizeTableTemplate_result result = new addSizeTableTemplate_result();
				ReceiveBase(result, addSizeTableTemplate_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<vipapis.marketplace.sizetable.SizeDetail> batchGetSizeDetails(List<long?> size_detail_ids_) {
				
				send_batchGetSizeDetails(size_detail_ids_);
				return recv_batchGetSizeDetails(); 
				
			}
			
			
			private void send_batchGetSizeDetails(List<long?> size_detail_ids_){
				
				InitInvocation("batchGetSizeDetails");
				
				batchGetSizeDetails_args args = new batchGetSizeDetails_args();
				args.SetSize_detail_ids(size_detail_ids_);
				
				SendBase(args, batchGetSizeDetails_argsHelper.getInstance());
			}
			
			
			private List<vipapis.marketplace.sizetable.SizeDetail> recv_batchGetSizeDetails(){
				
				batchGetSizeDetails_result result = new batchGetSizeDetails_result();
				ReceiveBase(result, batchGetSizeDetails_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public void deleteSizeTableTemplate(int size_table_template_id_) {
				
				send_deleteSizeTableTemplate(size_table_template_id_);
				recv_deleteSizeTableTemplate();
				
			}
			
			
			private void send_deleteSizeTableTemplate(int size_table_template_id_){
				
				InitInvocation("deleteSizeTableTemplate");
				
				deleteSizeTableTemplate_args args = new deleteSizeTableTemplate_args();
				args.SetSize_table_template_id(size_table_template_id_);
				
				SendBase(args, deleteSizeTableTemplate_argsHelper.getInstance());
			}
			
			
			private void recv_deleteSizeTableTemplate(){
				
				deleteSizeTableTemplate_result result = new deleteSizeTableTemplate_result();
				ReceiveBase(result, deleteSizeTableTemplate_resultHelper.getInstance());
				
				
			}
			
			
			public vipapis.marketplace.sizetable.SizeTable getSizeTable(long size_table_id_) {
				
				send_getSizeTable(size_table_id_);
				return recv_getSizeTable(); 
				
			}
			
			
			private void send_getSizeTable(long size_table_id_){
				
				InitInvocation("getSizeTable");
				
				getSizeTable_args args = new getSizeTable_args();
				args.SetSize_table_id(size_table_id_);
				
				SendBase(args, getSizeTable_argsHelper.getInstance());
			}
			
			
			private vipapis.marketplace.sizetable.SizeTable recv_getSizeTable(){
				
				getSizeTable_result result = new getSizeTable_result();
				ReceiveBase(result, getSizeTable_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.marketplace.sizetable.GetSizeTableTemplateResponse getSizeTableTemplate(vipapis.marketplace.sizetable.GetSizeTableTemplateRequest request_) {
				
				send_getSizeTableTemplate(request_);
				return recv_getSizeTableTemplate(); 
				
			}
			
			
			private void send_getSizeTableTemplate(vipapis.marketplace.sizetable.GetSizeTableTemplateRequest request_){
				
				InitInvocation("getSizeTableTemplate");
				
				getSizeTableTemplate_args args = new getSizeTableTemplate_args();
				args.SetRequest(request_);
				
				SendBase(args, getSizeTableTemplate_argsHelper.getInstance());
			}
			
			
			private vipapis.marketplace.sizetable.GetSizeTableTemplateResponse recv_getSizeTableTemplate(){
				
				getSizeTableTemplate_result result = new getSizeTableTemplate_result();
				ReceiveBase(result, getSizeTableTemplate_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.marketplace.sizetable.GetTemplateTypeResponse getTemplateTypes(List<int?> template_types_) {
				
				send_getTemplateTypes(template_types_);
				return recv_getTemplateTypes(); 
				
			}
			
			
			private void send_getTemplateTypes(List<int?> template_types_){
				
				InitInvocation("getTemplateTypes");
				
				getTemplateTypes_args args = new getTemplateTypes_args();
				args.SetTemplate_types(template_types_);
				
				SendBase(args, getTemplateTypes_argsHelper.getInstance());
			}
			
			
			private vipapis.marketplace.sizetable.GetTemplateTypeResponse recv_getTemplateTypes(){
				
				getTemplateTypes_result result = new getTemplateTypes_result();
				ReceiveBase(result, getTemplateTypes_resultHelper.getInstance());
				
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
			
			
			public void updateSizeDetail(vipapis.marketplace.sizetable.UpdateSizeDetailRequest request_) {
				
				send_updateSizeDetail(request_);
				recv_updateSizeDetail();
				
			}
			
			
			private void send_updateSizeDetail(vipapis.marketplace.sizetable.UpdateSizeDetailRequest request_){
				
				InitInvocation("updateSizeDetail");
				
				updateSizeDetail_args args = new updateSizeDetail_args();
				args.SetRequest(request_);
				
				SendBase(args, updateSizeDetail_argsHelper.getInstance());
			}
			
			
			private void recv_updateSizeDetail(){
				
				updateSizeDetail_result result = new updateSizeDetail_result();
				ReceiveBase(result, updateSizeDetail_resultHelper.getInstance());
				
				
			}
			
			
			public void updateSizeTable(vipapis.marketplace.sizetable.UpdateSizeTableRequest request_) {
				
				send_updateSizeTable(request_);
				recv_updateSizeTable();
				
			}
			
			
			private void send_updateSizeTable(vipapis.marketplace.sizetable.UpdateSizeTableRequest request_){
				
				InitInvocation("updateSizeTable");
				
				updateSizeTable_args args = new updateSizeTable_args();
				args.SetRequest(request_);
				
				SendBase(args, updateSizeTable_argsHelper.getInstance());
			}
			
			
			private void recv_updateSizeTable(){
				
				updateSizeTable_result result = new updateSizeTable_result();
				ReceiveBase(result, updateSizeTable_resultHelper.getInstance());
				
				
			}
			
			
		}
		
		
	}
	
}