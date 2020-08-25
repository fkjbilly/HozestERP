using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.vreturn{
	
	
	public class VendorReturnServiceHelper {
		
		
		
		public class getReturnDetail_args {
			
			///<summary>
			/// 供应商ID
			/// @sampleValue vendor_id vend234
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 仓库
			/// @sampleValue warehouse warehouse=VIP_NH,退供仓库只支持下面仓库(VIP_NH, VIP_SH, VIP_CD, VIP_HZ, VIP_BJ, VIP_HK，VIP_TYO，VIP_NYC，VIP_PAR，VIP_SEL，VIP_SYD，VIP_LON，VIP_FRA，VIP_MIL)
			///</summary>
			
			private vipapis.common.Warehouse? warehouse_;
			
			///<summary>
			/// 退供单号
			/// @sampleValue return_sn return_sn=RTV14102800001NH
			///</summary>
			
			private string return_sn_;
			
			///<summary>
			/// 起始出仓时间(格式为yyyy-MM-dd HH:mm:ss,最早为查询当天的服务器时间的180天内，超过180天可能无数据)
			/// @sampleValue out_time_start out_time_start=2015-05-05 00:00:00
			///</summary>
			
			private string out_time_start_;
			
			///<summary>
			/// 截止出仓时间(格式为yyyy-MM-dd HH:mm:ss,最晚为查询当天的服务器时间)
			/// @sampleValue out_time_end out_time_end=2015-05-05 00:00:00
			///</summary>
			
			private string out_time_end_;
			
			///<summary>
			/// 页码参数
			/// @sampleValue page page=1
			///</summary>
			
			private int? page_;
			
			///<summary>
			/// 返回结果数量(默认为50,最大支持100)
			/// @sampleValue limit limit=50
			///</summary>
			
			private int? limit_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public vipapis.common.Warehouse? GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(vipapis.common.Warehouse? value){
				this.warehouse_ = value;
			}
			public string GetReturn_sn(){
				return this.return_sn_;
			}
			
			public void SetReturn_sn(string value){
				this.return_sn_ = value;
			}
			public string GetOut_time_start(){
				return this.out_time_start_;
			}
			
			public void SetOut_time_start(string value){
				this.out_time_start_ = value;
			}
			public string GetOut_time_end(){
				return this.out_time_end_;
			}
			
			public void SetOut_time_end(string value){
				this.out_time_end_ = value;
			}
			public int? GetPage(){
				return this.page_;
			}
			
			public void SetPage(int? value){
				this.page_ = value;
			}
			public int? GetLimit(){
				return this.limit_;
			}
			
			public void SetLimit(int? value){
				this.limit_ = value;
			}
			
		}
		
		
		
		
		public class getReturnInfo_args {
			
			///<summary>
			/// 供应商ID
			/// @sampleValue vendor_id vendor=1234
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 仓库
			/// @sampleValue warehouse warehouse=VIP_NH,退供仓库只支持下面仓库(VIP_NH, VIP_SH, VIP_CD, VIP_HZ, VIP_BJ, VIP_HK，VIP_TYO，VIP_NYC，VIP_PAR，VIP_SEL，VIP_SYD，VIP_LON，VIP_FRA，VIP_MIL)
			///</summary>
			
			private vipapis.common.Warehouse? warehouse_;
			
			///<summary>
			/// 退供单号
			/// @sampleValue return_sn return_sn=RTV14102800001NH
			///</summary>
			
			private string return_sn_;
			
			///<summary>
			/// 开始时间(格式为yyyy-MM-dd HH:mm:ss,最早为查询当天的服务器时间的180天内，超过180天可能无数据)
			/// @sampleValue st_create_time st_create_time=2015-05-05 00:00:00
			///</summary>
			
			private string st_create_time_;
			
			///<summary>
			/// 结束时间(格式为yyyy-MM-dd HH:mm:ss,最晚为查询当天的服务器时间)
			/// @sampleValue ed_create_time ed_create_time=2015-05-05 00:00:00
			///</summary>
			
			private string ed_create_time_;
			
			///<summary>
			/// 页码参数
			/// @sampleValue page page=1
			///</summary>
			
			private int? page_;
			
			///<summary>
			/// 返回结果数量(默认为50,最大支持100)
			/// @sampleValue limit limit=50
			///</summary>
			
			private int? limit_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public vipapis.common.Warehouse? GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(vipapis.common.Warehouse? value){
				this.warehouse_ = value;
			}
			public string GetReturn_sn(){
				return this.return_sn_;
			}
			
			public void SetReturn_sn(string value){
				this.return_sn_ = value;
			}
			public string GetSt_create_time(){
				return this.st_create_time_;
			}
			
			public void SetSt_create_time(string value){
				this.st_create_time_ = value;
			}
			public string GetEd_create_time(){
				return this.ed_create_time_;
			}
			
			public void SetEd_create_time(string value){
				this.ed_create_time_ = value;
			}
			public int? GetPage(){
				return this.page_;
			}
			
			public void SetPage(int? value){
				this.page_ = value;
			}
			public int? GetLimit(){
				return this.limit_;
			}
			
			public void SetLimit(int? value){
				this.limit_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class getReturnDetail_result {
			
			///<summary>
			///</summary>
			
			private vipapis.vreturn.GetReturnDetailResponse success_;
			
			public vipapis.vreturn.GetReturnDetailResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.vreturn.GetReturnDetailResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getReturnInfo_result {
			
			///<summary>
			///</summary>
			
			private vipapis.vreturn.GetReturnInfoResponse success_;
			
			public vipapis.vreturn.GetReturnInfoResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.vreturn.GetReturnInfoResponse value){
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
		
		
		
		
		
		public class getReturnDetail_argsHelper : TBeanSerializer<getReturnDetail_args>
		{
			
			public static getReturnDetail_argsHelper OBJ = new getReturnDetail_argsHelper();
			
			public static getReturnDetail_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getReturnDetail_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					vipapis.common.Warehouse? value;
					
					value = vipapis.common.WarehouseUtil.FindByName(iprot.ReadString());
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetReturn_sn(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetOut_time_start(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetOut_time_end(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetPage(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetLimit(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getReturnDetail_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteI32((int)structs.GetVendor_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse().ToString());  
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("warehouse can not be null!");
				}
				
				
				if(structs.GetReturn_sn() != null) {
					
					oprot.WriteFieldBegin("return_sn");
					oprot.WriteString(structs.GetReturn_sn());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetOut_time_start() != null) {
					
					oprot.WriteFieldBegin("out_time_start");
					oprot.WriteString(structs.GetOut_time_start());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetOut_time_end() != null) {
					
					oprot.WriteFieldBegin("out_time_end");
					oprot.WriteString(structs.GetOut_time_end());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetPage() != null) {
					
					oprot.WriteFieldBegin("page");
					oprot.WriteI32((int)structs.GetPage()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetLimit() != null) {
					
					oprot.WriteFieldBegin("limit");
					oprot.WriteI32((int)structs.GetLimit()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getReturnDetail_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getReturnInfo_argsHelper : TBeanSerializer<getReturnInfo_args>
		{
			
			public static getReturnInfo_argsHelper OBJ = new getReturnInfo_argsHelper();
			
			public static getReturnInfo_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getReturnInfo_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					vipapis.common.Warehouse? value;
					
					value = vipapis.common.WarehouseUtil.FindByName(iprot.ReadString());
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetReturn_sn(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSt_create_time(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetEd_create_time(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetPage(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetLimit(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getReturnInfo_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteI32((int)structs.GetVendor_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse().ToString());  
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("warehouse can not be null!");
				}
				
				
				if(structs.GetReturn_sn() != null) {
					
					oprot.WriteFieldBegin("return_sn");
					oprot.WriteString(structs.GetReturn_sn());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetSt_create_time() != null) {
					
					oprot.WriteFieldBegin("st_create_time");
					oprot.WriteString(structs.GetSt_create_time());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetEd_create_time() != null) {
					
					oprot.WriteFieldBegin("ed_create_time");
					oprot.WriteString(structs.GetEd_create_time());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetPage() != null) {
					
					oprot.WriteFieldBegin("page");
					oprot.WriteI32((int)structs.GetPage()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetLimit() != null) {
					
					oprot.WriteFieldBegin("limit");
					oprot.WriteI32((int)structs.GetLimit()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getReturnInfo_args bean){
				
				
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
		
		
		
		
		public class getReturnDetail_resultHelper : TBeanSerializer<getReturnDetail_result>
		{
			
			public static getReturnDetail_resultHelper OBJ = new getReturnDetail_resultHelper();
			
			public static getReturnDetail_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getReturnDetail_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.vreturn.GetReturnDetailResponse value;
					
					value = new vipapis.vreturn.GetReturnDetailResponse();
					vipapis.vreturn.GetReturnDetailResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getReturnDetail_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.vreturn.GetReturnDetailResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getReturnDetail_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getReturnInfo_resultHelper : TBeanSerializer<getReturnInfo_result>
		{
			
			public static getReturnInfo_resultHelper OBJ = new getReturnInfo_resultHelper();
			
			public static getReturnInfo_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getReturnInfo_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.vreturn.GetReturnInfoResponse value;
					
					value = new vipapis.vreturn.GetReturnInfoResponse();
					vipapis.vreturn.GetReturnInfoResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getReturnInfo_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.vreturn.GetReturnInfoResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getReturnInfo_result bean){
				
				
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
		
		
		
		
		public class VendorReturnServiceClient : OspRestStub , VendorReturnService  {
			
			
			public VendorReturnServiceClient():base("vipapis.vreturn.VendorReturnService","1.0.0") {
				
				
			}
			
			
			
			public vipapis.vreturn.GetReturnDetailResponse getReturnDetail(int vendor_id_,vipapis.common.Warehouse? warehouse_,string return_sn_,string out_time_start_,string out_time_end_,int? page_,int? limit_) {
				
				send_getReturnDetail(vendor_id_,warehouse_,return_sn_,out_time_start_,out_time_end_,page_,limit_);
				return recv_getReturnDetail(); 
				
			}
			
			
			private void send_getReturnDetail(int vendor_id_,vipapis.common.Warehouse? warehouse_,string return_sn_,string out_time_start_,string out_time_end_,int? page_,int? limit_){
				
				InitInvocation("getReturnDetail");
				
				getReturnDetail_args args = new getReturnDetail_args();
				args.SetVendor_id(vendor_id_);
				args.SetWarehouse(warehouse_);
				args.SetReturn_sn(return_sn_);
				args.SetOut_time_start(out_time_start_);
				args.SetOut_time_end(out_time_end_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				
				SendBase(args, getReturnDetail_argsHelper.getInstance());
			}
			
			
			private vipapis.vreturn.GetReturnDetailResponse recv_getReturnDetail(){
				
				getReturnDetail_result result = new getReturnDetail_result();
				ReceiveBase(result, getReturnDetail_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.vreturn.GetReturnInfoResponse getReturnInfo(int vendor_id_,vipapis.common.Warehouse? warehouse_,string return_sn_,string st_create_time_,string ed_create_time_,int? page_,int? limit_) {
				
				send_getReturnInfo(vendor_id_,warehouse_,return_sn_,st_create_time_,ed_create_time_,page_,limit_);
				return recv_getReturnInfo(); 
				
			}
			
			
			private void send_getReturnInfo(int vendor_id_,vipapis.common.Warehouse? warehouse_,string return_sn_,string st_create_time_,string ed_create_time_,int? page_,int? limit_){
				
				InitInvocation("getReturnInfo");
				
				getReturnInfo_args args = new getReturnInfo_args();
				args.SetVendor_id(vendor_id_);
				args.SetWarehouse(warehouse_);
				args.SetReturn_sn(return_sn_);
				args.SetSt_create_time(st_create_time_);
				args.SetEd_create_time(ed_create_time_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				
				SendBase(args, getReturnInfo_argsHelper.getInstance());
			}
			
			
			private vipapis.vreturn.GetReturnInfoResponse recv_getReturnInfo(){
				
				getReturnInfo_result result = new getReturnInfo_result();
				ReceiveBase(result, getReturnInfo_resultHelper.getInstance());
				
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