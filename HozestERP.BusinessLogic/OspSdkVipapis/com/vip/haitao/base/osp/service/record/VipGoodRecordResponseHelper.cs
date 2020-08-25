using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.haitao.base.osp.service.record{
	
	
	
	public class VipGoodRecordResponseHelper : TBeanSerializer<VipGoodRecordResponse>
	{
		
		public static VipGoodRecordResponseHelper OBJ = new VipGoodRecordResponseHelper();
		
		public static VipGoodRecordResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(VipGoodRecordResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("respCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRespCode(value);
					}
					
					
					
					
					
					if ("msg".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMsg(value);
					}
					
					
					
					
					
					if ("dataList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.haitao.base.osp.service.record.VipGoodRecordResult> value;
						
						value = new List<com.vip.haitao.base.osp.service.record.VipGoodRecordResult>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.haitao.base.osp.service.record.VipGoodRecordResult elem0;
								
								elem0 = new com.vip.haitao.base.osp.service.record.VipGoodRecordResult();
								com.vip.haitao.base.osp.service.record.VipGoodRecordResultHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetDataList(value);
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
		
		
		public void Write(VipGoodRecordResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetRespCode() != null) {
				
				oprot.WriteFieldBegin("respCode");
				oprot.WriteString(structs.GetRespCode());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("respCode can not be null!");
			}
			
			
			if(structs.GetMsg() != null) {
				
				oprot.WriteFieldBegin("msg");
				oprot.WriteString(structs.GetMsg());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("msg can not be null!");
			}
			
			
			if(structs.GetDataList() != null) {
				
				oprot.WriteFieldBegin("dataList");
				
				oprot.WriteListBegin();
				foreach(com.vip.haitao.base.osp.service.record.VipGoodRecordResult _item0 in structs.GetDataList()){
					
					
					com.vip.haitao.base.osp.service.record.VipGoodRecordResultHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(VipGoodRecordResponse bean){
			
			
		}
		
	}
	
}