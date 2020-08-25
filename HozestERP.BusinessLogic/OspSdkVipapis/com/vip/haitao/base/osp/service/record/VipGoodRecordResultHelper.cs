using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.haitao.base.osp.service.record{
	
	
	
	public class VipGoodRecordResultHelper : TBeanSerializer<VipGoodRecordResult>
	{
		
		public static VipGoodRecordResultHelper OBJ = new VipGoodRecordResultHelper();
		
		public static VipGoodRecordResultHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(VipGoodRecordResult structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("header".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.haitao.base.osp.service.record.VipGoodRecordHeader value;
						
						value = new com.vip.haitao.base.osp.service.record.VipGoodRecordHeader();
						com.vip.haitao.base.osp.service.record.VipGoodRecordHeaderHelper.getInstance().Read(value, iprot);
						
						structs.SetHeader(value);
					}
					
					
					
					
					
					if ("dataList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.haitao.base.osp.service.record.VipGoodRecordModel> value;
						
						value = new List<com.vip.haitao.base.osp.service.record.VipGoodRecordModel>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.haitao.base.osp.service.record.VipGoodRecordModel elem1;
								
								elem1 = new com.vip.haitao.base.osp.service.record.VipGoodRecordModel();
								com.vip.haitao.base.osp.service.record.VipGoodRecordModelHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
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
		
		
		public void Write(VipGoodRecordResult structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetHeader() != null) {
				
				oprot.WriteFieldBegin("header");
				
				com.vip.haitao.base.osp.service.record.VipGoodRecordHeaderHelper.getInstance().Write(structs.GetHeader(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDataList() != null) {
				
				oprot.WriteFieldBegin("dataList");
				
				oprot.WriteListBegin();
				foreach(com.vip.haitao.base.osp.service.record.VipGoodRecordModel _item0 in structs.GetDataList()){
					
					
					com.vip.haitao.base.osp.service.record.VipGoodRecordModelHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(VipGoodRecordResult bean){
			
			
		}
		
	}
	
}