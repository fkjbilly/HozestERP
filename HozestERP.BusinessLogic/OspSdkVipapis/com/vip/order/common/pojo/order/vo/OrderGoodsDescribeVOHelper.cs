using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class OrderGoodsDescribeVOHelper : TBeanSerializer<OrderGoodsDescribeVO>
	{
		
		public static OrderGoodsDescribeVOHelper OBJ = new OrderGoodsDescribeVOHelper();
		
		public static OrderGoodsDescribeVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderGoodsDescribeVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("seqNum".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetSeqNum(value);
					}
					
					
					
					
					
					if ("descType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetDescType(value);
					}
					
					
					
					
					
					if ("descRemark".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDescRemark(value);
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
		
		
		public void Write(OrderGoodsDescribeVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSeqNum() != null) {
				
				oprot.WriteFieldBegin("seqNum");
				oprot.WriteI32((int)structs.GetSeqNum()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDescType() != null) {
				
				oprot.WriteFieldBegin("descType");
				oprot.WriteI32((int)structs.GetDescType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDescRemark() != null) {
				
				oprot.WriteFieldBegin("descRemark");
				oprot.WriteString(structs.GetDescRemark());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderGoodsDescribeVO bean){
			
			
		}
		
	}
	
}