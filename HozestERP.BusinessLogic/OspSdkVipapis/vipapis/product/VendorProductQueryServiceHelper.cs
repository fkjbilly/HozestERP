using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.product{
	
	
	public class VendorProductQueryServiceHelper {
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class queryByBarcode_args {
			
			///<summary>
			/// 供应商ID
			/// @sampleValue vendor_id 525
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 条形码
			/// @sampleValue barcode 113113302011245
			///</summary>
			
			private string barcode_;
			
			///<summary>
			/// 表示查询唯品会商品资料数据源自哪个库，默认查询发布库。<br>1：发布库。表示商品资料经过审核，已正式发布生效；<br>0：草稿库。表示商品资料已经提交到唯品会，但是未经过最后审核确认，是中间状态。
			///</summary>
			
			private int? source_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public string GetBarcode(){
				return this.barcode_;
			}
			
			public void SetBarcode(string value){
				this.barcode_ = value;
			}
			public int? GetSource(){
				return this.source_;
			}
			
			public void SetSource(int? value){
				this.source_ = value;
			}
			
		}
		
		
		
		
		public class queryByBrandAndSn_args {
			
			///<summary>
			/// 供应商ID
			/// @sampleValue vendor_id 525
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 品牌ID
			/// @sampleValue brand_id 456413215
			///</summary>
			
			private int? brand_id_;
			
			///<summary>
			/// 款号
			/// @sampleValue sn 113113302011
			///</summary>
			
			private string sn_;
			
			///<summary>
			/// 表示查询唯品会商品资料数据源自的哪个库，默认查询发布库。<br>1：发布库。表示商品资料经过审核，已正式发布生效；<br>0：草稿库。表示商品资料已经提交到唯品会，但是未经过最后审核确认，是中间状态。
			///</summary>
			
			private int? source_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public int? GetBrand_id(){
				return this.brand_id_;
			}
			
			public void SetBrand_id(int? value){
				this.brand_id_ = value;
			}
			public string GetSn(){
				return this.sn_;
			}
			
			public void SetSn(string value){
				this.sn_ = value;
			}
			public int? GetSource(){
				return this.source_;
			}
			
			public void SetSource(int? value){
				this.source_ = value;
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
		
		
		
		
		public class queryByBarcode_result {
			
			///<summary>
			///</summary>
			
			private List<vipapis.product.SpuWithSkusBaseInfo> success_;
			
			public List<vipapis.product.SpuWithSkusBaseInfo> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<vipapis.product.SpuWithSkusBaseInfo> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class queryByBrandAndSn_result {
			
			///<summary>
			///</summary>
			
			private List<vipapis.product.SpuWithSkusBaseInfo> success_;
			
			public List<vipapis.product.SpuWithSkusBaseInfo> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<vipapis.product.SpuWithSkusBaseInfo> value){
				this.success_ = value;
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
		
		
		
		
		public class queryByBarcode_argsHelper : TBeanSerializer<queryByBarcode_args>
		{
			
			public static queryByBarcode_argsHelper OBJ = new queryByBarcode_argsHelper();
			
			public static queryByBarcode_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(queryByBarcode_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetBarcode(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetSource(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(queryByBarcode_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetBarcode() != null) {
					
					oprot.WriteFieldBegin("barcode");
					oprot.WriteString(structs.GetBarcode());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("barcode can not be null!");
				}
				
				
				if(structs.GetSource() != null) {
					
					oprot.WriteFieldBegin("source");
					oprot.WriteI32((int)structs.GetSource()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(queryByBarcode_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class queryByBrandAndSn_argsHelper : TBeanSerializer<queryByBrandAndSn_args>
		{
			
			public static queryByBrandAndSn_argsHelper OBJ = new queryByBrandAndSn_argsHelper();
			
			public static queryByBrandAndSn_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(queryByBrandAndSn_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetBrand_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSn(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetSource(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(queryByBrandAndSn_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetBrand_id() != null) {
					
					oprot.WriteFieldBegin("brand_id");
					oprot.WriteI32((int)structs.GetBrand_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("brand_id can not be null!");
				}
				
				
				if(structs.GetSn() != null) {
					
					oprot.WriteFieldBegin("sn");
					oprot.WriteString(structs.GetSn());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sn can not be null!");
				}
				
				
				if(structs.GetSource() != null) {
					
					oprot.WriteFieldBegin("source");
					oprot.WriteI32((int)structs.GetSource()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(queryByBrandAndSn_args bean){
				
				
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
		
		
		
		
		public class queryByBarcode_resultHelper : TBeanSerializer<queryByBarcode_result>
		{
			
			public static queryByBarcode_resultHelper OBJ = new queryByBarcode_resultHelper();
			
			public static queryByBarcode_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(queryByBarcode_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.product.SpuWithSkusBaseInfo> value;
					
					value = new List<vipapis.product.SpuWithSkusBaseInfo>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.product.SpuWithSkusBaseInfo elem0;
							
							elem0 = new vipapis.product.SpuWithSkusBaseInfo();
							vipapis.product.SpuWithSkusBaseInfoHelper.getInstance().Read(elem0, iprot);
							
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
			
			
			public void Write(queryByBarcode_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(vipapis.product.SpuWithSkusBaseInfo _item0 in structs.GetSuccess()){
						
						
						vipapis.product.SpuWithSkusBaseInfoHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(queryByBarcode_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class queryByBrandAndSn_resultHelper : TBeanSerializer<queryByBrandAndSn_result>
		{
			
			public static queryByBrandAndSn_resultHelper OBJ = new queryByBrandAndSn_resultHelper();
			
			public static queryByBrandAndSn_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(queryByBrandAndSn_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.product.SpuWithSkusBaseInfo> value;
					
					value = new List<vipapis.product.SpuWithSkusBaseInfo>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.product.SpuWithSkusBaseInfo elem1;
							
							elem1 = new vipapis.product.SpuWithSkusBaseInfo();
							vipapis.product.SpuWithSkusBaseInfoHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
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
			
			
			public void Write(queryByBrandAndSn_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(vipapis.product.SpuWithSkusBaseInfo _item0 in structs.GetSuccess()){
						
						
						vipapis.product.SpuWithSkusBaseInfoHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(queryByBrandAndSn_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class VendorProductQueryServiceClient : OspRestStub , VendorProductQueryService  {
			
			
			public VendorProductQueryServiceClient():base("vipapis.product.VendorProductQueryService","1.0.0") {
				
				
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
			
			
			public List<vipapis.product.SpuWithSkusBaseInfo> queryByBarcode(int vendor_id_,string barcode_,int? source_) {
				
				send_queryByBarcode(vendor_id_,barcode_,source_);
				return recv_queryByBarcode(); 
				
			}
			
			
			private void send_queryByBarcode(int vendor_id_,string barcode_,int? source_){
				
				InitInvocation("queryByBarcode");
				
				queryByBarcode_args args = new queryByBarcode_args();
				args.SetVendor_id(vendor_id_);
				args.SetBarcode(barcode_);
				args.SetSource(source_);
				
				SendBase(args, queryByBarcode_argsHelper.getInstance());
			}
			
			
			private List<vipapis.product.SpuWithSkusBaseInfo> recv_queryByBarcode(){
				
				queryByBarcode_result result = new queryByBarcode_result();
				ReceiveBase(result, queryByBarcode_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<vipapis.product.SpuWithSkusBaseInfo> queryByBrandAndSn(int vendor_id_,int brand_id_,string sn_,int? source_) {
				
				send_queryByBrandAndSn(vendor_id_,brand_id_,sn_,source_);
				return recv_queryByBrandAndSn(); 
				
			}
			
			
			private void send_queryByBrandAndSn(int vendor_id_,int brand_id_,string sn_,int? source_){
				
				InitInvocation("queryByBrandAndSn");
				
				queryByBrandAndSn_args args = new queryByBrandAndSn_args();
				args.SetVendor_id(vendor_id_);
				args.SetBrand_id(brand_id_);
				args.SetSn(sn_);
				args.SetSource(source_);
				
				SendBase(args, queryByBrandAndSn_argsHelper.getInstance());
			}
			
			
			private List<vipapis.product.SpuWithSkusBaseInfo> recv_queryByBrandAndSn(){
				
				queryByBrandAndSn_result result = new queryByBrandAndSn_result();
				ReceiveBase(result, queryByBrandAndSn_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}