using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.inventory.admin{
	
	
	
	public class ListInvRequestRetryRequestResultHelper : TBeanSerializer<ListInvRequestRetryRequestResult>
	{
		
		public static ListInvRequestRetryRequestResultHelper OBJ = new ListInvRequestRetryRequestResultHelper();
		
		public static ListInvRequestRetryRequestResultHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ListInvRequestRetryRequestResult structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("invUpdateRetryRequestList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.inventory.admin.InvUpdateRetryRequest> value;
						
						value = new List<vipapis.inventory.admin.InvUpdateRetryRequest>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.inventory.admin.InvUpdateRetryRequest elem0;
								
								elem0 = new vipapis.inventory.admin.InvUpdateRetryRequest();
								vipapis.inventory.admin.InvUpdateRetryRequestHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetInvUpdateRetryRequestList(value);
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
		
		
		public void Write(ListInvRequestRetryRequestResult structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetInvUpdateRetryRequestList() != null) {
				
				oprot.WriteFieldBegin("invUpdateRetryRequestList");
				
				oprot.WriteListBegin();
				foreach(vipapis.inventory.admin.InvUpdateRetryRequest _item0 in structs.GetInvUpdateRetryRequestList()){
					
					
					vipapis.inventory.admin.InvUpdateRetryRequestHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ListInvRequestRetryRequestResult bean){
			
			
		}
		
	}
	
}