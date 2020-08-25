using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.vop.omni.logistics{
	
	
	
	public class WaybillRouteHelper : TBeanSerializer<WaybillRoute>
	{
		
		public static WaybillRouteHelper OBJ = new WaybillRouteHelper();
		
		public static WaybillRouteHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(WaybillRoute structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("routeId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRouteId(value);
					}
					
					
					
					
					
					if ("orderSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderSn(value);
					}
					
					
					
					
					
					if ("transportNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransportNo(value);
					}
					
					
					
					
					
					if ("acceptTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAcceptTime(value);
					}
					
					
					
					
					
					if ("acceptAddress".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAcceptAddress(value);
					}
					
					
					
					
					
					if ("remark".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRemark(value);
					}
					
					
					
					
					
					if ("opCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOpCode(value);
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
		
		
		public void Write(WaybillRoute structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetRouteId() != null) {
				
				oprot.WriteFieldBegin("routeId");
				oprot.WriteString(structs.GetRouteId());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("routeId can not be null!");
			}
			
			
			if(structs.GetOrderSn() != null) {
				
				oprot.WriteFieldBegin("orderSn");
				oprot.WriteString(structs.GetOrderSn());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("orderSn can not be null!");
			}
			
			
			if(structs.GetTransportNo() != null) {
				
				oprot.WriteFieldBegin("transportNo");
				oprot.WriteString(structs.GetTransportNo());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("transportNo can not be null!");
			}
			
			
			if(structs.GetAcceptTime() != null) {
				
				oprot.WriteFieldBegin("acceptTime");
				oprot.WriteString(structs.GetAcceptTime());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("acceptTime can not be null!");
			}
			
			
			if(structs.GetAcceptAddress() != null) {
				
				oprot.WriteFieldBegin("acceptAddress");
				oprot.WriteString(structs.GetAcceptAddress());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("acceptAddress can not be null!");
			}
			
			
			if(structs.GetRemark() != null) {
				
				oprot.WriteFieldBegin("remark");
				oprot.WriteString(structs.GetRemark());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("remark can not be null!");
			}
			
			
			if(structs.GetOpCode() != null) {
				
				oprot.WriteFieldBegin("opCode");
				oprot.WriteString(structs.GetOpCode());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("opCode can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(WaybillRoute bean){
			
			
		}
		
	}
	
}