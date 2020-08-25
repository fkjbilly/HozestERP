using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class GetOrdersBySizeIdReqHelper : TBeanSerializer<GetOrdersBySizeIdReq>
	{
		
		public static GetOrdersBySizeIdReqHelper OBJ = new GetOrdersBySizeIdReqHelper();
		
		public static GetOrdersBySizeIdReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetOrdersBySizeIdReq structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("sizeId".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetSizeId(value);
					}
					
					
					
					
					
					if ("orderStatusSet".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<int?> value;
						
						value = new List<int?>();
						iprot.ReadSetBegin();
						while(true){
							
							try{
								
								int elem0;
								elem0 = iprot.ReadI32(); 
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadSetEnd();
						
						structs.SetOrderStatusSet(value);
					}
					
					
					
					
					
					if ("orderTypeSet".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<int?> value;
						
						value = new List<int?>();
						iprot.ReadSetBegin();
						while(true){
							
							try{
								
								int elem1;
								elem1 = iprot.ReadI32(); 
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadSetEnd();
						
						structs.SetOrderTypeSet(value);
					}
					
					
					
					
					
					if ("payTypeSet".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<int?> value;
						
						value = new List<int?>();
						iprot.ReadSetBegin();
						while(true){
							
							try{
								
								int elem2;
								elem2 = iprot.ReadI32(); 
								
								value.Add(elem2);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadSetEnd();
						
						structs.SetPayTypeSet(value);
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
		
		
		public void Write(GetOrdersBySizeIdReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSizeId() != null) {
				
				oprot.WriteFieldBegin("sizeId");
				oprot.WriteI32((int)structs.GetSizeId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderStatusSet() != null) {
				
				oprot.WriteFieldBegin("orderStatusSet");
				
				oprot.WriteSetBegin();
				foreach(int _item0 in structs.GetOrderStatusSet()){
					
					oprot.WriteI32((int)_item0); 
					
				}
				
				oprot.WriteSetEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderTypeSet() != null) {
				
				oprot.WriteFieldBegin("orderTypeSet");
				
				oprot.WriteSetBegin();
				foreach(int _item0 in structs.GetOrderTypeSet()){
					
					oprot.WriteI32((int)_item0); 
					
				}
				
				oprot.WriteSetEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPayTypeSet() != null) {
				
				oprot.WriteFieldBegin("payTypeSet");
				
				oprot.WriteSetBegin();
				foreach(int _item0 in structs.GetPayTypeSet()){
					
					oprot.WriteI32((int)_item0); 
					
				}
				
				oprot.WriteSetEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetOrdersBySizeIdReq bean){
			
			
		}
		
	}
	
}