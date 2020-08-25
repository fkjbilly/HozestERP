using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	public class OrderBatchDetailInfoHelper : TBeanSerializer<OrderBatchDetailInfo>
	{
		
		public static OrderBatchDetailInfoHelper OBJ = new OrderBatchDetailInfoHelper();
		
		public static OrderBatchDetailInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderBatchDetailInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("oderSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOderSn(value);
					}
					
					
					
					
					
					if ("seqNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSeqNo(value);
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
		
		
		public void Write(OrderBatchDetailInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOderSn() != null) {
				
				oprot.WriteFieldBegin("oderSn");
				oprot.WriteString(structs.GetOderSn());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("oderSn can not be null!");
			}
			
			
			if(structs.GetSeqNo() != null) {
				
				oprot.WriteFieldBegin("seqNo");
				oprot.WriteString(structs.GetSeqNo());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("seqNo can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderBatchDetailInfo bean){
			
			
		}
		
	}
	
}