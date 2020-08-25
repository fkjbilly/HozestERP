using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.order{
	
	
	
	public class ReplyStoreSnRespHelper : TBeanSerializer<ReplyStoreSnResp>
	{
		
		public static ReplyStoreSnRespHelper OBJ = new ReplyStoreSnRespHelper();
		
		public static ReplyStoreSnRespHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ReplyStoreSnResp structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("success_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								string elem0;
								elem0 = iprot.ReadString();
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetSuccess_list(value);
					}
					
					
					
					
					
					if ("fail_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.order.FailItem> value;
						
						value = new List<vipapis.order.FailItem>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.order.FailItem elem1;
								
								elem1 = new vipapis.order.FailItem();
								vipapis.order.FailItemHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetFail_list(value);
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
		
		
		public void Write(ReplyStoreSnResp structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSuccess_list() != null) {
				
				oprot.WriteFieldBegin("success_list");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetSuccess_list()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("success_list can not be null!");
			}
			
			
			if(structs.GetFail_list() != null) {
				
				oprot.WriteFieldBegin("fail_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.order.FailItem _item0 in structs.GetFail_list()){
					
					
					vipapis.order.FailItemHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("fail_list can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ReplyStoreSnResp bean){
			
			
		}
		
	}
	
}