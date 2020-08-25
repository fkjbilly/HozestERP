using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	public class OspOutWmsOrderStatusSModelHelper : TBeanSerializer<OspOutWmsOrderStatusSModel>
	{
		
		public static OspOutWmsOrderStatusSModelHelper OBJ = new OspOutWmsOrderStatusSModelHelper();
		
		public static OspOutWmsOrderStatusSModelHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OspOutWmsOrderStatusSModel structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("logisticsId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetLogisticsId(value);
					}
					
					
					
					
					
					if ("orderSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderSn(value);
					}
					
					
					
					
					
					if ("orderStatus".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderStatus(value);
					}
					
					
					
					
					
					if ("memo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMemo(value);
					}
					
					
					
					
					
					if ("createTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCreateTime(value);
					}
					
					
					
					
					if(needSkip){
						
						ProtocolUtil.skip(iprot);
					}
					
					iprot.ReadFieldEnd();
				}
				
				iprot.ReadStructEnd();
				Validate(structs);
			}
			else{
				
				throw new OspException();
			}
			
			
		}
		
		
		public void Write(OspOutWmsOrderStatusSModel structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetLogisticsId() != null) {
				
				oprot.WriteFieldBegin("logisticsId");
				oprot.WriteString(structs.GetLogisticsId());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("logisticsId can not be null!");
			}
			
			
			if(structs.GetOrderSn() != null) {
				
				oprot.WriteFieldBegin("orderSn");
				oprot.WriteString(structs.GetOrderSn());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("orderSn can not be null!");
			}
			
			
			if(structs.GetOrderStatus() != null) {
				
				oprot.WriteFieldBegin("orderStatus");
				oprot.WriteString(structs.GetOrderStatus());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("orderStatus can not be null!");
			}
			
			
			if(structs.GetMemo() != null) {
				
				oprot.WriteFieldBegin("memo");
				oprot.WriteString(structs.GetMemo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCreateTime() != null) {
				
				oprot.WriteFieldBegin("createTime");
				oprot.WriteString(structs.GetCreateTime());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("createTime can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OspOutWmsOrderStatusSModel bean){
			
			
		}
		
	}
	
}