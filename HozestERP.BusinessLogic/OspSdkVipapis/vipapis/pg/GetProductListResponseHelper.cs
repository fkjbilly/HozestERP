using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.pg{
	
	
	
	public class GetProductListResponseHelper : TBeanSerializer<GetProductListResponse>
	{
		
		public static GetProductListResponseHelper OBJ = new GetProductListResponseHelper();
		
		public static GetProductListResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetProductListResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("goods".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.pg.Product> value;
						
						value = new List<vipapis.pg.Product>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.pg.Product elem0;
								
								elem0 = new vipapis.pg.Product();
								vipapis.pg.ProductHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetGoods(value);
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
		
		
		public void Write(GetProductListResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetGoods() != null) {
				
				oprot.WriteFieldBegin("goods");
				
				oprot.WriteListBegin();
				foreach(vipapis.pg.Product _item0 in structs.GetGoods()){
					
					
					vipapis.pg.ProductHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("goods can not be null!");
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
		
		
		public void Validate(GetProductListResponse bean){
			
			
		}
		
	}
	
}