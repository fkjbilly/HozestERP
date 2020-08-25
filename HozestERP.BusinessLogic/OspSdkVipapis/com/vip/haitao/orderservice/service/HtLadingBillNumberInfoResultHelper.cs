using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.haitao.orderservice.service{
	
	
	
	public class HtLadingBillNumberInfoResultHelper : TBeanSerializer<HtLadingBillNumberInfoResult>
	{
		
		public static HtLadingBillNumberInfoResultHelper OBJ = new HtLadingBillNumberInfoResultHelper();
		
		public static HtLadingBillNumberInfoResultHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(HtLadingBillNumberInfoResult structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("head".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.haitao.orderservice.service.Head value;
						
						value = new com.vip.haitao.orderservice.service.Head();
						com.vip.haitao.orderservice.service.HeadHelper.getInstance().Read(value, iprot);
						
						structs.SetHead(value);
					}
					
					
					
					
					
					if ("ladingBill".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.haitao.orderservice.service.HtLadingBillNumberManagmentModel value;
						
						value = new com.vip.haitao.orderservice.service.HtLadingBillNumberManagmentModel();
						com.vip.haitao.orderservice.service.HtLadingBillNumberManagmentModelHelper.getInstance().Read(value, iprot);
						
						structs.SetLadingBill(value);
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
		
		
		public void Write(HtLadingBillNumberInfoResult structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetHead() != null) {
				
				oprot.WriteFieldBegin("head");
				
				com.vip.haitao.orderservice.service.HeadHelper.getInstance().Write(structs.GetHead(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetLadingBill() != null) {
				
				oprot.WriteFieldBegin("ladingBill");
				
				com.vip.haitao.orderservice.service.HtLadingBillNumberManagmentModelHelper.getInstance().Write(structs.GetLadingBill(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(HtLadingBillNumberInfoResult bean){
			
			
		}
		
	}
	
}