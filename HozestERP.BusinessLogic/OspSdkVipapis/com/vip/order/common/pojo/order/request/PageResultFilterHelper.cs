using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.request{
	
	
	
	public class PageResultFilterHelper : TBeanSerializer<PageResultFilter>
	{
		
		public static PageResultFilterHelper OBJ = new PageResultFilterHelper();
		
		public static PageResultFilterHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(PageResultFilter structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("limit".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetLimit(value);
					}
					
					
					
					
					
					if ("offset".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetOffset(value);
					}
					
					
					
					
					
					if ("orderby".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.request.OrderBy> value;
						
						value = new List<com.vip.order.common.pojo.order.request.OrderBy>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.request.OrderBy elem0;
								
								elem0 = new com.vip.order.common.pojo.order.request.OrderBy();
								com.vip.order.common.pojo.order.request.OrderByHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderby(value);
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
		
		
		public void Write(PageResultFilter structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetLimit() != null) {
				
				oprot.WriteFieldBegin("limit");
				oprot.WriteI32((int)structs.GetLimit()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOffset() != null) {
				
				oprot.WriteFieldBegin("offset");
				oprot.WriteI32((int)structs.GetOffset()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderby() != null) {
				
				oprot.WriteFieldBegin("orderby");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.request.OrderBy _item0 in structs.GetOrderby()){
					
					
					com.vip.order.common.pojo.order.request.OrderByHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(PageResultFilter bean){
			
			
		}
		
	}
	
}