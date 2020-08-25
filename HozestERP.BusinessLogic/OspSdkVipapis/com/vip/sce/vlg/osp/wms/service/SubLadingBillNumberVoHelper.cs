using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	public class SubLadingBillNumberVoHelper : TBeanSerializer<SubLadingBillNumberVo>
	{
		
		public static SubLadingBillNumberVoHelper OBJ = new SubLadingBillNumberVoHelper();
		
		public static SubLadingBillNumberVoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SubLadingBillNumberVo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("subLadingBillNumber".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSubLadingBillNumber(value);
					}
					
					
					
					
					
					if ("weight".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetWeight(value);
					}
					
					
					
					
					
					if ("batchNolist".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.sce.vlg.osp.wms.service.BatchNoVo> value;
						
						value = new List<com.vip.sce.vlg.osp.wms.service.BatchNoVo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.sce.vlg.osp.wms.service.BatchNoVo elem1;
								
								elem1 = new com.vip.sce.vlg.osp.wms.service.BatchNoVo();
								com.vip.sce.vlg.osp.wms.service.BatchNoVoHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetBatchNolist(value);
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
		
		
		public void Write(SubLadingBillNumberVo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSubLadingBillNumber() != null) {
				
				oprot.WriteFieldBegin("subLadingBillNumber");
				oprot.WriteString(structs.GetSubLadingBillNumber());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWeight() != null) {
				
				oprot.WriteFieldBegin("weight");
				oprot.WriteDouble((double)structs.GetWeight());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBatchNolist() != null) {
				
				oprot.WriteFieldBegin("batchNolist");
				
				oprot.WriteListBegin();
				foreach(com.vip.sce.vlg.osp.wms.service.BatchNoVo _item0 in structs.GetBatchNolist()){
					
					
					com.vip.sce.vlg.osp.wms.service.BatchNoVoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("batchNolist can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SubLadingBillNumberVo bean){
			
			
		}
		
	}
	
}