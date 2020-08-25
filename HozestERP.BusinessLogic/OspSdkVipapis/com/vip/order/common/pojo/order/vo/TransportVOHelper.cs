using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class TransportVOHelper : TBeanSerializer<TransportVO>
	{
		
		public static TransportVOHelper OBJ = new TransportVOHelper();
		
		public static TransportVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(TransportVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("transportNumber".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransportNumber(value);
					}
					
					
					
					
					
					if ("transportOperatorLogList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.TransportOperateLogVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.TransportOperateLogVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.TransportOperateLogVO elem0;
								
								elem0 = new com.vip.order.common.pojo.order.vo.TransportOperateLogVO();
								com.vip.order.common.pojo.order.vo.TransportOperateLogVOHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetTransportOperatorLogList(value);
					}
					
					
					
					
					
					if ("isCod".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetIsCod(value);
					}
					
					
					
					
					
					if ("transportName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransportName(value);
					}
					
					
					
					
					
					if ("transportId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransportId(value);
					}
					
					
					
					
					
					if ("transportTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetTransportTime(value);
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
		
		
		public void Write(TransportVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetTransportNumber() != null) {
				
				oprot.WriteFieldBegin("transportNumber");
				oprot.WriteString(structs.GetTransportNumber());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransportOperatorLogList() != null) {
				
				oprot.WriteFieldBegin("transportOperatorLogList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.TransportOperateLogVO _item0 in structs.GetTransportOperatorLogList()){
					
					
					com.vip.order.common.pojo.order.vo.TransportOperateLogVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsCod() != null) {
				
				oprot.WriteFieldBegin("isCod");
				oprot.WriteI32((int)structs.GetIsCod()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransportName() != null) {
				
				oprot.WriteFieldBegin("transportName");
				oprot.WriteString(structs.GetTransportName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransportId() != null) {
				
				oprot.WriteFieldBegin("transportId");
				oprot.WriteString(structs.GetTransportId());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransportTime() != null) {
				
				oprot.WriteFieldBegin("transportTime");
				oprot.WriteI64((long)structs.GetTransportTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(TransportVO bean){
			
			
		}
		
	}
	
}