using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.vo{
	
	
	
	public class OrderCoopVOHelper : TBeanSerializer<OrderCoopVO>
	{
		
		public static OrderCoopVOHelper OBJ = new OrderCoopVOHelper();
		
		public static OrderCoopVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderCoopVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("vipclub".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVipclub(value);
					}
					
					
					
					
					
					if ("exOrderSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetExOrderSn(value);
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
		
		
		public void Write(OrderCoopVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVipclub() != null) {
				
				oprot.WriteFieldBegin("vipclub");
				oprot.WriteString(structs.GetVipclub());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetExOrderSn() != null) {
				
				oprot.WriteFieldBegin("exOrderSn");
				oprot.WriteString(structs.GetExOrderSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderCoopVO bean){
			
			
		}
		
	}
	
}