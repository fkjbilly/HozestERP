using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.address{
	
	
	public class AddressServiceHelper {
		
		
		
		public class getFullAddress_args {
			
			///<summary>
			/// 父级地址id
			/// @sampleValue area_code area_code=914101101101
			///</summary>
			
			private string area_code_;
			
			///<summary>
			/// 是否显示港澳台地址,0:只显示大陆地址；1:只显示港澳台；-1:显示全部
			/// @sampleValue is_show_gat Is_Show_GAT.SHOW_MAINLAND
			///</summary>
			
			private vipapis.address.Is_Show_GAT? is_show_gat_;
			
			///<summary>
			/// 是否在遇到直辖的时候追加显示下级
			/// @sampleValue is_bind is_bind=true
			///</summary>
			
			private bool? is_bind_;
			
			public string GetArea_code(){
				return this.area_code_;
			}
			
			public void SetArea_code(string value){
				this.area_code_ = value;
			}
			public vipapis.address.Is_Show_GAT? GetIs_show_gat(){
				return this.is_show_gat_;
			}
			
			public void SetIs_show_gat(vipapis.address.Is_Show_GAT? value){
				this.is_show_gat_ = value;
			}
			public bool? GetIs_bind(){
				return this.is_bind_;
			}
			
			public void SetIs_bind(bool? value){
				this.is_bind_ = value;
			}
			
		}
		
		
		
		
		public class getProvinceWarehouse_args {
			
			///<summary>
			/// 是否显示港澳台地址,0:只显示大陆地址；1:只显示港澳台；-1:显示全部
			/// @sampleValue is_show_gat Is_Show_GAT.SHOW_MAINLAND
			///</summary>
			
			private vipapis.address.Is_Show_GAT? is_show_gat_;
			
			public vipapis.address.Is_Show_GAT? GetIs_show_gat(){
				return this.is_show_gat_;
			}
			
			public void SetIs_show_gat(vipapis.address.Is_Show_GAT? value){
				this.is_show_gat_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class getFullAddress_result {
			
			///<summary>
			///</summary>
			
			private vipapis.address.FullAddress success_;
			
			public vipapis.address.FullAddress GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.address.FullAddress value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getProvinceWarehouse_result {
			
			///<summary>
			///</summary>
			
			private List<vipapis.address.ProvinceWarehouse> success_;
			
			public List<vipapis.address.ProvinceWarehouse> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<vipapis.address.ProvinceWarehouse> value){
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
		
		
		
		
		
		public class getFullAddress_argsHelper : TBeanSerializer<getFullAddress_args>
		{
			
			public static getFullAddress_argsHelper OBJ = new getFullAddress_argsHelper();
			
			public static getFullAddress_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getFullAddress_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetArea_code(value);
				}
				
				
				
				
				
				if(true){
					
					vipapis.address.Is_Show_GAT? value;
					
					value = vipapis.address.Is_Show_GATUtil.FindByName(iprot.ReadString());
					
					structs.SetIs_show_gat(value);
				}
				
				
				
				
				
				if(true){
					
					bool? value;
					value = iprot.ReadBool();
					
					structs.SetIs_bind(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getFullAddress_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetArea_code() != null) {
					
					oprot.WriteFieldBegin("area_code");
					oprot.WriteString(structs.GetArea_code());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("area_code can not be null!");
				}
				
				
				if(structs.GetIs_show_gat() != null) {
					
					oprot.WriteFieldBegin("is_show_gat");
					oprot.WriteString(structs.GetIs_show_gat().ToString());  
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetIs_bind() != null) {
					
					oprot.WriteFieldBegin("is_bind");
					oprot.WriteBool((bool)structs.GetIs_bind());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getFullAddress_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getProvinceWarehouse_argsHelper : TBeanSerializer<getProvinceWarehouse_args>
		{
			
			public static getProvinceWarehouse_argsHelper OBJ = new getProvinceWarehouse_argsHelper();
			
			public static getProvinceWarehouse_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getProvinceWarehouse_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.address.Is_Show_GAT? value;
					
					value = vipapis.address.Is_Show_GATUtil.FindByName(iprot.ReadString());
					
					structs.SetIs_show_gat(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getProvinceWarehouse_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetIs_show_gat() != null) {
					
					oprot.WriteFieldBegin("is_show_gat");
					oprot.WriteString(structs.GetIs_show_gat().ToString());  
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getProvinceWarehouse_args bean){
				
				
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
		
		
		
		
		public class getFullAddress_resultHelper : TBeanSerializer<getFullAddress_result>
		{
			
			public static getFullAddress_resultHelper OBJ = new getFullAddress_resultHelper();
			
			public static getFullAddress_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getFullAddress_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.address.FullAddress value;
					
					value = new vipapis.address.FullAddress();
					vipapis.address.FullAddressHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getFullAddress_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.address.FullAddressHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getFullAddress_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getProvinceWarehouse_resultHelper : TBeanSerializer<getProvinceWarehouse_result>
		{
			
			public static getProvinceWarehouse_resultHelper OBJ = new getProvinceWarehouse_resultHelper();
			
			public static getProvinceWarehouse_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getProvinceWarehouse_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.address.ProvinceWarehouse> value;
					
					value = new List<vipapis.address.ProvinceWarehouse>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.address.ProvinceWarehouse elem0;
							
							elem0 = new vipapis.address.ProvinceWarehouse();
							vipapis.address.ProvinceWarehouseHelper.getInstance().Read(elem0, iprot);
							
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
			
			
			public void Write(getProvinceWarehouse_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(vipapis.address.ProvinceWarehouse _item0 in structs.GetSuccess()){
						
						
						vipapis.address.ProvinceWarehouseHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getProvinceWarehouse_result bean){
				
				
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
		
		
		
		
		public class AddressServiceClient : OspRestStub , AddressService  {
			
			
			public AddressServiceClient():base("vipapis.address.AddressService","1.0.0") {
				
				
			}
			
			
			
			public vipapis.address.FullAddress getFullAddress(string area_code_,vipapis.address.Is_Show_GAT? is_show_gat_,bool? is_bind_) {
				
				send_getFullAddress(area_code_,is_show_gat_,is_bind_);
				return recv_getFullAddress(); 
				
			}
			
			
			private void send_getFullAddress(string area_code_,vipapis.address.Is_Show_GAT? is_show_gat_,bool? is_bind_){
				
				InitInvocation("getFullAddress");
				
				getFullAddress_args args = new getFullAddress_args();
				args.SetArea_code(area_code_);
				args.SetIs_show_gat(is_show_gat_);
				args.SetIs_bind(is_bind_);
				
				SendBase(args, getFullAddress_argsHelper.getInstance());
			}
			
			
			private vipapis.address.FullAddress recv_getFullAddress(){
				
				getFullAddress_result result = new getFullAddress_result();
				ReceiveBase(result, getFullAddress_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<vipapis.address.ProvinceWarehouse> getProvinceWarehouse(vipapis.address.Is_Show_GAT? is_show_gat_) {
				
				send_getProvinceWarehouse(is_show_gat_);
				return recv_getProvinceWarehouse(); 
				
			}
			
			
			private void send_getProvinceWarehouse(vipapis.address.Is_Show_GAT? is_show_gat_){
				
				InitInvocation("getProvinceWarehouse");
				
				getProvinceWarehouse_args args = new getProvinceWarehouse_args();
				args.SetIs_show_gat(is_show_gat_);
				
				SendBase(args, getProvinceWarehouse_argsHelper.getInstance());
			}
			
			
			private List<vipapis.address.ProvinceWarehouse> recv_getProvinceWarehouse(){
				
				getProvinceWarehouse_result result = new getProvinceWarehouse_result();
				ReceiveBase(result, getProvinceWarehouse_resultHelper.getInstance());
				
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