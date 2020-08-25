using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.user{
	
	
	
	public class GetGroupsResponseHelper : TBeanSerializer<GetGroupsResponse>
	{
		
		public static GetGroupsResponseHelper OBJ = new GetGroupsResponseHelper();
		
		public static GetGroupsResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetGroupsResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("groups".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.user.GroupInfo> value;
						
						value = new List<vipapis.user.GroupInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.user.GroupInfo elem0;
								
								elem0 = new vipapis.user.GroupInfo();
								vipapis.user.GroupInfoHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetGroups(value);
					}
					
					
					
					
					
					if ("total".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetTotal(value);
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
		
		
		public void Write(GetGroupsResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetGroups() != null) {
				
				oprot.WriteFieldBegin("groups");
				
				oprot.WriteListBegin();
				foreach(vipapis.user.GroupInfo _item0 in structs.GetGroups()){
					
					
					vipapis.user.GroupInfoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotal() != null) {
				
				oprot.WriteFieldBegin("total");
				oprot.WriteI32((int)structs.GetTotal()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("total can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetGroupsResponse bean){
			
			
		}
		
	}
	
}