using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.product{
	
	
	public class ChannelProductServiceHelper {
		
		
		
		public class getProductImageUrl_args {
			
			///<summary>
			/// 商品ID
			/// @sampleValue product_id 29698121
			///</summary>
			
			private long? product_id_;
			
			///<summary>
			/// 商品库商品id
			/// @sampleValue vendor_spu_id 13092
			///</summary>
			
			private long? vendor_spu_id_;
			
			public long? GetProduct_id(){
				return this.product_id_;
			}
			
			public void SetProduct_id(long? value){
				this.product_id_ = value;
			}
			public long? GetVendor_spu_id(){
				return this.vendor_spu_id_;
			}
			
			public void SetVendor_spu_id(long? value){
				this.vendor_spu_id_ = value;
			}
			
		}
		
		
		
		
		public class getProductList_args {
			
			///<summary>
			/// 渠道名称
			/// @sampleValue channel_name 人人网
			///</summary>
			
			private string channel_name_;
			
			///<summary>
			/// 查询开始时间，按开售时间sell_time_from查(格式：yyyyMMddHHmmss)
			/// @sampleValue start_date start_time=20140602160000
			///</summary>
			
			private string start_date_;
			
			///<summary>
			/// 查询结束时间，按开售时间sell_time_from查(格式：yyyyMMddHHmmss)
			/// @sampleValue end_date end_time=20140702160000
			///</summary>
			
			private string end_date_;
			
			public string GetChannel_name(){
				return this.channel_name_;
			}
			
			public void SetChannel_name(string value){
				this.channel_name_ = value;
			}
			public string GetStart_date(){
				return this.start_date_;
			}
			
			public void SetStart_date(string value){
				this.start_date_ = value;
			}
			public string GetEnd_date(){
				return this.end_date_;
			}
			
			public void SetEnd_date(string value){
				this.end_date_ = value;
			}
			
		}
		
		
		
		
		public class getSizeTable_args {
			
			///<summary>
			/// 尺码表id
			/// @sampleValue size_table_id 13092
			///</summary>
			
			private long? size_table_id_;
			
			public long? GetSize_table_id(){
				return this.size_table_id_;
			}
			
			public void SetSize_table_id(long? value){
				this.size_table_id_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class getProductImageUrl_result {
			
			///<summary>
			///</summary>
			
			private vipapis.product.ImageUrl success_;
			
			public vipapis.product.ImageUrl GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.product.ImageUrl value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getProductList_result {
			
			///<summary>
			///</summary>
			
			private List<vipapis.product.ChannelProduct> success_;
			
			public List<vipapis.product.ChannelProduct> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<vipapis.product.ChannelProduct> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getSizeTable_result {
			
			///<summary>
			///</summary>
			
			private vipapis.product.SizeTable success_;
			
			public vipapis.product.SizeTable GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.product.SizeTable value){
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
		
		
		
		
		
		public class getProductImageUrl_argsHelper : BeanSerializer<getProductImageUrl_args>
		{
			
			public static getProductImageUrl_argsHelper OBJ = new getProductImageUrl_argsHelper();
			
			public static getProductImageUrl_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getProductImageUrl_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetProduct_id(value);
				}
				
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetVendor_spu_id(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getProductImageUrl_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetProduct_id() != null) {
					
					oprot.WriteFieldBegin("product_id");
					oprot.WriteI64((long)structs.GetProduct_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("product_id can not be null!");
				}
				
				
				if(structs.GetVendor_spu_id() != null) {
					
					oprot.WriteFieldBegin("vendor_spu_id");
					oprot.WriteI64((long)structs.GetVendor_spu_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_spu_id can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getProductImageUrl_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getProductList_argsHelper : BeanSerializer<getProductList_args>
		{
			
			public static getProductList_argsHelper OBJ = new getProductList_argsHelper();
			
			public static getProductList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getProductList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetChannel_name(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetStart_date(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetEnd_date(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getProductList_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetChannel_name() != null) {
					
					oprot.WriteFieldBegin("channel_name");
					oprot.WriteString(structs.GetChannel_name());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("channel_name can not be null!");
				}
				
				
				if(structs.GetStart_date() != null) {
					
					oprot.WriteFieldBegin("start_date");
					oprot.WriteString(structs.GetStart_date());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("start_date can not be null!");
				}
				
				
				if(structs.GetEnd_date() != null) {
					
					oprot.WriteFieldBegin("end_date");
					oprot.WriteString(structs.GetEnd_date());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("end_date can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getProductList_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSizeTable_argsHelper : BeanSerializer<getSizeTable_args>
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
		
		
		
		
		public class healthCheck_argsHelper : BeanSerializer<healthCheck_args>
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
		
		
		
		
		public class getProductImageUrl_resultHelper : BeanSerializer<getProductImageUrl_result>
		{
			
			public static getProductImageUrl_resultHelper OBJ = new getProductImageUrl_resultHelper();
			
			public static getProductImageUrl_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getProductImageUrl_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.product.ImageUrl value;
					
					value = new vipapis.product.ImageUrl();
					vipapis.product.ImageUrlHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getProductImageUrl_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.product.ImageUrlHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getProductImageUrl_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getProductList_resultHelper : BeanSerializer<getProductList_result>
		{
			
			public static getProductList_resultHelper OBJ = new getProductList_resultHelper();
			
			public static getProductList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getProductList_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.product.ChannelProduct> value;
					
					value = new List<vipapis.product.ChannelProduct>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.product.ChannelProduct elem0;
							
							elem0 = new vipapis.product.ChannelProduct();
							vipapis.product.ChannelProductHelper.getInstance().Read(elem0, iprot);
							
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
			
			
			public void Write(getProductList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(vipapis.product.ChannelProduct _item0 in structs.GetSuccess()){
						
						
						vipapis.product.ChannelProductHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getProductList_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSizeTable_resultHelper : BeanSerializer<getSizeTable_result>
		{
			
			public static getSizeTable_resultHelper OBJ = new getSizeTable_resultHelper();
			
			public static getSizeTable_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSizeTable_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.product.SizeTable value;
					
					value = new vipapis.product.SizeTable();
					vipapis.product.SizeTableHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSizeTable_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.product.SizeTableHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSizeTable_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class healthCheck_resultHelper : BeanSerializer<healthCheck_result>
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
		
		
		
		
		public class ChannelProductServiceClient : OspRestStub , ChannelProductService  {
			
			
			public ChannelProductServiceClient():base("vipapis.product.ChannelProductService","1.0.0") {
				
				
			}
			
			
			
			public vipapis.product.ImageUrl getProductImageUrl(long product_id_,long vendor_spu_id_) {
				
				send_getProductImageUrl(product_id_,vendor_spu_id_);
				return recv_getProductImageUrl(); 
				
			}
			
			
			private void send_getProductImageUrl(long product_id_,long vendor_spu_id_){
				
				InitInvocation("getProductImageUrl");
				
				getProductImageUrl_args args = new getProductImageUrl_args();
				args.SetProduct_id(product_id_);
				args.SetVendor_spu_id(vendor_spu_id_);
				
				SendBase(args, getProductImageUrl_argsHelper.getInstance());
			}
			
			
			private vipapis.product.ImageUrl recv_getProductImageUrl(){
				
				getProductImageUrl_result result = new getProductImageUrl_result();
				ReceiveBase(result, getProductImageUrl_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<vipapis.product.ChannelProduct> getProductList(string channel_name_,string start_date_,string end_date_) {
				
				send_getProductList(channel_name_,start_date_,end_date_);
				return recv_getProductList(); 
				
			}
			
			
			private void send_getProductList(string channel_name_,string start_date_,string end_date_){
				
				InitInvocation("getProductList");
				
				getProductList_args args = new getProductList_args();
				args.SetChannel_name(channel_name_);
				args.SetStart_date(start_date_);
				args.SetEnd_date(end_date_);
				
				SendBase(args, getProductList_argsHelper.getInstance());
			}
			
			
			private List<vipapis.product.ChannelProduct> recv_getProductList(){
				
				getProductList_result result = new getProductList_result();
				ReceiveBase(result, getProductList_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.product.SizeTable getSizeTable(long size_table_id_) {
				
				send_getSizeTable(size_table_id_);
				return recv_getSizeTable(); 
				
			}
			
			
			private void send_getSizeTable(long size_table_id_){
				
				InitInvocation("getSizeTable");
				
				getSizeTable_args args = new getSizeTable_args();
				args.SetSize_table_id(size_table_id_);
				
				SendBase(args, getSizeTable_argsHelper.getInstance());
			}
			
			
			private vipapis.product.SizeTable recv_getSizeTable(){
				
				getSizeTable_result result = new getSizeTable_result();
				ReceiveBase(result, getSizeTable_resultHelper.getInstance());
				
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
			
			
		}
		
		
	}
	
}