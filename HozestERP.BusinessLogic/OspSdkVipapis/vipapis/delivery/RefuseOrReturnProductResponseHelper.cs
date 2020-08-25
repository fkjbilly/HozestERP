using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.delivery{
	
	
	
	public class RefuseOrReturnProductResponseHelper : TBeanSerializer<RefuseOrReturnProductResponse>
	{
		
		public static RefuseOrReturnProductResponseHelper OBJ = new RefuseOrReturnProductResponseHelper();
		
		public static RefuseOrReturnProductResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(RefuseOrReturnProductResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("success_num".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetSuccess_num(value);
					}
					
					
					
					
					
					if ("success_data".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.delivery.RefuseOrReturnProductResultInfo> value;
						
						value = new List<vipapis.delivery.RefuseOrReturnProductResultInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.delivery.RefuseOrReturnProductResultInfo elem0;
								
								elem0 = new vipapis.delivery.RefuseOrReturnProductResultInfo();
								vipapis.delivery.RefuseOrReturnProductResultInfoHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetSuccess_data(value);
					}
					
					
					
					
					
					if ("fail_num".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetFail_num(value);
					}
					
					
					
					
					
					if ("fail_data".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.delivery.RefuseOrReturnProductResultInfo> value;
						
						value = new List<vipapis.delivery.RefuseOrReturnProductResultInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.delivery.RefuseOrReturnProductResultInfo elem2;
								
								elem2 = new vipapis.delivery.RefuseOrReturnProductResultInfo();
								vipapis.delivery.RefuseOrReturnProductResultInfoHelper.getInstance().Read(elem2, iprot);
								
								value.Add(elem2);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetFail_data(value);
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
		
		
		public void Write(RefuseOrReturnProductResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSuccess_num() != null) {
				
				oprot.WriteFieldBegin("success_num");
				oprot.WriteI32((int)structs.GetSuccess_num()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSuccess_data() != null) {
				
				oprot.WriteFieldBegin("success_data");
				
				oprot.WriteListBegin();
				foreach(vipapis.delivery.RefuseOrReturnProductResultInfo _item0 in structs.GetSuccess_data()){
					
					
					vipapis.delivery.RefuseOrReturnProductResultInfoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFail_num() != null) {
				
				oprot.WriteFieldBegin("fail_num");
				oprot.WriteI32((int)structs.GetFail_num()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFail_data() != null) {
				
				oprot.WriteFieldBegin("fail_data");
				
				oprot.WriteListBegin();
				foreach(vipapis.delivery.RefuseOrReturnProductResultInfo _item0 in structs.GetFail_data()){
					
					
					vipapis.delivery.RefuseOrReturnProductResultInfoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(RefuseOrReturnProductResponse bean){
			
			
		}
		
	}
	
}